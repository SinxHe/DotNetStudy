using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Heab.DAL.EF;
using N32IDAL;
using N32MODEL;

namespace N32DALMSSQL
{
    /// <summary>
    /// mssql数据库 数据层 父类
    /// </summary>
    public class BaseDal<T>:IBaseDal<T> where T:class, new()
    {
        /// <summary>
        /// EF 上下文对象
        /// </summary>
        private DbContext Db = new DbContextFactory().GetDbContext();//new OuOAEntities(); 1. 可能改 2. 线程共用

        #region 增 1. model

        /// <summary>
        /// 增加一个记录model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public /*T*/ int Add(T model)
        {
            Db.Set<T>().Add(model);
            return Db.SaveChanges();   // 返回受影响的行数, 并把Id赋值给model
            //return model;   // 新增产生的Id已经复制给了model
        }

        #endregion

        #region 删 1. model:id   2. models:where

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="model">包含要删除对象主键的Model</param>
        /// <returns></returns>
        public int Del(T model)
        {
            Db.Set<T>().Attach(model); // 将实体以Unchanged状态添加到上下文
            Db.Set<T>().Remove(model);
            return Db.SaveChanges();
        }

        /// <summary>
        /// 根据条件删除一个集合
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public int DelBy(Expression<Func<T, bool>> delWhere)
        {
            List<T> list = Db.Set<T>().Where(delWhere).ToList();
            list.ForEach(u => Db.Set<T>().Remove(u));
            return Db.SaveChanges();
        }

        #endregion

        #region 改 反射实现 1. model:id,proNames  2. models:commonModel,where,proNames

        /// <summary>
        /// 更改一条数据, 需指定更改的字段
        /// 这个函数在第二次执行同一个主键的数据时会报异常, ObjectStatusManager只能同时跟踪一个主键相同的对象
        /// 改成Virtual, 让派生类通过Id查找出来再去改把
        /// </summary>
        /// <param name="model">要更改的数据</param>
        /// <param name="modifiedProNames">更改的字段名</param>
        /// <returns></returns>
        public virtual int Modify(T model, params string[] modifiedProNames)
        {
            DbEntityEntry<T> entry = Db.Entry(model);
            entry.State = System.Data.EntityState.Unchanged;
            foreach (string item in modifiedProNames)
            {
                entry.Property(item).IsModified = true;
            }
            if (modifiedProNames.Length < 1)
            {
                throw new Exception(GetType() + " : 请指定要修改的属性的名字!");
            }

            return Db.SaveChanges();
        }

        #region 先查后删 Modify2
        /// <summary>
        /// 修改一个实体
        /// 先查后改 对同一个主键的实体更改第二次的时候不会出现ObjectStatusManager重复跟踪的异常
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="whereLambda">指定修改的数据库实体</param>
        /// <param name="modifiedProNames">修改的属性名称(反射实现)</param>
        /// <returns></returns>
        public int Modify2(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            // 0. 如果未指定更改了哪个属性, 报异常
            if (modifiedProNames.Length < 1)
            {
                throw new Exception(GetType() + " : 请指定要修改的属性的名字!");
            }

            // 1. 获取 实体类 类型对象
            Type t = model.GetType();   // typeof (User);
            // 2. 获取 实体类 所有的 公有属性
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            // 3. 创建 实体属性 字典集合
            Dictionary<string, PropertyInfo> dicPros = new Dictionary<string, PropertyInfo>();
            // 4. 将实体属性中要修改的属性名 添加到 字典集合中 键: 属性名 值: 属性对象
            proInfos.ForEach(p =>
            {
                if (modifiedProNames.Contains(p.Name))
                {
                    dicPros.Add(p.Name, p);
                }
            });
            // 5. 循环要修改的属性名
            foreach (string proName in modifiedProNames)
            {
                // 6. 判断属性名是否在 实体类的集合 中存在
                if (dicPros.ContainsKey(proName))
                {
                    // 6.1 如果存在, 取出要修改的 属性对象
                    PropertyInfo proInfo = dicPros[proName];
                    // 6.1.1 从属性对象中取出 要修改的值
                    object newValue = proInfo.GetValue(model, null);    // object newValue = model.uName...
                    // 6.1.2 从数据库查询指定条件的数据
                    T entity = Db.Set<T>().FirstOrDefault(whereLambda);
                    if (entity == null)
                    {
                        throw new Exception("数据库中没有符合条件的对象!");
                    }
                    // 6.1.3 设置要修改的对象的属性为新的值
                    proInfo.SetValue(entity, newValue, null);
                }
                else
                {
                    throw new Exception("指定实体属性名字并不在实体中!");
                }
            }
            return Db.SaveChanges();
        }
        #endregion

        /// <summary>
        /// 根据条件更改数据库集合的值
        /// </summary>
        /// <param name="commonModel">赋值给数据库集合的公共实体</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="modifiedProNames">更改的属性名</param>
        /// <returns></returns>
        public int ModifyBy(T commonModel, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            // 从数据库获取数据集合
            List<T> list = Db.Set<T>().Where(whereLambda).ToList();
            // 设置集合的新值
            foreach (var item in modifiedProNames)
            {
                list.ForEach(u =>
                {
                    object obj = ProByStr.GetProByStr(commonModel, item);
                    ProByStr.SetProByStr(u, obj, item);
                });
            }
            return Db.SaveChanges();
        }

        #endregion

        #region 查 0. model:where 1. models:where   2. models:where,order   3. pageModels

        /// <summary>
        /// 集合: 根据条件查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public List<T> GetListBy(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).ToList();
        }

        /// <summary>
        /// 集合: 根据条件 排序 和 查询
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <returns></returns>
        public List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            return Db.Set<T>().Where(whereLambda).OrderBy(orderLambda).ToList();
        }

        /// <summary>
        /// 集合: 分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="orderBy">排序lambda表达式</param>
        /// <param name="whereLambda">条件lambda表达式</param>
        /// <returns></returns>
        public List<T> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderBy, Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        #endregion
    }
}

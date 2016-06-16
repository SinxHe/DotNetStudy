using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using N28_4MODEL;
using N28_5Common;

namespace N28_3DAL
{
    public class UserDalSrc
    {
        /// <summary>
        /// 数据上下文对象
        /// </summary>
        private readonly DotNetStudyEntities _db = new DotNetStudyEntities();

        #region 增 int Add(User model)

        public /*User*/ int Add(User model)
        {
            _db.Users.Add(model);
            return _db.SaveChanges();   // 返回受影响的行数, 并把Id赋值给model
            //return model;   // 新增产生的Id已经复制给了model
        }

        #endregion

        #region 删

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public int Del(int uId)
        {
            User user = new User() { uId = uId };
            _db.Users.Attach(user);
            _db.Users.Remove(user);
            return _db.SaveChanges();
        }

        /// <summary>
        /// 根据条件删除一个集合
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public int DelBy(Expression<Func<User, bool>> delWhere)
        {
            List<User> list = _db.Users.Where(delWhere).ToList();
            list.ForEach(u => _db.Users.Remove(u));
            return _db.SaveChanges();
        }

        #endregion

        #region 改 反射实现

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="modifiedProNames">修改的属性名称(反射实现)</param>
        /// <returns></returns>
        public int Modify(User model, params string[] modifiedProNames)
        {
            // 视频中的方法我这个各种不支持
            //DbEntityEntry<User> entry = _db.Entry<User>(model);
            //entry.State = System.Data.EntityState.Unchanged;
            //foreach (string item in proNames)
            //{
            //    entry.Property(item).IsModified = true;
            //}

            // 0. 如果未指定更改了哪个属性, 报异常
            if (modifiedProNames.Length < 1)
            {
                throw new Exception("未指定修改属性的名字!");
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
                    User user = _db.Users.FirstOrDefault(u => u.uId == model.uId);
                    if (user == null)
                    {
                        throw new Exception("数据库中没有符合条件的对象!");
                    }
                    // 6.1.3 设置要修改的对象的属性为新的值
                    proInfo.SetValue(user, newValue, null);
                }
                else
                {
                    throw new Exception("指定实体属性名字并不在实体中!");
                }
            }
            return _db.SaveChanges();
        }

        /// <summary>
        /// 根据条件更改数据库集合的值
        /// </summary>
        /// <param name="commonModel">赋值给数据库集合的公共实体</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="modifiedPaoNames">更改的属性名</param>
        /// <returns></returns>
        public int ModifyBy(User commonModel, Expression<Func<User, bool>> whereLambda, params string[] modifiedPaoNames)
        {
            // 从数据库获取数据集合
            List<User> list = _db.Users.Where(whereLambda).ToList();
            // 设置集合的新值
            foreach (var item in modifiedPaoNames)
            {
                list.ForEach(u =>
                {
                    object obj = ProByStr.GetProByStringName(commonModel, item);
                       ProByStr.SetProByStringName<User>(u, obj, item);
                   });
            }
            return _db.SaveChanges();
        }

        #endregion

        #region 查

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public List<User> GetListBy(Expression<Func<User, bool>> whereLambda)
        {
            return _db.Users.Where(whereLambda).ToList();
        }

        /// <summary>
        /// 根据条件 排序 和 查询
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <returns></returns>
        public List<User> GetListBy<TKey>(Expression<Func<User, bool>> whereLambda, Expression<Func<User, TKey>> orderLambda)
        {
            return _db.Users.Where(whereLambda).OrderBy(orderLambda).ToList();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="orderBy">排序lambda表达式</param>
        /// <param name="whereLambda">条件lambda表达式</param>
        /// <returns></returns>
        public List<User> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<User, TKey>> orderBy, Expression<Func<User, bool>> whereLambda)
        {
            return _db.Users.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        #endregion
    }
}

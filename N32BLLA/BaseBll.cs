using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using N32IBLL;
using N32IDAL;

namespace N32BLLA
{
    /// <summary>
    /// 业务层父类
    /// </summary>
    public abstract class BaseBll<T>:IBaseBll<T> where T:class, new()
    {
        public BaseBll()
        {
            SetDal();
        }
        // 1. 数据层 接口对象 - 等待被实例化(控制反转)
        protected IBaseDal<T> iDal = null;

        /// <summary>
        /// 由子类实现, 为 业务父类 里的 数据接口对象 设置值
        /// </summary>
        public abstract void SetDal();

        /// <summary>
        /// 2. 数据仓储接口(相当于数据层工厂, 可以拿到所有的数据子类对象)
        /// </summary>
        private IDbSession iDbSession = null;

        #region 数据仓储 属性

        public IDbSession DbSession
        {
            get
            {
                if (iDbSession == null)
                {
                    //  1. 读取配置文件
                    string strFactoryDll = N32Common.ConfigurationHelper.AppSettings("DbSessionFactoryDll");
                    string strFactoryType = N32Common.ConfigurationHelper.AppSettings("DbSessionFactory");
                    // 2. 通过反射创建DbSessionFactory对象
                    Assembly dalDll = Assembly.LoadFrom(strFactoryDll);
                    Type typeDbSessionFactory = dalDll.GetType(strFactoryType);
                    //      2.1 创建工厂
                    IDbSessionFactory sessionFactory = Activator.CreateInstance(typeDbSessionFactory) as IDbSessionFactory;
                    // 2. 根据配置文件内容 使用 DI层里的Spring.Net 创建 DbSessionFactory 工厂对象

                    // 3. 通过工厂创建DbSession工厂对象
                    iDbSession = sessionFactory.GetDbSession();
                }
                return iDbSession;
            }
        }

        #endregion

        // 2. CRUD
        #region 增 int Add(T model)

        public /*T*/ int Add(T model)
        {
            return iDal.Add(model);
        }

        #endregion

        #region 删

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="model">包含主键的Model</param>
        /// <returns></returns>
        public int Del(T model)
        {
            return iDal.Del(model);
        }

        /// <summary>
        /// 根据条件删除一个集合
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public int DelBy(Expression<Func<T, bool>> delWhere)
        {
            return iDal.DelBy(delWhere);
        }

        #endregion

        #region 改 反射实现

        /// <summary>
        /// 修改一个实体 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modifiedProNames"></param>
        /// <returns></returns>
        public int Modify(T model, params string[] modifiedProNames)
        {
            return iDal.Modify(model, modifiedProNames);
        }

        /// <summary>
        /// 修改一个实体 
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="whereLambda">指定修改的数据库实体</param>
        /// <param name="modifiedProNames">修改的属性名称(反射实现)</param>
        /// <returns></returns>
        public int Modify2(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            return iDal.Modify2(model, whereLambda, modifiedProNames);
        }

        /// <summary>
        /// 根据条件更改数据库集合的值
        /// </summary>
        /// <param name="commonModel">赋值给数据库集合的公共实体</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="modifiedPaoNames">更改的属性名</param>
        /// <returns></returns>
        public int ModifyBy(T commonModel, Expression<Func<T, bool>> whereLambda, params string[] modifiedPaoNames)
        {
            return iDal.ModifyBy(commonModel, whereLambda, modifiedPaoNames);
        }

        #endregion

        #region 查

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public List<T> GetListBy(Expression<Func<T, bool>> whereLambda)
        {
            return iDal.GetListBy(whereLambda);
        }

        /// <summary>
        /// 根据条件 排序 和 查询
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <returns></returns>
        public List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            return iDal.GetListBy(whereLambda, orderLambda);
        }

        /// <summary>
        /// 分页查询 -- 分页前一定要排序
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="orderByLambda">排序lambda表达式</param>
        /// <param name="whereLambda">条件lambda表达式</param>
        /// <returns></returns>
        public List<T> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderByLambda, Expression<Func<T, bool>> whereLambda)
        {
            return iDal.GetPageList(pageIndex, pageSize, orderByLambda, whereLambda);// -- 分页前一定要排序
        }

        #endregion
    }
}

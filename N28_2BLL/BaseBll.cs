using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using N28_3DAL;

namespace N28_2BLL
{
    public abstract class BaseBll<T> where T : class, new()
    {
        /// <summary>
        /// 数据访问层对象 由子类指定
        /// 业务父类无法确定使用 那个具体实体 的数据访问曾
        /// 生命一个抽象方法, 在使用的时候指定就行了
        /// </summary>
        protected BaseDal<T> Dal = null;

        public BaseBll()
        {
            SetDal();   // 指定创建的是 哪个数据实体的 数据访问层
        }

        public abstract void SetDal();

        #region 增 int Add(T model)

        public /*T*/ int Add(T model)
        {
            return Dal.Add(model);
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
            return Dal.Del(model);
        }

        /// <summary>
        /// 根据条件删除一个集合
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public int DelBy(Expression<Func<T, bool>> delWhere)
        {
            return Dal.DelBy(delWhere);
        }

        #endregion

        #region 改 反射实现

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="whereLambda">指定修改的数据库实体</param>
        /// <param name="modifiedProNames">修改的属性名称(反射实现)</param>
        /// <returns></returns>
        public int Modify(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            return Dal.Modify(model, whereLambda, modifiedProNames);
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
            return Dal.ModifyBy(commonModel, whereLambda, modifiedPaoNames);
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
            return Dal.GetListBy(whereLambda);
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
            return Dal.GetListBy(whereLambda, orderLambda);
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
            return Dal.GetPageList(pageIndex, pageSize, orderByLambda, whereLambda);// -- 分页前一定要排序
        }

        #endregion
    }
}

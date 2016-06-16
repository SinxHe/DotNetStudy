using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using N28_4MODEL;

namespace N28_2Bll
{
    public class UserBll
    {
        /// <summary>
        /// 数据访问层对象
        /// </summary>
        private readonly N28_3DAL.UserDalSrc _dal = new N28_3DAL.UserDalSrc();

        #region 增 int Add(User model)

        public /*User*/ int Add(User model)
        {
            return _dal.Add(model);
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
            return _dal.Del(uId);
        }

        /// <summary>
        /// 根据条件删除一个集合
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public int DelBy(Expression<Func<User, bool>> delWhere)
        {
            return _dal.DelBy(delWhere);
        }

        #endregion

        #region 改

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="proNames">修改的属性名称</param>
        /// <returns></returns>
        public int Modify(User model, params string[] proNames)
        {
            return _dal.Modify(model, proNames);
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
            return _dal.ModifyBy(commonModel, whereLambda, modifiedPaoNames);
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
            return _dal.GetListBy(whereLambda);
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
            return _dal.GetListBy(whereLambda, orderLambda);
        }

        /// <summary>
        /// 分页查询 -- 分页前一定要排序
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="orderByLambda">排序lambda表达式</param>
        /// <param name="whereLambda">条件lambda表达式</param>
        /// <returns></returns>
        public List<User> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<User, TKey>> orderByLambda, Expression<Func<User, bool>> whereLambda)
        {
            return _dal.GetPageList(pageIndex, pageSize, orderByLambda, whereLambda);// -- 分页前一定要排序
        }

        #endregion
    }
}

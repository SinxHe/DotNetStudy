using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace N32IDAL
{
    /// <summary>
    /// 数据层 父接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDal<T>
    {
        #region 增 1. model

        /// <summary>
        /// 增加一个记录model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /*T*/
        int Add(T model);

        #endregion

        #region 删 1. model:id   2. models:where

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="model">包含要删除对象主键的Model</param>
        /// <returns></returns>
        int Del(T model);

        /// <summary>
        /// 根据条件删除一个集合
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        int DelBy(Expression<Func<T, bool>> delWhere);

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
        int Modify(T model, params string[] modifiedProNames);

        #region 先查后删 Modify2

        /// <summary>
        /// 修改一个实体
        /// 先查后改 对同一个主键的实体更改第二次的时候不会出现ObjectStatusManager重复跟踪的异常
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="whereLambda">指定修改的数据库实体</param>
        /// <param name="modifiedProNames">修改的属性名称(反射实现)</param>
        /// <returns></returns>
        int Modify2(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames);
        #endregion

        /// <summary>
        /// 根据条件更改数据库集合的值
        /// </summary>
        /// <param name="commonModel">赋值给数据库集合的公共实体</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="modifiedProNames">更改的属性名</param>
        /// <returns></returns>
        int ModifyBy(T commonModel, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames);

        #endregion

        #region 查 0. model:where 1. models:where   2. models:where,order   3. pageModels

        /// <summary>
        /// 集合: 根据条件查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        List<T> GetListBy(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 集合: 根据条件 排序 和 查询
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <returns></returns>
        List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda);

        /// <summary>
        /// 集合: 分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="orderBy">排序lambda表达式</param>
        /// <param name="whereLambda">条件lambda表达式</param>
        /// <returns></returns>
        List<T> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> orderBy,
           Expression<Func<T, bool>> whereLambda);

        #endregion
    }
}

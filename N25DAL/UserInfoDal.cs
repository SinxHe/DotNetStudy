using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using N25Model;
using System.Data.SqlClient;
using N25IDAL;

namespace N25DAL
{
    public partial class UserInfoDal : BaseDal<UserInfo>, IUserInfoDal
    {
        //// 获取唯一数据上下文
        //private readonly DbContext _context = ContextFactory.GetMvcOAContext();
        //#region 增

        //public int Add(UserInfo userInfo)
        //{
        //    _context.Set<UserInfo>().Add(userInfo);
        //    return _context.SaveChanges();
        //}

        //#endregion
        //#region 删

        //public int Remove(int id)
        //{
        //    UserInfo user = _context.Set<UserInfo>().Find(id);
        //    _context.Set<UserInfo>().Remove(user);
        //    return _context.SaveChanges();
        //}

        //public int Remove(int[] ids)
        //{
        //    foreach (int i in ids)
        //    {
        //        UserInfo user = _context.Set<UserInfo>().Find(ids[i]);
        //        _context.Set<UserInfo>().Remove(user);
        //    }

        //    return _context.SaveChanges();
        //}

        //public int Remove(UserInfo userInfo)
        //{
        //    _context.Set<UserInfo>().Remove(userInfo);
        //    return _context.SaveChanges();
        //}

        //#endregion
        //#region 改

        //public int Edit(UserInfo userInfo)
        //{
        //    _context.Entry(userInfo).State = EntityState.Modified;
        //    return _context.SaveChanges();
        //}

        //#endregion
        //#region 查

        //public UserInfo GetById(int id)
        //{
        //    return _context.Set<UserInfo>().Find(id);
        //}

        //// IEnumerable : 直接把语句扔到数据库执行, 把拿到的结果放到内存中进行进一步的筛选
        //// IQueryable : Expression 拼接命令树 => 把所有的命令拼接到一起构成一个完整的语句去执行
        //public IQueryable<UserInfo> GetList(Expression<Func<UserInfo, bool>> whereLambda)
        //{
        //    return _context.Set<UserInfo>().Where(whereLambda);
        //}

        //// 分页查询
        //public IQueryable<UserInfo> GetPageList<TKey>(Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, TKey>> orderLambda, int pageIndex, int pageSize)
        //{
        //    return _context.Set<UserInfo>()
        //        .Where(whereLambda)
        //        .OrderByDescending(orderLambda)
        //        .Skip((pageIndex - 1) * pageSize)
        //        .Take(pageSize);
        //}

        //#endregion
    }
}

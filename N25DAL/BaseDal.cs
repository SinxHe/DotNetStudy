using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace N25DAL
{
    public partial class BaseDal<T> where T : class
    {
        // 获取唯一数据上下文
        private readonly DbContext _context = ContextFactory.GetMvcOaContext();
        #region 增

        public int Add(T userInfo)
        {
            _context.Set<T>().Add(userInfo);
            return _context.SaveChanges();
        }

        #endregion
        #region 删

        public int Remove(int id)
        {
            T user = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(user);
            return _context.SaveChanges();
        }

        public int Remove(int[] ids)
        {
            foreach (int i in ids)
            {
                T user = _context.Set<T>().Find(ids[i]);
                _context.Set<T>().Remove(user);
            }

            return _context.SaveChanges();
        }

        public int Remove(T userInfo)
        {
            _context.Set<T>().Remove(userInfo);
            return _context.SaveChanges();
        }

        #endregion
        #region 改

        public int Edit(T userInfo)
        {
            _context.Entry(userInfo).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        #endregion
        #region 查

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        // IEnumerable : 直接把语句扔到数据库执行, 把拿到的结果放到内存中进行进一步的筛选
        // IQueryable : Expression 拼接命令树 => 把所有的命令拼接到一起构成一个完整的语句去执行
        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return _context.Set<T>().Where(whereLambda);
        }

        // 分页查询
        public IQueryable<T> GetPageList<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, int pageIndex, int pageSize)
        {
            return _context.Set<T>()
                .Where(whereLambda)
                .OrderByDescending(orderLambda)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace N25IDAL
{
    public partial interface IBaseDal<T>
    {
        int Add(T t);
        int Edit(T t);
        T GetById(int id);
        int Remove(T t);
        int Remove(int id);
        int Remove(int[] ids);
        IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetPageList<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, int pageIndex, int pageSize);
    }
}

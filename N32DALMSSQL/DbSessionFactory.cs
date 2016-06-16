using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using N32IDAL;

namespace N32DALMSSQL
{
    /// <summary>
    /// 此方法的作用: 提高效率, 在线程中 共用同一个 DbSession 对象
    /// </summary>
    public class DbSessionFactory : IDbSessionFactory
    {
        public IDbSession GetDbSession()
        {
            // 从当前线程中 获取 数据仓储 对象
            IDbSession dbSession = CallContext.GetData(typeof(DbSessionFactory).Name + "DbSession") as DbSession;
            if (dbSession == null)
            {
                dbSession = new DbSession();
                CallContext.SetData(typeof(DbSessionFactory).Name + "DbSession", dbSession);
            }
            return dbSession;
        }
    }
}

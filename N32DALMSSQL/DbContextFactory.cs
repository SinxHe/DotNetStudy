using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using N32IDAL;
using N32MODEL;

namespace N32DALMSSQL
{
    public class DbContextFactory : IDbContextFactory
    {
        #region 创建EF上下文对象 线程共享同一个DbSession对象
        /// <summary>
        /// 创建 EF 上下文 对象 -- For: 在线程中共享一个上下文对象
        /// </summary>
        /// <returns></returns>
        public DbContext GetDbContext()
        {
            DbContext dbContext = CallContext.GetData(typeof(DbContextFactory).Name + "dbContext") as DbContext;
            if (dbContext == null)
            {
                dbContext = new OuOAEntities();
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                CallContext.SetData(typeof(DbContextFactory).Name + "dbContext", dbContext);
            }
            return dbContext;
        } 
        #endregion
    }
}

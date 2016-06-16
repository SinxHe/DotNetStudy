using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace N32IDAL
{
    /// <summary>
    /// EF 数据上下文 工厂
    /// </summary>
    public interface IDbContextFactory
    {
        DbContext GetDbContext();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N32IDAL
{
    /// <summary>
    /// 数据层的便捷大接口
    /// 里面包含所有的 数据层 接口访问方式
    /// </summary>
    public partial interface IDbSession
    {
        int SaveChanges();
    }
}

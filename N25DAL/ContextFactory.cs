using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace N25DAL
{
    public partial class ContextFactory
    {
        public static DbContext GetMvcOaContext()
        {
            DbContext context = CallContext.GetData("MvcOAContext") as DbContext;
            // 把上下文放到线程相关的数据槽中
            if (context == null)
            {
                context = new N25Model.MvcOAEntities();
                CallContext.SetData("MvcOAContext", context);
            }
            return context;
        }
    }
}

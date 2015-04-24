using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N23异步
{
    /// <summary>
    /// N01返回时间 的摘要说明
    /// </summary>
    public class N01返回时间 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(DateTime.Now.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
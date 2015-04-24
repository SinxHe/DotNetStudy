using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N23异步
{
    /// <summary>
    /// N02返回Json 的摘要说明
    /// </summary>
    public class N02返回Json : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("{\"Data\":\"" + DateTime.Now.ToString() + "\"}");
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
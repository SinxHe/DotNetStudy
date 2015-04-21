using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace N21AspDotNet对象
{
    /// <summary>
    /// ValidateCodeImageHandler 的摘要说明
    /// </summary>
    public class ValidateCodeImageHandler : IHttpHandler, IRequiresSessionState // 一般处理程序使用Session要先实现这个接口
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            Heab.WebUI.ValidateCode validateCode = new Heab.WebUI.ValidateCode();
            string randString = validateCode.CreateValidateCode(4);

            // 把随机字符串放到Sessoin中
            context.Session["VCode"] = randString;

            validateCode.CreateValidateGraphic(randString, context);
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
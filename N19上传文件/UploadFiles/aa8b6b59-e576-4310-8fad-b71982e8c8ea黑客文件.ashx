<%@ WebHandler Language="C#" Class="N01返回图片" %>

using System;
using System.Web;

public class N01返回图片 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        context.Response.Write("<script>alert('小爷是黑客, 小爷已经控制了你的电脑!');</script>");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
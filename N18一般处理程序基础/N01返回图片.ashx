<%@ WebHandler Language="C#" Class="N01返回图片" %>

using System;
using System.Web;

public class N01返回图片 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/jpg";
        context.Response.WriteFile("N01.jpg");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
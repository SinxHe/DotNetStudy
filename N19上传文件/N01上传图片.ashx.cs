using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace N19上传文件
{
    /// <summary>
    /// N01上传图片 的摘要说明
    /// </summary>
    public class N01上传图片 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            // 接受图片数据
            HttpPostedFile file = context.Request.Files["imageFile"];
            // 保存到服务器文件中
            if (file != null)
            {
                string path = "/UploadFiles/" + Guid.NewGuid().ToString() + file.FileName;

                // 安全校验, 只接受.jpg文件
                if (Path.GetExtension(path) != ".jpg")
                {
                    context.Response.Write("Shit, 请上传.jpg图片!");
                    context.Response.End(); // 将所有缓冲发送给客户端, 停止当页的执行, 引发EndRequest()事件
                }

                file.SaveAs(context.Request.MapPath(path));

                // 把图片显示给用户
                context.Response.Write(string.Format("<html><body><img src='{0}' /></body></html>", path));
            }
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
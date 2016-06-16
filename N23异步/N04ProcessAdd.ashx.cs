using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace N23异步
{
    /// <summary>
    /// N04ProcessAdd 的摘要说明
    /// </summary>
    public class N04ProcessAdd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            // 将添加的数据加到数据库
            //      取数据
            string title = context.Request["txtTitle"];
            string content = context.Request["txtContent"];
            string people = context.Request["txtPeople"];
            //      加到数据库
            Heab.SQL.SQLHelper.ExecuteNonQuery("Insert into HKSJ_Main(title, content, type, Date, people) values(@title, @content, @type, @Date, @people)", new SqlParameter("@title", title),
                new SqlParameter("@content", content),
                new SqlParameter("@type", "456"),
                new SqlParameter("@Date", DateTime.Now),
                new SqlParameter("@people", people));
            context.Response.Write("ok");
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
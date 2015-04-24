using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace N23异步
{
    /// <summary>
    /// N04UpdateNews 的摘要说明
    /// </summary>
    public class N04UpdateNews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            // 获取数据
            int Id = int.Parse(context.Request["hidId"] ?? "0");
            string title = context.Request["txtEditContent"];
            // 更新数据库
            int i = Heab.SQL.SQLHelper.ExecuteNonQuery("update HKSJ_Main set title = @title where ID = @Id",
                new SqlParameter("@title",title),
                new SqlParameter("@Id",Id));
            if (i == 1)
            {
                context.Response.Write("ok");    
            }
            else
            {
                context.Response.Write("error");
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace N23异步
{
    /// <summary>
    /// N04GetNewsById 的摘要说明
    /// </summary>
    public class N04GetNewsById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int Id = int.Parse(context.Request["Id"]??"0");
            DataTable dt = Heab.SQL.SQLHelper.ExecuteDataTable("select * from HKSJ_Main where ID = @Id",
                new SqlParameter("@Id", Id));
            DataRow dr = dt.Rows[0];
            string jsonData = "{" + string.Format("\"ID\":\"{0}\",\"title\":\"{1}\"", dr["ID"], dr["title"]) + "}";
            context.Response.Write(jsonData);
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
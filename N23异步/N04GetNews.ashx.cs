using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace N23异步
{
    /// <summary>
    /// N04GetNews 的摘要说明
    /// </summary>
    public class N04GetNews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //Heab.SQL.SQLHelper.ConnStr ="Data Source=.; Initial Catalog=DotNetStudy;User ID=HeabKing; Password=he394899990";
            DataTable dt = Heab.SQL.SQLHelper.ExecuteDataTable("select * from HKSJ_Main");
            // 将查出来的数据放到一个集合中
            List<ModelNews> list = new List<ModelNews>();
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new ModelNews()
                {
                    ID = Convert.ToInt32(item["ID"]),
                    title = Convert.ToString(item["title"]),
                    content = Convert.ToString(item["people"]),
                    Date = DateTime.Parse(item["Date"].ToString())
                });
            }
            // 把集合转换成Json
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            var json = jsSerializer.Serialize(list);
            context.Response.Write(json);
        }


        private class ModelNews
        {
            public int ID { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public DateTime Date { get; set; }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
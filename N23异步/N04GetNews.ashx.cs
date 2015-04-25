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

            // 分页信息初始化
            int pageSize = Convert.ToInt32(context.Request["pageSize"] ?? "5");
            int currentPage = Convert.ToInt32(context.Request["pageIndex"] ?? "1");
            int totalCount = Convert.ToInt32(Heab.SQL.SQLHelper.ExecuteScalar("select COUNT(*) from HKSJ_Main"));
            // 实例化 一个分页器
            Heab.WebUI.Pager pager = new Heab.WebUI.Pager(totalCount, pageSize, currentPage);
            #region 分页标签部分
            string strPageNav = pager.ShowPageNavigate();
            #endregion

            #region 每页的数据
            //Heab.SQL.SQLHelper.ConnStr ="Data Source=.; Initial Catalog=DotNetStudy;User ID=HeabKing; Password=he394899990";
            DataTable dt = Heab.SQL.SQLHelper.ExecuteDataTable("select * from (select *, ROW_NUMBER() over(order by m.Id asc) as num from HKSJ_Main as m) as s where s.num between @begin and @end",
                new SqlParameter("@begin", pager.BetweenBegin),
                new SqlParameter("@end", pager.BetweenEnd));
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
            #endregion
            
            // 把集合转换成Json
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            var json = jsSerializer.Serialize(new { pagerTags = strPageNav, dataList = list});
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
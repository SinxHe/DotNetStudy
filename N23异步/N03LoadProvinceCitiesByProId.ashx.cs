using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using N23异步.N03ProCityTableAdapters;

namespace N23异步
{
    /// <summary>
    /// N03LoadProvinceCitiesByProId 的摘要说明
    /// </summary>
    public class N03LoadProvinceCitiesByProId : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            // 获取pId
            int pId = int.Parse(context.Request["pId"] ?? "0");
            // 获取城市
            T_CityTableAdapter adapter = new T_CityTableAdapter();
            N03ProCity.T_CityDataTable city = adapter.GetCityDataByProID(pId);
            // 转换成Json
            //StringBuilder sb = new StringBuilder();
            //sb.Append("[");
            //foreach (var item in city)
            //{
            //    sb.Append("{");
            //    sb.AppendFormat("\"cityId\":\"{0}\",\"cityName\":\"{1}\"",item.CityID, item.CityName);
            //    sb.Append("},");
            //}
            //string str = sb.ToString().TrimEnd(',') + "]";
            // 发送数据
            //context.Response.Write(str);

            // 使用方法将集合转换成Json
            List<CityData> list = new List<CityData>();
            foreach (var item in city)
            {
                list.Add(new CityData(){cityId = item.CityID, cityName = item.CityName});
            }
            System.Web.Script.Serialization.JavaScriptSerializer jsSerializer =
                new System.Web.Script.Serialization.JavaScriptSerializer();
            var response = jsSerializer.Serialize(list);
            // 返回
            context.Response.Write(response);
        }

        private class CityData
        {
            public int cityId { get; set; }
            public string cityName { get; set; }
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
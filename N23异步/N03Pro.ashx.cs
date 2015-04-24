using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N23异步.N03ProCityTableAdapters;
using System.Text;

namespace N23异步
{
    /// <summary>
    /// N03Pro 的摘要说明
    /// </summary>
    public class N03Pro : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            // 用强类型DataSet获取省的所有数据
            T_ProvinceTableAdapter adapter = new T_ProvinceTableAdapter();
            N03ProCity.T_ProvinceDataTable provinces = adapter.GetData();
            StringBuilder sb = new StringBuilder();
            foreach (var province in provinces)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", province.ProID, province.ProName);
            }

            context.Response.Write(sb.ToString());
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
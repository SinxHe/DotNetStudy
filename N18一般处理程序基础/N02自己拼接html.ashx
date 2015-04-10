<%@ WebHandler Language="C#" Class="N02自己拼接html" %>

using System;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Data;

public class N02自己拼接html : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";

        string html = ReadHtmlFile().Replace("@Table", T_UserBLL_GetTop20());
        
        context.Response.Write(html);
    }
 
    
    /// <summary>
    ///  从数据库获取T_User信息并转换成一个<table>标签
    /// </summary>
    /// <returns></returns>
    private string T_UserBLL_GetTop20()
    {
        DataTable dt = Heab.SQL.SQLHelper.ExecuteDataTable("select top(20) * from T_User");
        StringBuilder sb = new StringBuilder();
        sb.Append("<table border=\"1\"><tr><th>Id</th><th>UserName</th><th>Password</th></tr>");
        foreach (DataRow row in dt.Rows)
        {
            sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", 
                row["Id"], row["UserName"], row["Password"]));
        }
        sb.Append("</table>");
        return sb.ToString();
    }

    /// <summary>
    /// 从模板中获取html标签
    /// </summary>
    /// <returns></returns>
    private string ReadHtmlFile()
    {
        return System.IO.File.ReadAllText(HttpContext.Current.Request.MapPath("N02html.html"));
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}
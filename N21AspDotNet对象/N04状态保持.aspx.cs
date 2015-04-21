// 2015-04-19 13:52:16 创建
// 1.   Http请求是无状态的:
//      1.  ViewState实现状态保持:
//          1.  禁用ViewState
//              1.  当前页面禁用 <%@ Page EnableViewState="false" %>
//          2.  特定控件的属性禁用
// 2.   页面给自己传递数据:
//      1.  ViewState
//      2.  隐藏域
//      3.  QueryString
//      4.  全局变量
//      5.  数据库
//      6.  Session
//      7.  Cookie
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N21AspDotNet对象
{
    public partial class N04状态保持 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["Key"] = "hidden隐藏标签实现...";
        }
    }
}
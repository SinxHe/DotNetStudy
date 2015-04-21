using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N21AspDotNet对象
{
    public partial class N07Session : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 第一次访问, 开始会话, 设置Session
                Context.Session["SessionId"] = "Cookie中保存着SessionId";
            }
            else
            {
                // 读取Session
                Context.Response.Write(Session["SessionId"]);
            }
        }
    }
}
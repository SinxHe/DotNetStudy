using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N21AspDotNet对象
{
    public partial class N03后台跳转Transfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.Transfer("N01Buffer缓冲区.aspx");
                // 后台跳转, 浏览器是不知道的
        }
    }
}
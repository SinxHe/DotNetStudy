using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N22页面生命周期
{
    public partial class N01动态页面类的位置 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 拿到代码后置类动态生成dll的位置
            Response.Write("代码后置类位置: " + Assembly.GetExecutingAssembly().Location);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N21AspDotNet对象
{
    public partial class N06Login : System.Web.UI.Page
    {
        public string StrUserName { get; set; }

        public string StrScript { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get
            if (!IsPostBack)
            {
                StrScript = "当前在线人数" + Application["OnLineUserNum"].ToString();
                string username = Server.UrlDecode(Context.Request["userName"]);
                StrUserName = username; // 保证Get的时候如果有Cookie就显示用户名
            }
            // Post
            else
            {
                #region 处理Cookie中的用户名
                // 点击登录, 将用户名密码保存到客户端的Cookie中
                string username = Context.Request["txtClientID"];
                // 不进行编码, userName=ä½å£«é(汉字成了乱码), 这样在某些浏览器中, 会解析userName后边的Cookie异常
                //Context.Response.Cookies["userName"].Value = username;
                // 对Cookie进行编码
                Context.Response.Cookies["userName"].Value = Server.UrlEncode(username);
                StrUserName = username; // 保证Post返回的时候文本框也有用户名
                #endregion
                #region 处理验证码
                // 获取用户输入的验证码
                string userVC = Context.Request["txtCode"];
                // 从Session中拿出验证码
                string sessionVC = Session["VCode"] as string;
                // 与Sesson中的验证码进行比较
                if (sessionVC != userVC)
                {
                    StrScript = "<script>alert('验证码错误!');</script>";
                }
                #endregion
            }
        }
    }
}
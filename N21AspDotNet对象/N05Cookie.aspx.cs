// 2015-04-19 14:41:47 创建
// 1.   Cookie是网站相关的, 只有对应的网站可以访问自己的Cookie
//      Cookie是浏览器相关的, 不能相互共享;
// 2.   如果浏览器有某网站的Cookie, 那么会自动发送给服务器
// 3.   拿Cookie: Request.Cookie["Key"].Value
// 4.   写Cookie: Response.Cookie["Key"].Value 有则覆盖, 无则创建
// 5.   Cookie的应用场景:
//      1.  与Session配合实现用户名密码的保存;
//      2.  淘宝: 记录用户的浏览商品信息; 记录用户的操作习惯;
// 6.   Cookie域:
//      1.  子域可以访问主域的Cookie(浏览器在访问子域的时候会把主域的Cookie发送过去);
//      2.  子域的Cookie只能自己访问, 子域可以设置域为主域;
// 7.   Path: 
//      1.  指定Path下的页面才能访问Cookie
// 8.   域和Path的作用:
//      1.  防止一股脑的给后台发送Cookie数据;
// 9.   删除Cookie:
//      1.  Cookie是保存在客户端的, 服务器不能直接删除, 手没那么长...
//      2.  服务器直接让Cookie过期就删除了不过,Expires = DateTime.Now.AddDays(-8);
// 10.  要对Cookie的中文进行编码, 防止出现无法预知的错误;
using System;
using System.Web;

namespace N21AspDotNet对象
{
    public partial class N05Cookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get
            if (!IsPostBack)
            {
                // 向浏览器中写入一个Cookie
                Context.Response.Cookies["CookieKey"].Value = "CookieValue";
                // 设置过期时间, 不设置的话是"会话级别Session, 浏览器一关闭就没了(存在浏览器内存)"
                Context.Response.Cookies["CookieKey"].Expires = DateTime.Now.AddDays(2);
                // 设置域
                //Context.Response.Cookies["CookieKey"].Domain = "没法演示主域和子域";
                // 设置Path 只有网站指定路径下的页面可以访问这个Cookie
                Context.Response.Cookies["CookieKey"].Path = "/";

            }
            // Post
            else
            {
                //Context.Response.Write(Context.Response.Cookies["CookieKey"].Value);
                    // Response.Cookies["Key"].Value; 会把Cookie设置成null
                Context.Response.Write(Context.Request.Cookies["CookieKey"].Value);
            }
        }
    }
}
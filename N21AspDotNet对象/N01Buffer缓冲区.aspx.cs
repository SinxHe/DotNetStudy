using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N21AspDotNet对象
{
    public partial class N01Buffer缓冲区 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Context.Response.Buffer = true; // 默认是开通的
                // 开通: 输出先加载到缓冲区, 等页面加载完成之后, 一次性整体的放到客户端去
                // 不开通: 输出一点, 向客户端发送一点;

            Context.Response.Write("Hello World!");
            Context.Response.Flush();   // 刷新缓冲区
            Thread.Sleep(2000);
            Context.Response.Write("Context.Response.Clear();");
            Context.Response.Clear();   // 清空缓冲区
            Thread.Sleep(2000);

            // 设置响应报文的编码
            Context.Response.ContentEncoding = Encoding.ASCII;

            // 输出流的内容类型
            Context.Response.ContentType = "text/html";

            // 刷新缓冲区, 然后终止响应, 后边的代码不被执行
            //Context.Response.End();

            // 在前台显示html标签
            // 编码化实现
            //string str = "<html><body>一坨shit</body></html>";
            //string encodingString = Server.HtmlEncode(str);
            //Context.Response.Write(encodingString);
            Thread.Sleep(2000);
            Context.Response.Write("Hello World!!!!");
        }
    }
}
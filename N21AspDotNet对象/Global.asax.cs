using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace N21AspDotNet对象
{
    public class Global : System.Web.HttpApplication
    {
        // 整个网站生命周期只被执行一次
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["OnLineUserNum"] = 0;
        }

        // 保证锁的是同一个对象
        // 锁同一个对象, 保证每个线程来的时候肯定是互斥的
        private static readonly object LockObj = new object();
        // 每一次新的请求都会开辟一个新的会话
        // 每个用户过来之后, 后台会有一个专门的线程处理当前请求(防止并发);
        protected void Session_Start(object sender, EventArgs e)
        {
            lock ("Application_Num")//lock (LockObj)  // 保证互斥
            {
                int onLineUserNum = (int)Application["OnLineUserNum"];
                onLineUserNum++;
                Application["OnLineUserNum"] = onLineUserNum; 
            }
        }

        // 会话结束
        protected void Session_End(object sender, EventArgs e)
        {
            lock ("Application_Num")
            {
                int onLineUserNum = (int)Application["OnLineUserNum"];
                onLineUserNum--;
                Application["OnLineUserNum"] = onLineUserNum; 
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
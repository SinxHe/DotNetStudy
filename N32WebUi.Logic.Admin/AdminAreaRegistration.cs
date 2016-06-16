using System.Web.Mvc;

namespace N32WebUi.Login.Admin
{
    /// <summary>
    /// 区域注册类
    /// </summary>
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin"; // 对应到区域下的文件夹
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[1] { "N32WebUi.Login.Admin" }
            );
        }
    }
}

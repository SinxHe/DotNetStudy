using System.Web;
using System.Web.Mvc;

namespace N32WebUi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // 添加权限验证过滤器
            filters.Add(new Login.Admin.Filters.LoginValidateAttribute());
        }
    }
}
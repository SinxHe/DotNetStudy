using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using N32WebUi.Helper;

namespace N32WebUi.Login.Admin.Filters
{
    public class LoginValidateAttribute : AuthorizeAttribute
    {
        #region 验证方法 - 在ActionExcuting过滤器之前执行
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // 1. 如果请求的是 Admin 区域 里面的控制器方法, 那么验证权限
                if (filterContext.RouteData.DataTokens.Keys.Contains("area")    // 当前请求匹配的 路由对象 是否有区域
                && filterContext.RouteData.DataTokens["area"].ToString().ToLower() == "admin")  // 检测区域名是否为 Admin
            {
                // 2. 检查 被请求的 方法 和控制器 是否有 Skip 标签, 如果有, 则不验证, 如果没有, 则验证
                if (!filterContext.ActionDescriptor.IsDefined(typeof (N32Common.Attributes.SkipAttribute), false) &&
                    !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                        typeof (N32Common.Attributes.SkipAttribute), false))
                {
                    #region 1. 验证用户是否登陆(session && cookie)
                    if (!OperateContext.Current.IsLogin())
                    {
                        filterContext.Result = OperateContext.Current.Redirect("/admin/admin/login", filterContext.ActionDescriptor);
                    }
                    #endregion

                    #region 2. 获取 登陆用户的权限
                    else
                    {
                        string strAreaName = filterContext.RouteData.DataTokens["area"].ToString().ToLower();
                        string strContrllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
                        string strActionName = filterContext.ActionDescriptor.ActionName.ToLower();
                        string strHttpMethod = filterContext.HttpContext.Request.HttpMethod;
                        if (!OperateContext.Current.HasPermission(strAreaName, strActionName, strContrllerName, strHttpMethod))
                        {
                            filterContext.Result = OperateContext.Current.Redirect("/admin/admin/login?Msg = NoPermission", filterContext.ActionDescriptor);
                        }
                    }
                    #endregion
                }
            }
        } 
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using N32Common.Attributes;
using N32MODEL;
using N32MODEL.FormatModel;
using N32MODEL.ViewModel;
using N32WebUi.Helper;

namespace N32WebUi.Login.Admin
{
    /// <summary>
    /// 管理登陆等相关业务
    /// </summary>
    public class AdminController : Controller
    {
        #region 1. 管理员登陆 - 页面显示 - Login()
        /// <summary>
        /// 1. 管理员登陆
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Skip]
        public ActionResult Login()
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
        #endregion

        #region 2. 管理员登陆 - 数据处理 - Login()
        /// <summary>
        /// 1. 管理员登陆
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Skip]
        public ActionResult Login(LoginUser loginUser)
        {
            AjaxModel ajaxModel = new AjaxModel() { Statu = "Err", Msg = "登陆失败!" };

            if (!ModelState.IsValid)
            {
                return OperateContext.Current.RedirectAjax("Err", "没有权限!", null, "");
            }

            if (OperateContext.Current.LoginAdmin(loginUser))
            {
                return OperateContext.Current.RedirectAjax("Ok", "登陆成功!", null, "/admin/admin/index");
            }
            else
            {
                return OperateContext.Current.RedirectAjax("Err", "登陆失败!", null, "");
            }
        }
        #endregion

        #region 3. 显示管理首页 - Index()
        /// <summary>
        /// 显示管理首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        } 
        #endregion

        /// <summary>
        /// 根据当前登录用户 权限 生成菜单
        /// </summary>
        /// <returns></returns>
        [AjaxRequest]
        public ActionResult GetMenuData()
        {
            return Content(OperateContext.Current.UserTreeJsonStr);
        }
    }
}

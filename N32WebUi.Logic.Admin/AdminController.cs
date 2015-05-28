using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using N32MODEL;
using N32MODEL.FormatModel;
using N32WebUi.Helper;

namespace N32WebUi.Logic.Admin
{
    /// <summary>
    /// 管理登陆等相关业务
    /// </summary>
    public class AdminController : Controller
    {
        #region 1. 管理员登陆 - Login()
        /// <summary>
        /// 1. 管理员登陆
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
        #endregion

        #region 2. 管理员登陆 - Login()
        /// <summary>
        /// 1. 管理员登陆
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            AjaxModel ajaxModel = new AjaxModel() { Statu = "Err", Msg = "登陆失败!" };

            // 1. 获取数据
            string strName = form["txtName"];
            string strPwd = form["txtPwd"];
            // 2. 验证 TODO
            // 3. 通过 操作上下文 获取 用户业务接口对象
            Ou_UserInfo userInfo;
            try
            {
                userInfo = OperateContext.bllSession.IOu_UserInfoBll.Login(strName, strPwd);
            }
            catch (Exception ex)
            {
                throw;
            }

            if (userInfo != null)
            {
                ajaxModel.Statu = "Ok";
                ajaxModel.Msg = "登陆成功!";
            }
            return Json(ajaxModel);
        }
        #endregion
    }
}

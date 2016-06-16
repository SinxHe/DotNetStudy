using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using N32MODEL;
using N32WebUi.Helper;

namespace N32WebUi.Login.Admin
{
    /// <summary>
    /// 系统管理
    /// </summary>
    public class SysController : Controller
    {
        #region 1. 权限列表 视图 + Permission()
        /// <summary>
        /// 权限列表视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Permission()
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
        #endregion
        #region 2. 权限列表 数据 + GetPermData()
        /// <summary>
        /// 权限列表视图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetPermData()
        {
            // 1. 查询数据
            var list = OperateContext.Current.BllSession.IOu_PermissionBll
                .GetListBy(p => p.pIsDel == false)
                .Select(p => p.ToPoco());
            // 2. 生成规定格式的Json字符串
            N32MODEL.EasyUiModel.DataGridModel dgModel = new N32MODEL.EasyUiModel.DataGridModel()
            {
                total = list.Count(),
                rows = list,
                footer = null
            };
            return Json(dgModel);
        }
        #endregion
        #region 3. 加载 权限修改 窗体HTML - EditPermission(int id)
        /// <summary>
        /// 3. 加载 权限修改 窗体HTML - EditPermission()
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditPermission(int id)
        {
            // 根据Id查询要修改的权限
            var firstOrDefault = OperateContext.Current.BllSession.IOu_PermissionBll.GetListBy(p => p.pid == id).FirstOrDefault();
            if (firstOrDefault != null)
            {
                // 将权限传给视图的Model属性
                var model = firstOrDefault.ToViewModel();

                // 准备请求方式下拉框
                ViewBag.httpMethodList = new List<SelectListItem>()
                {
                    new SelectListItem(){Text = "Get", Value = "1"},
                    new SelectListItem(){Text = "Post", Value="2" }
                };

                // 0 无操作 1 ezsyui链接 2 打开新窗体
                ViewBag.operationList = new List<SelectListItem>() { 
             new SelectListItem(){ Text="无操作",Value="0"},
             new SelectListItem(){ Text="easyui连接",Value="1"},
             new SelectListItem(){ Text="打开新窗体",Value="2"}
            };

                // ReSharper disable once Mvc.PartialViewNotResolved
                return PartialView(model);
            }
            return null;
        }

        #endregion

        /// <summary>
        /// 权限修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditPermission(Ou_Permission model)
        {
            int res = OperateContext.Current.BllSession.IOu_PermissionBll.Modify(model, "pName", "pAreaName", "pControllerName", "pActionName", "pFormMethod", "pOperationType", "pOrder", "pIsShow", "pRemark");
            if (res > 0)
            {
                return Redirect("/admin/sys/Permission?Ok");
            }
            else
            {
                return Redirect("/admin/sys/Permission?Err");
            }
        }
    }
}

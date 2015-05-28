using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using N32IBLL;
using Spring.Context;

namespace N32WebUi.Logic
{
    public class HomeController:Controller
    {
        /// <summary>
        /// 测试方法, 读取所有的权限数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // 1. 要调用业务层 对象 获取 权限
            var list = Helper.OperateContext.bllSession.IOu_PermissionBll.GetListBy(p => p.pIsDel == false);
            // 2. 加载视图
            return View(list);
        }
    }
}

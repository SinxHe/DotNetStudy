using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N25BLL;
using N25Model;

namespace N25UI.Controllers
{
    public class UserInfoController : Controller
    {
        private UserInfoBll _userInfoBll = new UserInfoBll();
        public ActionResult Index()
        {
            ViewData.Model = _userInfoBll.GetList(u => true);
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserInfo user)
        {
            string result = "no";

            // 执行添加操作, 返回结果
            if (_userInfoBll.Add(user))
            {
                result = "ok";
            }

            return Content(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace N31区域.Controllers
{
    public class QvYuController : Controller
    {
        //
        // GET: /QvYu/

        public ActionResult Index()
        {
            return Content("我是一个外部区域, 我可以被N30引用, 然后被当作一个功能模块使用." +
                           "如果没有");
        }

    }
}

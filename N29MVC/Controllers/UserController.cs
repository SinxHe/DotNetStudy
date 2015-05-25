using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using N29MVC.Models;

namespace N29MVC.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// EF 上下文对象
        /// </summary>
        private DotNetStudyEntities _db = new DotNetStudyEntities();

        /// <summary>
        /// 构造函数中关闭 EF 实体验证
        /// </summary>
        public UserController()
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
        }

        #region 1 显示User列表 public ActionResult Index()
        /// <summary>
        /// 1 显示用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // 1.1 查数据 (EF查询到的实体其实是代理类对象)
            var list = _db.Users.Include("Msgs").Include("Msgs1").ToList();
            // 1.2 加载视图, 把数据给视图
            return View(list);  // 把集合传给视图的Model(强类型)
        } 
        #endregion

        #region 2 删除指定User数据 -- 返回重定向
        /// <summary>
        /// 2 删除指定User数据 -- 返回重定向
        /// </summary>
        /// <returns></returns>
        public ActionResult Del(int id) // id一定要与路由中{id}占位符一样
        {
            // 2.1 检查id是否存在
            // 2.2 删除
            User user = new User() { uId = id };
            //_db.Users.Attach(user);
            //_db.Users.Remove(user);
            DbEntityEntry<User> entry = _db.Entry(user);
            entry.State = System.Data.EntityState.Deleted;
            _db.SaveChanges();
            return Redirect("/User/Index");
        } 
        #endregion

        #region 2 删除指定User, 返回JS代码

        /// <summary>
        /// 删除指定User
        /// </summary>
        /// <param name="id"></param>
        public void DelWithJsReturn(int id)
        {
            // 2.1 检查id是否存在
            // 2.2 删除
            User user = new User() { uId = id };
            //_db.Users.Attach(user);
            //_db.Users.Remove(user);
            DbEntityEntry<User> entry = _db.Entry(user);
            entry.State = System.Data.EntityState.Deleted;
            _db.SaveChanges();
            //Response.Write("<scrip>alert('删除成功!');window.location='/User/Index';</scrip>");    // 返回的语句直接写出来了
            
        }

        #endregion

        #region 3 修改 - 显示要修改的数据
        [HttpGet]
        public ActionResult Modify(int id)
        {
            // 3.1 检查id
            // 3.2 查询数据
            User user = (from u in _db.Users where u.uId == id select u).FirstOrDefault();
            //// 3.3 模拟去数据库查选项
            //List<string> isDelList = new List<string>() {"True", "False"};
            // 3.3 生成适用于HtmlHelper的数据类型
            List<SelectListItem> isDelList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "True", Value = "True", Selected = user != null && (user.uIsDel.ToString() == "True")},
                new SelectListItem(){Text = "False", Value = "False", Selected = user != null && (user.uIsDel.ToString() == "False")}
            };
            // 3.4 传递数据, 列出视图
            ViewBag.IsDelList = isDelList;
            var viewResult = View(user);
            return viewResult;
        }
        [HttpPost]
        public ActionResult Modify(User user)
        {
            DbEntityEntry entry = _db.Entry(user);
            entry.State = System.Data.EntityState.Unchanged;
            entry.Property("uName").IsModified = true;
            entry.Property("uIsDel").IsModified = true;
            _db.SaveChanges();
            return Redirect("/User");
        }

        #endregion
    }
}

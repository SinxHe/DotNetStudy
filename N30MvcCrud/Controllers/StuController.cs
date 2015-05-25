using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N30MvcCrud.Models;

namespace N30MvcCrud.Controllers
{
    public class StuController : Controller
    {
        private readonly DotNetStudyEntities _db = new DotNetStudyEntities();

        #region 1.0 生成学员列表页面
        /// <summary>
        /// 1.0 生成学员列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // 1.1 查询班级列表生成下拉框
            var list = _db.Classes.Where(e => e.CIsDel == false).ToList();
            // 1.2 生成SelectList集合, 指定Value和Text
            SelectList selList = new SelectList(list, "CId", "CName");
            // 1.3 生成List<SelectListItem>
            ViewBag.SelList = selList.AsEnumerable();
            return View();
        }
        #endregion

        #region 2.0 根据页码加载数据
        /// <summary>
        /// 2.0 根据页码加载数据
        /// </summary>
        /// <param name="id">实际上是pageIndex</param>
        /// <returns></returns>
        public ActionResult List(int id)
        {
            int pageIndex = id; // 页码
            int pageSize = 3;   // 页容量
            // 2.1 获取分页数据
            var list2 =
                _db.Students.Include("Class").OrderBy(s => s.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Where(s => s.Class.CID == s.CId)
                    .ToList();
            List<Models.DTO.StudentDto> list = list2.Select(s => s.ToDto()).ToList();// 将EF查询出来的 EF 实体集合(包装类)转换成DTO(DataTransferObject)实体集合
            // 2.2 获取总行数
            int rowCount = _db.Students.Count();
            // 2.3 计算总页数
            int pageCount = Convert.ToInt32(Math.Ceiling((rowCount * 1.0) / pageSize));
            // 2.4 把数据封装到 PageDataModel f分页数据实体中
            PageDataModel<Models.DTO.StudentDto> pageDataModel = new PageDataModel<Models.DTO.StudentDto>()
            {
                PageData = list,
                PageCount = pageCount,
                PageIndex = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount
            };
            // 2.5 将分页数据封装到 Json 标准格式的实体中
            JsonModel jsonModel = new JsonModel()
            {
                Data = pageDataModel,
                Msg = "成功",
                Statu = "Ok"
            };
            // 2.6 生成Json格式数据, 此JSON方法默认只接受post请求
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 3.0 根据Id删除学员
        /// <summary>
        /// 3.0 根据Id删除学员
        /// </summary>
        /// <returns></returns>
        public ActionResult Del()
        {

            JsonModel jsonModel = new JsonModel();
            try
            {
                // 3.1 接收数据
                string strId = Request.QueryString["id"];
                // 3.2 验证是否为整型
                // 3.3 根据Id删除
                Models.Student delModel = new Student() { Id = Convert.ToInt32(strId) };
                _db.Students.Attach(delModel);
                _db.Students.Remove(delModel);
                _db.SaveChanges();
                jsonModel.Statu = "Ok";
                jsonModel.Msg = "删除成功!";
            }
            catch (Exception ex)
            {
                jsonModel.Statu = "Error";
                jsonModel.Msg = "异常: " + ex.Message;
            }
            return Json(jsonModel);
        }
        #endregion

        #region 4.0 Get(int id)
        public ActionResult Get(int id)
        {
            Student stu = _db.Students.Include("Class").FirstOrDefault(s => s.Id == id);
            JsonModel jsonModel = new JsonModel()
            {
                Data = stu.ToDto(),
                Statu = "Ok",
                Msg = "成功获取Id为" + id + "的数据",
            };
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 5.0 Modify(Student student)
        [HttpPost]
        public ActionResult Modify(Student student)
        {
            JsonModel jsonModel = new JsonModel();
            try
            {
                DbEntityEntry entry = _db.Entry(student);
                entry.State = System.Data.EntityState.Unchanged;
                entry.Property("Name").IsModified = true;
                entry.Property("CId").IsModified = true;
                entry.Property("Gender").IsModified = true;
                _db.SaveChanges();
                jsonModel.Data = student;
                jsonModel.Statu = "Ok";
                jsonModel.Msg = "修改成功!";
            }
            catch (Exception ex)
            {
                jsonModel.Statu = "Error";
                jsonModel.Msg = "异常: " + ex.Message;
            }
            return Json(jsonModel);
        }
        #endregion

        // ===================== 强类型 修改 ====================

        #region 6.0 强类型 修改
        [HttpGet]
        public ActionResult ModifyPage(int id)
        {
            Student stu = _db.Students.FirstOrDefault(s => s.Id == id);
            var list = _db.Classes.Select(c => new { CID = c.CID, CName = c.CName }).ToList();
            SelectList selList = new SelectList(list, "CID", "CName");
            ViewBag.SelList = selList.AsEnumerable();
            return View(stu);
        }

        [HttpPost]
        public ActionResult ModifyPage(Student model)
        {
            try
            {
                DbEntityEntry entry = _db.Entry(model);
                entry.State = System.Data.EntityState.Unchanged;
                entry.Property("Name").IsModified = true;
                entry.Property("Gender").IsModified = true;
                entry.Property("CId").IsModified = true;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("<script>alert('异常:" + ex.Message + "');window.location = '/Stu/Index';</script>");
            }
            return Content("<script>alert('修改成功!');window.location = '/Stu/Index';</script>");
        }
        #endregion

        [HttpGet]
        [OutputCache(Duration = 20)]  // 在服务器缓存20秒 绝对过期时间
        [ValidateInput(false)]  // 关闭验证就可以输入<a>等标签了
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Student stu)
        {
            return null;
        }
    }
}

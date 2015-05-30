using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using N32Common.Attributes;
using N32MODEL;
using N32MODEL.EasyUiModel;
using N32MODEL.FormatModel;
using N32MODEL.ViewModel;

namespace N32WebUi.Helper
{
    /// <summary>
    /// 网站操作上下文
    /// </summary>
    public class OperateContext
    {
        private const string AdminCookiePath = @"/admin/";
        private const string AdminInfoKey = @"ainfo";
        private const string AdminPermissionKey = @"apermission";
        private const string AdminLogicSessionKey = @"BllSession";
        private const string AdminTreeString = @"aTreeString";

        /// <summary>
        /// 业务仓储
        /// </summary>
        public readonly N32IBLL.IBllSession BllSession;

        #region 实例构造函数 初始化 业务仓储
        public OperateContext()
        {
            BllSession = N32DI.SpringHelper.GetObject<N32IBLL.IBllSession>("BllSession");
        }
        #endregion

        #region 获取当前线程的 静态 操作上下文
        /// <summary>
        /// 获取当前 操作上下文(从当前服务器处理线程中获取)
        /// </summary>
        public static OperateContext Current
        {
            get
            {
                OperateContext oContext = CallContext.GetData(typeof(OperateContext).Name) as OperateContext;
                if (oContext == null)
                {
                    oContext = new OperateContext();
                    CallContext.SetData(typeof(OperateContext).Name, oContext);
                }
                return oContext;
            }
        }
        #endregion

        #region 用户权限
        /// <summary>
        /// 用户权限
        /// </summary>
        public List<Ou_Permission> UserPermission
        {
            get { return Session[AdminPermissionKey] as List<Ou_Permission>; }
            set
            {
                Session[AdminPermissionKey] = value;
            }
        }
        #endregion

        #region 当前用户对象
        public Ou_UserInfo User
        {
            get
            {
                return Session[AdminInfoKey] as Ou_UserInfo;
            }
            set
            {
                Session[AdminInfoKey] = value;
            }
        }
        #endregion

        #region 1. Http上下文 及 相关属性
        private HttpContext ContextHttp
        {
            get { return HttpContext.Current; }
        }

        private HttpResponse Response
        {
            get { return ContextHttp.Response; }
        }

        private HttpRequest Request
        {
            get { return ContextHttp.Request; }
        }

        private HttpSessionState Session
        {
            get { return ContextHttp.Session; }
        }
        #endregion

        // ---------------------- 登陆 权限 等系统操作 ------------------

        #region 管理员登陆
        /// <summary>
        /// 管理员登陆
        /// </summary>
        /// <param name="usrPara"></param>
        public bool LoginAdmin(LoginUser usrPara)
        {
            Ou_UserInfo user = BllSession.IOu_UserInfoBll.Login(usrPara.LoginName, usrPara.Pwd);
            if (user != null)
            {
                #region 保存用户数据 Session and Cookie
                // 1. Session - 用户Model
                User = user;
                // 2. Cookie - 用户Id号
                if (usrPara.IsAllways)
                { // 如果选择了复选框, 则用Cookie保存数据
                    // 2.1 对用户Id加密成字符串
                    string strCookieValue = N32Common.SecurityHelper.EncryptUserInfo(user.uId.ToString());
                    // 2.2 创建Cookie
                    HttpCookie cookie = new HttpCookie(AdminInfoKey, strCookieValue)
                    {
                        Expires = DateTime.Now.AddDays(1),
                        Path = AdminCookiePath
                    };
                    // 区域相关的Cookie
                    Response.Cookies.Add(cookie);
                }
                // 3. Session - 用户权限
                UserPermission = GetUserPermission(user.uId);
                return true;
                #endregion
            }
            return false;
        }
        #endregion

        #region 判断当前用户是否登陆 - bool IsLogin()
        /// <summary>
        /// 判断当前用户是否登陆
        /// </summary>
        /// <returns></returns>
        public bool IsLogin()
        {
            if (Session[AdminInfoKey] == null)
            {
                if (Request.Cookies[AdminInfoKey] == null)
                {
                    return false;
                }
                else
                {
                    string strUserInfo = Request.Cookies[AdminInfoKey].Value;
                    strUserInfo = N32Common.SecurityHelper.DecryptUserInfo(strUserInfo);
                    int userid = int.Parse(strUserInfo);
                    Ou_UserInfo user = BllSession.IOu_UserInfoBll.GetListBy(u => u.uId == userid).First();
                    User = user;
                    UserPermission = OperateContext.Current.GetUserPermission(user.uId);
                }
            }
            return true;
        }
        #endregion

        #region 判断当前用户是否有 访问 当前页面的权限
        /// <summary>
        /// 判断当前用户是否有 访问 当前页面的权限
        /// </summary>
        /// <returns></returns>
        public bool HasPermission(string areaName, string actionName, string controllerName, string httpMethod)
        {
            var listP = from per in UserPermission
                        where
                            string.Equals(per.pAreaName, areaName, StringComparison.CurrentCultureIgnoreCase) &&
                            string.Equals(per.pControllerName, controllerName, StringComparison.CurrentCultureIgnoreCase) &&
                            string.Equals(per.pActionName, actionName, StringComparison.CurrentCultureIgnoreCase) &&
                            per.pFormMethod == (httpMethod.ToLower() == "get" ? 1 : 2)
                        select per;
            ;
            return listP.Any();
        } 
        #endregion


        #region 根据用户Id查询用户权限
        /// <summary>
        /// 根据用户Id查询用户权限
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public List<Ou_Permission> GetUserPermission(int uId)
        {
            #region 1. 根据角色查询出权限 List<Ou_Permission> listPer
            // 1. 根据用户Id查询到用户的角色Id
            List<int> listRoleId = OperateContext.Current.BllSession.IOu_UserRoleBll.GetListBy(u => u.urUId == uId).Select(u => u.urRId).ToList();
            // 2. 根据角色Id查询角色的权限Id
            List<int> listPerId = OperateContext.Current.BllSession.IOu_RolePermissionBll.GetListBy(rp => listRoleId.Contains(rp.rpRId)).Select(rp => rp.rpPId).ToList();
            // 3. 查询所有角色数据
            List<Ou_Permission> listPer = OperateContext.Current.BllSession.IOu_PermissionBll.GetListBy(p => listPerId.Contains(p.pid)).Select(p => p.ToPoco()).ToList();
            #endregion
            #region 2. 查询特权 List<Ou_Permission> listPerVip
            // 1. 查询用户特权
            List<int> listVipPerId = OperateContext.Current.BllSession.IOu_UserVipPermissionBll.GetListBy(vip => vip.vipUserId == uId).Select(vip => vip.vipPermission).ToList();
            // 2. 查询特权数据
            List<Ou_Permission> listPerVip = OperateContext.Current.BllSession.IOu_PermissionBll.GetListBy(p => listVipPerId.Contains(p.pid)).Select(p => p.ToPoco()).ToList();
            #endregion

            // 3. 权限合并
            listPerVip.ForEach(p => listPer.Add(p));
            return listPer;
        }
        #endregion

        #region 获取当前登录用户的权限树Json字符串 - Session
        public string UserTreeJsonStr
        {
            get
            {
                if (Session[AdminTreeString] == null)
                {
                    // 将登陆用户的权限集合 转成 树节点 集合(其中IsShow = false的不要生成树节点)
                    List<TreeNode> listTree = N32MODEL.Ou_Permission.ToTreeNodes(UserPermission.Where(p => p.pIsShow == true).ToList());
                    Session[AdminTreeString] = N32Common.DataHelper.Obj2Json(listTree);
                }
                return Session[AdminTreeString].ToString();
            }
        } 
        #endregion

        // ---------------------- 公用操作方法 ------------------

        #region 生成Json格式返回值
        /// <summary>
        /// 生成Json格式返回值
        /// </summary>
        /// <param name="statu"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <param name="backUrl"></param>
        /// <returns></returns>
        public ActionResult RedirectAjax(string statu, string msg, object data, string backUrl)
        {
            AjaxModel ajaxModel = new AjaxModel()
            {
                Statu = statu,
                Msg = msg,
                Data = data,
                BackUrl = backUrl
            };
            JsonResult res = new JsonResult();
            res.Data = ajaxModel;
            return res;
        }
        #endregion

        #region 重定向 - 根据Action方法特性
        /// <summary>
        /// 当前重定向方法: 1. Ajax请求: 返回Json字符串 2. 普通请求, 返回重定向命令
        /// </summary>
        /// <returns></returns>
        public ActionResult Redirect(string url, ActionDescriptor action)
        {
            // 如果Ajax请求没有权限, 返回Json消息
            if (action.IsDefined(typeof(AjaxRequestAttribute), false) ||
                action.ControllerDescriptor.IsDefined(typeof(AjaxRequestAttribute), false))
            {
                return RedirectAjax("NoLogin", "您还没有登陆或没有权限访问此页面!", null, url);
            }
            else    // 如果超链接或表单没有权限访问 返回重定向302
            {
                return new RedirectResult(url);
            }
        } 
        #endregion

        

    } 
}

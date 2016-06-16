using System;
using System.Collections.Generic;
using N28_2Bll;
using N28_4MODEL;

namespace N28_1UI
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserBll bll = new UserBll();
                //List<User> list = bll.GetListBy(u => u.uIsDel == false);
                //bll.Modify(new User { uId = 1, uLoginName = "UserListChaged" }, "uLoginName");
                //rptUserList.DataSource = list;
                //rptUserList.DataBind();
                bll.ModifyBy(new User(){uLoginName = "ModifyByChange", uPwd = "123456"}, u => u.uId == 4||u.uId == 5, "uLoginName", "uPwd");
            }
        }
    }
}
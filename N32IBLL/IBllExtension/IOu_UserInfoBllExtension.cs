using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N32MODEL;

namespace N32IBLL
{
    public partial interface IOu_UserInfoBll
    {
        N32MODEL.Ou_UserInfo Login(string strName, string strPwd);
    }
}

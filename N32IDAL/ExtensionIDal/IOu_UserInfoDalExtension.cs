using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N32MODEL;

namespace N32IDAL//.ExtensionIDal
{
    public partial interface IOu_UserInfoDal
    {
        Ou_UserInfo Login(string loginName);
    }
}

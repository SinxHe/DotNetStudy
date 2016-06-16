using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N32IDAL;
using N32MODEL;

namespace N32DALMSSQL//.ExtensionDal
{
    public partial class Ou_UserInfoDal:IOu_UserInfoDal
    {
        public Ou_UserInfo Login(string loginName)
        {
            return GetListBy(u => u.uLoginName == loginName).FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N27EntityFramwork
{
    public partial class User
    {
        public override string ToString()
        {
            return string.Format("姓名: {0}   登录名: {1}    密码: {2}", 
                this.uName, this.uLoginName, this.uPwd);
        }
    }
}

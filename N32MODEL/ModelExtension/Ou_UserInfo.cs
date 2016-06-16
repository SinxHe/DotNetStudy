using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N32MODEL
{
    /// <summary>
    /// 拓展用户实体类
    /// </summary>
    public partial class Ou_UserInfo
    {
        public Ou_UserInfo ToPoco()
        {
            Ou_UserInfo poco = new Ou_UserInfo()
            {
                uId = this.uId,
                uDepId = this.uDepId,
                uLoginName = this.uLoginName,
                uPwd = this.uPwd,
                uGender = this.uGender,
                uPost = this.uPost,
                uRemark = this.uRemark,
                uIsDel = this.uIsDel,
                uAddTime = this.uAddTime
            };
            return poco;
        }
    }
}

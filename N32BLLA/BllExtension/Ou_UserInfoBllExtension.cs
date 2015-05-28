using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N32IBLL;
using N32MODEL;

namespace N32BLLA
{
    public partial class Ou_UserInfoBll : IOu_UserInfoBll
    {
        /// <summary>
        /// 实现登陆功能
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public Ou_UserInfo Login(string strName, string strPwd)
        {
            // 1. 调用业务层方法, 根据登陆名查询
            Ou_UserInfo usr = GetListBy(u => u.uLoginName == strName).First();
            // 2. 判断登陆是否成功
            if (usr != null && usr.uPwd == Common.DataHelper.Md5(strPwd))
            {
                return usr;
            }
            return null;
        }
    }
}

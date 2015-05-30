using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace N32Common
{
    /// <summary>
    /// 票据对象 设备相关 加密 解密 
    /// </summary>
    public class SecurityHelper
    {
        #region 1. 用户信息加密 使用票据对象实现 - EncryptUserInfo
        /// <summary>
        /// 使用票据 对象 将用户数据加密成字符串 加密是跟设备相关的, 在别的设备上无法解密
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static string EncryptUserInfo(string userInfo)
        {
            // 1 将用户数据存入票据对象
            System.Web.Security.FormsAuthenticationTicket ticket = new System.Web.Security.FormsAuthenticationTicket(1, "哈哈", DateTime.Now, DateTime.Now, true, userInfo);
            // 2. 将票据对象 加密成字符串(可逆)
            string strData = System.Web.Security.FormsAuthentication.Encrypt(ticket);
            return strData;
        }
        #endregion
        #region 2. 解密 加密的字符串
        /// <summary>
        /// 加密字符串 解密
        /// </summary>
        /// <param name="cryptograph">加密字符串</param>
        /// <returns></returns>
        public static string DecryptUserInfo(string cryptograph)
        {
            // 1. 将加密字符串 解压成 票据对象
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cryptograph);
            // 2. 将 票据对象里面的 用户数据 返回
            if (ticket != null)
                return ticket.UserData;
            return null;
        }
        #endregion
    }
}

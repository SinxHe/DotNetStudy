using N10三层架构.DAL;
using N10三层架构.Model;
// 2015-4-3 12:16:11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N10三层架构.BLL
{
    class T_UsersBLL
    {
        /// <summary>
        /// 用户登录返回的结果
        /// 成功 用户名有多个 用户不存在 密码错误
        /// </summary>
        public enum LoginResult { Success, UserNotExists, ErrorPassword, MultiUsers }

        /// <summary>
        /// 用户更改密码的结果
        /// 成功, 用户名有多个, 用户名不存在, 密码错误, 两次密码不一致
        /// </summary>
        public enum ChangePasswordResult { Successed, FailedOfMultiName, FailedOfNameNotExits, FailedOfErrorPassword, FailedOfDiffNewPwd }

        /// <summary>
        /// 检查用户登录
        /// 1.  参数: 用户输入的用户名, 密码
        /// 2.  返回值: 用户不存在, 用户密码不正确, 登录成功
        ///     1.  返回null, 用户不存在
        ///     2.  返回实体的密码与输入密码不一致, 用户密码不正确
        ///     3.  返回实体密码与输入密码一致, 登录成功
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public LoginResult CheckUserLogin(string name, string password, out T_UserModel user)
        {
            try
            {
                user = new T_UsersDAL().GetUserBasicInfoByName(name);
            }
            catch (Exception e)
            {
                // 异常: 重名用户
                if (e.Message == "MultiUsers")
                {
                    user = null;
                    return LoginResult.MultiUsers;
                }
                else
                {
                    throw;
                }
            }

            if (user == null)
            {
                return LoginResult.UserNotExists;
            }
            else if (user.Password == Heab.SQL.MD5.GetMD5(password))
            {
                return LoginResult.Success;
            }
            else
            {
                return LoginResult.ErrorPassword;
            }
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="newPwd1">新密码</param>
        /// <param name="newPwd2">重复新密码</param>
        /// <returns>成功 重名用户 用户不存在 密码错误 新密码不一致</returns>
        public ChangePasswordResult ChangePassword(string name, string pwd, string newPwd1, string newPwd2)
        {
            pwd = Heab.SQL.MD5.GetMD5(pwd);
            newPwd1 = Heab.SQL.MD5.GetMD5(newPwd1);
            newPwd2 = Heab.SQL.MD5.GetMD5(newPwd2);
            // 1.   验证密码是否一致
            if (newPwd1 == newPwd2)
            {
                // 2.   用户登录是否成功
                int userNum = new T_UsersDAL().SelectCountFromNameAndPwd(name, pwd);
                if ( 0 >= userNum)  // 到底是用户名密码不对还是用户不存在
                {
                    if (new T_UsersDAL().GetUserBasicInfoByName(name) == null)  // 用户不存在
                    {
                        return ChangePasswordResult.FailedOfNameNotExits;    
                    }
                    else
                    {
                        return ChangePasswordResult.FailedOfErrorPassword;
                    }
                }
                else if (userNum > 1)
                {
                    return ChangePasswordResult.FailedOfMultiName;
                }
                else //if (userNum == 1)  // 登录成功
                {
                    if (new T_UsersDAL().UpdatePassword(name, newPwd1) == 1)
                    {
                        return ChangePasswordResult.Successed;
                    }
                    else
                    {
                        throw new Exception("更新密码出异常!");
                    }
                }
            }
            else
            {
                return ChangePasswordResult.FailedOfDiffNewPwd;
            }
            

            // 3.   更改密码
        }
    }
}

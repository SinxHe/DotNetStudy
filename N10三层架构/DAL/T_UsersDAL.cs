using N10三层架构.Model;
// 2015-4-3 11:22:18
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N10三层架构.DAL
{
    class T_UsersDAL
    {
        /// <summary>
        /// 返回指定用户名的信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T_UserModel GetUserBasicInfoByName(string name)
        {
            T_UserModel user = null;    // 先不实例化, 如果没有查到数据就返回null了
                                        // 如果实例化, 不赋值, 会有默认值, 谁知道默认值是不是有效值;
                                        // 如果是集合的话, 返回count是0的一个实例就行了, 因为集合是要遍历的, 返回null会报异常

            string sql = "select * from T_Users where Name = @Name";
            DataTable dt = Heab.SQL.SqlHelper.ExecuteDataTable(sql, new SqlParameter("@Name", name));

            if (dt.Rows.Count == 1)
            {
                user = new T_UserModel();
                DataRow dr = dt.Rows[0];
                user.Id = Convert.ToInt32(dr["Id"]);
                user.Name = Convert.ToString(dr["Name"]);
                user.Password = Convert.ToString(dr["Password"]);
                user.RealName = Convert.ToString(Heab.SQL.SqlHelper.FromDbValue(dr["RealName"]));
            }
            else if (dt.Rows.Count > 1)
            {
                throw new Exception("MultiUsers");
            }
            else // <1 返回null
            {}

            return user;
        }

        /// <summary>
        /// 返回指定用户名密码的用户的个数(验证登录)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int SelectCountFromNameAndPwd(string name, string pwd)
        {
            string sql = "select COUNT(*) from T_Users where Name=@Name and Password=@Password";
            SqlParameter[] Params = new SqlParameter[]
            {
                new SqlParameter("@Name", name), 
                new SqlParameter("@Password", pwd)
            };
            int num = (int)Heab.SQL.SqlHelper.ExecuteScalar(sql, Params);
            return num;
        }

        /// <summary>
        /// 根据用户名修改密码
        /// </summary>
        /// <param name="name"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public int UpdatePassword(string name, string newPwd)
        {
            string sql = "update T_Users set Password = @Password where Name = @Name";
            int num = Heab.SQL.SqlHelper.ExecuteNonQuery(sql, 
                new SqlParameter("@Name", name),
                new SqlParameter("@Password", newPwd));
            return num;
        }
    }
}

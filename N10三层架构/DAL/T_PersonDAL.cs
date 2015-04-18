// 2015-4-2 20:41:24
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N10三层架构.DAL
{
    /// <summary>
    /// 操作AspNetStudy数据库T_Person表
    /// </summary>
    public class T_PersonDAL
    {
        /// <summary>
        /// 编写一个方法前考虑方法的参数和返回值:
        ///     1. 参数: 执行该SQL语句需要外界参数吗, 不需要就没有参数
        ///     2. 返回值: sql语句执行完毕, 数据库返回什么值就将此方法设置为返回什么类型的值 
        /// </summary>
        public int UpdateEmailByName(string name, string email)
        {
            string SqlString = "UPDATE T_Persons SET Email = @Email WHERE Name = @Name";
            int num = Heab.SQL.SQLHelper.ExecuteNonQuery(SqlString, 
                new SqlParameter("@Email", email),
                new SqlParameter("@Name", name));
            return num;
        }
    }
}

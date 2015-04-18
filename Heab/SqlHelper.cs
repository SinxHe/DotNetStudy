// 2015-04-02 20:03:03
// 2015-04-10 20:19:34   将字段connStr改成了public 非readonly
// 2015-04-11 13:12:15  添加TestConn()方法 添加了TODO:SqlHelperInit.SetConfigConnStr
// 2015-04-12 14:42:43  去除了SqlHelperInit, 使用静态构造函数捕获异常的手段实现了静态变量异常初始化.
//                      实现功能:   1. 默认从配置文件中读取数据库连接字符串; 
//                                  2. 可以直接赋值ConStr覆盖默认数据库连接字符串;
//                                  3. 都不满足, 异常InvalidateOperationException

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Heab.SQL
{
    /// <summary>
    /// 数据库的SQL操作
    /// 使用条件: 
    ///     1. ConnStr为配置文件中必须有的connstr连接字符串
    ///     2. ConnStr为null, 此时没有配置文件, 必须手动设置ConnStr
    ///     3. InvalidOperationException异常, 说明此时以上两步都不满足
    /// </summary>
    public class SqlHelper
    {
        /// <summary>
        /// 默认: 配置文件中获取连接字符串connstr, 如果配置文件中没有配置, 异常为NullReferenceException, 然后异常为TypeInitializationException, 在构造函数中已经捕获, 设置为null
        /// 设置: 直接赋值(null说明没有配置connstr, 否则为有默认配置)
        /// </summary>
        public static string ConnStr;

        static SqlHelper()
        {
            try
            {
                ConnStr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            }
            // 如果此时配置文件中没有设置connstr数据库连接字符串
            catch (System.NullReferenceException)
            {
                ConnStr = null;
            }
        }

        /// <summary>
        /// 测试数据库连接, 不成功会报出异常
        /// </summary>
        public static void TestConn()
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
            }
        }

        /// <summary>
        /// 执行非查询语句
        /// 返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;

                    // 第一种
                    //foreach (SqlParameter param in parameters)
                    //{
                    //    cmd.Parameters.Add(param);
                    //}
                    // 第二种
                    cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // SQL操作返回一个一行一列的数据
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        // 执行查询结果比较少的SQL
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }
        #region 完成数据库与C#语言中null的转换
        /// <summary>
        /// 如果对象是null, 则返回数据空中的"null"(即: DBNull.Value), 否则返回对象本身
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object ToDbValue(object obj)
        {
            if (obj == null)
            {
                return DBNull.Value;
            }
            else
            {
                return obj;
            }
        }

        /// <summary>
        /// 取出数据库中的数据, 如果是SQL中的Null则转换成C#中的Null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object FromDbValue(object obj)
        {
            if (obj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return obj;
            }
        }
        #endregion
    }
}

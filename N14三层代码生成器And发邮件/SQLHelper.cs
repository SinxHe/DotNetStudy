// 2015-4-2 20:03:03
// 2015-4-10 20:19:34 将字段connStr改成了public 非readonly
// 2015-04-11 13:12:15 添加TestConn()方法 添加了TODO:SqlHelperInit.SetConfigConnStr
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Heab.SQL
{
    /// <summary>
    /// 数据库的SQL操作
    /// 使用条件: 配置文件中必须有connstr连接字符串
    /// </summary>
    public class SqlHelper
    {
        /// <summary>
        /// 默认: 配置文件中获取连接字符串connstr, 否则异常为TypeInitializationException
        /// 设置: catch异常TypeInitializationException, 设置ConnStr字段
        /// </summary>
        public static string ConnStr;

        /// <summary>
        /// 测试数据库连接, 不成功会报出异常
        /// </summary>
        public static void TestConn()
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                conn.Close();
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

    #region 完成ConnStr的初始化
    public static class SqlHelperInit
    {
        public static void SetConfigConnStr(string connstr)
        {
            //ConfigurationManager.ConnectionStrings["connstr"].ConnectionString = connstr;
            //ConfigurationManager.ConnectionStrings.Add(new ConnectionStringSettings(connstr, "lalalal"));
            //Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //appConfig.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("connstr", "123456"));
            //appConfig.url
            //appConfig.Save();
        }
    }
    #endregion
}

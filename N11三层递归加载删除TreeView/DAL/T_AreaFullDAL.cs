using N11三层递归加载删除TreeView.Model;
// 2015-4-3 22:01:27
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N11三层递归加载删除TreeView.DAL
{
    class T_AreaFullDAL
    {
        /// <summary>
        /// 返回指定Pid下的所有Area
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<T_AreaFullModel> GetAreaByPid(int pid)
        {
            string sql = "select * from T_AreaFull where AreaPid = @Pid";
            DataTable dt = Heab.SQL.SqlHelper.ExecuteDataTable(sql, new SqlParameter("@Pid", pid));
            List<T_AreaFullModel> list = new List<T_AreaFullModel>();
            foreach (DataRow item in dt.Rows)
            {
                T_AreaFullModel area = new T_AreaFullModel();
                    // 这里每次都新创建一个对象放到list中才对, 因为是引用的...

                area.AreaId = Convert.ToInt32(item["AreaId"]);
                area.AreaName = (string)item["AreaName"];
                area.AreaPid = Convert.ToInt32(item["AreaPid"]);
                list.Add(area);
            }
            return list;
        }

        /// <summary>
        /// 删除指定AreaId下的Area
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns>返回受影响的行数, 正常情况下为1</returns>
        public int DeleteAreaByAreaId(int areaId)
        {
            string sql = "delete from T_AreaFull where AreaId = @AreaId";
            return Heab.SQL.SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@AreaId", areaId));
        }
    }
}

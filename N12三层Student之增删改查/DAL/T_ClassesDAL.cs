using N12三层Student之增删改查.Model;
// 2015-4-4 15:31:18
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N12三层Student之增删改查.DAL
{
    class T_ClassesDAL
    {
        /// <summary>
        /// 返回所有class的list集合
        /// </summary>
        /// <returns></returns>
        public List<T_ClassesModel> GetAllClasses()
        {
            List<T_ClassesModel> list = new List<T_ClassesModel>();
            string sql = "select * from T_Classes where 1 = 1";
            DataTable dt = Heab.SQL.SQLHelper.ExecuteDataTable(sql);
            foreach (DataRow item in dt.Rows)
            {
                T_ClassesModel classInfo = new T_ClassesModel();
                classInfo.Id = Convert.ToInt32(item["Id"]);
                classInfo.Name = Convert.ToString(item["Name"]);
                list.Add(classInfo);
            }
            return list;
        }

    }
}

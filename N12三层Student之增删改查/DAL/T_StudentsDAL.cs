using N12三层Student之增删改查.Model;
// 2015-4-4 16:32:36
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N12三层Student之增删改查.DAL
{
    class T_StudentsDAL
    {
        /// <summary>
        /// 插入一条学生信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns>正常插入返回1</returns>
        public int InsertStudent(T_StudentsModel s)
        {
            string sql = "insert into T_Students([Name], [Gender], [Age], [ClassId], [Birthday]) values(@Name, @Gender, @Age, @ClassId, @Birthday)";
            SqlParameter[] sp = new SqlParameter[] { 
                new SqlParameter("@Name", s.Name),
                new SqlParameter("@Gender", s.Gender),
                new SqlParameter("@Age", s.Age),
                new SqlParameter("@ClassId", s.t_ClassModel.Id),
                new SqlParameter("@Birthday", s.Birthday)
            };
            return Heab.SQL.SqlHelper.ExecuteNonQuery(sql, sp);
        }

        public List<T_StudentsModel> GetAllStudents()
        {
            List<T_StudentsModel> list = new List<T_StudentsModel>();
            string sql = "select T_Students.*, T_Classes.Name as ClassName from T_Students inner join T_Classes on T_Students.Id = T_Classes.Id";
            DataTable dt = Heab.SQL.SqlHelper.ExecuteDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                T_StudentsModel student = new T_StudentsModel();
                student.Id = Convert.ToInt32(row["Id"]);
                student.Name = Convert.ToString(row["Name"]);
                student.Gender = Convert.ToString(row["Gender"]);
                student.Age = Convert.ToInt32(row["Age"]);
                student.Birthday = (DateTime)row["Birthday"];
                T_ClassesModel classModel = new T_ClassesModel();
                classModel.Name = Convert.ToString(row["ClassName"]);
                classModel.Id = Convert.ToInt32(row["ClassId"]);
                student.t_ClassModel = classModel;
                list.Add(student);
            }
            return list;
        }
    }
}

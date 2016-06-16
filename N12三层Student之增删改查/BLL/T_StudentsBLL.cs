using N12三层Student之增删改查.DAL;
using N12三层Student之增删改查.Model;
// 2015-4-4 16:55:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N12三层Student之增删改查.BLL
{
    class T_StudentsBLL
    {
        T_StudentsDAL dal = new T_StudentsDAL();
        public void InsertStudent(T_StudentsModel student)
        {
            dal.InsertStudent(student);
        }

        public List<T_StudentsModel> GetAllStudents()
        {
            return dal.GetAllStudents();
        }
    }
}

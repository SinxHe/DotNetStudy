using N12三层Student之增删改查.DAL;
using N12三层Student之增删改查.Model;
// 2015-4-4 15:42:20
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N12三层Student之增删改查.BLL
{
    class T_ClassesBLL
    {
        T_ClassesDAL dal = new T_ClassesDAL();
        public List<T_ClassesModel> GetAllClasses()
        {
            return dal.GetAllClasses();
        }
    }
}

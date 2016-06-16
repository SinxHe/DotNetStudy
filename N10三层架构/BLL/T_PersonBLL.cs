using N10三层架构.DAL;
// 2015-4-2 21:30:40
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N10三层架构.BLL
{
    class T_PersonBLL
    {
        public bool UpdateEmailByName(string name, string email)
        {
            T_PersonDAL pd = new T_PersonDAL();
            return pd.UpdateEmailByName(name, email) == 1;
        }
    }
}

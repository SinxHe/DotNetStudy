// 2015-4-4 14:44:13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// java => 跨平台 
// .net => 
// 
namespace N12三层Student之增删改查.Model
{
    // [Id], [Name], [Gender], [Age], [ClassId], [Birthday]
    class T_StudentsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        // 模拟表中的主外键关系
        public T_ClassesModel t_ClassModel { get; set; }
    }
}

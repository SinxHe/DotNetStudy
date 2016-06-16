// 2015-4-3 11:10:25
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N10三层架构.Model
{
    /// <summary>
    /// 实体类T_User
    /// 一般数据库中有几个字段就写几个属性
    /// [Id], [Name], [Password], [RealName]
    /// </summary>
    class T_UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
    }
}

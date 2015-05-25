using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N30MvcCrud.Models
{
    /// <summary>
    /// 将 EF 包装Student转成DTO的Studnet
    /// </summary>
    public partial class Student
    {
        public DTO.StudentDto ToDto()
        {
            return new DTO.StudentDto()
            {
                Id = this.Id,
                CId = this.CId,
                Gender = this.Gender,
                AddTime = this.AddTime,
                IsDel = this.IsDel,
                Name = this.Name,
                Class = this.Class.ToDto()
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N30MvcCrud.Models
{
    /// <summary>
    /// 将EF 班级转成Dto班级
    /// </summary>
    public partial class Class
    {
        public DTO.ClassDto ToDto()
        {
            return new DTO.ClassDto()
            {
                CID = this.CID,
                CName = this.CName,
                CAddTime = this.CAddTime,
                CCount = this.CCount,
                CImg = this.CImg,
                CIsDel = this.CIsDel,
            };
        }
    }
}
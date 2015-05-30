using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace N32MODEL.ViewModel
{
    /// <summary>
    /// 登陆视图 模型
    /// </summary>
    public class LoginUser
    {
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Pwd { get; set; }
        public bool IsAllways { get; set; }
    }
}

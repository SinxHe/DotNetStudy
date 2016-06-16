using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N32MODEL.FormatModel
{
    /// <summary>
    /// 统一的Ajax格式
    /// </summary>
    public class AjaxModel
    {
        public string Msg { get; set; }
        public string Statu { get; set; }   // Ok, Err
        public string BackUrl { get; set; }
        public object Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 关闭命名规范检验
// ReSharper disable InconsistentNaming
namespace N32MODEL.EasyUiModel
{
    public class DataGridModel
    {
        public int total { get; set; }
        public object rows { get; set; }
        public object footer { get; set; }
    }
}

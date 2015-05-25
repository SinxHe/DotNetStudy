using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N30MvcCrud.Models
{
    /// <summary>
    /// 分页数据实体
    /// </summary>
    public class PageDataModel<T>
    {
        public List<T> PageData { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int RowCount { get; set; }
    }
}
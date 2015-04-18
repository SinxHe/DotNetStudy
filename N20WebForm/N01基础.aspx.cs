using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N20WebForm
{
    public partial class N01基础 : System.Web.UI.Page
    {
        public string Str1 { get; set; }
        private string str;

        /// <summary>
        /// 后台页面加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Str1 = "我是 N01基础 的public属性, 能被子类拿到!";
            str = "我是 N01基础 的private字段, 不能被子类拿到";
        }
    }
}
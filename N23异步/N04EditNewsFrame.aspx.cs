using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N23异步
{
    public partial class N04EditNewsFrame : System.Web.UI.Page
    {
        public DataRow dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/html";
            int Id = int.Parse(Request["Id"] ?? "0");
            DataTable dt = Heab.SQL.SQLHelper.ExecuteDataTable("select * from HKSJ_Main where ID = @Id",
                new SqlParameter("@Id", Id));
            dr = dt.Rows[0];
        }
    }
}
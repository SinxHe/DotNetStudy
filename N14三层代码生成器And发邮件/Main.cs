using Heab.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N14三层代码生成器And发邮件
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Heab.SQL.SqlHelper.ConnStr = txtConnString.Text;
            try
            {
                SqlHelper.TestConn();
            }
            catch (Exception ex)
            {
                lblConnStatus.Text = ex.Message;
                throw;
            }
            lblConnStatus.Text = "连接成功!";
            
            // 加载所有的表到ListBox中
            DataTable dt = SqlHelper.ExecuteDataTable("select TABLE_NAME from INFORMATION_SCHEMA.TABLES");
            foreach (DataRow row in dt.Rows)
            {
                listBox1.Items.Add(row[0]);
            }
        }
    }
}

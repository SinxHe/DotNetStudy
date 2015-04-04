using N10三层架构.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N10三层架构
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;

            // 这是表现层的逻辑不是"业务逻辑"
            if (new T_PersonBLL().UpdateEmailByName(name, email))
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("not ok");
            }
        }
    }
}

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

namespace N10三层架构.UI
{
    public partial class N02改密码 : Form
    {
        public N02改密码()
        {
            InitializeComponent();
        }

        private void btnUpdatePwd_Click(object sender, EventArgs e)
        {
            string pwd = txtOldPwd.Text;
            string newPwd1 = txtNewPwd1.Text;
            string newPwd2 = txtNewPwd2.Text;
            T_UsersBLL.ChangePasswordResult result = new T_UsersBLL().ChangePassword(GlobalHelper.T_Users_name, pwd, newPwd1, newPwd2);
            switch (result)
            {
                case T_UsersBLL.ChangePasswordResult.Successed:
                    MessageBox.Show("修改成功!");
                    break;
                case T_UsersBLL.ChangePasswordResult.FailedOfMultiName:
                    MessageBox.Show("用户名重名!");
                    break;
                case T_UsersBLL.ChangePasswordResult.FailedOfNameNotExits:
                    MessageBox.Show("用户名不存在!");
                    break;
                case T_UsersBLL.ChangePasswordResult.FailedOfErrorPassword:
                    MessageBox.Show("密码错误!");
                    break;
                case T_UsersBLL.ChangePasswordResult.FailedOfDiffNewPwd:
                    MessageBox.Show("两次输入密码不一致!");
                    break;
                default:
                    MessageBox.Show("更改密码返回位置结果!");
                    break;
            }
        }
    }
}

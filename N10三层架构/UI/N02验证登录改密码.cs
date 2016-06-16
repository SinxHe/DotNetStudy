using N10三层架构.BLL;
using N10三层架构.Model;
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
    public partial class N02验证登录改密码 : Form
    {
        public N02验证登录改密码()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string password = txtPassword.Text;
            T_UsersBLL userBll = new T_UsersBLL();
            T_UserModel userModel;
            T_UsersBLL.LoginResult loginResult = userBll.CheckUserLogin(name, password, out userModel);
            switch (loginResult)
            {
                case T_UsersBLL.LoginResult.Success:
                    MessageBox.Show("登录成功!");
                    lblWelcome.Text = userModel.Name + ", 欢迎你!";
                    GlobalHelper.T_Users_name = name;
                    btnUpdatePassword.Enabled = true;
                    break;
                case T_UsersBLL.LoginResult.UserNotExists:
                    MessageBox.Show("用户不存在!");
                    break;
                case T_UsersBLL.LoginResult.ErrorPassword:
                    MessageBox.Show("密码错误!");
                    break;
                case T_UsersBLL.LoginResult.MultiUsers:
                    MessageBox.Show("用户重名!");
                    break;
                default:
                    MessageBox.Show("LoginResult: default");
                    break;
            }
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            N02改密码 changePwdForm = new N02改密码();
            changePwdForm.ShowDialog();
        }
    }
}

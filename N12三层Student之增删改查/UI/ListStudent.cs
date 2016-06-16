using N12三层Student之增删改查.BLL;
using N12三层Student之增删改查.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N12三层Student之增删改查
{
    public partial class ListStudent : Form
    {
        public ListStudent()
        {
            InitializeComponent();
        }

        private void ListStudent_Load(object sender, EventArgs e)
        {
            // 加载class到下拉列表
            LoadClasses();
            // 显示所有Students
            T_StudentsBLL bll = new T_StudentsBLL();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bll.GetAllStudents();
        }

        private void LoadClasses()
        {
            // 加载增加栏班级下拉列表
            T_ClassesBLL t_ClassesBLL = new T_ClassesBLL();
            List<T_ClassesModel> list = t_ClassesBLL.GetAllClasses();
            cboClass.DisplayMember = "Name";    // 这里要和Model中的属性一致, 而不是字段, 因为这里是通过反射实现的;
            cboClass.ValueMember = "Id";
            cboClass.DataSource = list;
            // 加载编辑栏班级下拉列表
            cboEditClass.DisplayMember = "Name";
            cboEditClass.ValueMember = "Id";
            cboEditClass.DataSource = list.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. 采集数据
            T_StudentsModel student = new T_StudentsModel();
            student.Name = txtName.Text.Trim();
            student.Age = int.Parse(txtAge.Text.Trim());
            student.Gender = cboGender.Text;    // 获取的是可编辑部分的值(如果是在界面上绑定的值)
            student.Birthday = dateTimePicker1.Value;
            T_ClassesModel classModel = new T_ClassesModel();
            classModel.Id = int.Parse(cboClass.SelectedValue.ToString());
            classModel.Name = cboClass.SelectedText;
            student.t_ClassModel = classModel;
            // 2. 处理数据
            T_StudentsBLL studentBll = new T_StudentsBLL();
            studentBll.InsertStudent(student);
            MessageBox.Show("增加成功!");
            // 3. 更新显示
            T_StudentsBLL bll = new T_StudentsBLL();
            dataGridView1.DataSource = bll.GetAllStudents();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value != null && e.Value is T_ClassesModel)
            {
                e.Value = ((T_ClassesModel)e.Value).Name;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // 获取选中数据
            T_StudentsModel student = dataGridView1.Rows[e.RowIndex].DataBoundItem as T_StudentsModel;
            
            // 展现在编辑栏
            txtEditName.Text = student.Name;
            txtEditAge.Text = student.Age.ToString();
            cboEditGender.Text = student.Gender;
            cboEditClass.Text = student.t_ClassModel.Name;
            dateTimePicker2.Text = student.Birthday.ToString();
            lbId.Text = student.Id.ToString();
        }
    }
}

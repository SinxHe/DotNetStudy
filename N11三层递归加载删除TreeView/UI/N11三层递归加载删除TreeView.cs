using N11三层递归加载删除TreeView.BLL;
using N11三层递归加载删除TreeView.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N11三层递归加载删除TreeView
{
    public partial class N11三层递归加载删除TreeView : Form
    {
        public N11三层递归加载删除TreeView()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAreaToTree(0, treeView1.Nodes);
        }

        private void LoadAreaToTree(int pid, TreeNodeCollection tnc)
        {
            T_AreaFullBLL bll = new T_AreaFullBLL();
            // 查询数据
            List<T_AreaFullModel> list = bll.GetAreaByPid(pid);
            // 数据加载
            foreach (T_AreaFullModel model in list)
            {
                TreeNode tnode = tnc.Add(model.AreaName);
                tnode.Tag = model.AreaId;
                LoadAreaToTree(model.AreaId, tnode.Nodes);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // 1.   判断用户有没有选中
            if (this.treeView1.SelectedNode != null)
            {
                int areaId = (int)treeView1.SelectedNode.Tag;
                // 2.   调用业务逻辑层实现删除
                //      1.  数据库删除
                T_AreaFullBLL bll = new T_AreaFullBLL();
                bll.DeleteArea(areaId); 
                //      2.  从界面删除
                treeView1.SelectedNode.Remove();
            }
            else
            {
                MessageBox.Show("请先选中节点!");
            }
        }
    }
}

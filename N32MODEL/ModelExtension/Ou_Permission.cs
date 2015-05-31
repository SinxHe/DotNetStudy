using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N32MODEL.EasyUiModel;

namespace N32MODEL
{
    public partial class Ou_Permission
    {
        #region 1.0 生成 很纯洁的 实体对象 - Ou_Permission ToPoco()
        /// <summary>
        /// 生成 很纯洁的 实体对象
        /// </summary>
        /// <returns></returns>
        public Ou_Permission ToPoco()
        {
            Ou_Permission poco = new Ou_Permission()
            {
                pid = this.pid,
                pParent = this.pParent,
                pName = this.pName,
                pAreaName = this.pAreaName,
                pControllerName = this.pControllerName,
                pActionName = this.pActionName,
                pFormMethod = this.pFormMethod,
                pOperationType = this.pOperationType,
                pIco = this.pIco,
                pOrder = this.pOrder,
                pIsLink = this.pIsLink,
                pLinkUrl = this.pLinkUrl,
                pIsShow = this.pIsShow,
                pRemark = this.pRemark,
                pIsDel = this.pIsDel,
                pAddTime = this.pAddTime
            };
            return poco;
        }
        #endregion

        #region 2.0 将权限集合 转成 树节点集合
        #region 1. 转换
        public static List<TreeNode> ToTreeNodes(List<Ou_Permission> listPer)
        {
            List<TreeNode> listNodes = new List<TreeNode>();
            //生成 树节点时，根据 pid=0的根节点 来生成
            LoadTreeNode(listPer, listNodes, 0);
            return listNodes;
        } 
        #endregion
        #region 2. 递归生成树节点集合
        public static void LoadTreeNode(List<Ou_Permission> listPer, List<TreeNode> listNodes, int pid)
        {
            foreach (var permission in listPer)
            {
                // 如果权限的父Id 和参数一样
                if (permission.pParent == pid)
                {
                    //将 权限转成 树节点
                    TreeNode node = permission.ToNode();
                    // 将节点加入到 树节点集合
                    listNodes.Add(node);
                    // 递归 为这个新创建的树节点找 子节点 
                    LoadTreeNode(listPer, node.children, node.id);
                }
            }
        } 
        #endregion
        #region 3. 将当前权限对象转成树节点对象 - TreeNode ToNode()
        /// <summary>
        /// 将当前权限对象转成树节点对象
        /// </summary>
        /// <returns></returns>
        public TreeNode ToNode()
        {
            TreeNode node = new TreeNode()
            {
                id = this.pid,
                text = this.pName,
                state = "open",
                Checked = false,
                attributes = new { Url = this.GetUrl() },
                children = new List<TreeNode>()
            };
            return node;
        }
        #endregion
        #region 4. 将当前权限的 区域名+控制器名+Action方法名 合并成一个字符串
        /// <summary>
        /// 将当前权限的 区域名+控制器名+Action方法名 合并成一个字符串
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            return GetUrlPart(this.pAreaName) + "/" + GetUrlPart(this.pControllerName) + GetUrlPart(pActionName);
        }

        protected string GetUrlPart(string urlPart)
        {
            return string.IsNullOrEmpty(urlPart) ? "" : "/" + urlPart;
        }
        #endregion
        #endregion

        #region 3.0 生成 ViewModel - oViewModel()
        /// <summary>
        /// 生成 ViewModel
        /// </summary>
        /// <returns></returns>
        public ViewModel.Permission ToViewModel()
        {
            ViewModel.Permission viewModel = new ViewModel.Permission()
            {
                pid = this.pid,
                pParent = this.pParent,
                pName = this.pName,
                pAreaName = this.pAreaName,
                pControllerName = this.pControllerName,
                pActionName = this.pActionName,
                pFormMethod = this.pFormMethod,
                pOperationType = this.pOperationType,
                pOrder = this.pOrder,
                pIsShow = this.pIsShow,
                pRemark = this.pRemark,
            };
            return viewModel;
        }
        #endregion
    }
}

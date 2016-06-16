
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N32IBLL;

namespace N32BLLA
{
	public partial class BllSession : IBllSession
    {
		#region  01. 业务接口 IBill_LeaveBll
		IBill_LeaveBll iBill_LeaveBll;
		public IBill_LeaveBll IBill_LeaveBll
		{ 
			get
			{
				if (iBill_LeaveBll == null)
					iBill_LeaveBll = new Bill_LeaveBll();
				return iBill_LeaveBll;
			}
			set
			{
				iBill_LeaveBll = value;
			}
		}
		#endregion

		#region  02. 业务接口 IOu_DepartmentBll
		IOu_DepartmentBll iOu_DepartmentBll;
		public IOu_DepartmentBll IOu_DepartmentBll
		{ 
			get
			{
				if (iOu_DepartmentBll == null)
					iOu_DepartmentBll = new Ou_DepartmentBll();
				return iOu_DepartmentBll;
			}
			set
			{
				iOu_DepartmentBll = value;
			}
		}
		#endregion

		#region  03. 业务接口 IOu_PermissionBll
		IOu_PermissionBll iOu_PermissionBll;
		public IOu_PermissionBll IOu_PermissionBll
		{ 
			get
			{
				if (iOu_PermissionBll == null)
					iOu_PermissionBll = new Ou_PermissionBll();
				return iOu_PermissionBll;
			}
			set
			{
				iOu_PermissionBll = value;
			}
		}
		#endregion

		#region  04. 业务接口 IOu_RoleBll
		IOu_RoleBll iOu_RoleBll;
		public IOu_RoleBll IOu_RoleBll
		{ 
			get
			{
				if (iOu_RoleBll == null)
					iOu_RoleBll = new Ou_RoleBll();
				return iOu_RoleBll;
			}
			set
			{
				iOu_RoleBll = value;
			}
		}
		#endregion

		#region  05. 业务接口 IOu_RolePermissionBll
		IOu_RolePermissionBll iOu_RolePermissionBll;
		public IOu_RolePermissionBll IOu_RolePermissionBll
		{ 
			get
			{
				if (iOu_RolePermissionBll == null)
					iOu_RolePermissionBll = new Ou_RolePermissionBll();
				return iOu_RolePermissionBll;
			}
			set
			{
				iOu_RolePermissionBll = value;
			}
		}
		#endregion

		#region  06. 业务接口 IOu_UserInfoBll
		IOu_UserInfoBll iOu_UserInfoBll;
		public IOu_UserInfoBll IOu_UserInfoBll
		{ 
			get
			{
				if (iOu_UserInfoBll == null)
					iOu_UserInfoBll = new Ou_UserInfoBll();
				return iOu_UserInfoBll;
			}
			set
			{
				iOu_UserInfoBll = value;
			}
		}
		#endregion

		#region  07. 业务接口 IOu_UserRoleBll
		IOu_UserRoleBll iOu_UserRoleBll;
		public IOu_UserRoleBll IOu_UserRoleBll
		{ 
			get
			{
				if (iOu_UserRoleBll == null)
					iOu_UserRoleBll = new Ou_UserRoleBll();
				return iOu_UserRoleBll;
			}
			set
			{
				iOu_UserRoleBll = value;
			}
		}
		#endregion

		#region  08. 业务接口 IOu_UserVipPermissionBll
		IOu_UserVipPermissionBll iOu_UserVipPermissionBll;
		public IOu_UserVipPermissionBll IOu_UserVipPermissionBll
		{ 
			get
			{
				if (iOu_UserVipPermissionBll == null)
					iOu_UserVipPermissionBll = new Ou_UserVipPermissionBll();
				return iOu_UserVipPermissionBll;
			}
			set
			{
				iOu_UserVipPermissionBll = value;
			}
		}
		#endregion

		#region  09. 业务接口 IWF_AutoTransactNodeBll
		IWF_AutoTransactNodeBll iWF_AutoTransactNodeBll;
		public IWF_AutoTransactNodeBll IWF_AutoTransactNodeBll
		{ 
			get
			{
				if (iWF_AutoTransactNodeBll == null)
					iWF_AutoTransactNodeBll = new WF_AutoTransactNodeBll();
				return iWF_AutoTransactNodeBll;
			}
			set
			{
				iWF_AutoTransactNodeBll = value;
			}
		}
		#endregion

		#region  10. 业务接口 IWF_BillFlowNodeBll
		IWF_BillFlowNodeBll iWF_BillFlowNodeBll;
		public IWF_BillFlowNodeBll IWF_BillFlowNodeBll
		{ 
			get
			{
				if (iWF_BillFlowNodeBll == null)
					iWF_BillFlowNodeBll = new WF_BillFlowNodeBll();
				return iWF_BillFlowNodeBll;
			}
			set
			{
				iWF_BillFlowNodeBll = value;
			}
		}
		#endregion

		#region  11. 业务接口 IWF_BillFlowNodeRemarkBll
		IWF_BillFlowNodeRemarkBll iWF_BillFlowNodeRemarkBll;
		public IWF_BillFlowNodeRemarkBll IWF_BillFlowNodeRemarkBll
		{ 
			get
			{
				if (iWF_BillFlowNodeRemarkBll == null)
					iWF_BillFlowNodeRemarkBll = new WF_BillFlowNodeRemarkBll();
				return iWF_BillFlowNodeRemarkBll;
			}
			set
			{
				iWF_BillFlowNodeRemarkBll = value;
			}
		}
		#endregion

		#region  12. 业务接口 IWF_BillStateBll
		IWF_BillStateBll iWF_BillStateBll;
		public IWF_BillStateBll IWF_BillStateBll
		{ 
			get
			{
				if (iWF_BillStateBll == null)
					iWF_BillStateBll = new WF_BillStateBll();
				return iWF_BillStateBll;
			}
			set
			{
				iWF_BillStateBll = value;
			}
		}
		#endregion

		#region  13. 业务接口 IWF_NodeBll
		IWF_NodeBll iWF_NodeBll;
		public IWF_NodeBll IWF_NodeBll
		{ 
			get
			{
				if (iWF_NodeBll == null)
					iWF_NodeBll = new WF_NodeBll();
				return iWF_NodeBll;
			}
			set
			{
				iWF_NodeBll = value;
			}
		}
		#endregion

		#region  14. 业务接口 IWF_NodeStateBll
		IWF_NodeStateBll iWF_NodeStateBll;
		public IWF_NodeStateBll IWF_NodeStateBll
		{ 
			get
			{
				if (iWF_NodeStateBll == null)
					iWF_NodeStateBll = new WF_NodeStateBll();
				return iWF_NodeStateBll;
			}
			set
			{
				iWF_NodeStateBll = value;
			}
		}
		#endregion

		#region  15. 业务接口 IWF_WorkFlowBll
		IWF_WorkFlowBll iWF_WorkFlowBll;
		public IWF_WorkFlowBll IWF_WorkFlowBll
		{ 
			get
			{
				if (iWF_WorkFlowBll == null)
					iWF_WorkFlowBll = new WF_WorkFlowBll();
				return iWF_WorkFlowBll;
			}
			set
			{
				iWF_WorkFlowBll = value;
			}
		}
		#endregion

		#region  16. 业务接口 IWF_WorkFlowNodeBll
		IWF_WorkFlowNodeBll iWF_WorkFlowNodeBll;
		public IWF_WorkFlowNodeBll IWF_WorkFlowNodeBll
		{ 
			get
			{
				if (iWF_WorkFlowNodeBll == null)
					iWF_WorkFlowNodeBll = new WF_WorkFlowNodeBll();
				return iWF_WorkFlowNodeBll;
			}
			set
			{
				iWF_WorkFlowNodeBll = value;
			}
		}
		#endregion

		   
    }
}
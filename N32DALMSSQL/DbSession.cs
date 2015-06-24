
using N32IDAL;

namespace N32DALMSSQL
{
	public partial class DbSession : IDbSession
    {
		#region  01. 数据接口 IBill_LeaveDal
		IBill_LeaveDal iBill_LeaveDal;
		public IBill_LeaveDal IBill_LeaveDal
		{ 
			get
			{
				if (iBill_LeaveDal == null)
					iBill_LeaveDal = new Bill_LeaveDal();
				return iBill_LeaveDal;
			}
			set
			{
				iBill_LeaveDal = value;
			}
		}
		#endregion

		#region  02. 数据接口 IOu_DepartmentDal
		IOu_DepartmentDal iOu_DepartmentDal;
		public IOu_DepartmentDal IOu_DepartmentDal
		{ 
			get
			{
				if (iOu_DepartmentDal == null)
					iOu_DepartmentDal = new Ou_DepartmentDal();
				return iOu_DepartmentDal;
			}
			set
			{
				iOu_DepartmentDal = value;
			}
		}
		#endregion

		#region  03. 数据接口 IOu_PermissionDal
		IOu_PermissionDal iOu_PermissionDal;
		public IOu_PermissionDal IOu_PermissionDal
		{ 
			get
			{
				if (iOu_PermissionDal == null)
					iOu_PermissionDal = new Ou_PermissionDal();
				return iOu_PermissionDal;
			}
			set
			{
				iOu_PermissionDal = value;
			}
		}
		#endregion

		#region  04. 数据接口 IOu_RoleDal
		IOu_RoleDal iOu_RoleDal;
		public IOu_RoleDal IOu_RoleDal
		{ 
			get
			{
				if (iOu_RoleDal == null)
					iOu_RoleDal = new Ou_RoleDal();
				return iOu_RoleDal;
			}
			set
			{
				iOu_RoleDal = value;
			}
		}
		#endregion

		#region  05. 数据接口 IOu_RolePermissionDal
		IOu_RolePermissionDal iOu_RolePermissionDal;
		public IOu_RolePermissionDal IOu_RolePermissionDal
		{ 
			get
			{
				if (iOu_RolePermissionDal == null)
					iOu_RolePermissionDal = new Ou_RolePermissionDal();
				return iOu_RolePermissionDal;
			}
			set
			{
				iOu_RolePermissionDal = value;
			}
		}
		#endregion

		#region  06. 数据接口 IOu_UserInfoDal
		IOu_UserInfoDal iOu_UserInfoDal;
		public IOu_UserInfoDal IOu_UserInfoDal
		{ 
			get
			{
				if (iOu_UserInfoDal == null)
					iOu_UserInfoDal = new Ou_UserInfoDal();
				return iOu_UserInfoDal;
			}
			set
			{
				iOu_UserInfoDal = value;
			}
		}
		#endregion

		#region  07. 数据接口 IOu_UserRoleDal
		IOu_UserRoleDal iOu_UserRoleDal;
		public IOu_UserRoleDal IOu_UserRoleDal
		{ 
			get
			{
				if (iOu_UserRoleDal == null)
					iOu_UserRoleDal = new Ou_UserRoleDal();
				return iOu_UserRoleDal;
			}
			set
			{
				iOu_UserRoleDal = value;
			}
		}
		#endregion

		#region  08. 数据接口 IOu_UserVipPermissionDal
		IOu_UserVipPermissionDal iOu_UserVipPermissionDal;
		public IOu_UserVipPermissionDal IOu_UserVipPermissionDal
		{ 
			get
			{
				if (iOu_UserVipPermissionDal == null)
					iOu_UserVipPermissionDal = new Ou_UserVipPermissionDal();
				return iOu_UserVipPermissionDal;
			}
			set
			{
				iOu_UserVipPermissionDal = value;
			}
		}
		#endregion

		#region  09. 数据接口 IWF_AutoTransactNodeDal
		IWF_AutoTransactNodeDal iWF_AutoTransactNodeDal;
		public IWF_AutoTransactNodeDal IWF_AutoTransactNodeDal
		{ 
			get
			{
				if (iWF_AutoTransactNodeDal == null)
					iWF_AutoTransactNodeDal = new WF_AutoTransactNodeDal();
				return iWF_AutoTransactNodeDal;
			}
			set
			{
				iWF_AutoTransactNodeDal = value;
			}
		}
		#endregion

		#region  10. 数据接口 IWF_BillFlowNodeDal
		IWF_BillFlowNodeDal iWF_BillFlowNodeDal;
		public IWF_BillFlowNodeDal IWF_BillFlowNodeDal
		{ 
			get
			{
				if (iWF_BillFlowNodeDal == null)
					iWF_BillFlowNodeDal = new WF_BillFlowNodeDal();
				return iWF_BillFlowNodeDal;
			}
			set
			{
				iWF_BillFlowNodeDal = value;
			}
		}
		#endregion

		#region  11. 数据接口 IWF_BillFlowNodeRemarkDal
		IWF_BillFlowNodeRemarkDal iWF_BillFlowNodeRemarkDal;
		public IWF_BillFlowNodeRemarkDal IWF_BillFlowNodeRemarkDal
		{ 
			get
			{
				if (iWF_BillFlowNodeRemarkDal == null)
					iWF_BillFlowNodeRemarkDal = new WF_BillFlowNodeRemarkDal();
				return iWF_BillFlowNodeRemarkDal;
			}
			set
			{
				iWF_BillFlowNodeRemarkDal = value;
			}
		}
		#endregion

		#region  12. 数据接口 IWF_BillStateDal
		IWF_BillStateDal iWF_BillStateDal;
		public IWF_BillStateDal IWF_BillStateDal
		{ 
			get
			{
				if (iWF_BillStateDal == null)
					iWF_BillStateDal = new WF_BillStateDal();
				return iWF_BillStateDal;
			}
			set
			{
				iWF_BillStateDal = value;
			}
		}
		#endregion

		#region  13. 数据接口 IWF_NodeDal
		IWF_NodeDal iWF_NodeDal;
		public IWF_NodeDal IWF_NodeDal
		{ 
			get
			{
				if (iWF_NodeDal == null)
					iWF_NodeDal = new WF_NodeDal();
				return iWF_NodeDal;
			}
			set
			{
				iWF_NodeDal = value;
			}
		}
		#endregion

		#region  14. 数据接口 IWF_NodeStateDal
		IWF_NodeStateDal iWF_NodeStateDal;
		public IWF_NodeStateDal IWF_NodeStateDal
		{ 
			get
			{
				if (iWF_NodeStateDal == null)
					iWF_NodeStateDal = new WF_NodeStateDal();
				return iWF_NodeStateDal;
			}
			set
			{
				iWF_NodeStateDal = value;
			}
		}
		#endregion

		#region  15. 数据接口 IWF_WorkFlowDal
		IWF_WorkFlowDal iWF_WorkFlowDal;
		public IWF_WorkFlowDal IWF_WorkFlowDal
		{ 
			get
			{
				if (iWF_WorkFlowDal == null)
					iWF_WorkFlowDal = new WF_WorkFlowDal();
				return iWF_WorkFlowDal;
			}
			set
			{
				iWF_WorkFlowDal = value;
			}
		}
		#endregion

		#region  16. 数据接口 IWF_WorkFlowNodeDal
		IWF_WorkFlowNodeDal iWF_WorkFlowNodeDal;
		public IWF_WorkFlowNodeDal IWF_WorkFlowNodeDal
		{ 
			get
			{
				if (iWF_WorkFlowNodeDal == null)
					iWF_WorkFlowNodeDal = new WF_WorkFlowNodeDal();
				return iWF_WorkFlowNodeDal;
			}
			set
			{
				iWF_WorkFlowNodeDal = value;
			}
		}
		#endregion

		   
    }
}
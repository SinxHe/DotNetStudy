
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N32MODEL;

namespace N32IBLL
{

	public partial interface IBllSession
    { 
		IBill_LeaveBll IBill_LeaveBll{ get; set; }
		 
		IOu_DepartmentBll IOu_DepartmentBll{ get; set; }
		 
		IOu_PermissionBll IOu_PermissionBll{ get; set; }
		 
		IOu_RoleBll IOu_RoleBll{ get; set; }
		 
		IOu_RolePermissionBll IOu_RolePermissionBll{ get; set; }
		 
		IOu_UserInfoBll IOu_UserInfoBll{ get; set; }
		 
		IOu_UserRoleBll IOu_UserRoleBll{ get; set; }
		 
		IOu_UserVipPermissionBll IOu_UserVipPermissionBll{ get; set; }
		 
		IWF_AutoTransactNodeBll IWF_AutoTransactNodeBll{ get; set; }
		 
		IWF_BillFlowNodeBll IWF_BillFlowNodeBll{ get; set; }
		 
		IWF_BillFlowNodeRemarkBll IWF_BillFlowNodeRemarkBll{ get; set; }
		 
		IWF_BillStateBll IWF_BillStateBll{ get; set; }
		 
		IWF_NodeBll IWF_NodeBll{ get; set; }
		 
		IWF_NodeStateBll IWF_NodeStateBll{ get; set; }
		 
		IWF_WorkFlowBll IWF_WorkFlowBll{ get; set; }
		 
		IWF_WorkFlowNodeBll IWF_WorkFlowNodeBll{ get; set; }
		   
    }
}
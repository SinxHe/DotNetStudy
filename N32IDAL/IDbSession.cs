
namespace N32IDAL
{

	public partial interface IDbSession
    { 
		IBill_LeaveDal IBill_LeaveDal{ get; set; }
		 
		IOu_DepartmentDal IOu_DepartmentDal{ get; set; }
		 
		IOu_PermissionDal IOu_PermissionDal{ get; set; }
		 
		IOu_RoleDal IOu_RoleDal{ get; set; }
		 
		IOu_RolePermissionDal IOu_RolePermissionDal{ get; set; }
		 
		IOu_UserInfoDal IOu_UserInfoDal{ get; set; }
		 
		IOu_UserRoleDal IOu_UserRoleDal{ get; set; }
		 
		IOu_UserVipPermissionDal IOu_UserVipPermissionDal{ get; set; }
		 
		IWF_AutoTransactNodeDal IWF_AutoTransactNodeDal{ get; set; }
		 
		IWF_BillFlowNodeDal IWF_BillFlowNodeDal{ get; set; }
		 
		IWF_BillFlowNodeRemarkDal IWF_BillFlowNodeRemarkDal{ get; set; }
		 
		IWF_BillStateDal IWF_BillStateDal{ get; set; }
		 
		IWF_NodeDal IWF_NodeDal{ get; set; }
		 
		IWF_NodeStateDal IWF_NodeStateDal{ get; set; }
		 
		IWF_WorkFlowDal IWF_WorkFlowDal{ get; set; }
		 
		IWF_WorkFlowNodeDal IWF_WorkFlowNodeDal{ get; set; }
		   
    }
}
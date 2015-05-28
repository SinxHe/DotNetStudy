 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N32BLLA;
using N32IBLL;
using N32MODEL;

namespace N32BLLA
{
	public partial class Bill_LeaveBll : BaseBll<Bill_Leave>,IBill_LeaveBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IBill_LeaveDal;
		}
    }
	public partial class Ou_DepartmentBll : BaseBll<Ou_Department>,IOu_DepartmentBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IOu_DepartmentDal;
		}
    }
	public partial class Ou_PermissionBll : BaseBll<Ou_Permission>,IOu_PermissionBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IOu_PermissionDal;
		}
    }
	public partial class Ou_RoleBll : BaseBll<Ou_Role>,IOu_RoleBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IOu_RoleDal;
		}
    }
	public partial class Ou_RolePermissionBll : BaseBll<Ou_RolePermission>,IOu_RolePermissionBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IOu_RolePermissionDal;
		}
    }
	public partial class Ou_UserInfoBll : BaseBll<Ou_UserInfo>,IOu_UserInfoBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IOu_UserInfoDal;
		}
    }
	public partial class Ou_UserRoleBll : BaseBll<Ou_UserRole>,IOu_UserRoleBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IOu_UserRoleDal;
		}
    }
	public partial class Ou_UserVipPermissionBll : BaseBll<Ou_UserVipPermission>,IOu_UserVipPermissionBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IOu_UserVipPermissionDal;
		}
    }
	public partial class WF_AutoTransactNodeBll : BaseBll<WF_AutoTransactNode>,IWF_AutoTransactNodeBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IWF_AutoTransactNodeDal;
		}
    }
	public partial class WF_BillFlowNodeBll : BaseBll<WF_BillFlowNode>,IWF_BillFlowNodeBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IWF_BillFlowNodeDal;
		}
    }
	public partial class WF_BillFlowNodeRemarkBll : BaseBll<WF_BillFlowNodeRemark>,IWF_BillFlowNodeRemarkBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IWF_BillFlowNodeRemarkDal;
		}
    }
	public partial class WF_BillStateBll : BaseBll<WF_BillState>,IWF_BillStateBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IWF_BillStateDal;
		}
    }
	public partial class WF_NodeBll : BaseBll<WF_Node>,IWF_NodeBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IWF_NodeDal;
		}
    }
	public partial class WF_NodeStateBll : BaseBll<WF_NodeState>,IWF_NodeStateBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IWF_NodeStateDal;
		}
    }
	public partial class WF_WorkFlowBll : BaseBll<WF_WorkFlow>,IWF_WorkFlowBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IWF_WorkFlowDal;
		}
    }
	public partial class WF_WorkFlowNodeBll : BaseBll<WF_WorkFlowNode>,IWF_WorkFlowNodeBll
    {
		public override void SetDal()
		{
			iDal = DbSession.IWF_WorkFlowNodeDal;
		}
    }
}
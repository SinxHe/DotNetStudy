using N11三层递归加载删除TreeView.DAL;
using N11三层递归加载删除TreeView.Model;
// 2015-4-4 09:22:10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N11三层递归加载删除TreeView.BLL
{
    class T_AreaFullBLL
    {
        T_AreaFullDAL areaFullDal = new T_AreaFullDAL();

        /// <summary>
        /// 建立UI层跟DAL层联系的酱油方法
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<T_AreaFullModel> GetAreaByPid(int pid)
        {
            return areaFullDal.GetAreaByPid(pid);
        }

        public void DeleteArea(int areaId)
        {
            T_AreaFullDAL dal = new T_AreaFullDAL();
            //1.	根据AreaId得到一个Area
            //2.	查询他的所有子节点
            List<T_AreaFullModel> list = dal.GetAreaByPid(areaId);
            foreach (T_AreaFullModel model in list)
            {
                DeleteArea(model.AreaId);
            }
            //3.	从最有一个子节点的下一个递归开始, 依次删除父节点
            dal.DeleteAreaByAreaId(areaId); // 第一次执行的时候是进入了最后一个节点的搜寻, 搜寻到没子节点了, 删除没有的子节点的父节点(即最后一个节点);
        }
    }
}

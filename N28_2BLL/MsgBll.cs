using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N28_3DAL;
using N28_4MODEL;

namespace N28_2BLL
{
    public class MsgBll:BaseBll<Msg>
    {
        MsgDal _dalMsg = null;
        public void TestForBaseMuban()
        {
            // 这里在数据层写了一个方法, 
            // 要想要业务层的MsgBll访问到, 
            // 但是MsgBll是继承自BaseBll中的数据层实体
            _dalMsg.TestForBaseMuban();
        }

        /// <summary>
        /// 重写父类的方法完成指定 哪个实体的数据访问层
        /// </summary>
        public override void SetDal()
        {
            Dal = new MsgDal();
            _dalMsg = (MsgDal)Dal;
        }
    }
}

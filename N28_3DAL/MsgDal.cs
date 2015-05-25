using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N28_4MODEL;

namespace N28_3DAL
{
    public class MsgDal:BaseDal<Msg>
    {
        public void TestForBaseMuban()
        {
            // 这里在数据层写了一个方法, 要想要业务层的MsgBll访问到, 但是MsgBll是继承自BaseBll中的数据层实体
        }
    }
}

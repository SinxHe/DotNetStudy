using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N28_4MODEL;

namespace N28_3DAL
{
    public class UserDal:BaseDal<User>
    {
        public int GetNum()
        {
            return 3;
        }
    }
}

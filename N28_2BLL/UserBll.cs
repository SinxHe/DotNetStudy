using N28_3DAL;
using N28_4MODEL;

namespace N28_2BLL
{
    public class UserBll:BaseBll<User>
    {
        UserDal _dalUser;
        public override void SetDal()
        {
            // 实例化父类 数据操作对象
            Dal = new UserDal();
            _dalUser = (UserDal)Dal;
        }

        public int GetNum()
        {
            return _dalUser.GetNum();
        }
    }
}

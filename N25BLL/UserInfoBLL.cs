using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using N25IDAL;
using N25Model;
using N25DalFactory;

namespace N25BLL
{
    public class UserInfoBll
    {
        private readonly IUserInfoDal _userInfoDal = DalFactory.GetUserInfoDal();

        #region 增

        public bool Add(UserInfo userInfo)
        {
            return _userInfoDal.Add(userInfo) > 0;
        }

        #endregion
        #region 删
        
        #endregion
        #region 改

        public bool Edit(UserInfo userInfo)
        {
            return _userInfoDal.Edit(userInfo) > 0;
        }

        #endregion
        #region 查

        public UserInfo GetById(int id)
        {
            return _userInfoDal.GetById(id);
        }

        public IQueryable<UserInfo> GetList(Expression<Func<UserInfo, bool>> whereLambda)
        {
            return _userInfoDal.GetList(whereLambda);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using N25DAL;
using N25IDAL;

namespace N25DalFactory
{
    public partial class DalFactory
    {
        // 简单工厂
        public static IUserInfoDal GetUserInfoDal1()
        {
            return new UserInfoDal();
        }

        // 抽象工厂
        public static IUserInfoDal GetUserInfoDal()
        {
            // 从配置文件中读取类的名字和程序集的名字
            string s1 = System.Configuration.ConfigurationManager.AppSettings["UserInfoDal"];
            // 程序集的名字
            string assemblyStr = s1.Split(',')[0];
            // 类的名字(包含命名空间, 程序集的名字和命名空间可能不一样)
            string className = s1.Split(',')[1];

            // 获取程序集对象
            Assembly a1 = Assembly.Load(assemblyStr);    // 你要得到的类所在的程序集
            // 创建对象实例 
            return a1.CreateInstance(className) as IUserInfoDal;  // 创建a1程序集中的某个对象
        }
    }
}

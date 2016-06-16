using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N24EntityFramework
{
    class N02Poco
    {
        public static void Main()
        {
            POCO关系Container context = new POCO关系Container();

            // 添加关联以后, 会自动把Order中的数据加载出来
            var user = context.UserSet.Where(u=>u.Id == 2).FirstOrDefault();

            Console.WriteLine(user.Name);
        }
    }
}

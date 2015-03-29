using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace N01控制台
{
    class N01正则表达式
    {
        public static void Main()
        {
            #region 邮箱验证
            while (true)
            {
                Console.WriteLine("输入邮箱:");
                string email = Console.ReadLine();
                //bool b = Regex.IsMatch(email, @"^[-_a-zA-Z0-9]+@[-_a-zA-Z0-9]+(\.[-_a-zA-Z0-9]+)+$");
                bool b = Regex.IsMatch(email, @"^\w+@\w+(\.\w+)+$", RegexOptions.ECMAScript);   // 这个不支持-
                if (b)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
            #endregion
        }
    }
}

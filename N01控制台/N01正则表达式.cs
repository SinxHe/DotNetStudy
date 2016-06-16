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
            //while (true)
            //{
            //    Console.WriteLine("输入邮箱:");
            //    string email = Console.ReadLine();
            //    //bool b = Regex.IsMatch(email, @"^[-_a-zA-Z0-9]+@[-_a-zA-Z0-9]+(\.[-_a-zA-Z0-9]+)+$");
            //    bool b = Regex.IsMatch(email, @"^\w+@\w+(\.\w+)+$", RegexOptions.ECMAScript);   // 这个不支持-
            //    if (b)
            //    {
            //        Console.WriteLine("true");
            //    }
            //    else
            //    {
            //        Console.WriteLine("false");
            //    }
            //}
            #endregion
            
            string s = "aaaa(bbb)aaaaaaaaa(bb)aaaaaa";
            string pattern = @"\(\w+\)";
            Match result = Regex.Match(s, pattern);
            MatchCollection results = Regex.Matches(s, pattern);
            Console.WriteLine(result.Value);
            Console.WriteLine(results[0].Value);
            Console.WriteLine(results[1].Value);

            string str = @"<?xml version='1.0' encoding='utf-8'?><root><res><id>6</id><name>田氏快餐</name><tel>13513227441</tel><click>0</click></res><res><id>7</id><name>咱家凉皮</name><tel>15603253000</tel><click>0</click></res><res><id>8</id><name>阳阳饺子</name><tel>13463233363</tel><click>0</click></res></root><div ></div>";
            string pat = @"<\?xml.+\?>";    // 寻找<?xml='1.0' enconding='utf-8'?>
            string pat2 = @"<root>.+</root>";   // 寻找所有res数据
            Match head = Regex.Match(str,pat);
            Match resData = Regex.Match(str, pat2);
            Console.WriteLine(head.Index);
            Console.WriteLine(head.Value);
            Console.WriteLine(resData.Value);
        }
    }
}

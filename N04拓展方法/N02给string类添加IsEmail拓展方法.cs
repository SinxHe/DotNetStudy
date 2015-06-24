// 2015-3-29 14:13:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace N04拓展方法
{
    class N02给string类添加IsEmail拓展方法
    {
        public static void Main()
        {
            while (true)
            {
                string msg = Console.ReadLine(); 
                if (msg.IsEmail())
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }

    static partial class MethodExt
    {
        public static bool IsEmail(this string msg)
        {
            return Regex.IsMatch(msg, @"^\w+@\w+(\.\w+)+$");
        }
    }
}

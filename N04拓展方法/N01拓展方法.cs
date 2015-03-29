// 2015-3-29 14:01:21
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N04拓展方法
{
    class N01拓展方法
    {
        static void Mai(string[] args)
        {
            MyClass mc = new MyClass();
            mc.Name = "HeabKing";
            
            // 类中方法
            mc.SayHi();
            // 拓展方法(有一个向下的小箭头)
            mc.SayHello();
        }
    }

    class MyClass
    {
        public string Name { get; set; }
        public void SayHi()
        {
            Console.WriteLine("Hi, " + Name);
        }
    }

    /// <summary>
    /// 1.  增加一个静态类, 类名随便起;
    /// 2.  该静态类应该与使用拓展方法的地方在一个命名空间下, 否则必须导入该命名空间
    /// </summary>
    static partial class MethodExt
    {
        // 3.   向静态类中添加静态方法
        //      1.  第一个参数表示要给那个类型添加该拓展方法
        //      2.  
        public static void SayHello(this MyClass obj)
        {
            Console.WriteLine("Hello, " + obj.Name +", 我来自拓展方法!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N02匿名方法和lambda表达式
{
    class Program
    {
        private delegate void Delegate1();  // 这里看似声明了一个委托类型, 实际上是声明了一个Delegate类
        private delegate int Delegate2(int n);
        delegate void Delegate3(params int[] a);

        static void Main(string[] args)
        {
            // 无参数, 无返回值的匿名方法

            // 1. 普通声明
            Delegate1 d1 = delegate() { Console.WriteLine("我是一个匿名方法!"); };
            // 1. 声明一个匿名方法
            // 2. 把声明的匿名方法传进Delegate类的构造函数中
            d1();    // 调用invoke()方法

            // 2. lambda声明
            Delegate1 d11 = () => { Console.WriteLine("我是一个lambda表示的匿名方法!"); };
            d11();


            // 有一个参数, 有一个返回值匿名方法

            Delegate2 d2 = delegate(int c)  // 这里的delegate前面不用加int, 因为d2已经声明为有int返回值的委托类型了
            {
                return c * 2;
            };
            Console.WriteLine(d2(10));

            Delegate2 d22 = x => 3 * x;//(x) => { return 2 * x; };
            // 1. 如果只有一个参数, 可以省略"()", 如果只有一条语句, 可以省略"{}"
            Console.WriteLine(d22(20));

            // 利用委托, 找出list中的数据

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            foreach (var item in list.Where(x => x > 5))
            {
                Console.WriteLine(item);
            }

            // 可变参数 实现匿名方法
            Delegate3 md3 = delegate(int[] arr) { Console.WriteLine(arr.Length); };
            md3(1, 2, 3);

            // 可变参数, 实现lambda
            Delegate3 md33 = arr => Console.WriteLine(arr.Length);
            md33(1, 2, 3, 4);
        }
    }
}

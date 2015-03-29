// 2015-3-29 13:22:16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N03自定义泛型
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass<int> mc = new MyClass<int>(new int[] {1, 2, 3, 4});
            mc.Show();
            Program p = new Program();
            p.Show(mc);
        }

        public void Show<T>(T param)
        {
            //param.Show();// TODO:难道不能直接这么用?
        }
    }

    /// <summary>
    /// 泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyClass<T>
    {
        T[] names;
        public MyClass(T[] names)
        {
            this.names = names;
        }

        public void Show()
        {
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}

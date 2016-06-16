using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N26新语法
{
    class Program
    {

        #region 已经会了
        #region 1. 自动属性
        // 1. 自动属性会自动生成一个私有字段
        // 2. get, set就是对这个字段的操作
        #endregion
        #region 2. var隐式类型变量
        //static void Main(string[] args)
        //{
        //    var a = 3;
        //    //a = ""; //无法将string转换为int, 说明a的类型在编译之前已经被推断出来了
        //    // 初始化的时候不能是匿名函数
        //}
        #endregion
        #region 3. 参数默认值
        // 1. 默认参数的默认值在调用的时候会被自动加上, 而不是C++那样进行多个函数的生成
        #endregion
        #region 4. 命名参数 ---- C++没有

        //public static void Main()
        //{
        //    Add();
        //    Add(1);
        //    Add(right:7);   // C# 中可以通过命名参数, 跳过第一个参数直接给第二个参数更改默认值
        //}

        //public static void Add(int left = 2, int right = 4)
        //{
        //    Console.WriteLine(left + right);
        //}

        #endregion
        #endregion
        #region 很重要
        #region (1) 匿名类
        // 1. 需求: (1)我需要一个类, 只用一次 (2) 临时封装一组数据
        // 2. 属性名字一样, 顺序一样 -- 同一个泛型类
        // 3. 属性名字一样, 属性顺序不一样 -- 不是同一个泛型类
        //private static void TestAnoyClass()
        //{
        //    var cla = new {Name = "Dog", Age = 9};
        //                // 编译器生成的类Name和Age为只读的
        //    var cla2 = new { Name = "cat", Age = 19 };
        //                // cal2和cal公用一个匿名类(属性的类型, 位置一样才会这样)
        //    var cla3 = new {Age = 19, Name = "cat"};
        //                // cla3不跟cla2不是同一个类型
        //    var cla4 = new {Name = 9, Age = "animal"};
        //                // cla4和cla2用的同一个泛型类 他们的属性名称, 顺序一样, 但是类型不一样

        //    Console.WriteLine(cla.Name + cla.Age);
        //    Console.WriteLine(cla.GetType());
        //    Console.WriteLine(cla2.GetType());
        //    Console.WriteLine(cla3.GetType());
        //    Console.WriteLine(cla4.GetType());
        //    Console.WriteLine(cla.GetType() == cla2.GetType());
        //}

        //public static void Main()
        //{
        //    TestAnoyClass();
        //}

        #endregion
        #region (2) 匿名方法
        // 1. 委托本质是一个类, 是方法指针的容器
        // 2. Java里面没有委托, 只能自己定义类, 然后把方法放到类里面实现函数之间的传d递
        // 3. 匿名方法其实是一个静态的委托对象
        // 4. 匿名方法编译后: 1. 生成一个编译器取名字的静态方法, 2. 一个静态的静态的委托对象, 保存着那个方法
        #endregion
        #region (3) 拓展方法

        //public static void Main()
        //{
        //    // 形式
        //    "123".Pee();
        //    // 实际
        //    StringExtension.Pee("456");
        //}

        #endregion
        
        #endregion
        #region 很重要 + 常用 + 很少接触
        #region 一 系统泛型委托 和 list中部分系统拓展方法(select...)
        #region Action -- 无返回值
        // Action
        private static void TestAction()
        {
            List<C01Dog> list = GetDogs();
            list.ForEach(new Action<C01Dog>(delegate(C01Dog d) { Console.WriteLine(d.Name); }));
            list.ForEach(delegate(C01Dog d) { Console.WriteLine(d.Age); }); // 匿名方法自动生成静态委托对象
            // 已经知道Action中的参数是C01Dog了还是声明一下 不爽 
            list.ForEach(d => Console.WriteLine(d.Name));
        }
        #endregion
        #region Predicate -- 返回bool

        /// <summary>
        /// 根据条件筛选出一个新集合
        /// </summary>
        public static void TestPredicate()
        {
            List<C01Dog> list = GetDogs();
            // 使用FindAll可以让我们 根据条件 筛选出一个新的集合
            list = list.FindAll(new Predicate<C01Dog>(delegate(C01Dog d) { return d.Age > 1; }));   // 对每个元素使用委托方法, 如果返回true, 则帅选出来放到新集合中
            list.ForEach(u => Console.WriteLine(u.Name));
        }



        #endregion
        #region Comparison -- 返回int 用来比较大小
        /// <summary>
        /// 排序
        /// </summary>
        private static void TestComparison()
        {
            List<C01Dog> list = GetDogs();
            list.Sort(delegate(C01Dog x, C01Dog y)
            {
                return x.Age - y.Age;
            });
            list.ForEach(delegate(C01Dog d)
            {
                Console.WriteLine(d.Name);
            });
        }

        #endregion
        #region Function -- 返回自定义的值 关于拓展方法不用制定类型 编译器自动的类型推断

        /// <summary>
        /// 得到一个集合, 只有狗的名字
        /// 对C01Dog集合进行遍历, 得到C02Dog集合
        /// </summary>
        private static void TestFunc()
        {
            List<C01Dog> list = GetDogs();
            // select 遍历集合 按照条件返回一个新的集合
            //IEnumerable<C02SmallDog> enu = list.Select(new Func<C01Dog, C02SmallDog>(delegate(C01Dog d) { return new C02SmallDog() {Name = d.Name}; }));  // 明确指定了TResult
            //IEnumerable<C02SmallDog> enu = list.Select(delegate(C01Dog d) { return new C02SmallDog() {Name = d.Name}; }); // 根据返回值自动推断除了TResult
            //List<C02SmallDog> list2 = list.MySelect<C01Dog, C02SmallDog>(delegate(C01Dog d)
            var list2 = list.MySelect(delegate(C01Dog d) // 我草, 这里也根据返回值类型进行了推断
            {
                return new C02SmallDog() { Name = d.Name };
            });
            list2.ForEach(delegate(C02SmallDog s) { Console.WriteLine(s.Name); });
            // 甚至能推断出一个匿名类对象 虽然不知道推断除了什么类型, 但是可以var啊
            var list3 = list.MySelect(delegate(C01Dog d)    // 显示推断出的类型为 'a
            {
                return new { Age = d.Age };
            });
            // 如果是lambda呢
            var list4 = list.MySelect(u => new { Age = u.Age });    // 甚至在lambda中都能推断
        }

        #endregion

        //public static void Main()
        //{
        //TestAction();
        //TestPredicate();
        //var v = GetDogs();
        //v.TestPredicate2(delegate(C01Dog d) { return d.Age == 2; });
        //v.ForEach(u => Console.WriteLine(u.Name));
        //TestComparison();
        //TestFunc();
        //}

        #endregion
        #region 二 lambda表达式
        
        // 1. lambda是比匿名方法更简洁的匿名方法
        //public static void Main()
        //{
        //    var list = GetDogs();
        //    //      -- lambda表达式 只有一个表达式
        //    // 1. ForEach   --  Action
        //    list.ForEach(d => Console.WriteLine(d.Name));
        //    // 2. FindAll   --  Predicate
        //    list.FindAll(d => d.Age > 1).ForEach(d => Console.WriteLine(d.Age));
        //    // 3. Sort      --  Comparison
        //    list.Sort((x, y) => x.Age - y.Age);
        //    list.ForEach(d => Console.WriteLine(d.Name));
        //    // 4. Select    --  Func
        //    list.Select(d => new{Age = d.Age}).ToList().ForEach(sd => Console.WriteLine(sd.Age));
        //    // 5. Lambda中有多个语句, 则大括号不能省, return不能省(另外有多个形参, 括号不能省)
        //    //      -- 语句lambda 有多个语句
        //    list.Select(d =>
        //    {
        //        var sd = new C02SmallDog();
        //        sd.Name = d.Name;
        //        return sd;
        //    }).ToList().ForEach(d => Console.WriteLine(d.Name));
        //}

        #endregion
        #endregion
        public static List<C01Dog> GetDogs()
        {
            return new List<C01Dog>()
            {new C01Dog() {Age = 2, Name = "Dog2"},
                new C01Dog() {Age = 1, Name = "Dog1"},
                
                new C01Dog() {Age = 3, Name = "Dog3"},
            };
        }
    }
    public static class StringExtension
    {
        /// <summary>
        /// 自己模拟的方法将一个类型的集合转换成另一个类型的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TR"></typeparam>
        /// <param name="list"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<TR> MySelect<T, TR>(this List<T> list, Func<T, TR> func)
        {
            List<TR> listNew = new List<TR>();
            // 遍历老集合
            foreach (T item in list)
            {
                // 调用 func 委托, 将老集合每一个元素转换成另一个元素 返回
                TR re = func(item);
                // 将转换后的新元素放入新集合
                listNew.Add(re);
            }
            return listNew;
        }

        public static void Pee(this string s)
        {
            Console.WriteLine(s + ", Pee......");
        }
        /// <summary>
        /// 根据条件删除集合中的元素
        /// </summary>
        public static void TestPredicate2<T>(this List<T> list, Predicate<T> deleteWhere)
        {
            List<T> deletedItem = new List<T>();
            foreach (T item in list)
            {
                if (deleteWhere(item))  // 找到要删除的元素
                {
                    deletedItem.Add(item);
                }
            }
            // 遍历删除
            foreach (T item in deletedItem)
            {
                list.Remove(item);
            }
        }
    }
}

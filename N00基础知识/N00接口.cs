// 2015-3-29 17:05:07
// 接口实现list.sort针对于用户定义的类型
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N00基础知识
{
    class N00接口
    {
        public static void Main()
        {
            List<Person> list = new List<Person>() 
            { 
                new Person { Age = 12 },
                new Person { Age = 13 },
                new Person { Age = 39 }
            };
            list.Sort();    // 实现接口
            foreach (var item in list)
            {
                Console.WriteLine(item.Age);
            }

            List<Person2> list2 = new List<Person2>() 
            { 
                new Person2 { Age = 12 },
                new Person2 { Age = 13 },
                new Person2 { Age = 39 }
            };
            list2.Sort(new SortPerson2());   // 指定比较器
            foreach (var item in list2)
            {
                Console.WriteLine(item.Age);
            }
        }
    }

    /// <summary>
    /// 用户定义的类型直接实现IComparable
    /// </summary>
    class Person : IComparable<Person>
    {
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            return other.Age - this.Age;
        }
    }

    /// <summary>
    /// 不用实现IComparable, 指定比较器
    /// </summary>
    class Person2
    {
        public int Age { get; set; }
    }

    /// <summary>
    /// Person2的比较器
    /// </summary>
    class SortPerson2 : IComparer<Person2>
    {
        public int Compare(Person2 p1, Person2 p2)
        {
            return p1.Age - p2.Age;
        }
    }
}


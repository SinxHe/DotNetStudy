using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N26新语法
{
    class N02SQO标准查询运算符
    {
        // 1. 为什么Sqo返回IEnumerable:
        //      1.  链式编程    --  返回本省类型, 所以Sqo放到一个类里面
        //      2.  返回IEnumerable 可以直接支持链式编程
        //public static void Main()
        //{
            //SqoWhere();
            //SqlSelect();
            //SqoOrder();
            //TestJoin();
            //TestGropBy();
        //}
        #region 1. Sqo  --  Where 查询方法 FindAll 立即查 Where 延迟查
        /// <summary>
        /// 拿到年轻的公狗
        /// </summary>
        /// <returns></returns>
        private static void SqoWhere()
        {
            var list = GetDogs();
            // 在集合中筛选 青壮年 公狗
            var listNew = list.Where(d => d.Gender && d.Age > 12).ToList();
            listNew.ForEach(d => Console.WriteLine(d.ToString()));
        }
        #endregion
        #region 2. Sqo  --  Select 投射方法 (返回一个新的集合)
        /// <summary>
        /// 获取母狗姓名集合
        /// </summary>
        private static void SqlSelect()
        {
            var list = GetDogs();
            var listNew = list.Where(d => !d.Gender)  // 找到所有母狗
                .Select(d => new { d.Name }).ToList();    // 返回母狗姓名集合
            listNew.ForEach(d => Console.WriteLine(d.Name));
        }

        #endregion  
        #region 3. Sqo  --  OrderBy 排序方法 Sort 在原集合牌 OrderBy 返回一个排好的新集合 ThenBy 对前面排序的相等情况尽心进一步排序


        public static void SqoOrder()
        {
            var list = GetDogs();
            //var listNew = list.OrderByDescending(d => d.Age).ToList();  // 这里不是在原集合排序, 而是返回一个排好的集合 Sort是在本集合排序
            var listNew = list.OrderByDescending(d => d.Age).ThenBy(d => d.Id).ToList();    // ThenBy用于在前面条件相同的时候, 后续执行的排序
            listNew.ForEach(d => Console.WriteLine(d.ToString()));
        }

        #endregion
        #region 4. Sqo  --  join 连接集合 将实现了关联的两个集合合并成一个集合

        /// <summary>
        /// 查询有玩具的狗
        /// </summary>
        public static void TestJoin()
        {
            var listDog = GetDogs();
            var listToy = GetDogToys();
            // 连接查询
            var listNew = listDog.Join(listToy, d=>d.Id, t=>t.DogId, (d, t)=>new{DogName = d.Name, ToyName = t.Name}).ToList();
            listNew.ForEach(s => Console.WriteLine(string.Format("狗名: {0}, 玩具: {1}", s.DogName, s.ToyName)));
        }

        #endregion
        #region 5. Sqo -- GropBy 分组

        public static void TestGropBy()
        {
            List<Dog> list = GetDogs();
            // 按照Gender(bool)分的组, 组的成员是Dog
            IEnumerable<IGrouping<bool, Dog>> Grop = list.GroupBy(d => d.Gender);
            List<IGrouping<bool, Dog>> listGrop = Grop.ToList();
            foreach (IGrouping<bool, Dog> item in listGrop)
            {
                // 按照什么分的组
                Console.WriteLine("组名: " + item.Key);   // 将分组标志作为组名
                // 成员
                foreach (Dog d in item)
                {
                    Console.WriteLine("成员: " + d);
                    Console.WriteLine("--------");
                }
                Console.WriteLine("======================");
            }
        }

        #endregion
        #region Sqo --  Skip Take 分页查询 使用之前必须OrderBy给每个Row标上行数
        
        #endregion
        /// <summary>
        /// 获取狗集合
        /// </summary>
        /// <returns></returns>
        public static List<Dog> GetDogs()
        {
            return new List<Dog>()
            {
                new Dog(){Id = 1, Name = "Dog1", Age = 11, Gender = true},
                new Dog(){Id = 2, Name = "Dog2", Age = 12, Gender = true},
                new Dog(){Id = 3, Name = "Dog3", Age = 13, Gender = false},
                new Dog(){Id = 4, Name = "Dog4", Age = 14, Gender = false},
                new Dog(){Id = 5, Name = "Dog5", Age = 15, Gender = true},
                new Dog(){Id = 6, Name = "Dog5", Age = 15, Gender = true}
            };
        }

        public static List<DogToy> GetDogToys()
        {
            return new List<DogToy>()
            {
                new DogToy(){Id = 1, DogId=3, Name = "狗骨头"},
                new DogToy(){Id = 2,DogId = 1, Name = "玩具"},
                new DogToy(){Id = 3,DogId = 2, Name = "沙发"},
                new DogToy(){Id = 4, DogId = 3, Name = "飞盘"},
                new DogToy(){Id = 5, DogId = 1, Name = "球"}
            };
        }
    }

    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + " Name: " + Name + " Age: " + Age + " Gender: " + (Gender ? "男" : "女");
        }
    }

    public class DogToy
    {
        public int Id { get; set; }
        public int DogId { get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N26新语法1
{
    class N03Linq
    {
        // 编译后Linq会被转换为Sqo
        // Linq不能实现Skip()和Take()分页, 其他的都能实现
        //public static void Main()
        //{
        //    var list = GetDogs();
        //    // 从老集合中拿出数据存入新集合
        //    var listNew = from d in list select d;
        //    Console.WriteLine(listNew.GetType());
        //    listNew.ToList().ForEach(d => Console.WriteLine(d.Name));
        //    Console.WriteLine("==============");
        //    // 从老集合中查询所有母狗存入新集合
        //    var dogs = from d in list where d.Gender == false select d;
        //    dogs.ToList().ForEach(d => Console.WriteLine(d.Name + " : " + d.Gender));
        //    Console.WriteLine("==============");
        //    // 排序
        //    var dogs3 = from d in list orderby d.Age orderby d.Id descending  select d.Name;
        //    dogs3.ToList().ForEach(d => Console.WriteLine(d.ToString()));
        //     Console.WriteLine("==============");
        //    // 连接查询
        //    var toyList = GetDogToys();
        //    var joinedList = from a in list join t in toyList on a.Id equals t.DogId select new {Name = a.Name, Toy = t.Name};
        //    joinedList.ToList().ForEach(d => Console.WriteLine("狗名: " + d.Name + " 玩具: " + d.Toy));
        //    Console.WriteLine("==============");
        //    // 分组查询
        //    var groupList = from d in list group d by d.Gender;
        //    groupList.ToList().ForEach(d => Console.WriteLine(d.Key));
        //    groupList.ToList().ForEach(d => d.ToList().ForEach(d2 => Console.WriteLine(d2.Name)));
        //}

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

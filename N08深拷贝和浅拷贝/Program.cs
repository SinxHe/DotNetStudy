// 2015-4-2 16:37:00
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace N08深拷贝和浅拷贝
{
    class Program
    {
        static void Main(string[] args)
        {
            // 拷贝: 将对象在内存中重新创建一份
            Person p1 = new Person() { Name = "HeabKing", Age = 22 };
            Person p2 = p1;     // 未发生拷贝, p1对象只有一个, HeabKing在内存中还是只有一份
            // 实现拷贝
            //      1. 蛮力法
            Person p3 = new Person();
            p3.Name = p1.Name;
            p3.Age = p1.Age;
            //      2. 序列化法 他是深拷贝
            BinaryFormatter bf = new BinaryFormatter();
            byte[] b = new byte[1000];
            using (MemoryStream ms = new MemoryStream(b))
            {
                bf.Serialize(ms, p1);
            }
            using (MemoryStream ms = new MemoryStream(b))
            {
                p2 = bf.Deserialize(ms) as Person;
            }
        }
    }
    [Serializable]
    class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private Car car;

        internal Car Car
        {
            get { return car; }
            set { car = value; }
        }
    }
    [Serializable]
    class Car
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public void show()
        {
            Console.WriteLine("我是一辆车");
        }
    }
}

// 2015-4-2 14:21:37
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N06程序集DLL
{
    #region 公有
    public class Class1
    { }
    public abstract class MyAbstractClass
    { }

    public static class MyStaticClass
    { }

    public class Person
    {
        public Person()
        { }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public void GetNameValue()
        {
            Console.WriteLine(this.Name);
        }

        public void SayHi()
        {
            Console.WriteLine("Hi");
        }
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
    public interface IFlayalbe
    {
        void Fly();
    }
    public class Student : Person, IFlayalbe
    {
        public string Studentno { get; set; }
        public void Fly()
        {
            throw new NotImplementedException();
        }
    }

    public delegate void MyDelegate();
    public enum GoodMan { 高, 富, 帅}
    #endregion
    #region 私有
    class MyClass
    {
        public void SayHi()
        {
            Console.WriteLine("Hi~~~");
        }
    }

    class Teacher : Person { }
    delegate void MyDeleagate1();
    #endregion
}

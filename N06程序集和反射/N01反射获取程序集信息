// 2015-4-2 13:49:08
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace N06程序集和反射
{
    class N01反射获取程序集信息
    {
        static void Main(string[] args)
        {
            #region 本程序集中的Person
            //  1.  Type对象就相当于"类型元数据"
            //      1.  获取Type
            //Type type = typeof(Person); // Type t = new Person().GetType();
            //      2.  获取所有方法
            //MethodInfo[] mi = type.GetMethods();
            //foreach (var item in mi)
            //{
                //Console.WriteLine(item.Name);
            //}
            #region 输出
            //get_Name  属性相关方法
            //set_Name
            //get_Age
            //set_Age
            //SayHello  用户定义的方法, 没有私有的...
            //ToString  object类继承
            //Equals
            //GetHashCode
            //GetType
            //请按任意键继续. . .
            #endregion
            //      3.  获取所有属性
            //PropertyInfo[] pi = type.GetProperties();
            //foreach (var item in pi)
            //{
                //Console.WriteLine(item.Name);
            //}
            #region 输出
            //Name
            //Age
            #endregion
            //      4.  获取所有字段
            //FieldInfo[] fi = type.GetFields();
            //foreach (var item in fi)
            //{
                //Console.WriteLine(item.Name);
            //}
            #region 输出
            //num 私有的字段不会输出
            #endregion
            #endregion
            #region 外部程序集中的Person2
            // 1. 动态加载程序集
            Assembly assembly = Assembly.LoadFile(@"C:\Users\daxiong\Desktop\Code\DotNetStudy\N06程序集DLL\bin\Debug\N06程序集DLL.dll");
            // 2. 获取所有类型
            //      1. assembly.GetType() 等价于 typeof(Assembly), 不能获取某个程序集中的所有类型
            //         输出中没有私有成员
            Type t = assembly.GetType();

            foreach (var item in t.GetMembers())
            {
                //Console.WriteLine(item.Name);
            }
            //      2. 获取所有类型
            //          1. 获取包括private
            Type[] types = assembly.GetTypes();
            foreach (var item in types)
            {
                //Console.WriteLine(item.Name);
            }
            //          2. 只获取public类型
            foreach (var item in assembly.GetExportedTypes())
            {
                //Console.WriteLine(item.Name);
            }
            //          3.  只获取Person类的type
            Type personType = assembly.GetType("N06程序集DLL.Person"); // 传进去的是"完全限定名称"
            //              1. 拿到某个方法并调用
            

            MethodInfo miPerson = personType.GetMethod("SayHi");
            //Console.WriteLine(miPerson.Name);
            //                  1. // 通过反射创建Person类型对象
            object objPerson = Activator.CreateInstance(personType);
            miPerson.Invoke(objPerson, null);  
            #endregion
        }
    }

    //class Person
    //{
    //    // 属性
    //    public string Name { get; set; }
    //    public int Age { get; set; }

    //    // 字段
    //    public string num;
    //    private string num2;

    //    public void SayHello()
    //    {
    //        Console.WriteLine("Hello!");
    //    }

    //    private void Private()
    //    {
    //        Console.WriteLine("I'm Private!");
    //    }
    //}
}

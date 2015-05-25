using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace N06程序集和反射
{
    class N02反射获取和设置类中的指定属性
    {
        public static void Main()
        {
            Person person = new Person() { Id = 1, Name = "HeabKing" };
            Person person2 = new Person() { Id = 2, Name = "123456" };
            SetProByStringName(person, GetProByStringName(person2, "Name"), "Name");
            //Console.WriteLine(GetProByStringName(person, "Name"));
            Console.WriteLine(person.Name);
        }

        /// <summary>
        /// 通过字符串属性名获取实体对应属性的值
        /// </summary>
        /// <param name="p">实体</param>
        /// <param name="proName">实体的属性名</param>
        /// <returns>实体对应属性名的值</returns>
        static object GetProByStringName<T>(T p, string proName)
        {
            // 获取实体类 类型对象
            Type t = p.GetType();   // typeof(Person);
            // 获取 实体类 所有 公有属性
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            // 获取 指定属性 对象
            PropertyInfo rightPro = proInfos.FirstOrDefault(pro => pro.Name == proName);
            if (rightPro == null)
            {
                throw new Exception("指定的属性名" + proName + "在实体中不存在!");
            }
            // 返回指定属性对应的值
            return rightPro.GetValue(p, null);
        }

        /// <summary>
        /// 设置实体指定字符串属性名对应属性的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p">实体</param>
        /// <param name="newValue">赋值给实体指定属性的值</param>
        /// <param name="proName">实体属性的名字</param>
        private static void SetProByStringName<T>(T p, object newValue , string proName)
        {
            // 获取实体类 类型对象
            Type t = p.GetType();   // typeof(Person);
            // 获取 实体类 所有 公有属性
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            // 获取 指定属性 对象
            PropertyInfo rightPro = proInfos.FirstOrDefault(pro => pro.Name == proName);
            if (rightPro == null)
            {
                throw new Exception("指定的属性名" + proName + "在实体中不存在!");
            }
            rightPro.SetValue(p, newValue, null);   // null 不加上有的时候会出现多个候选方法, 从而导致出错
        }
    }

    /// <summary>
    /// 尝试拓展失败...
    /// </summary>
    public static class TExtension
    {
        static object GetProByStringName<T>(this T th, string proName)
        {
            // 获取实体类 类型对象
            Type t = th.GetType();   // typeof(Person);
            // 获取 实体类 所有 公有属性
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            // 获取 指定属性 对象
            PropertyInfo rightPro = proInfos.FirstOrDefault(pro => pro.Name == proName);
            if (rightPro == null)
            {
                throw new Exception("指定的属性名" + proName + "在实体中不存在!");
            }
            // 返回指定属性对应的值
            return rightPro.GetValue(th, null);
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

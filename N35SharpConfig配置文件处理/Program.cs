using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SharpConfig;

namespace N35SharpConfig配置文件处理
{
    class Program
    {
        static void Main(string[] args)
        {
            //SharpConfigTest();
            SerealizeXmlTest();
        }

        static void SharpConfigTest()
        {
            //按文件名称加载配置文件
            Configuration config = Configuration.LoadFromFile("example.ini");
            //按照节的名称读取节
            Section section = config["General"];
            //依次根据每个配置项的名称来读取，如果配置文件类型搞错了，会报错
            string someString = section["SomeString"].Value;
            var someInteger = section["SomeInteger"].GetValue<int>();   // Failed to convert value '10' to type System.Boolean.
            float someFloat = section["SomeFloat"].GetValue<float>();
            Boolean someBool = section["ABoolean"].GetValue<Boolean>();
            Console.WriteLine("当前节名称:{0}", section.Name);
            Console.WriteLine("字符串SomeString值:{0}", someString);
            Console.WriteLine("整数someInteger值:{0}", someInteger);
            Console.WriteLine("双精度someFloat值:{0}", someFloat);
            Console.WriteLine("布尔值someBool值:{0}", someBool);
        }

        private static void SerealizeXmlTest()
        {
             // 声明一个猫咪对象
            var c = new Cat { Color = "White", Speed = 10, Saying = "我是Saying的内容" };
 
            // 序列化这个对象
            XmlSerializer serializer = new XmlSerializer(typeof(Cat));
 
            // 将对象序列化输出到控制台
            serializer.Serialize(Console.Out, c);

            Console.Read();
        }
    }

    [XmlRoot("cat")]
    public class Cat
    {
        // 定义Color属性的序列化为cat节点的属性
        [XmlAttribute("color")]
        public string Color { get; set; }
 
        // 要求不序列化Speed属性
        [XmlIgnore]
        public int Speed { get; set; }
 
        // 设置Saying属性序列化为Xml子元素
        [XmlElement("saying")]
        public string Saying { get; set; }

        // 如果没有定义, 那么为<Age>
        public int Age { get; set; }
    }
}

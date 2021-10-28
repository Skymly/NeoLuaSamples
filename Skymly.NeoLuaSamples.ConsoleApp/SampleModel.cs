using Newtonsoft.Json;

using Splat;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public class SampleModel : IEnableLogger
    {
        //属性
        public string Name { get; set; }
        //字段
        public int age;

        //只读属性
        public int NameLength => Name.Length;

        //常量
        public const double PI = 3.1416;

        //静态字段
        public static int Num = 888;

        //静态属性
        public static string Message { get; set; } = "Message From SampleModel";

        //实例方法
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        //返回this的实例方法
        public SampleModel SetName(string name)
        {
            var oldName = Name;
            this.Name = name;
            Console.WriteLine($"SetName:OldName={oldName},NewName={Name}");
            return this;
        }

        /// <summary>
        /// 求圆的周长
        /// </summary>
        /// <param name="radius">半径</param>
        /// <returns></returns>
        public double GetCircumference(double radius)
        {
            return 2.0 * PI * radius;
        }

        public static void PrintMessage()
        {
            Console.WriteLine($"Message={Message},Num={Num}");
        }
    }
}

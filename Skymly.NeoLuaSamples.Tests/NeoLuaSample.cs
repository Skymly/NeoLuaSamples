using Neo.IronLua;

using Newtonsoft.Json;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Skymly.NeoLuaSamples.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var array = new double[] { 55, 55, 55, 55 };
        }

        /// <summary>
        /// 执行字符串
        /// </summary>
        [Test]
        public void DoStringTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("print('Hello World!');", "DoStringTest");
        }

        /// <summary>
        /// 执行字符串 传参
        /// </summary>
        [Test]
        public void DoStringWithArgsTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var code = @" print ( 'a = ' .. a ..'\nb = ' .. b .. '\nc = ' .. c .. '\nd = ' .. d .. '\n')";
            var args = new Dictionary<string, object>
            {
                ["a"] = "张三",
                ["b"] = "李四",
                ["c"] = "Lua",
                ["d"] = "CSharp",
            }.ToArray();
            g.DoChunk(code, "DoStringWithArgsTest", args);
        }

        /// <summary>
        /// 执行文件
        /// </summary>
        [Test]
        public void DoFileTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk($"Scripts/DoFileTest.lua");
        }

        /// <summary>
        /// 执行文件 传参数
        /// </summary>
        [Test]
        public void DoFileWithArgsTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var args = new Dictionary<string, object>
            {
                ["a"] = "张三",
                ["b"] = "李四",
                ["c"] = "Lua",
                ["d"] = "CSharp",
            }.ToArray();
            g.DoChunk("Scripts/DoFileWithArgsTest.lua", args);
        }

        /// <summary>
        /// 类型
        /// </summary>
        [Test]
        public void TypeTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk($"Scripts/TypeTest.lua");
        }


        /// <summary>
        /// 属性、字段
        /// </summary>
        [Test]
        public void PropertyAndFieldTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var model_a = new SampleModel
            {
                Name = "Item1",
                age = 18,
            };
            var model_b = new SampleModel
            {
                Name = "Item2",
                age = 50,
            };
            g["m1"] = model_a;
            g["m2"] = model_b;
            g.DoChunk("Scripts/PropertyAndFieldTest.lua");
        }

        /// <summary>
        /// Lua调用C#方法
        /// </summary>
        [Test]
        public void LuaCallCSharpMethodTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var model_a = new SampleModel
            {
                Name = "Item1",
                age = 18,
            };
            g["m"] = model_a;
            g.DoChunk("Scripts/LuaCallCSharpMethodTest.lua");
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/ConstructorTest.lua");
        }

        /// <summary>
        /// 枚举
        /// </summary>
        [Test]
        public void EnumTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/EnumTest.lua");
        }


        /// <summary>
        /// 泛型
        /// </summary>
        [Test]
        public void GenericTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/GenericTest.lua");
        }

        /// <summary>
        /// Lua循环
        /// </summary>
        /// <param name="count"></param>
        [Test]
        [TestCase(0)]
        [TestCase(5)]
        public void LuaLoopTest(int count)
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            Random random = new Random((int)DateTime.Now.Ticks);
            var array = Enumerable.Range(0, count).Select(_ => random.Next(0, 100)).ToArray();
            var json = JsonConvert.SerializeObject(array);
            g.Add("count", count);
            g.Add("json", json);
            g["array"] = array;
            g.DoChunk("Scripts/LuaLoopTest.lua");
        }

        /// <summary>
        /// Lua foreach
        /// 原生lua并无foreach关键字 这是Neolua实现的
        /// </summary>
        [Test]
        public void LuaForeachTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            Random random = new Random((int)DateTime.Now.Ticks);
            var array = Enumerable.Range(0, 5).Select(_ => random.Next(0, 100)).ToArray();
            var json = JsonConvert.SerializeObject(array);
            g["json"] = json;
            g["array"] = array;
            g.DoChunk("Scripts/LuaForeachTest.lua");

        }

        /// <summary>
        /// Lua迭代器
        /// </summary>
        [Test]
        public void LuaIteratorTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/LuaIteratorTest.lua");
        }

        /// <summary>
        /// C#调用LuaFunction
        /// </summary>
        [Test]
        public void CSharpCallLuaFunctionTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var r = g.DoChunk("Scripts/CSharpCallLuaFunctionTest.lua");

            var sum = g.CallMember("Sum", 12, 33, 10, 9).ToInt32();
            Assert.AreEqual(sum, 12 + 33 + 10 + 9);

            var f = g.CallMember("Fibonacci", 5).ToInt32();
            Assert.AreEqual(f, 8);
        }
        /// <summary>
        /// 加载模块
        /// </summary>
        [Test]
        public void RequireModuleTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var r = g.DoChunk("Scripts/RequireModuleTest.lua");
        }

        [Test]
        public void LuaLambdaTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var r = g.DoChunk("Scripts/LuaLambdaTest.lua");

        }


       

    }
    public class LambdaTestModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public int Get(Func<int> arg)
        {
            return arg();
        }
    }
}
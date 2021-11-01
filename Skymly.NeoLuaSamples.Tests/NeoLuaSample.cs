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
        const string author = "Skymly";
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void DoStringTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("print('Hello World!');", "Sample01");
        }

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
            g.DoChunk(code, "Sample01", args);
        }


        [Test]
        public void DoFileTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk($"Scripts/DoFileTest.lua");
        }


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

        [Test]
        public void LuaCallCSahrpMethodTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var model_a = new SampleModel
            {
                Name = "Item1",
                age = 18,
            };
            g["m"] = model_a;
            g.DoChunk("Scripts/LuaCallCSahrpMethodTest.lua");
        }

        [Test]
        public void ConstructorTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/ConstructorTest.lua");
        }
        [Test]
        public void EnumTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/EnumTest.lua");
        }
        [Test]
        public void GenericTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/GenericTest.lua");
        }


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


        [Test]
        public void LuaIteratorTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/LuaIteratorTest.lua");
        }

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

    }
}
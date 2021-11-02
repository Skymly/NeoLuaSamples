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

        /// <summary>
        /// ִ���ַ���
        /// </summary>
        [Test]
        public void DoStringTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("print('Hello World!');", "Sample01");
        }

        /// <summary>
        /// ִ���ַ��� ����
        /// </summary>
        [Test]
        public void DoStringWithArgsTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var code = @" print ( 'a = ' .. a ..'\nb = ' .. b .. '\nc = ' .. c .. '\nd = ' .. d .. '\n')";
            var args = new Dictionary<string, object>
            {
                ["a"] = "����",
                ["b"] = "����",
                ["c"] = "Lua",
                ["d"] = "CSharp",
            }.ToArray();
            g.DoChunk(code, "Sample01", args);
        }

        /// <summary>
        /// ִ���ļ�
        /// </summary>
        [Test]
        public void DoFileTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk($"Scripts/DoFileTest.lua");
        }

        /// <summary>
        /// ִ���ļ� ������
        /// </summary>
        [Test]
        public void DoFileWithArgsTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var args = new Dictionary<string, object>
            {
                ["a"] = "����",
                ["b"] = "����",
                ["c"] = "Lua",
                ["d"] = "CSharp",
            }.ToArray();
            g.DoChunk("Scripts/DoFileWithArgsTest.lua", args);
        }

        /// <summary>
        /// ���ԡ��ֶ�
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
        /// Lua����C#����
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
        /// ���췽��
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/ConstructorTest.lua");
        }

        /// <summary>
        /// ö��
        /// </summary>
        [Test]
        public void EnumTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/EnumTest.lua");
        }


        /// <summary>
        /// ����
        /// </summary>
        [Test]
        public void GenericTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/GenericTest.lua");
        }

        /// <summary>
        /// Luaѭ��
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
        /// ԭ��lua����foreach�ؼ��� ����Neoluaʵ�ֵ�
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
        /// Lua������
        /// </summary>
        [Test]
        public void LuaIteratorTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/LuaIteratorTest.lua");
        }

        /// <summary>
        /// C#����LuaFunction
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
        /// ����ģ��
        /// </summary>
        [Test]
        public void RequireModuleTest()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var r = g.DoChunk("Scripts/RequireModuleTest.lua");
        }

    }
}
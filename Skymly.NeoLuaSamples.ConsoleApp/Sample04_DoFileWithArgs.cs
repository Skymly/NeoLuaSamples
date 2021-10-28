using Neo.IronLua;

using System.Collections.Generic;
using System.Linq;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public class Sample04_DoFileWithArgs : BaseSample
    {
        public override void Run()
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
            g.DoChunk("Scripts/Sample04.lua", args);

        }
    }
}

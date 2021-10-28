using Neo.IronLua;
using System.Collections.Generic;
using System.Linq;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public class Sample02_DoStringWithArgs : BaseSample
    {
        public override void Run()
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
    }
}

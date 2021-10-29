using Neo.IronLua;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public class Sample00_Test : BaseSample
    {
        public override void Run()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var result = g.DoChunk("Scripts/Sample00.lua");
            Console.WriteLine(result[0]);
        }
    }
}

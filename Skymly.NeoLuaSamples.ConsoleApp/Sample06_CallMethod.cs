using Neo.IronLua;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public class Sample06_CallMethod : BaseSample
    {
        public override void Run()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            var model_a = new SampleModel
            {
                Name = "Item1",
                age = 18,
            };
            g["m"] = model_a;
            g.DoChunk("Scripts/Sample06.lua");
        }
    }
}

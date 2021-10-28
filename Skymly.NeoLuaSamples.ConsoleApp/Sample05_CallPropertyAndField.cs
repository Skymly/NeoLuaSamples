using Neo.IronLua;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public class Sample05_CallPropertyAndField : BaseSample
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
            var model_b = new SampleModel
            {
                Name = "Item2",
                age = 50,
            };
            g["m1"] = model_a;
            g["m2"] = model_b;
            g.DoChunk("Scripts/Sample05.lua");
        }
    }
}

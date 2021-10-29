using Neo.IronLua;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public class Sample10_Loop : BaseSample
    {
        public override void Run()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/Sample10.lua");
        }
    }
}

using Neo.IronLua;

using Splat;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public abstract class BaseSample : IEnableLogger
    {
        
        public virtual void Run()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk($"Scripts/{GetType().Name[..8]}.lua");

        }
    }
}

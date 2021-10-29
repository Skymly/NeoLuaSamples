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
        
        public abstract void Run();
    }
}

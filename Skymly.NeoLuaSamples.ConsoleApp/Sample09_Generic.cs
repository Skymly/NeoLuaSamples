
using Neo.IronLua;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public class Sample09_Generic : BaseSample
    {
        public override void Run()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/Sample09.lua");
        }
    }
}

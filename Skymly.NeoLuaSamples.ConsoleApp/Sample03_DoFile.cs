using Neo.IronLua;
namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public class Sample03_DoFile : BaseSample
    {
        public override void Run()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("Scripts/Sample03.lua");
        }
    }
}
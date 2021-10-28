using Neo.IronLua;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public class Sample01_DoString : BaseSample
    {
        public override void Run()
        {
            using Lua l = new();
            var g = l.CreateEnvironment();
            g.DoChunk("print('Hello World!');", "Sample01");
        }
    }
}

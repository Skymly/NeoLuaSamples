using Splat;

using System;
using Serilog;
using Splat.Serilog;
using Serilog.Events;
using System.Reflection;
using System.Linq;
using Neo.IronLua;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    internal class Program
    {
        const string logTemplate = "{Timestamp:HH:mm} [{Level}] [{SourceContext}] [ThreadId:{ThreadId}] {NewLine}{Message}{NewLine}{Exception}";
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
               .Enrich.FromLogContext()
               .Enrich.WithThreadId()
               .WriteTo.File("Logs/logs.txt", outputTemplate: logTemplate)
               .WriteTo.Console(outputTemplate: logTemplate)
               .CreateLogger();
            Locator.CurrentMutable.UseSerilogFullLogger();

            Console.WriteLine(typeof(Sample01_DoString).IsSubclassOf(typeof(BaseSample)));
            Console.WriteLine(typeof(BaseSample).IsSubclassOf(typeof(Sample01_DoString)));

            LuaType.RegisterTypeExtension(typeof(SampleModelExtensions));

            Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(BaseSample))).ToList().ForEach(RunSample);
        }

        static void RunSample(Type sampleType)
        {
            var sample = (BaseSample)Activator.CreateInstance(sampleType);
            Log.ForContext<Program>().Information("Run:" + sampleType.Name);
            sample.Run();
            Console.WriteLine();
        }

    }
}

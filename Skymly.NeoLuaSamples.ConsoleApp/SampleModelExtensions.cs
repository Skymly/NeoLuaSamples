using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    public static class SampleModelExtensions
    {

        public static void Say(this SampleModel model)
        {
            Console.WriteLine($"{model.Name} Say: I am {model.age} years old.");
        }
    }
}

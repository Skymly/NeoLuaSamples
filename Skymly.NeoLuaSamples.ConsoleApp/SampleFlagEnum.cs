using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.NeoLuaSamples.ConsoleApp
{
    [Flags]
    public enum SampleFlagEnum
    {
        固态 = 1 << 0,
        气态 = 1 << 1,
        液态 = 1 << 2,
        有毒 = 1 << 3,
        酸性 = 1 << 4,
        碱性 = 1 << 5,
        金属 = 1 << 6,
        非金属 = 1 << 7,
        腐蚀性 = 1 << 8,
    }
}

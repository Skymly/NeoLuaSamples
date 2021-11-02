using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skymly.NeoLuaSamples.Wpf.Models
{
    public class RoutingItem
    {
        public RoutingItem()
        {
        }

        public RoutingItem(string display, string source)
        {
            Display = display;
            Source = source;
        }

        public string Display { get; set; }
        public string Source { get; set; }
    }
}

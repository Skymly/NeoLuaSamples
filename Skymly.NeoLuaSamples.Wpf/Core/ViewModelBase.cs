using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Services;
using Prism.Navigation;
using Serilog;

namespace Skymly.NeoLuaSamples.Wpf.Core
{
    public class ViewModelBase : BindableBase, IDestructible
    {
        protected ViewModelBase()
        {
            Logger = Log.ForContext(GetType());
        }

        public ILogger Logger { get; set; }

        public void Destroy()
        {
            Logger?.Debug($"Destroy:{GetType().FullName}");
        }
    }
}

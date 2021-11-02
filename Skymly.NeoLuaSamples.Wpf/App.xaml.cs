using Serilog.Enrichers;
using Serilog.Events;
using Serilog;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism;
using Prism.Unity;
using Prism.Ioc;
using Skymly.NeoLuaSamples.Wpf.Views;
using Skymly.NeoLuaSamples.Wpf.ViewModels;
using Splat;
using Splat.Serilog;
namespace Skymly.NeoLuaSamples.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication, IEnableLogger
    {

        const string logTemplate = "{Timestamp:HH:mm} [{Level}] [{SourceContext}] [({ThreadId})] {Message}{NewLine}{Exception}";
        public App()
        {
            static IContainerExtension createContainerExtension() => new UnityContainerExtension();
            ContainerLocator.SetContainerExtension(createContainerExtension);
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Verbose()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.With(new ThreadIdEnricher())
                .WriteTo.Async(c => c.File("Logs/logs.txt", outputTemplate: logTemplate, rollingInterval: RollingInterval.Day))
                .WriteTo.Async(c => c.Debug(outputTemplate: logTemplate))
                .CreateLogger();
            Locator.CurrentMutable.UseSerilogFullLogger();
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e) => this.Log().Error(e.Exception, "{Observed}", e.Observed);
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) => this.Log().Error(e.ToString());
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) => this.Log().Error(e.Exception, e.ToString());

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<RoutingBar, RoutingBarViewModel>();
            containerRegistry.RegisterForNavigation<DataBindingSample, DataBindingSampleViewModel>();
        }
    }
}

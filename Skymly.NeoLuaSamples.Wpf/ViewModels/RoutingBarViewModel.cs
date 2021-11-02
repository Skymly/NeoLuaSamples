using Prism.Commands;
using Prism.Mvvm;

using Skymly.NeoLuaSamples.Wpf.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Regions;
using Skymly.NeoLuaSamples.Wpf.Extensions;
using MaterialDesignThemes.Wpf;
using Skymly.NeoLuaSamples.Wpf.Views;

namespace Skymly.NeoLuaSamples.Wpf.ViewModels
{
    public class RoutingBarViewModel : BindableBase
    {
        private RoutingItem currentItem;
        private DelegateCommand<RoutingItem> routingCommand;
        readonly IRegionManager regionManager;
        public RoutingBarViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            Items = new List<RoutingItem>()
            {
                new("数据绑定",nameof(DataBindingSample)),
            };
        }

        public RoutingItem ActivedItem { get => currentItem; set => SetProperty(ref currentItem, value); }
        public IEnumerable<RoutingItem> Items { get; set; }
        public DelegateCommand<RoutingItem> RoutingCommand => routingCommand ??= new DelegateCommand<RoutingItem>(Routing);
        private void Routing(RoutingItem item)
        {
            if (item != ActivedItem)
            {
                ActivedItem = item;
                regionManager.RequestNavigate("MainRegion", ActivedItem.Source);
            }
            App.Current.MainWindow.FindChild<DrawerHost>().IsLeftDrawerOpen = false;

        }
    }
}

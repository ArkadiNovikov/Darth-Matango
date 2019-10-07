using Darth_Matango.Views;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Darth_Matango
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void OnInitialized()
        {
//    Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQyMzQwQDMxMzcyZTMyMmUzMG9EaDhjVlJYdmhUUmtGQkJ2NTN5cVEwYTNjY0VDMGRVOUxnVjBLRS9vMlE9");

            base.OnInitialized();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<Models.SaveDataRoot>(new Models.SaveDataRoot());
        }
    }
}

using ModuleA;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using PrismRegionDemo.Core.Regions;
using PrismRegionDemo.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PrismRegionDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);

            regionAdapterMappings.RegisterMapping(typeof(StackPanel),
                Container.Resolve<StackPanelRegionAdapter>());
        }

        // Register a module using code
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleAModule>();
        }

        // Register a module using a Directory
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        //}

        // Register a module using an App.Config
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new ConfigurationModuleCatalog();
        //}

        // This override is used when you don't follow the conventional method of setting up
        // the View/ViewModel pattern, i.e. if you want to change the default naming convention,
        // and use another folder for your views instead of the Views folder. In this example
        // we have a folder called Controls for the views, and a view called ControlA.xaml in
        // that folder. 
        //protected override void ConfigureViewModelLocator()
        //{
        //    base.ConfigureViewModelLocator();

        //    ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
        //    {
        //        var viewName = viewType.FullName;
        //        var assemblyName = viewType.Assembly.FullName;
        //        var vmName = $"{viewName.Replace("Controls", "ViewModels")}ViewModel, {assemblyName}";
        //        return Type.GetType(vmName);
        //    });
        //}
    }
}

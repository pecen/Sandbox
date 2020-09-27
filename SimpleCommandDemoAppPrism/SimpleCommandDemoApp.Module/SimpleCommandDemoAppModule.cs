using SimpleCommandDemoApp.Module.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace SimpleCommandDemoApp.Module {
  public class SimpleCommandDemoAppModule : IModule {
    public void OnInitialized(IContainerProvider containerProvider) {
      var regionManager = containerProvider.Resolve<IRegionManager>();

      regionManager.RegisterViewWithRegion("ContentRegion", typeof(Calculator));
      regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry) {

    }
  }
}
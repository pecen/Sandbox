using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using PrismUnityApp.Module.Enums;
using PrismUnityApp.Module.Views;
using PrismUnityApp.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp.Module {
  public class PrismUnityAppModule : IModule {
    private readonly IRegionManager _regionManager;
    private readonly IUnityContainer _container;

    public PrismUnityAppModule(IRegionManager regionManager, IUnityContainer container) {
      _regionManager = regionManager;
      _container = container;
    }

    public void Initialize() {
      //_container.RegisterType<object, PersonViewA>("PersonViewA");
      //_container.RegisterType<object, PersonViewB>("PersonViewB");

      // The following line puts ViewA in the content area from the start
      _regionManager.RegisterViewWithRegion("TabRegion", typeof(PersonViewA));
      _regionManager.RegisterViewWithRegion("TabRegion", typeof(PersonViewB));

      _container.RegisterTypeForNavigation<PersonViewA>(EnumExtensions.GetEnumDescription(ViewNames.PersonViewA));
      _container.RegisterTypeForNavigation<PersonViewB>(EnumExtensions.GetEnumDescription(ViewNames.PersonViewB));
    }
  }
}

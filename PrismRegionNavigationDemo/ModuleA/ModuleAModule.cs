using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(PersonList));

            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate("ContentRegion", "PersonList");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<ViewA>();
            //containerRegistry.RegisterForNavigation<ViewB>();

            containerRegistry.RegisterForNavigation<PersonList>();
            containerRegistry.RegisterForNavigation<PersonDetail>();
        }
    }
}
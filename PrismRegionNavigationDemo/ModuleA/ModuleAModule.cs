using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        public ModuleAModule(RegionManager regionManager)
        {
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(PersonList));
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();

            //containerRegistry.RegisterForNavigation<PersonDetail>();
        }
    }
}
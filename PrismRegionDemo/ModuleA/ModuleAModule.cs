using ModuleA.Controls;
using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            // Displaying the View using View Discovery
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
            //_regionManager.RegisterViewWithRegion("ContentRegion", typeof(ControlA));

            // Displaying the View using View Injection, which gives you more control

            //IRegion region = _regionManager.Regions["ContentRegion"];

            //var view1 = containerProvider.Resolve<ControlA>();
            //region.Add(view1);

            //var view2 = containerProvider.Resolve<ViewA>();
            //view2.Content = new TextBlock()
            //{
            //    Text = "Hello from View 2",
            //    HorizontalAlignment = HorizontalAlignment.Center,
            //    VerticalAlignment = VerticalAlignment.Center
            //};
            //region.Add(view2);
            //region.Activate(view2);

            //// Activate view1 again
            //region.Activate(view1);

            //// Just because you deactivate view1 doesn't mean view2 will be displayed since you have to 
            //// activate it again to do so
            //region.Deactivate(view1);

            //// You have to re-activate view2 to have it displayed in the region
            //region.Activate(view2);

            //// When you remove a view it doesn't automatically activate any other view in that region
            //region.Remove(view2);

            //region.Activate(view1);

            // End of View Injection part
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // This is used when you want to directly point out which naming convention
            // you are using for your View/ViewModel. In this case we use the Controls
            // folder for the Views and we point out that the view ControlA should use
            // the ControlAViewModel as the viewmodel. This instead of changing the naming
            // convention in general as we could do by overriding ConfigureViewModelLocator()
            // in App.xaml.cs

            //ViewModelLocationProvider.Register<ControlA, ControlAViewModel>();

            // This is the same as above, but the difference lies in using a factory instead.
            // The benefit of using this approach is that we have removed the necessity of using
            // Reflection, which will make this approach a little faster. 

            //ViewModelLocationProvider.Register<ControlA>(() =>
            //{
            //    return new ControlAViewModel() { Text = "Hello from factory!" };
            //});
        }
    }
}
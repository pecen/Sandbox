using Prism.Regions;
using SimpleCommandDemoApp.Module.ViewModels;

namespace SimpleCommandDemoApp.Shell.ViewModels {
  public class MainWindowViewModel : ViewModelBase {
    // Uncomment if using several views or tabs
    //private readonly IRegionManager _regionManager;

    public MainWindowViewModel(IRegionManager regionManager) {
      Title = "Simple Command Demo App with Prism";

      // Uncomment if using several views or tabs
      //_regionManager = regionManager;
    }
  }
}

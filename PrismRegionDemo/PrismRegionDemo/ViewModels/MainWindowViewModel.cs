using ModuleA.ViewModels;
using Prism.Mvvm;
using PrismRegionDemo.Core.Commands;

namespace PrismRegionDemo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string ContentRegion { get; } = "ContentRegion";

        private IApplicationCommands _applicationCommands;

        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { _applicationCommands = value; }
        }

        public MainWindowViewModel(IApplicationCommands applicationCommands)
        {
            ApplicationCommands = applicationCommands;

            Title = "Prism Application";
        }
    }
}

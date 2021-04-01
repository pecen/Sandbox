using ModuleA.ViewModels;
using Prism.Mvvm;

namespace PrismRegionDemo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string TabRegion { get; } = "TabRegion";

        //private string _title = "Prism Application";
        //public string Title
        //{
        //    get { return _title; }
        //    set { SetProperty(ref _title, value); }
        //}

        public MainWindowViewModel()
        {
            Title = "Prism Application";
        }
    }
}

using BindableBaseDemo.MVVM.Core;

namespace BindableBaseDemo.MVVM.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
		private string _title;
		public string Title
		{
			get => _title; 
			set { SetProperty(ref _title, value); }
		}

        public MainWindowViewModel()
        {
            _title = "BindableBase Demo";
        }
    }
}

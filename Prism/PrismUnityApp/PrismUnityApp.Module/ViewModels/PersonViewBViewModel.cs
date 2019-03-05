using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PrismUnityApp.Module.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp.Module.ViewModels
{
	public class PersonViewBViewModel : ViewModelBase //, IConfirmNavigationRequest
	{
		private string _message = "PersonViewB";
		public string Message {
      get => _message;
      set { SetProperty(ref _message, value); }
    }

    public PersonViewBViewModel(IEventAggregator eventAggregator) {
      Title = "View B";
      eventAggregator.GetEvent<UpdateCommand>().Subscribe(Updated);
    }

    private void Updated(string obj) => Message = obj;

    //public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback) {
    //  // By setting this to false, the tab cannot be closed. 
    //  continuationCallback(false);
    //}
  }
}

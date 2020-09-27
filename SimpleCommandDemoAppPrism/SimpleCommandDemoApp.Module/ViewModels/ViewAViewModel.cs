using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using SimpleCommandDemoApp.Module.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandDemoApp.Module.ViewModels {
  public class ViewAViewModel : ViewModelBase {
    private string _message;
    public string Message {
      get { return _message; }
      set { SetProperty(ref _message, value); }
    }

    public ViewAViewModel(IEventAggregator eventAggregator) {
      eventAggregator.GetEvent<CalculateCommand>().Subscribe(CalculatedValueReceived);
    }

    private void CalculatedValueReceived(double obj) {
      Message = $"Calculated value = {obj}";
    }
  }
}

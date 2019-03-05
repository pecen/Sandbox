using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp.Module.ViewModels {
  public class ViewModelBase : BindableBase, INavigationAware {
    string _title;
    public string Title {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    public virtual bool IsNavigationTarget(NavigationContext navigationContext) {
      return true;
    }

    public virtual void OnNavigatedFrom(NavigationContext navigationContext) {
    }

    public void OnNavigatedTo(NavigationContext navigationContext) {
    }
  }
}

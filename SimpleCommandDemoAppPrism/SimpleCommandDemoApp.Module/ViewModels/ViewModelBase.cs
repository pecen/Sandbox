﻿using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommandDemoApp.Module.ViewModels {
  public class ViewModelBase : BindableBase, INavigationAware {
    private string _title;
    public string Title {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    public virtual bool IsNavigationTarget(NavigationContext navigationContext) {
      return true;
    }

    // Making this one virtual to be able to override in the child classes
    public virtual void OnNavigatedFrom(NavigationContext navigationContext) {

    }

    public virtual void OnNavigatedTo(NavigationContext navigationContext) {

    }
  }
}

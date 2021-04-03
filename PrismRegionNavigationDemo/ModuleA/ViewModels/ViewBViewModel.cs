using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleA.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private int _pageViews;
        public int PageViews
        {
            get { return _pageViews; }
            set { SetProperty(ref _pageViews, value); }
        }

        public ViewBViewModel()
        {
            Message = "View B from your Prism Module";
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
    }
}

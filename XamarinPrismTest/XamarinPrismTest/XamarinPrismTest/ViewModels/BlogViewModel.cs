using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinPrismTest.Models;

namespace XamarinPrismTest.ViewModels
{
	public class BlogViewModel : ViewModelBase
	{
    public BlogViewModel(INavigationService navigationService)
        : base(navigationService) {
    }
    private Blog _blogDetail;
    public Blog BlogDetail {
      get { return _blogDetail; }
      set { SetProperty(ref _blogDetail, value); }
    }
    //public override void OnNavigatingTo(INavigationParameters parameters) {
    //  base.OnNavigatingTo(parameters);
    //}
    public override void OnNavigatedTo(INavigationParameters parameters) {
      BlogDetail = (Blog)parameters["Blog"];
      Title = BlogDetail.BlogTitle;
      base.OnNavigatedTo(parameters);
    }
  }
}

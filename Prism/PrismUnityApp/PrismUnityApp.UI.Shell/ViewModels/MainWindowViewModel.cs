using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismUnityApp.Utilities.Extensions;
using PrismUnityApp.UI.Shell.Enums;
using Microsoft.Practices.Unity;
using PrismUnityApp.Module.Views;

namespace PrismUnityApp.UI.Shell.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private readonly IRegionManager _regionManager;
		//private readonly IUnityContainer _container;

		public DelegateCommand<string> NavigateCommand { get; set; }

		private string _title = "Prism Unity Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

    private string _contentRegion;
    public string ContentRegion {
      get { return _contentRegion; }
      set { SetProperty(ref _contentRegion, value); }
    }

    private string _tabRegion;
    public string TabRegion {
      get { return _tabRegion; }
      set { SetProperty(ref _tabRegion, value); }
    }

    public MainWindowViewModel(IRegionManager regionManager) //IUnityContainer container) 
		{
			_regionManager = regionManager;
			//_container = container;
			NavigateCommand = new DelegateCommand<string>(Navigate);
			ContentRegion = EnumExtensions.GetEnumDescription(WindowRegions.ContentRegion);
      TabRegion = EnumExtensions.GetEnumDescription(WindowRegions.TabRegion);
		}

		private void Navigate(string uri)
		{
      // using Navigation mechanism
      //_regionManager.RequestNavigate(ContentRegion, uri);
      _regionManager.RequestNavigate(TabRegion, uri);

      // View Injection 
      // Using strong coupling - big no no. First of all, I'm adding a 
      // reference to PersonViewA in a ViewModel, which should know
      // nothing about the View itself. 
      //IRegion region = _regionManager.Regions["TabRegion"];
      //var view = _container.Resolve<PersonViewA>();
      //region.Add(view);
      //region.Activate(view);


    }
  }
}

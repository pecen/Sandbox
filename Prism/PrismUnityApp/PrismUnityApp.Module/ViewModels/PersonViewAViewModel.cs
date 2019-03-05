using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PrismUnityApp.Library;
using PrismUnityApp.Module.Events;
using PrismUnityApp.Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp.Module.ViewModels
{
	public class PersonViewAViewModel : ViewModelBase
	{
		private int _id;
		public int Id
		{
			get { return _id; }
			set { SetProperty(ref _id, value); }
		}

		private string _firstName = "Peter";
		public string FirstName
		{
			get { return _firstName; }
			set { SetProperty(ref _firstName, value); }
		}

		private string _lastName;
		public string LastName
		{
			get { return _lastName; }
			set { SetProperty(ref _lastName, value); }
		}

		private DateTime _lastUpdated;
		public DateTime LastUpdated
		{
			get { return _lastUpdated; }
			set { SetProperty(ref _lastUpdated, value); }
		}

		private IEventAggregator _eventAggregator;

		public DelegateCommand UpdateCommand { get; set; }

		public PersonViewAViewModel(IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;

			UpdateCommand = new DelegateCommand(Execute, CanExecute)
				.ObservesProperty(() => FirstName)
				.ObservesProperty(() => LastName);

			PersonInfo person = PersonInfo.GetPerson(2);

			Id = person.Id;
			FirstName = person.FirstName;
			LastName = person.LastName;
			LastUpdated = person.LastUpdated;
      Title = "View A";
		}

		private bool CanExecute()
		{
			return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName);
		}

		private void Execute()
		{
			LastUpdated = DateTime.Now;

			_eventAggregator.GetEvent<UpdateCommand>().Publish($"Updated @ {LastUpdated.ToString()}");
		}

    public override bool IsNavigationTarget(NavigationContext navigationContext) {
      // By setting this to false, several tabs of the same view can be opened
      return false;
    }

    public override void OnNavigatedFrom(NavigationContext navigationContext) {
      base.OnNavigatedFrom(navigationContext);
    }
  }
}

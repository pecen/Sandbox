using ModuleA.Business;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ModuleA.ViewModels
{
    public class PersonListViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        private IRegionNavigationJournal _journal;

        public DelegateCommand<Person> PersonSelectedCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; set; }

        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        public PersonListViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            PersonSelectedCommand = new DelegateCommand<Person>(PersonSelected);
            GoForwardCommand = new DelegateCommand(GoForward, CanGoForward);

            CreatePeople();
        }

        private bool CanGoForward()
        {
            return _journal != null && _journal.CanGoForward;
        }

        private void GoForward()
        {
            _journal.GoForward();
        }

        private void PersonSelected(Person person)
        {
            if (person == null) return;

            var p = new NavigationParameters();
            p.Add("person", person);

            //_regionManager.RequestNavigate("PersonDetailsRegion", "PersonDetail", p);
            _regionManager.RequestNavigate("ContentRegion", "PersonDetail", p);
        }

        //demo code only, use a service in production code
        private void CreatePeople()
        {
            var people = new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++)
            {
                people.Add(new Person()
                {
                    FirstName = $"First {i}",
                    LastName = $"Last {i}",
                    Age = i
                });
            }

            people.Add(new Person()
            {
                FirstName = "First 10",
                LastName = "Last 1",
                Age = 33
            });

            People = people;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
            GoForwardCommand.RaiseCanExecuteChanged();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}

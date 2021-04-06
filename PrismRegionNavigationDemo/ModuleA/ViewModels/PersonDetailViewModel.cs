using ModuleA.Business;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleA.ViewModels
{
    public class PersonDetailViewModel : BindableBase, INavigationAware
    {
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
        }

        public PersonDetailViewModel()
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var person = navigationContext.Parameters.GetValue<Person>("person");

            if(SelectedPerson.FirstName == person.FirstName && SelectedPerson.LastName == person.LastName)
            {
                return true;
            }

            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("person"))
            {
                SelectedPerson = navigationContext.Parameters.GetValue<Person>("person");
            }
        }
    }
}

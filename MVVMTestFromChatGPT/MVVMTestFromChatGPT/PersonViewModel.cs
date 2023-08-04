using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMTestFromChatGPT
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private PersonModel _person;

        public PersonModel Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand SaveOneCommand { get; }

        public PersonViewModel()
        {
            Person = new PersonModel();
            //SaveCommand = new RelayCommand(o => Save());
            SaveCommand = new RelayCommand(Save);
            //SaveOneCommand = new RelayCommand<object>(SaveOne);
        }

        private void SaveOne(object obj)
        {
            throw new NotImplementedException();
        }

        private void Save()
        {
            // Här kan du implementera logik för att spara personuppgifterna
            // till exempel genom att anropa en tjänst eller uppdatera en databas.
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleA.ViewModels
{
    public class TabViewModel : ViewModelBase
    {
        public DelegateCommand UpdateCommand { get; private set; }

        //private string _title;
        //public string Title
        //{
        //    get { return _title; }
        //    set { SetProperty(ref _title, value); }
        //}

        private bool _canUpdate = false;

        public bool CanUpdate
        {
            get { return _canUpdate; }
            set { SetProperty(ref _canUpdate, value); }
        }

        private string _updatedText;

        public string UpdatedText
        {
            get { return _updatedText; }
            set { SetProperty(ref _updatedText, value); }
        }


        public TabViewModel()
        {
            Title = "View A";

            UpdateCommand = new DelegateCommand(Update)
                .ObservesCanExecute(() => CanUpdate);
        }

        private void Update()
        {
            UpdatedText = $"Updated: {DateTime.Now}";
        }
    }
}

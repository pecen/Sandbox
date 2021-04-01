using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : ViewModelBase
    {
        public DelegateCommand ClickCommand { get; private set; }

        //private string _title;

        //public string Title
        //{
        //    get { return _title; }
        //    set { SetProperty(ref _title, value); }
        //}

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private bool _canExecute = false;

        public bool CanExecute
        {
            get { return _canExecute; }
            set 
            { 
                SetProperty(ref _canExecute, value); 

                // Manually force the UI to re-evaluate its binding
                //ClickCommand.RaiseCanExecuteChanged();
            }
        }


        public ViewAViewModel()
        {
            Message = "View A from your Prism Module";
            Title = "View A";

            // Automatically observes the specified property, in this case CanExecute,
            // and re-evaluates its binding
            //ClickCommand = new DelegateCommand(Click, CanClick)
            //  .ObservesProperty(() => CanExecute);

            // Automatically observes the CanExecute property, and we can remove the 
            // second parameter of the DelegateCommand
            ClickCommand = new DelegateCommand(Click)
                .ObservesCanExecute(() => CanExecute);

        }

        // We don't need this method when we use the ObservesCanExecute()
        //private bool CanClick()
        //{
        //    return CanExecute;
        //}

        private void Click()
        {
            Message = "You clicked me";
        }
    }
}

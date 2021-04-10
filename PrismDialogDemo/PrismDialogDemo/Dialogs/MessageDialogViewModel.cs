using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDialogDemo.Dialogs
{
    public class MessageDialogViewModel : BindableBase, IDialogAware
    {
        public event Action<IDialogResult> RequestClose;

        public DelegateCommand CloseDialogCommand { get; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public string Title => "My Message Dialog";

        public MessageDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand(CloseDialog);
        }

        private void CloseDialog()
        {
            var result = ButtonResult.OK;
            var p = new DialogParameters();

            p.Add("myParam", "The dialog was closed by the user");

            RequestClose?.Invoke(new DialogResult(result, p));
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
        }
    }
}

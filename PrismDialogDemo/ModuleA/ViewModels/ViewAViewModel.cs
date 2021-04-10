using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;

        public DelegateCommand ShowDialogCommand { get; }

        private string _messageReceived;
        public string MessageReceived
        {
            get { return _messageReceived; }
            set { SetProperty(ref _messageReceived, value); }
        }

        public ViewAViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            ShowDialogCommand = new DelegateCommand(ShowDialog);
        }

        private void ShowDialog()
        {
            var p = new DialogParameters();

            p.Add("message", "This is a test message."); 

            _dialogService.ShowDialog("MessageDialog", p, result =>
            {
                if(result.Result == ButtonResult.OK)
                {
                    MessageReceived = result.Parameters.GetValue<string>("myParam");
                }
                else
                {
                    MessageReceived = "Okay button not clicked";
                }
            });
        }
    }
}

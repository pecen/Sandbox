using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDialogDemo.Core.Extensions.Dialogs
{
    public static class DialogServiceExtensions
    {
        public static void ShowMessageDialog(this IDialogService dialogService, string message, Action<IDialogResult> callBack)
        {
            var p = new DialogParameters
            {
                { "message", message }
            };

            dialogService.ShowDialog("MessageDialog", p, callBack);
        }
    }
}

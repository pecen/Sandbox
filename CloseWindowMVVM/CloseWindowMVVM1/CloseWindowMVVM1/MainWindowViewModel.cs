using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseWindowMVVM1
{
    public interface ICloseWindow
    {
        Action Close { get; set; }
        bool CanClose();
    }

    public class MainWindowViewModel : ICloseWindow
    {
        private DelegateCommand _closeCommand;

        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));

        public Action Close { get; set; }

        public bool CanClose()
        {
            return true;
        }

        private void CloseWindow()
        {
            Close?.Invoke();
        }
    }
}

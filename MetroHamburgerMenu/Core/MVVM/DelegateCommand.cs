using System.Windows.Input;

namespace MetroHamburgerMenu.Core.MVVM
{
    public class DelegateCommand : ICommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action executeMethod)
           //: this(executeMethod, null)
           : this(executeMethod, () => true)
        {
            _execute = executeMethod;
        }

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = executeMethod;
            _canExecute = canExecuteMethod;
        }

        public bool CanExecute()
        {
            return _canExecute();
        }

        public void Execute()
        {
            _execute();
        }

        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        public void Execute(object parameter)
        {
            Execute();
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        private readonly Func<T, bool> _canExecute;
        private readonly Action<T> _execute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<T> executeMethod)
           //: this(executeMethod, null)
           : this(executeMethod, (T o) => true)
        {
            _execute = executeMethod;
        }

        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = executeMethod;
            _canExecute = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}

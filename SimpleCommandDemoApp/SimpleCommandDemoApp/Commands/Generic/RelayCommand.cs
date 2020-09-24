using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleCommandDemoApp.Commands.Generic {
  public class RelayCommand : ICommand {
    public event EventHandler CanExecuteChanged;

    private readonly Action commandTask;

    public RelayCommand(Action workToDo) {
      commandTask = workToDo;
    }

    public bool CanExecute(object parameter) {
      return true;
    }

    public void Execute(object parameter) {
      commandTask();
    }
  }
}

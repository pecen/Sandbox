using SimpleCommandDemoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleCommandDemoApp.Commands.Specific {
  public class PlusCommand : ICommand {
    public event EventHandler CanExecuteChanged;

    private CalculatorViewModel calculatorViewModel;

    public PlusCommand(CalculatorViewModel vm) {
      calculatorViewModel = vm;
    }

    public bool CanExecute(object parameter) {
      return true;
    }

    public void Execute(object parameter) {
      calculatorViewModel.Add();
    }
  }
}

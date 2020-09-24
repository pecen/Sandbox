using SimpleCommandDemoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleCommandDemoApp.Commands.Specific {
  public class DivisionCommand : ICommand {
    public event EventHandler CanExecuteChanged;

    private CalculatorViewModel calculatorViewModel;

    public DivisionCommand(CalculatorViewModel vm) {
      calculatorViewModel = vm;
    }

    public bool CanExecute(object parameter) {
      return true;
    }

    public void Execute(object parameter) {
      calculatorViewModel.Divide();
    }
  }
}

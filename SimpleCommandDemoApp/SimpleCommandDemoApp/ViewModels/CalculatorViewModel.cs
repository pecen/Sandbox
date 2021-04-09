using SimpleCommandDemoApp.Commands.Generic;
using SimpleCommandDemoApp.Commands.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleCommandDemoApp.ViewModels {
  public class CalculatorViewModel : ViewModelBase {
    //private readonly PlusCommand plusCommand;
    //private MinusCommand minusCommand;
    //private MultiplicationCommand multiplicationCommand;
    //private DivisionCommand divisionCommand;

    public CalculatorViewModel() {
      //plusCommand = new PlusCommand(this);
      //minusCommand = new MinusCommand(this);
      //multiplicationCommand = new MultiplicationCommand(this);
      //divisionCommand = new DivisionCommand(this);
    }

    private double _firstValue;
    public double FirstValue {
      get { return _firstValue; }
      set {
        _firstValue = value;
      }
    }

    private double _secondValue;
    public double SecondValue {
      get { return _secondValue; }
      set {
        _secondValue = value;
      }
    }

    private double _output;

    public double Output {
      get { return _output; }
      set {
        _output = value;
        OnPropertyChanged(nameof(Output));
      }
    }

    public ICommand AddCommand {
      get {
        //return plusCommand;
        return new RelayCommand(Add);
      }
    }

    public ICommand SubtractCommand {
      get {
        //return minusCommand;
        return new RelayCommand(Subtract);
      }

    }

    public ICommand MultiplyCommand {
      get {
        //return multiplicationCommand;
        return new RelayCommand(Multiply);
      }
    }

    public ICommand DivideCommand {
      get {
        //return divisionCommand;
        return new RelayCommand(Divide);
      }
    }

    internal void Add() {
      Output = FirstValue + SecondValue;
    }

    internal void Subtract() {
      Output = FirstValue - SecondValue;
    }

    internal void Multiply() {
      Output = FirstValue * SecondValue;
    }

    internal void Divide() {
      Output = Math.Round(FirstValue / SecondValue, 4);
    }
  }
}

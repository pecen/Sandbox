using System;
using Prism.Commands;
using Prism.Events;
using SimpleCommandDemoApp.Module.Commands;

namespace SimpleCommandDemoApp.Module.ViewModels {
  public class CalculatorViewModel : ViewModelBase {
    private readonly IEventAggregator _eventAggregator;

    public DelegateCommand AddCommand { get; set; }
    public DelegateCommand SubtractCommand { get; set; }
    public DelegateCommand MultiplyCommand { get; set; }
    public DelegateCommand DivideCommand { get; set; }

    private double _firstValue;
    public double FirstValue {
      get { return _firstValue; }
      set { SetProperty(ref _firstValue, value); }
    }

    private double _secondValue;
    public double SecondValue {
      get { return _secondValue; }
      set { SetProperty(ref _secondValue, value); }
    }

    private double _output;
    public double Output {
      get { return _output; }
      set { SetProperty(ref _output, value); }
    }

    public CalculatorViewModel(IEventAggregator eventAggregator) {
      _eventAggregator = eventAggregator;

      AddCommand = new DelegateCommand(Add);
      SubtractCommand = new DelegateCommand(Subtract);
      MultiplyCommand = new DelegateCommand(Multiply);
      DivideCommand = new DelegateCommand(Divide, CanExecuteDiv)
        .ObservesProperty(() => SecondValue);

      _eventAggregator.GetEvent<CalculateCommand>().Subscribe(ValueReceived);
    }

    private bool CanExecuteDiv() {
      return SecondValue != 0;
    }

    private void ValueReceived(double obj) => Output = obj;

    private void Add() {
      _eventAggregator.GetEvent<CalculateCommand>().Publish(FirstValue + SecondValue);
    }

    private void Subtract() {
      _eventAggregator.GetEvent<CalculateCommand>().Publish(FirstValue - SecondValue);
    }

    private void Multiply() {
      _eventAggregator.GetEvent<CalculateCommand>().Publish(FirstValue * SecondValue);
    }

    private void Divide() {
      _eventAggregator.GetEvent<CalculateCommand>().Publish(Math.Round(FirstValue / SecondValue, 4));
    }
  }
}

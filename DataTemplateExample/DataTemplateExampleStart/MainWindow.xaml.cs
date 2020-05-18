using System.Collections.ObjectModel;
using System.Windows;

namespace DataTemplateExampleStart {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    SampleData sdata = new SampleData();

    public MainWindow() {
      InitializeComponent();
      //DataContext = this;
      
      // Add this line to the Window element instead of this.DataContext here...
      // DataContext="{Binding RelativeSource={RelativeSource Self}}" 

    }

    public ObservableCollection<Employee> Employees { get { return sdata.EmployeeList; } }
  }
}

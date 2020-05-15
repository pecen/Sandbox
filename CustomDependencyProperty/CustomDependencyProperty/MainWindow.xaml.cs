using System.Windows;

namespace CustomDependencyProperty {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void bkgColor_Click(object sender, RoutedEventArgs e) {
      if (chkBkgColor.IsChecked.Value == true) {
        myStack.IsBrownBkgrd = true;
      }
      else {
        myStack.IsBrownBkgrd = false;
      }
    }
  }
}

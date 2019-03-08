using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CloseableTabControl {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      AddHandler(CloseableTabItem.CloseTabEvent, new RoutedEventHandler(CloseTab));
    }

    private void CloseTab(object sender, RoutedEventArgs e) {
      var tabItem = e.Source as TabItem;
      if(tabItem == null) {
        if (tabItem.Parent is TabControl tabControl) {
          tabControl.Items.Remove(tabItem);
        }
      }
    }

    private void BtnAdd_Click(object sender, RoutedEventArgs e) {
      CloseableTabItem tabItem = new CloseableTabItem {
        Header = "New Tab"
      };
      MainTab.Items.Add(tabItem);
    }
  }
}

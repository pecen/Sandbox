using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismUnityApp.Module.Controls {
  public class TabClosingEventArgs : RoutedEventArgs {
    public bool Cancel { get; set; }
  }
}

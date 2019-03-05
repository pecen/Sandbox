using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismUnityApp.Module.Controls {
  public class TabControlEx : TabControl {
    protected override DependencyObject GetContainerForItemOverride() {
      return new TabItemEx();
    }
  }
}

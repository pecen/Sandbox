using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismUnityApp.Module.Controls {
  public class TabItemEx : TabItem {
    public static readonly RoutedEvent ClosingEvent = EventManager.RegisterRoutedEvent(
        "Closing", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabItemEx));

    public static readonly RoutedEvent ClosedEvent = EventManager.RegisterRoutedEvent(
        "Closed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabItemEx));

    // Provide CLR accessors for the event
    public event RoutedEventHandler Closing {
      add { AddHandler(ClosingEvent, value); }
      remove { RemoveHandler(ClosingEvent, value); }
    }

    // Provide CLR accessors for the event
    public event RoutedEventHandler Closed {
      add { AddHandler(ClosedEvent, value); }
      remove { RemoveHandler(ClosedEvent, value); }
    }

    // This method raises the Closing event
    void RaiseClosingEvent() {
      RoutedEventArgs newEventArgs = new RoutedEventArgs(TabItemEx.ClosingEvent);
      RaiseEvent(newEventArgs);
    }

    // This method raises the Closing event
    void RaiseClosedEvent() {
      RoutedEventArgs newEventArgs = new RoutedEventArgs(TabItemEx.ClosedEvent);
      RaiseEvent(newEventArgs);
    }
  }
}

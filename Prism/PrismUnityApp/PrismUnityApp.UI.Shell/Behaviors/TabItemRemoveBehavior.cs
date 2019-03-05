using Prism.Regions;
using PrismUnityApp.Module.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace PrismUnityApp.UI.Shell.Behaviors
{
    public class TabItemRemoveBehavior : Behavior<TabControl>
    {
    protected override void OnAttached() {
      base.OnAttached();
      AssociatedObject.AddHandler(TabItemEx.ClosingEvent, new RoutedEventHandler(TabItem_Closing));
      AssociatedObject.AddHandler(TabItemEx.ClosedEvent, new RoutedEventHandler(TabItem_Closed));
    }

    protected override void OnDetaching() {
      base.OnDetaching();
    }

    void TabItem_Closing(object sender, RoutedEventArgs e) {
      IRegion region = RegionManager.GetObservableRegion(AssociatedObject).Value;
      if (region == null)
        return;

      var args = (TabClosingEventArgs)e;

      args.Cancel = !CanRemoveItem(GetItemFromTabItem(args.OriginalSource), region);
    }

    void TabItem_Closed(object sender, RoutedEventArgs e) {
      IRegion region = RegionManager.GetObservableRegion(AssociatedObject).Value;
      if (region == null)
        return;

      RemoveItemFromRegion(GetItemFromTabItem(e.OriginalSource), region);
    }

    object GetItemFromTabItem(object source) {
      var tabItem = source as TabItemEx;
      if (tabItem == null)
        return null;

      return tabItem.Content;
    }

    bool CanRemoveItem(object item, IRegion region) {
      bool canRemove = true;

      var context = new NavigationContext(region.NavigationService, null);

      if (item is IConfirmNavigationRequest confirmRequestItem) {
        confirmRequestItem.ConfirmNavigationRequest(context, result => {
          canRemove = result;
        });
      }

      if (item is FrameworkElement frameworkElement && canRemove) {
        if (frameworkElement.DataContext is IConfirmNavigationRequest confirmRequestDataContext) {
          confirmRequestDataContext.ConfirmNavigationRequest(context, result => {
            canRemove = result;
          });
        }
      }

      return canRemove;
    }

    void RemoveItemFromRegion(object item, IRegion region) {
      var context = new NavigationContext(region.NavigationService, null);

      InvokeOnNavigatedFrom(item, context);

      region.Remove(item);
    }

    void InvokeOnNavigatedFrom(object item, NavigationContext navigationContext) {
      if (item is INavigationAware navigationAwareItem) {
        navigationAwareItem.OnNavigatedFrom(navigationContext);
      }

      if (item is FrameworkElement frameworkElement) {
        if (frameworkElement.DataContext is INavigationAware navigationAwareDataContext) {
          navigationAwareDataContext.OnNavigatedFrom(navigationContext);
        }
      }
    }
  }
}

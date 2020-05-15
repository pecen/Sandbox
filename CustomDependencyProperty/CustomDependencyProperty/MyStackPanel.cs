using System.Windows;
using System.Windows.Controls;

namespace CustomDependencyProperty {
  // This class derives from StackPanel to create a new StackPanel control that adds the property
  // IsBrownBkgrd
  class MyStackPanel : StackPanel {
    // This is how you start with defining the DependencyProperty. In this case we have the first
    // parameter which is the name of the property, then we have the type, the class name where 
    // it's defined, and then the PropertyMetaData which in this case sets a default value to false,
    // defines the delegate which defines what happens, and the callback method for verification.
    public static DependencyProperty IsBrownBkgrdProperty = DependencyProperty
        .Register("IsBrownBkgrd", typeof(bool), typeof(MyStackPanel), new PropertyMetadata(false, OnIsBrownBkgrdChanged, CoerceIsBrownBkgrdChanged));

    // This is our created new property, ready to be used in the Xaml code. 
    public bool IsBrownBkgrd {
      get { return (bool)GetValue(IsBrownBkgrdProperty); }
      set { SetValue(IsBrownBkgrdProperty, value); }
    }

    // Here we create a coerce value callback. This call from the 3rd parameter in PropertyMedadata 
    // above is where we can verify or constrain values that are being assigned to our dependency 
    // property. The callback implementation code is called from within the SetValue method. 
    private static object CoerceIsBrownBkgrdChanged(DependencyObject d, object baseValue) {
      var msp = d as MyStackPanel;

      if (msp.IsBrownBkgrd == false) {
        MessageBox.Show("The IsBrownBkgrd depdendency property is being changed to true");
        return true;
      }
      else {
        MessageBox.Show("The IsBrownBkgrd depdendency property is being changed to false");
        return false;
      }
    }

    // This is what takes place when the property is set, i.e. when "IsBrownBkgrd" is set to either "true"
    // or "false", this method is hit, and after the coerce value callback method above is called. 
    private static void OnIsBrownBkgrdChanged(DependencyObject source, DependencyPropertyChangedEventArgs e) {
      var msp = source as MyStackPanel;

      if (msp.IsBrownBkgrd == true) {
        msp.Background = System.Windows.Media.Brushes.BurlyWood;
      }
      else {
        msp.Background = System.Windows.Media.Brushes.LightGray;
      }
    }
  }
}

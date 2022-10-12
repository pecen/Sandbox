using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CloseWindowMVVM2
{
    public interface ICloseWindow
    {
        Action Close { get; set; }
        //bool CanClose();
    }

    public class MainWindowViewModel : ICloseWindow
    {
        private DelegateCommand _closeCommand;

        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));

        public Action Close { get; set; }

        //public bool CanClose()
        //{
        //    return false;
        //}

        private void CloseWindow()
        {
            Close?.Invoke();
        }
    }

    public class WindowCloser
    {


        public static bool GetEnableWindowClosing(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableWindowClosingProperty);
        }

        public static void SetEnableWindowClosing(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableWindowClosingProperty, value);
        }

        // Using a DependencyProperty as the backing store for EnableWindowClosing.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnableWindowClosingProperty =
            DependencyProperty.RegisterAttached("EnableWindowClosing", typeof(bool), typeof(WindowCloser), new PropertyMetadata(false, OnEnabledWindowClosingChanged));

        private static void OnEnabledWindowClosingChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (d is Window window)
            {
                window.Loaded += (s, e) =>
                {
                    if (window.DataContext is ICloseWindow vm)
                    {
                        vm.Close += () =>
                        {
                            window.Close();
                        };

                        //window.Closing += (t, u) =>
                        //{
                        //    u.Cancel = !vm.CanClose();
                        //};
                    }
                };
            }
        }
    }
}

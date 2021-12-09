using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLayeredDrawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly DependencyProperty RulerThicknessProperty = DependencyProperty.Register(
            "RulerThicknessProperty", typeof(Thickness), typeof(MainWindow),
            new PropertyMetadata(new Thickness(1), OnRulerThicknessChanged));

        public Thickness RulerThickness
        {
            get => (Thickness)GetValue(RulerThicknessProperty);
            set => SetValue(RulerThicknessProperty, value);
        }

        private static void OnRulerThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int i = 0;

            var rt = d as MainWindow;

            if (rt != null)
            {
                //RulerThicknessProperty = new Thickness(DraggableMouseOverThicknessProperty);
                //rt.RulerThickness = (Thickness)e.NewValue;
                rt.OnPropertyChanged(new DependencyPropertyChangedEventArgs(RulerThicknessProperty, e.OldValue, e.NewValue));
                rt.PropertyChanged?.Invoke(rt, new PropertyChangedEventArgs(nameof(RulerThickness)));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            m_layers.AddLayer(10, DrawBackground, ChangeType.Resize);
            m_layers.AddLayer(11, DrawBackgroundBlock);

            m_layers.AddLayer(20, DrawStaticForeground);
            m_layers.AddTextLayer(21, DrawText, ChangeType.Scroll);
            //m_layers.AddTextLayer(21, DrawText, ChangeType.Scroll);
            //m_layers.AddTextLayer(22, DrawText, ChangeType.Scroll);

            m_layers.AddLayer(30, DrawForeground);

            m_layers.AddLayer(40, DrawLeftArrow);

            Draw(ChangeType.Redraw);
        }

        private void DrawText(DrawingContext ctx, Fonts font)
        {
            var pen = new Pen(Brushes.Black, 1);
            var rect = new Rect(20, m_scroll.Value, 15, 25);
            ctx.DrawRectangle(Brushes.Teal, pen, rect);

            // Obsolete

            //var txt = new FormattedText(
            //    "qazwsxedcrfvtgbyhnujmik,ol.p;/[']\r\nqwertyuiop\r\n\r\nasdfghjkl\r\nzxcvbnm\r\n0987654321",
            //    CultureInfo.GetCultureInfo("en-us"),
            //    FlowDirection.LeftToRight,
            //    new Typeface("Consolas"),
            //    14,
            //    Brushes.White);

            var txt = new FormattedText(
                "qazwsxedcrfvtgbyhnujmik,ol.p;/[']\r\nqwertyuiop\r\n\r\nasdfghjkl\r\nzxcvbnm\r\n0987654321",
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Consolas"),
                24,
                Brushes.White,
                VisualTreeHelper.GetDpi(this).PixelsPerDip);

            txt.SetFontFamily(GetResource<FontFamily>(font.ToString()));

            ctx.DrawText(txt, new Point(20, m_scroll.Value));

            Log("text");
        }

        private void DrawBackground(DrawingContext ctx)
        {
            var pen = new Pen(Brushes.Black, 1);
            var rect = new Rect(0, 0, m_layers.ActualWidth, m_layers.ActualHeight);
            ctx.DrawRoundedRectangle(Brushes.Black, pen, rect, 50, 50);

            Log("background");
        }

        private void DrawBackgroundBlock(DrawingContext ctx)
        {
            var pen = new Pen(Brushes.DarkOliveGreen, 1);
            var rect = new Rect(20, 60, 200, 50);
            ctx.DrawRoundedRectangle(Brushes.DarkOliveGreen, pen, rect, 50, 50);

            Log("background block");
        }

        private void DrawLeftArrow(DrawingContext ctx)
        {
            var v = new Viewbox
            {
                Width = 13,
                Height = 13,
                Margin = new Thickness(50, 100, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Uniform
            };

            //var g = Geometry.Parse("M 0 0 4 4 0 8");
            //g.Freeze();

            var g = GetResource<Geometry>("LeftArrowGeometry");

            var p = new Path
            {
                Margin = new Thickness(0),
                VerticalAlignment = VerticalAlignment.Top,
                StrokeThickness = 1.5
            };

            p.Stroke = GetResource<SolidColorBrush>(ChartColors.BlackBrush.ToString());
            p.Data = g;

            //var pfc = new PathFigureCollection(new List<PathFigure>());
            //pfc.Add(new PathFigure())
            //var pg = new PathGeometry
            //{
            //    FillRule = FillRule.Nonzero,
            //    Figures = "M 0 0 4 4 0 8";
            //}
            //Geometry geometry = new Geometry();

            v.Child = p;

            //ctx.DrawGeometry(Brushes.DeepPink, new Pen(Brushes.Black, 1), (v.Child as Path).Data);

            var path = v.Child as Path;
            //if (path?.Children == null) return;
            //foreach (UIElement child in path..Children)
            //if (child is Path path)
            //{
            //path.Data.Transform = transform;
            ctx.DrawGeometry(Brushes.Black, new Pen(Brushes.Black, 1), path.Data);
            //}
            
        }

        public SolidColorBrush GetBrush(string name)
        {
            try
            {
                var brush = GetResource<SolidColorBrush>(name);

                if (brush == null)
                    return GetResource<SolidColorBrush>(ChartColors.BlackBrush.ToString());

                return brush;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetResource<T>(string name)
        {
            return (T)Application.Current.TryFindResource(name);
        }


        private void DrawForeground(DrawingContext ctx)
        {
            var pen = new Pen(Brushes.Black, 1);
            var rect = new Rect(20, 20, 50, 55);
            ctx.DrawRectangle(Brushes.Red, pen, rect);

            Log("foreground");
        }

        private void DrawStaticForeground(DrawingContext ctx)
        {
            var pen = new Pen(Brushes.Black, 1);
            var rect = new Rect(70, 20, 100, 100);
            ctx.DrawRectangle(Brushes.Blue, pen, rect);

            Log("foreground");
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            m_scroll.Minimum = 0;
            m_scroll.Maximum = m_layers.ActualHeight - 70;
            Draw(ChangeType.Resize);
        }

        private void OnScroll(object sender, ScrollEventArgs e)
        {
            Draw(ChangeType.Scroll);
        }

        private void Draw(ChangeType change)
        {
            m_layers.Draw(change);
        }

        private void Log(string text)
        {
            m_log.Text = text + "\r\n" + m_log.Text;

            if (m_log.Text.Length > 1000)
            {
                m_log.Text = m_log.Text.Substring(0, 1000);
            }
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            RulerThickness = new Thickness(5);
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            RulerThickness = new Thickness(1);
        }
    }
}

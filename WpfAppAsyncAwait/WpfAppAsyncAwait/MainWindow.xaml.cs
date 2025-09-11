using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppAsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 🔴 Synkron knapp - fryser UI i 5 sekunder
        private void SyncButton_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Arbetar (synkront)...";

            // Blockerar UI-tråden
            Thread.Sleep(5000);

            StatusText.Text = "Klar (synkront)";
        }

        // 🟢 Asynkron knapp - UI fortsätter svara
        private async void AsyncButton_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Arbetar (asynkront)...";

            // Väntar 5 sek men UI är fortfarande responsivt
            await Task.Delay(5000);

            StatusText.Text = "Klar (asynkront)";
        }
    }
}
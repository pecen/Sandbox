using DISimpleSample.DI;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using static System.Console;

namespace DISimpleSample
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    ShowMenu();

                    var input = ReadLine();

                    switch (input)
                    { //ReadKey().KeyChar) {
                        case "1": Charge(); break;
                        case "2": CreateReport(); break;
                        case "3": PrintReport(); break;
                        case "4": SavePayment(); break;
                        case "0": WriteLine(); return;

                        default: ShowMenu(); break;
                    }
                }
                catch (Exception ex)
                {
                    WriteLine();
                    WriteLine("There was an error: ");
                    while (ex != null)
                    {
                        WriteLine(ex.Message);
                        ex = ex.InnerException;
                    }
                }

                WriteLine();
                WriteLine("Press <ENTER> to return to menu.");
                ReadLine();
            }
        }

        private static void InitializeRepo()
        {
            SimpleIOC ioc = new SimpleIoC();
            ioc.Register<MainViewModel, MainViewModel>();
            ioc.Register<ICustomer, Customer>();
            ioc.Register<ICustomerRepository, CustomerRepository>();
            ioc.Register<IDbGateway, DbGateway>();

            var mainViewModel = ioc.Resolve<MainViewModel>();
        }

        private static void Charge()
        {
            MessageBox.Show("Charging...");
        }

        private static void CreateReport()
        {
            MessageBox.Show("Creating Report...");
        }

        private static void PrintReport()
        {
            PrintDialog p = new PrintDialog();
            p.PageRangeSelection = PageRangeSelection.AllPages;
            p.UserPageRangeEnabled = true;

            // Display the dialog. This returns true if the user presses the Print button.
            bool? print = p.ShowDialog();
            if (print == true)
            {
                XpsDocument xpsDocument = new XpsDocument("C:\\FixedDocumentSequence.xps", FileAccess.ReadWrite);
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
                p.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");

                MessageBox("The report was printed");
            }
            else
            {
                MessageBox.Show("Printing cancelled...");
            }
        }

        private static void SavePayment()
        {
            SaveFileDialog s = new SaveFileDialog();
            s.FileName = "TestPayment.txt";

            bool? save = s.ShowDialog();
            if (save == true)
            {
                var fileName = $@"C:\Temp\{s.FileName}_{Guid.NewGuid()}";

                using (var fs = File.OpenWrite(fileName))
                {
                    var payment = "The payment has been saved";
                    byte[] bytes = Encoding.UTF8.GetBytes(payment);
                    fs.Write(bytes, 0, bytes.Length);

                    MessageBox.Show($"The payment has been saved to {fileName}");
                }
            }
            else
            {
                MessageBox.Show("The save of the Payment was cancelled");
            }
        }

        public static void ShowMenu()
        {
            Clear();
            WriteLine("PREREQ:");
            WriteLine("1. Set first req here,");
            WriteLine("2. Set second req here");
            WriteLine("");
            WriteLine("- Select command.");
            WriteLine("");
            WriteLine(" 1) Charge for Service.");
            WriteLine(" 2) Create Report.");
            WriteLine(" 3) Print Report.");
            WriteLine(" 4) Save Payment");
            WriteLine(" 0) Exit");

            WriteLine("");
            Write(" > ");
        }
    }
}

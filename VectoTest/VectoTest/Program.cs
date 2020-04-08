using Microsoft.Win32;
using System;
using System.IO;
using static System.Console;

namespace VectoTest {
  public class Program {
    private static Stream XmlStream { get; set; }

    [STAThread]
    static void Main(string[] args) {
      //WriteLine($"Vecto version: {VectoApi.GetVectoCoreVersion()}");

      //GetFileDialog();

      //using (XmlReader xmlReader = XmlReader.Create(XmlStream)) {            //new StringReader(strVehicleXML)))

      //  var run = VectoApi.VectoInstance(xmlReader);

      //  ReadKey();
      //}

      while (true) {
        try {
          ShowMenu();

          switch (ReadKey().KeyChar) {
            case '1': ReadVecto(); break;
            case '2': Simulate(); break;
            case '3': SendResponse(); break;
            case '0': WriteLine(); return;

            default: ShowMenu(); break;
          }
        }
        catch (Exception ex) {
          WriteLine();
          WriteLine("There was an error: ");
          while (ex != null) {
            WriteLine(ex.Message);
            ex = ex.InnerException;
          }
        }

        WriteLine();
        WriteLine("Press <ENTER> to return to menu.");
        ReadLine();
      }
    }

    public static void ShowMenu() {
      Clear();
      WriteLine("PREREQ:");
      WriteLine("1. Set first req here,");
      WriteLine("2. Set second req here");
      WriteLine("");
      WriteLine("- Select Vecto command.");
      WriteLine("");
      WriteLine(" 1) Read files.");
      WriteLine(" 2) Simulate.");
      WriteLine(" 3) Send response.");
      WriteLine(" 0) Exit");

      WriteLine("");
      Write(" > ");
    }

    private static void ReadVecto() {
      GetFileDialog();

      var file = GetXml();

      using (CmdService cmdService = new CmdService("cmd.exe")) {
        string output = cmdService.ExecuteCommand(file);
        WriteLine(">>> {0}", output);
        ReadKey();
      }
    }

    private static void Simulate() {
      throw new NotImplementedException();
    }

    private static void SendResponse() {
      throw new NotImplementedException();
    }

    private static string GetXml() {
      using (StreamReader reader = new StreamReader(XmlStream)) {
        return reader.ReadToEnd();
      }
    }

    private static void GetFileDialog() {
      OpenFileDialog openFileDialog = new OpenFileDialog {
        Filter = "Xml files (*.xml)|*.xml|All files (*.*)|*.*",
        FilterIndex = 1,
        RestoreDirectory = true
      };

      if ((bool)openFileDialog.ShowDialog()) {
        XmlStream = openFileDialog.OpenFile();
      }
    }
  }
}

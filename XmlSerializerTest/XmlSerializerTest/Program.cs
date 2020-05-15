using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Console;

namespace XmlSerializerTest {
  class Program {
    static void Main(string[] args) {
      while (true) {
        try {
          ShowMenu();

          switch (ReadKey().KeyChar) {
            case '1': DeserializeArray(); break;
            case '2': SerializeCollection("Employees.xml"); break;
            //case '3': WriteMessages(); break;
            case '0': WriteLine(); return;

            default: ShowMenu(); break;
          }
        }
        catch (Exception ex) {
          WriteLine();
          WriteLine("There was an error: " + ex.Message);
          WriteLine();
          WriteLine("Press <ENTER> to return to menu.");
          ReadLine();
        }
      }
    }

    public static void ShowMenu() {
      Clear();
      WriteLine("PREREQ:");
      WriteLine("1. In - Out- and Processed filefolders are created,");
      WriteLine("and the path for each of them are defined in the config file.");
      WriteLine("2. The TEA Core files that should be processed and");
      WriteLine("extracted are put in the TEA Core In-message folder.");
      WriteLine("");
      WriteLine("- Select TEACore message command.");
      WriteLine("");
      WriteLine(" 1) Delete extracted TEA Core messages from Out-folder.");
      WriteLine(" 2) Delete processed TEA Core file(s) from Processed-folder.");
      WriteLine(" 3) Process TEA Core file(s) and extract the TEA Core messages.");
      WriteLine(" 0) Exit");

      WriteLine("");
      Write(" > ");
    }

    private static void SerializeCollection(string filename) {
      Employees Emps = new Employees();
      // Note that only the collection is serialized -- not the
      // CollectionName or any other public property of the class.
      Emps.CollectionName = "Employees";
      Employee John100 = new Employee("John", "100xxx");
      Emps.Add(John100);
      XmlSerializer x = new XmlSerializer(typeof(Employees));
      TextWriter writer = new StreamWriter(filename);
      x.Serialize(writer, Emps);
    }

    private static void DeserializeArray() {
      PurchaseOrder purchaseOrder;
      // Construct an instance of the XmlSerializer with the type  
      // of object that is being deserialized.  
      XmlSerializer mySerializer =
      new XmlSerializer(typeof(PurchaseOrder));
      // To read the file, create a FileStream.  
      FileStream myFileStream =
      new FileStream("PurchaseOrder.xml", FileMode.Open);
      // Call the Deserialize method and cast to the object type.  
      purchaseOrder = (PurchaseOrder)
      mySerializer.Deserialize(myFileStream);
    }
  }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConversionTest {
  class Program {
    static void Main(string[] args) {

      UnitConverter unitConverter = new UnitConverter();

      foreach (string s in File.ReadAllLines("Conversions.txt")) {
        if (s.IndexOf("?") == -1)
          unitConverter.ParseConverterDefinition(s);
        else
          Console.WriteLine(unitConverter.Convert(s));
      } // foreach

      Console.ReadKey();
    }
  }
}

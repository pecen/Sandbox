using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DelegateTest {
  class Program {
    static void Main(string[] args) {
      Stock stock = new Stock("THPW") {
        Price = 27.10m
      };

      stock.PriceChanged += Stock_PriceChanged;
      stock.Price = 31.50m;

      ReadKey();
    }

    private static void Stock_PriceChanged(object sender, PriceChangedEventArgs e) {
      var increase = (e.NewPrice - e.LastPrice) / e.LastPrice;
      if (increase >= 0.1m) {
        WriteLine("Alert, 10% or more stock price increase!");
      }
      else {
        WriteLine("Price increase less than 10%");
      }
      WriteLine($"Increase = {Math.Round(increase * 100, 2)}%");
    }
  }
}

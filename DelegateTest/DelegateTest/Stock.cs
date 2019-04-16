using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest {
  public class Stock {
    private readonly string _symbol;

    public Stock(string symbol) {
      _symbol = symbol;
    }

    public event EventHandler<PriceChangedEventArgs> PriceChanged;

    protected virtual void OnPriceChanged(PriceChangedEventArgs e) {
      PriceChanged?.Invoke(this, e);
    }

    private decimal price;
    public decimal Price {
      get { return price; }
      set {
        if (price == value) return;
        decimal oldPrice = price;
        price = value;
        OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
      }
    }
  }
}

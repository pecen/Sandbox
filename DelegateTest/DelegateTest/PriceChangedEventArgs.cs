using System;

namespace DelegateTest {
  public class PriceChangedEventArgs : EventArgs {
    public readonly decimal LastPrice;
    public readonly decimal NewPrice;

    public PriceChangedEventArgs(decimal lastPrice, decimal newPrice) {
      LastPrice = lastPrice;
      NewPrice = newPrice;
    }
  }
}

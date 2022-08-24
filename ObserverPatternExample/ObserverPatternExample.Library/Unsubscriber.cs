using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternExample.Library
{
    internal class Unsubscriber<BaggageInfo> : IDisposable
    {
        private IList<IObserver<BaggageInfo>> _observers;
        private IObserver<BaggageInfo> _observer;

        public Unsubscriber(IList<IObserver<BaggageInfo>> observers, IObserver<BaggageInfo> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}

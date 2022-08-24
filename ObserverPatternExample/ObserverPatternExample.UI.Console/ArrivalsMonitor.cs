using ObserverPatternExample.Library;
using System;
using System.Collections.Generic;
using static System.Console;

namespace ObserverPatternExample.UI.Console
{
    public class ArrivalsMonitor : IObserver<BaggageInfo>
    {
        private string _name;
        private List<string> _flightInfos = new List<string>();
        private IDisposable _cancellation;
        private string _fmt = "{0,-20} {1,5} {2,3}";

        public ArrivalsMonitor(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("The observer must be assigned a name.");
            }

            _name = name;
        }

        public virtual void Subscribe(BaggageHandler provider)
        {
            _cancellation = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            _cancellation.Dispose();
            _flightInfos.Clear();
        }

        public void OnCompleted()
        {
            _flightInfos.Clear();
        }

        // No implementation needed: Method is not called by the BaggageHandler class.
        public void OnError(Exception error)
        {
            // No implementation.
        }

        // Update information.
        public void OnNext(BaggageInfo info)
        {
            bool updated = false;

            // Flight has unloaded its baggage; remove from the monitor.
            if (info.Carousel == 0)
            {
                var flightsToRemove = new List<string>();
                string flightNo = $"{info.FlightNumber,5}";

                foreach (var flightInfo in _flightInfos)
                {
                    if (flightInfo.Substring(21, 5).Equals(flightNo))
                    {
                        flightsToRemove.Add(flightInfo);
                        updated = true;
                    }
                }

                foreach (var flightToRemove in flightsToRemove)
                {
                    _flightInfos.Remove(flightToRemove);
                }

                flightsToRemove.Clear();
            }
            else
            {
                // Add flight if it does not exist in the collection.
                //string flightInfo = $"{_fmt} {info.From} {info.FlightNumber} {info.Carousel}";
                string flightInfo = string.Format(_fmt, info.From, info.FlightNumber, info.Carousel);

                if (!_flightInfos.Contains(flightInfo))
                {
                    _flightInfos.Add(flightInfo);
                    updated = true;
                }
            }

            if (updated)
            {
                _flightInfos.Sort();
                WriteLine($"Arrivals information from {_name}");

                foreach(var flightInfo in _flightInfos)
                {
                    WriteLine(flightInfo);
                }

                WriteLine();
            }
        }
    }
}

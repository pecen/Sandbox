using System;
using System.Collections.Generic;

namespace ObserverPatternExample.Library
{
    public class BaggageInfo
    {
        private int flightNo;
        private string origin;
        private int location;

        internal BaggageInfo(int flight, string from, int carousel)
        {
            flightNo = flight;
            origin = from;
            location = carousel;
        }

        public int FlightNumber { get { return flightNo; } } 
        public string From { get { return origin; } }
        public int Carousel { get { return location; } }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator
{
    public class Tractor : Vehicle
    {
        public string GetVehicleType()
        {
            return CongestionTaxCalculator.TollFreeVehicles.Tractor.ToString();
        }
    }
}

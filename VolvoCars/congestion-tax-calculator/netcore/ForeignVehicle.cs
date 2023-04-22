using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace congestion.calculator
{
    public class ForeignVehicle : Vehicle
    {
        public string GetVehicleType()
        {
            return CongestionTaxCalculator.TollFreeVehicles.Foreign.ToString();
        }
    }
}

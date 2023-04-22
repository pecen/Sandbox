using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator
{
    public class MilitaryVehicle : Vehicle
    {
        public string GetVehicleType()
        {
            return CongestionTaxCalculator.TollFreeVehicles.Military.ToString();
        }
    }
}

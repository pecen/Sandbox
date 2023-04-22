using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator
{
    public class DiplomatVehicle : Vehicle
    {
        public string GetVehicleType()
        {
            return CongestionTaxCalculator.TollFreeVehicles.Diplomat.ToString();
        }
    }
}

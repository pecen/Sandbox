using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator
{
    public class EmergencyVehicle : Vehicle
    {
        public string GetVehicleType()
        {
            return CongestionTaxCalculator.TollFreeVehicles.Emergency.ToString();
        }
    }
}

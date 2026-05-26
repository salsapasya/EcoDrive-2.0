using EcoDrive_vol2.AbstractandInterface.Interface;
using System;

namespace EcoDrive_vol2.Models.Vehicles
{
    public class ElectricMotor : Kendaraan, IChargeable
    {
        public bool RequiresHelmet { get; set; }

        public void Plugin()
        {
            Status = "Charging";
        }

        public void Unplug()
        {
            Status = "Available";
        }
    }
}

using EcoDrive_vol2.AbstractandInterface.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models.Kendaraan.Kendaraan
{
    public class ElectricMotor : Kendaraan, IChargeable
    {
        public bool RequiresHelmet { get; set; }

        public override decimal BiayaRental(int jam)
        {
            decimal total = jam * HargaSewa;

            // Tambahkan biaya tambahan jika baterai sangat rendah
            if (BatteryPercentage <= 5)
            {
                total += 50000;
            }

            return total;
        }

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

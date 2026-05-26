using EcoDrive_vol2.AbstractandInterface.Interface;
using System;

namespace EcoDrive_vol2.Models.Vehicles
{
    public class ElectricCar : Kendaraan, IChargeable
    {
        public int PassengerLimit { get; set; }

        public decimal Biaya { get; set; }

        // Polymorphism
        public override decimal BiayaRental(int jam)
        {
            return (jam * HargaSewa) + Biaya;
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
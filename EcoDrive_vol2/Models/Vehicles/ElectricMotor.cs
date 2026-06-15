using EcoDrive_vol2.AbstractandInterface.Interface;
using System;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Vehicles
{
    // OOP (Inheritance): ElectricMotor turunan dari Kendaraan
    // OOP (Interface): Mengikat kontrak dengan IChargeable
    public class ElectricMotor : Kendaraan, IChargeable 
    {
        // IMPLEMENTASI INTERFACE ICHARGEABLE
        public void Plugin()
        {
            // Status diwarisi dari Kendaraan.cs
            Status = "mengisi daya";
        }

        public void Unplug()
        {
            Status = "selesai";
        }
    }
}
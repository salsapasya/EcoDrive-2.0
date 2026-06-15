using EcoDrive_vol2.AbstractandInterface.Interface;
using System;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Vehicles
{
    public class ElectricCar : Kendaraan, IChargeable  //INHERITANCE KARENA ADA TANDA : BERATI TU NUNJUKIN KL INI ANAK DARI KENDARAAN //ABSTRAC(IChargerable)
    {
        public int PassengerLimit { get; set; }

        public decimal Biaya { get; set; }

        public void Plugin()
        {
            StatusKendaraan = OptionStatus.dalam_perbaikan;
        }

        public void Unplug()
        {
            StatusKendaraan = OptionStatus.tersedia;
        }
    }
}
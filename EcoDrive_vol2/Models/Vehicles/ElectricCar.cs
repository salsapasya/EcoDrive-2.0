using EcoDrive_vol2.AbstractandInterface.Interface;
using System;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Vehicles
{
    public class ElectricCar : Kendaraan, IChargeable  //INHERITANCE KARENA ADA TANDA : BERATI TU NUNJUKIN KL INI ANAK DARI KENDARAAN //ABSTRAC(IChargerable)
    {
        public void Plugin()
        {
            Status = "mengisi daya";
        }

        public void Unplug()
        {
            Status = "selesai";
        }
    }
}
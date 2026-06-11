using EcoDrive_vol2.AbstractandInterface.Interface;
using System;

namespace EcoDrive_vol2.Models.Vehicles
{
    public class ElectricMotor : Kendaraan, IChargeable //INHERITANCE KARENA ADA TANDA : BERATI TU NUNJUKIN KL INI ANAK DARI KENDARAAN  //ABSTRAC(IChargerable)
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

//BISA DIKASI OVERRIDE KL BEDA RUMUS BIAYANYA SM YG ELECTRIC CAR
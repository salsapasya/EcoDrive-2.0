using EcoDrive_vol2.AbstractandInterface.Interface;
using System;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Vehicles
{
    public class ElectricMotor : Kendaraan, IChargeable //INHERITANCE KARENA ADA TANDA : BERATI TU NUNJUKIN KL INI ANAK DARI KENDARAAN  //ABSTRAC(IChargerable)
    {
        public bool RequiresHelmet { get; set; }

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

//BISA DIKASI OVERRIDE KL BEDA RUMUS BIAYANYA SM YG ELECTRIC CAR
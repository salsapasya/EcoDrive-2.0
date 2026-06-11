using System;

namespace EcoDrive.Models.Vehicles
{
    public class ChargingStation
    {
        public int IdChargingStation { get; set; }

        public string NamaStation { get; set; }  //ENCAP

        public string Lokasi { get; set; }

        public decimal BiayaCharging { get; set; } //ENCAP

        public int JumlahSlot { get; set; }
    }
}

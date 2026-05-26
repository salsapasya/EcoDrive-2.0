using System;

namespace EcoDrive.Models.Vehicles
{
    public class ChargingStation
    {
        public int IdChargingStation { get; set; }

        public string NamaStation { get; set; }

        public string Lokasi { get; set; }

        public decimal BiayaCharging { get; set; }

        public int JumlahSlot { get; set; }
    }
}

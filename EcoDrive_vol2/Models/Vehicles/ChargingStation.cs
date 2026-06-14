using System;

namespace EcoDrive.Models.Vehicles
{
    public class ChargingStation
    {
        public int IdChargingStation { get; set; }

        public string NamaStation { get; set; }  //ENCAP

        public string Lokasi { get; set; }

        public decimal TarifPer15Menit { get; set; }

        public int JumlahSlot { get; set; }
    }
}

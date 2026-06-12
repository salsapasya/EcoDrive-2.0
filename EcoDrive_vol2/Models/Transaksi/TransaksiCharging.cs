using System;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Transaksi
{
    public class TransaksiCharging
    {
        public int IdTransaksiCharging { get; set; } // get set itu encapsulation

        public int IdUser { get; set; }

        public int IdKendaraan { get; set; }

        public int IdChargingStation { get; set; }

        public decimal BiayaCharging { get; set; }

        public DateTime TanggalCharging { get; set; }

        public ChargingStatus StatusCharging { get; set; }

        public int DurasiCharging { get; set; }

        // kolom tambahan untuk menampilkan data di customer charging
        public string NamaStation { get; set; }
        public string NamaKendaraan { get; set; }
        public string NomorPlat { get; set; }
    }
}

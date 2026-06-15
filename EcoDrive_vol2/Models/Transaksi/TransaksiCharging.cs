using System;
using EcoDrive_vol2.AbstractandInterface.Abstract;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Transaksi
{
    // OOP (Inheritance): Anak dari AbsTransaksi
    public class TransaksiCharging : AbsTransaksi
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

        // OOP (Polymorphism - Constructor Overloading)
        // Khusus digunakan oleh Data Access Layer (ChargingContext) untuk memetakan data dari PostgreSQL
        public TransaksiCharging()
        {
        }

        // Constructor Berparameter
        // Khusus digunakan oleh Controller untuk membuat data baru / simulasi estimasi
        public TransaksiCharging(int idTransaksiCharging, int idUser, int idKendaraan, int idChargingStation,
                                 int durasiCharging, ChargingStatus statusCharging,
                                 string namaStation, string namaKendaraan, string nomorPlat)
        {
            this.IdTransaksiCharging = idTransaksiCharging;
            this.IdUser = idUser;
            this.IdKendaraan = idKendaraan;
            this.IdChargingStation = idChargingStation;
            this.DurasiCharging = durasiCharging;
            this.StatusCharging = statusCharging;
            this.NamaStation = namaStation;
            this.NamaKendaraan = namaKendaraan;
            this.NomorPlat = nomorPlat;
            this.TanggalCharging = DateTime.Now;

            // Trigger kalkulasi biaya otomatis khusus transaksi charging
            HitungBiaya();
        }

        // OOP (Polymorphism - Override): Logika Perhitungan Biaya Per 15 Menit
        public override void HitungBiaya()
        {
            this.BiayaCharging = (this.DurasiCharging / 15) * 50000;
        }
    }
}

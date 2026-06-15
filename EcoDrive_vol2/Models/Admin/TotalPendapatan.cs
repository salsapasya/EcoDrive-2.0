using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models.Admin
{
    // OOP (ENCAPSULATION)
    public class CardPendapatanModel 
    {
        public decimal TotalSewaTahunan { get; set; }
        public decimal TotalChargingTahunan { get; set; }
        public decimal TotalGabunganTahunan { get; set; }
        public long TotalUnitTahunan { get; set; }
        public long TotalBanyakChargingTahunan { get; set; }

        // Constructor Kosong: Diperlukan database agar tetap sinkron
        public CardPendapatanModel() { }

        // Constructor Berparameter: Proteksi Enkapsulasi Objek
        public CardPendapatanModel(decimal sewa, decimal charging, decimal gabungan, long unit, long banyakCharging)
        {
            if (sewa < 0 || charging < 0 || gabungan < 0 || unit < 0 || banyakCharging < 0)
                throw new ArgumentException("Data summary pendapatan tahunan tidak valid (negatif).");

            this.TotalSewaTahunan = sewa;
            this.TotalChargingTahunan = charging;
            this.TotalGabunganTahunan = gabungan;
            this.TotalUnitTahunan = unit;
            this.TotalBanyakChargingTahunan = banyakCharging;
        }
    }

    public class RincianPendapatanModel 
    {
        public DateTime TanggalHari { get; set; }
        public decimal PendapatanSewa { get; set; }
        public decimal PendapatanCharging { get; set; }
        public decimal TotalHarian { get; set; }

        // Constructor Kosong: Diperlukan database agar tetap sinkron
        public RincianPendapatanModel() { }

        // Constructor Berparameter: Proteksi Enkapsulasi Objek
        public RincianPendapatanModel(DateTime tanggal, decimal sewa, decimal charging, decimal total)
        {
            if (sewa < 0 || charging < 0 || total < 0)
                throw new ArgumentException("Data rincian pendapatan harian tidak valid (negatif).");

            this.TanggalHari = tanggal;
            this.PendapatanSewa = sewa;
            this.PendapatanCharging = charging;
            this.TotalHarian = total;
        }
    }
}

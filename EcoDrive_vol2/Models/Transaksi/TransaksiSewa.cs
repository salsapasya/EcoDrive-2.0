using System;
using EcoDrive_vol2.AbstractandInterface.Abstract;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Transaksi
{ 
    public class TransaksiSewa : AbsTransaksi
    {
        public int IdTransaksiSewa { get; set; }

        public int IdUser { get; set; }

        public int IdKendaraan { get; set; }

        public DateTime TanggalSewa { get; set; }

        public DateTime TanggalKembali { get; set; }

        public int DurasiSewa { get; set; }

        public decimal HargaPerHari { get; set; }

        public decimal TotalBiaya { get; set; }

        public StatusKembali StatusPengembalian { get; set; }

        // tambahan buat di pengembalian kendaraan
        public string NamaKendaraan { get; set; }
        public string NomorPlatKendaraan { get; set; }

        public override void HitungBiaya()
        {
            DurasiSewa = (TanggalKembali - TanggalSewa).Days;
            if (DurasiSewa < 1)
                DurasiSewa = 1; // Minimal 1 hari sewa
            TotalBiaya = DurasiSewa * HargaPerHari;
        }

        public override string DapatkanInfoTransaksi()
        {
            return $"Sewa Kendaraan ID: {IdKendaraan} selama {DurasiSewa} hari. Total: Rp {TotalBiaya:N0}";
        }
    }
}

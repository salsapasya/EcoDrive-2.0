using System;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Transaksi
{ 
    public class TransaksiSewa
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
    }
}

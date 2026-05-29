using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models.Admin
{
    public class TransaksiModel
    {
        public string IdTransaksi { get; set; }
        public string Kategori { get; set; }
        public string Username { get; set; }
        public string Nama { get; set; }
        public string Kontak { get; set; }
        public string NamaKendaraan { get; set; }
        public string TanggalSewa { get; set; }
        public string TanggalKembali { get; set; }
        public string DurasiTransaksi { get; set; }
        public string Status { get; set; }
        public string TanggalCharging { get; set; }
        public string NamaStation { get; set; }
        public string TipeKendaraan { get; set; }
        public string NomorPlat { get; set; }
        public decimal TotalBiaya { get; set; }

        public int RawId { get; set; }
    }
}

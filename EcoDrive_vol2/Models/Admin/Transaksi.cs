using EcoDrive_vol2.AbstractandInterface.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models.Admin
{
    // INHERITANCE: Transaksi Admin sekarang mewarisi AbsTransaksi
    public class Transaksi : AbsTransaksi
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
        //public decimal TotalBiaya { get; set; }

        public int RawId { get; set; }

        // OOP (Constructor): Memastikan objek Transaksi tidak bisa dibuat kosongan!
        public Transaksi(string idTransaksi, string kategori, string username, decimal totalBiaya, string status, int rawId)
        {
            if (string.IsNullOrEmpty(idTransaksi)) throw new ArgumentException("ID Transaksi tidak boleh kosong.");

            IdTransaksi = idTransaksi;
            Kategori = kategori;
            Username = username;
            TotalBiaya = totalBiaya; // Mengisi properti milik AbsTransaksi
            Status = status;
            RawId = rawId;
            TotalBiaya = totalBiaya;
        }
        // Implementasi wajib dari AbsTransaksi
        public override void HitungBiaya()
        {
            // Logika kustom admin jika diperlukan, atau biarkan default base
        }
        // Helper Method internal Model untuk membersihkan string status
        public string DapatkanStatusBersih()
        {
            if (string.IsNullOrEmpty(Status)) return "";
            return Status.ToLower().Replace("_", " ").Trim();
        }
    }
}

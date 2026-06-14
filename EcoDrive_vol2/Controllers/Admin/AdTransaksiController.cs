using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Service; 
using System;
using System.Collections.Generic;

namespace EcoDrive_vol2.Controllers.Admin
{
    public class AdTransaksiController
    {
        // OOP (Enkapsulasi & Class): Menyembunyikan variabel bertipe Class TransaksiService
        private readonly TransaksiService _transaksiService;

        public AdTransaksiController()
        {
            // OOP (Objek / Instansiasi): Mengubah Class menjadi Objek nyata di memori lewat 'new'
            _transaksiService = new TransaksiService();
        }
        public void ProsesKonfirmasiCharging(Transaksi dataTransaksi)
        {
            _transaksiService.EksekusiKonfirmasiPengisianDaya(dataTransaksi);
        }

        public void ProsesPenyelesaianSewa(Transaksi dataTransaksi)
        {
            _transaksiService.EksekusiPenyelesaianSewa(dataTransaksi);
        }
        public List<Transaksi> AmbilLaporanKeuanganAdmin(string filter)
        {
            try
            {
                return _transaksiService.AmbilDaftarTransaksi(filter);
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal memproses data di tingkat Controller: " + ex.Message);
            }
        }
        // POLYMORPHISM & ENCAPSULATION LOGIC: Memindahkan if-else warna & teks dari View ke Controller
        public (Color Warna, bool BisaKonfirmasi, bool BisaSelesai) SkemaVisualStatus(Transaksi item)
        {
            string status = item.DapatkanStatusBersih();
            Color warnaTeks = Color.Red; // Default jika gagal / batal

            if (status == "selesai" || status == "sudah kembali" || status == "berhasil")
                warnaTeks = Color.FromArgb(92, 184, 92); // Hijau Sukses
            else if (status == "pending" || status == "menunggu konfirmasi")
                warnaTeks = Color.Blue; // Biru Awal
            else if (status == "mengisi daya" || status == "belum kembali")
                warnaTeks = Color.Orange; // Oranye Berjalan

            // Atur hak akses tombol berdasarkan status saat ini (Logika Bisnis di Controller)
            bool bolehKonfirmasi = (status == "pending");
            bool bolehSelesai = (status == "menunggu konfirmasi");

            return (Warna: warnaTeks, BisaKonfirmasi: bolehKonfirmasi, BisaSelesai: bolehSelesai);
        }
    }
}
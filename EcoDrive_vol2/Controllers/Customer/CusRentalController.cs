using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Vehicles;
using EcoDrive_vol2.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusRentalController
    {
        // ENCAPSULATION: Membatasi akses data dari RentalService
        private readonly IRental _rentalService;

        public CusRentalController()
        {
            _rentalService = new RentalService();
        }

        public decimal DapatkanEstimasiBiaya(int idKendaraan, int durasi)
        {
            return _rentalService.DapatkanEstimasiBiaya(idKendaraan, durasi);
        }

        // Memindahkan urusan perhitungan waktu sewa dari View
        public Tuple<string, string> DapatkanInfoTanggal(int durasi)
        {
            DateTime tglSewa = DateTime.Now;
            DateTime tglKembali = tglSewa.AddDays(durasi);
            return new Tuple<string, string>(tglSewa.ToString("dd MMMM yyyy"), tglKembali.ToString("dd MMMM yyyy"));
        }

        // Memindahkan urusan validasi kelayakan klik tombol sewa dari View
        public void ValidasiKesiapanSewa(Kendaraan kendaraan)
        {
            if (kendaraan.StokKendaraan <= 0)
            {
                throw new Exception("STOK_HABIS|Maaf, stok unit ini sedang kosong.");
            }
        }

        // Memindahkan pengondisian enum tipe kendaraan
        public string DapatkanTipeTeks(Kendaraan kendaraan)
        {
            return kendaraan.TipeKendaraan == KendaraanTipe.mobil ? "Mobil" : "Motor";
        }

        // Memindahkan boolean logic penentuan kesiapan unit
        public bool CekUnitReady(Kendaraan kendaraan)
        {
            return kendaraan.StokKendaraan > 0 && kendaraan.StatusKendaraan == OptionStatus.tersedia;
        }

        public dynamic DapatkanVisualStatus(Kendaraan kendaraan)
        {
            string statusDb = kendaraan.StatusKendaraan.ToString().Replace("_", " ");
            bool ready = CekUnitReady(kendaraan);

            if (ready)
            {
                return new { Text = "READY", BgColor = Color.FromArgb(232, 245, 233), FgColor = Color.FromArgb(67, 160, 71) };
            }

            switch (statusDb.ToLower())
            {
                case "disewa":
                    return new { Text = "DISEWA", BgColor = Color.FromArgb(255, 244, 229), FgColor = Color.FromArgb(255, 152, 0) };
                case "rusak":
                    return new { Text = "RUSAK", BgColor = Color.FromArgb(255, 235, 238), FgColor = Color.FromArgb(244, 67, 54) };
                default:
                    return new { Text = "HABIS", BgColor = Color.FromArgb(254, 241, 242), FgColor = Color.FromArgb(220, 38, 38) };
            }
        }

        // OOP: Menerima objek utuh dari View dan meneruskannya ke Service
        public void KonfirmasiSewa(int idUser, int idKendaraan, int durasiSewa, decimal hargaPerHari)
        {
            // Proses instansiasi 'new' dipindah ke sini agar View bersih dari logika model
            EcoDrive_vol2.Models.Transaksi.TransaksiSewa sewaBaru = new EcoDrive_vol2.Models.Transaksi.TransaksiSewa(
                idUser,
                idKendaraan,
                durasiSewa,
                hargaPerHari
             );

            // Oper objek yang sudah jadi ke Service
            _rentalService.ProsesSewaKendaraan(sewaBaru);
        }

        public void ProsesErrorTransaksi(Exception ex, Action aksiTopUp, Action<string> aksiTampilkanPesan)
        {
            string message = ex.Message.ToLower();

            // 1. Logika Bisnis: Menentukan jenis error berdasarkan pesan dari Service Layer
            if (message.Contains("saldo") || message.Contains("insufficient"))
            {
                // Controller menyuruh View mengeksekusi blok visual Top Up
                aksiTopUp();
            }
            else
            {
                // Controller menyuruh View mengeksekusi blok visual pesan biasa beserta teksnya
                aksiTampilkanPesan(ex.Message);
            }
        }
    }
}

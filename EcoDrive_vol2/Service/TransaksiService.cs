using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Context.Admin;
using EcoDrive_vol2.Context.Customer;
using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Views;
using System;
using System.Collections.Generic;

namespace EcoDrive_vol2.Service
{
    public class TransaksiService
    {
        // ==========================================
        // DEKLARASI CONTEXT / REPOSITORY
        // ==========================================
        private readonly ITransaksi _interfaceTransaksi;
        private readonly TransaksiChargingContext _chargingContext;
        private readonly TransaksiSewaContext _sewaContext;
        private readonly AdTransaksiContext _adTransaksiContext;

        public TransaksiService()
        {
            _chargingContext = new TransaksiChargingContext();
            _sewaContext = new TransaksiSewaContext();
            _adTransaksiContext = new AdTransaksiContext();

            _interfaceTransaksi = _adTransaksiContext;
        }

        // ==========================================
        // LOGIKA UNTUK CUSTOMER
        // ==========================================

        //public List<TransaksiSewa> AmbilRiwayatSewaCustomer(int idUser)
        //{
        //    return _sewaContext.GetRiwayatByUser(idUser);
        //}

        // ==========================================
        // LOGIKA UNTUK ADMIN
        // ==========================================

        public List<Transaksi> AmbilDaftarTransaksi(string filterMode)
        {
            // Amankan pencocokan filter dengan mengabaikan huruf besar/kecil (Case-Insensitive)
            if (string.IsNullOrEmpty(filterMode) || filterMode.Equals("Semua", StringComparison.OrdinalIgnoreCase))
            {
                return _adTransaksiContext.GetAllTransaksi();
            }

            return _adTransaksiContext.GetTransaksiBerdasarkanFilter(filterMode);
        }

        public void EksekusiKonfirmasiPengisianDaya(Transaksi dataTransaksi)
        {
            if (dataTransaksi == null)
                throw new ArgumentNullException("Data transaksi tidak valid.");

            string statusBersih = dataTransaksi.Status.ToLower().Replace("_", " ").Trim();
            if (statusBersih != "pending")
            {
                throw new Exception("Transaksi ini sudah dikonfirmasi sebelumnya!");
            }
            // Jika lolos pengecekan, tembak method update database di Context kamu
            _adTransaksiContext.UpdateStatusCharging(dataTransaksi.RawId);
        }

        public void EksekusiPenyelesaianSewa(Transaksi dataTransaksi)
        {
            if (dataTransaksi == null)
                throw new ArgumentNullException("Data transaksi tidak valid.");

            string statusBersih = dataTransaksi.Status.ToLower().Replace("_", " ").Trim();
            if (statusBersih != "menunggu konfirmasi")
            {
                throw new Exception("Tombol ini hanya untuk transaksi Sewa yang berstatus 'Menunggu Konfirmasi'!");
            }
            _adTransaksiContext.UpdateStatusPengembalian(dataTransaksi.RawId);
        }

        // ==========================================
        // 🟩 PERBAIKAN: DISINKRONKAN DENGAN ENUM DATABASE
        // ==========================================
        public decimal HitungTotalOmset(List<Transaksi> daftarTransaksi)
        {
            if (daftarTransaksi == null) return 0;

            decimal total = 0;
            foreach (var trx in daftarTransaksi)
            {
                if (trx == null || string.IsNullOrEmpty(trx.Status)) continue;

                // Normalisasi string status (huruf kecil tanpa spasi ganda/underscore)
                string statusBersih = trx.Status.ToLower().Replace("_", " ").Trim();

                // Sesuai dengan isi ENUM database: 'sudah kembali' (Sewa) dan 'selesai' (Charging)
                if (statusBersih == "sudah kembali" || statusBersih == "selesai" || statusBersih == "sukses")
                {
                    total += trx.TotalBiaya;
                }
            }
            return total;
        }
    }
}
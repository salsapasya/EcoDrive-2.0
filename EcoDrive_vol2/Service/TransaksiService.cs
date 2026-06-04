using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using System;
using System.Collections.Generic;

namespace EcoDrive_vol2.Service
{
    public class TransaksiService
    {
        // ==========================================
        // DEKLARASI CONTEXT / REPOSITORY
        // ==========================================
        private readonly ITransaksi _transaksiContext;
        private readonly TransaksiChargingContext _chargingContext = new TransaksiChargingContext();
        private readonly TransaksiSewaContext _sewaContext = new TransaksiSewaContext();

        public TransaksiService()
        {
            // Instansiasi Context admin menggunakan Interface
            _transaksiContext = new AdTransaksiContext();
        }

        // ==========================================
        // LOGIKA UNTUK CUSTOMER
        // ==========================================

        public List<TransaksiSewa> AmbilRiwayatSewaCustomer(int idUser)
        {
            return _sewaContext.GetRiwayatByUser(idUser);
        }

        // ==========================================
        // LOGIKA UNTUK ADMIN
        // ==========================================

        public List<TransaksiModel> AmbilDaftarTransaksi(string filterMode)
        {
            // Amankan pencocokan filter dengan mengabaikan huruf besar/kecil (Case-Insensitive)
            if (string.IsNullOrEmpty(filterMode) || filterMode.Equals("Semua", StringComparison.OrdinalIgnoreCase))
            {
                return _transaksiContext.GetAllTransaksi();
            }

            return _transaksiContext.GetTransaksiBerdasarkanFilter(filterMode);
        }

        public void KonfirmasiPengisianDaya(int rawId)
        {
            if (rawId <= 0) throw new ArgumentException("ID Transaksi tidak valid!");
            _transaksiContext.UpdateStatusCharging(rawId);
        }

        public void SelesaikanPenyewaan(int rawId)
        {
            if (rawId <= 0) throw new ArgumentException("ID Transaksi tidak valid!");
            _transaksiContext.UpdateStatusPengembalian(rawId);
        }

        // ==========================================
        // 🟩 PERBAIKAN: DISINKRONKAN DENGAN ENUM DATABASE
        // ==========================================
        public decimal HitungTotalOmset(List<TransaksiModel> daftarTransaksi)
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
using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Context;
using EcoDrive_vol2.Context.Admin;
using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Views;
using System;
using System.Collections.Generic;
using System.Data;

namespace EcoDrive_vol2.Service
{
    public class TransaksiService
    {
        // ==========================================
        // DEKLARASI CONTEXT / REPOSITORY
        // ==========================================
        private readonly ITransaksi _interfaceTransaksi; // OOP (Abstraksi): Menggunakan Interface ITransaksi untuk menyembunyikan detail database
        private readonly AdTransaksiContext _adTransaksiContext;
        private readonly TopUpContext _topupContext;

        public TransaksiService()
        {
            _adTransaksiContext = new AdTransaksiContext();
            _topupContext = new TopUpContext();

            // OOP (Polimorfisme): Interface diisi oleh objek dari Class (AdTransaksiContext)
            _interfaceTransaksi = _adTransaksiContext;
        }


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
        // PERBAIKAN: DISINKRONKAN DENGAN ENUM DATABASE
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

        // ====================================================================
        // LOGIKA BARU: TRANSAKSI TOP UP SALDO (CUSTOMER SIDE)
        // ====================================================================

        // 1. Ambil data nominal saldo user untuk label utama di UI
        public decimal AmbilSaldoUser(int idUser)
        {
            return _topupContext.GetSaldo(idUser);
        }
        // 2. Ambil data riwayat transaksi top up untuk dimasukkan ke FlowLayoutPanel
        public DataTable AmbilRiwayatTopUpUser(int idUser)
        {
            return _topupContext.GetRiwayatTopUpByCustomer(idUser);
        }
        // 3. Menangani insert transaksi top up baru (bisa BERHASIL / PENDING)
        public void EksekusiTopUpBaru(int idUser, decimal nominal, string status)
        {
            if (nominal <= 0)
                throw new ArgumentException("Nominal top up harus lebih besar dari 0.");

            if (status == "BERHASIL")
            {
                _topupContext.InsertTopUpLangsung(idUser, nominal);
            }
            else if (status == "PENDING")
            {
                _topupContext.InsertTopUpPending(idUser, nominal);
            }
        }
        // 4. Mengeksekusi pembayaran dari invoice top up yang berstatus PENDING
        public void EksekusiBayarPending(int idTopUp, int idUser, decimal jumlah)
        {
            if (jumlah <= 0)
                throw new ArgumentException("Jumlah pembayaran tidak valid.");

            _topupContext.BayarPendingLangsung(idTopUp, idUser, jumlah);
        }
        // 5. Mengubah nilai kolom minta_batal menjadi true di database (menunggu respon admin)
        public void EksekusiMintaBatal(int idTopUp)
        {
            _topupContext.UpdateMintaBatalCustomer(idTopUp);
        }
    }
}
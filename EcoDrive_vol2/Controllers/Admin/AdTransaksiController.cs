using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Service; // Ambil namespace folder Service
using System;
using System.Collections.Generic;

namespace EcoDrive_vol2.Controllers.Admin
{
    // Ubah internal menjadi public agar bisa dipanggil oleh file UI/Form Admin Anda
    public class AdTransaksiController
    {
        private readonly TransaksiService _transaksiService;

        public AdTransaksiController()
        {
            _transaksiService = new TransaksiService();
        }

        // Tambahkan ini di dalam class AdTransaksiController

        public void ProsesKonfirmasiCharging(int rawId)
        {
            // Controller meneruskan perintah dari UI ke Service
            _transaksiService.KonfirmasiPengisianDaya(rawId);
        }

        public void ProsesPenyelesaianSewa(int rawId)
        {
            _transaksiService.SelesaikanPenyewaan(rawId);
        }

        // Fungsi yang akan dipanggil oleh DataGridView di Form Admin Anda
        public List<TransaksiModel> AmbilLaporanKeuanganAdmin(string filter)
        {
            try
            {
                return _transaksiService.AmbilDaftarTransaksi(filter);
            }
            catch (Exception ex)
            {
                // Lempar ke View untuk ditampilkan dalam bentuk MessageBox.Show()
                throw new Exception("Gagal memproses data di tingkat Controller: " + ex.Message);
            }
        }

        // Fungsi untuk mengambil nilai omset bersih untuk ditaruh di Label text
        public decimal AmbilRingkasanOmset(List<TransaksiModel> list)
        {
            return _transaksiService.HitungTotalOmset(list);
        }
    }
}
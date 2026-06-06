using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Service; 
using System;
using System.Collections.Generic;

namespace EcoDrive_vol2.Controllers.Admin
{
    public class AdTransaksiController
    {
        private readonly TransaksiService _transaksiService;

        public AdTransaksiController()
        {
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
        public decimal AmbilRingkasanOmset(List<Transaksi> list)
        {
            return _transaksiService.HitungTotalOmset(list);
        }
    }
}
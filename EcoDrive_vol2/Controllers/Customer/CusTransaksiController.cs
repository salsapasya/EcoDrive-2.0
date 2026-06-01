using System;
using System.Collections.Generic;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Service; // Memanggil folder Service

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusTransaksiController
    {
        private readonly TransaksiService _transaksiService;

        public CusTransaksiController()
        {
            // Memanggil TransaksiService yang sudah berisi logika gabungan
            _transaksiService = new TransaksiService();
        }

        // Fungsi ini yang akan dipanggil oleh Form Riwayat Sewa milik Customer
        public List<TransaksiSewa> AmbilRiwayatSewaSaya(int idUser)
        {
            try
            {
                if (idUser <= 0) return new List<TransaksiSewa>();

                return _transaksiService.AmbilRiwayatSewaCustomer(idUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal mengambil riwayat transaksi customer: " + ex.Message);
            }
        }
    }
}
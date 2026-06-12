using System;
using System.Collections.Generic;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Service; // Memanggil folder Service

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusTransaksiController
    {
        private readonly TransaksiService _transaksiService; // encap (di private) = menyembunyikan data, tidak boleh mengacak-acak data transaksi, hanya bisa diakses melalui method yang sudah disediakan di TransaksiService

        public CusTransaksiController()
        {
            // Memanggil TransaksiService yang sudah berisi logika gabungan
            _transaksiService = new TransaksiService(); 
        }
    }
}
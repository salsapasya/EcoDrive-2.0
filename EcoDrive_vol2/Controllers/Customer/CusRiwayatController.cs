using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Service; // memanggil folder service tempat RiwayatService
using System;
using System.Collections.Generic;
using System.Data;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusRiwayatController
    {
        // Hubungkan ke RiwayatService untuk mengambil history sewa/charging
        private readonly RiwayatService _riwayatService = new RiwayatService();

        // Mengambil riwayat sewa motor milik customer
        public DataTable AmbilRiwayatSewa(int idUser)
        {
            return _riwayatService.AmbilRiwayatSewa(idUser);
        }

        // Mengambil riwayat pengisian daya (charging) milik customer
        public DataTable AmbilRiwayatCharging(int idUser)
        {
            return _riwayatService.AmbilRiwayatCharging(idUser);
        }
    }
}

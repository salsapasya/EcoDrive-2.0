using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Service; // Pindah ke namespace Service yang baru
using System;
using System.Collections.Generic;
using System.Data;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusRiwayatController
    {
        // 1. Ganti CustomerService lama dengan TransaksiService yang baru
        private readonly RiwayatService _riwayatService = new RiwayatService();

        public DataTable AmbilRiwayatSewa(int idUser)
        {
            return _riwayatService.AmbilRiwayatSewa(idUser);
        }
        public DataTable AmbilRiwayatCharging(int idUser)
        {
            return _riwayatService.AmbilRiwayatCharging(idUser);
        }
    }
}

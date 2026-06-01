using System;
using System.Collections.Generic;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Service; // Pindah ke namespace Service yang baru

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusRiwayatController
    {
        // 1. Ganti CustomerService lama dengan TransaksiService yang baru
        private readonly TransaksiService _transaksiService = new TransaksiService();

        public List<TransaksiSewa> GetRiwayat(int idUser)
        {
            try
            {
                if (idUser <= 0) return new List<TransaksiSewa>();

                // 2. Alihkan panggilan ke fungsi AmbilRiwayatSewaCustomer di TransaksiService
                return _transaksiService.AmbilRiwayatSewaCustomer(idUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di Controller saat mengambil riwayat: " + ex.Message);
            }
        }
    }
}
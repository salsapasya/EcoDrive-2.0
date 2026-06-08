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

        //public List<TransaksiSewa> GetRiwayat(int idUser)
        //{
        //    try
        //    {
        //        if (idUser <= 0) return new List<TransaksiSewa>();

        //        // 2. Alihkan panggilan ke fungsi AmbilRiwayatSewaCustomer di TransaksiService
        //        return _transaksiService.AmbilRiwayatSewaCustomer(idUser);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error di Controller saat mengambil riwayat: " + ex.Message);
        //    }
        //}
        //}
        public DataTable AmbilRiwayatSewa(int idUser)
        {
            return _riwayatService.AmbilRiwayatSewa(idUser);
        }
        public DataTable AmbilRiwayatCharging(int idUser)
        {
            return _riwayatService.AmbilRiwayatCharging(idUser);
        }
        public DataTable AmbilRiwayatTopUp(int idUser)
        {
            return _riwayatService.AmbilRiwayatTopUp(idUser);
        }
    }
}

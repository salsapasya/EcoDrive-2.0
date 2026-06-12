using EcoDrive_vol2.Context.Customer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EcoDrive_vol2.Service
{
    public class RiwayatService
    {
        private readonly RiwayatContext _riwayatContext = new RiwayatContext();

        public DataTable AmbilRiwayatSewa(int idUser)
        {
            try
            {
                return _riwayatContext.GetRiwayatSewa(idUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di Riwayat Service (Sewa): " + ex.Message);
            }
        }

        public DataTable AmbilRiwayatCharging(int idUser)
        {
            try
            {
                return _riwayatContext.GetRiwayatCharging(idUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di Riwayat Service (Charging): " + ex.Message);
            }
        }
    }
}


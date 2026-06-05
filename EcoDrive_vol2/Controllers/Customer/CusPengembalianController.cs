using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusPengembalianController
    {
        private readonly PengembalianService _service = new PengembalianService();
        public List<TransaksiSewa> AmbilSewaAktifUser(int idUser)
        {
            try
            {
                return _service.AmbilSewaAktifUser(idUser);

            }
            catch (Exception ex)
            {
                throw new Exception("Gagal mengambil data sewa aktif: " + ex.Message);
            }
        }
        public void AjukanPengembalian(int idTransaksiSewa)
        {
            try
            {
                _service.ProsesAjukanPengembalian(idTransaksiSewa);

            }
            catch (Exception ex)
            {
                throw new Exception("Gagal mengajukan pengembalian: " + ex.Message);
            }
        }
    }
}

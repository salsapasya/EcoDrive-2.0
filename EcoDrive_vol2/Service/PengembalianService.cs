using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Context.Customer;
using EcoDrive_vol2.Models.Transaksi;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Service
{
    public class PengembalianService : IPengembalianService
    {
        private readonly PengembalianContext _context = new PengembalianContext();
        private readonly ChargingContext _chargingContext = new ChargingContext();
        public List<TransaksiSewa> AmbilSewaAktifUser (int idUser)
        {
            return _context.GetSewaAktifUser(idUser);
        }  
        public void ProsesAjukanPengembalian(int idTransaksiSewa, int idUser, string platNomor)
        {
            //  Cek status charging
            var listChargingAktif = _chargingContext.GetTransaksiAktif(idUser);

            foreach (var charge in listChargingAktif)
            {
                // Jika plat nomor kendaraan yang mau dikembalikan ada di daftar charging aktif
                if (charge.NomorPlat == platNomor)
                {
                    throw new Exception($"Kendaraan dengan plat {platNomor} masih dalam proses charging aktif. Harap selesaikan sesi charging terlebih dahulu!");
                }
            }
            _context.AjukanPengembalian(idTransaksiSewa);
        }
    }
}

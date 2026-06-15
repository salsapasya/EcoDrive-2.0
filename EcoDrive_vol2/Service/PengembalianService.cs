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
        public List<TransaksiSewa> AmbilSewaAktifUser (int idUser)
        {
            return _context.GetSewaAktifUser(idUser);
        }  
        public void ProsesAjukanPengembalian(int idTransaksiSewa)
        {
            _context.AjukanPengembalian(idTransaksiSewa);
        }
    }
}

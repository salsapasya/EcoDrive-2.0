using EcoDrive_vol2.Models.Transaksi;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    public interface IPengembalianService
    {
        List<TransaksiSewa> AmbilSewaAktifUser(int idUser);
        void ProsesAjukanPengembalian(int idTransaksiSewa, int idUser, string platNomor);
    }
}

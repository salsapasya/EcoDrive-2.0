using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using System.Collections.Generic;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    public interface ITransaksi
    {
        void UpdateStatusCharging(int rawId);
        void UpdateStatusPengembalian(int rawId);

        List<TransaksiModel> GetAllTransaksi();

        // TAMBAHKAN BARIS INI AGAR SERVICE BISA MEMANGGILNYA
        List<TransaksiModel> GetTransaksiBerdasarkanFilter(string filterMode);
    }
}
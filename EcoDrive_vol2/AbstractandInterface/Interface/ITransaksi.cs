using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using System.Collections.Generic;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    public interface ITransaksi
    {
        void UpdateStatusCharging(int rawId);
        void UpdateStatusPengembalian(int rawId);

        List<Transaksi> GetAllTransaksi();

        // TAMBAHKAN BARIS INI AGAR SERVICE BISA MEMANGGILNYA
        List<Transaksi> GetTransaksiBerdasarkanFilter(string filterMode);
    }
}
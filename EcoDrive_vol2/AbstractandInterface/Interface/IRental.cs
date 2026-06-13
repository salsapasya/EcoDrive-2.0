using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    public interface IRental
    {
        decimal DapatkanEstimasiBiaya(int idKendaraan, int durasi);
        // OOP (Abstraksi): Menggunakan objek model TransaksiSewa, bukan variabel pecahan (primitive)
        void ProsesSewaKendaraan(Models.Transaksi.TransaksiSewa transaksi);
    }
}
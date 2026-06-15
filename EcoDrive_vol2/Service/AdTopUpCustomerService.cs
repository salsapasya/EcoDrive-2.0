using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Context;
using EcoDrive_vol2.Context.Admin;
using EcoDrive_vol2.Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Service
{
    // Menggunakan Polymorphism via Interface(IAdTopUpRepository) sebagai tipe data
    //  referensi objek Context, bukan langsung menunjuk kelas konkritnya.
    public class AdTopUpCustomerService
    {
        private readonly AdTopUpCustomerContext _adminContext = new AdTopUpCustomerContext();

        public List<TopUp> AmbilDaftarTopUpAdmin(string statusFilter)
        {
             return _adminContext.GetDaftarTopUpFromView(statusFilter);
        }

        public void ProsesKonfirmasiPembatalan(int idTopupSaldo, int idUser)
        {
             if (idTopupSaldo <= 0) throw new ArgumentException("ID Transaksi tidak valid.");

             _adminContext.KonfirmasiTopUp(idTopupSaldo, idUser);
        }
        public int GetIdUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return 0;
            return _adminContext.GetIdUserByUsername(username);
        }

        // PINDAHAN LOGIKA DARI VIEW
        public (bool IsEnabled, string ButtonText) ValidasiStateTombolAksi(string status, bool isMintaBatal)
        {
            string statusUpper = status.ToUpper();

            if (statusUpper == "PENDING" && isMintaBatal)
            {
                return (true, "✔ SETUJUI PEMBATALAN");
            }
            else if (statusUpper == "BERHASIL" || statusUpper == "GAGAL")
            {
                return (false, $"✔ {statusUpper} (DIKUNCI)");
            }
            else
            {
                return (false, "⏳ MENUNGGU PEMBAYARAN (DIKUNCI)");
            }
        }
    }
}

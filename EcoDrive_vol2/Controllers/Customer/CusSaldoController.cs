using System;
using System.Data; // WAJIB DITAMBAHKAN untuk menggunakan DataTable
using EcoDrive_vol2.Service;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusSaldoController
    {
        private readonly LoginService _loginService = new LoginService();

        public decimal GetSaldo(int idUser)
        {
            try
            {
                return _loginService.AmbilSaldoUser(idUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di Controller saat mengambil saldo: " + ex.Message);
            }
        }

        public void TopupSaldo(int idUser, decimal jumlah)
        {
            try
            {
                _loginService.ProsesTopupSaldo(idUser, jumlah);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di Controller saat top up saldo: " + ex.Message);
            }
        }

        // ====================================================================
        // TAMBAHKAN FUNGSI BARU INI DI SINI
        // ====================================================================
        public DataTable GetDaftarTransaksiTopUp(string status = "")
        {
            try
            {
                // Meneruskan request dari UI ke LoginService yang bertugas mengambil data dari database
                return _loginService.AmbilDaftarTopUpAdmin(status);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di Controller saat mengambil daftar transaksi: " + ex.Message);
            }
        }
    }
}
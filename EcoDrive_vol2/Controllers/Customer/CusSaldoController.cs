using System;
using System.Data;
using EcoDrive_vol2.Service;
using EcoDrive_vol2.Views.Admin;

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

        public DataTable GetDaftarTransaksiTopUp(string status = "")
        {
            try
            {
                return _loginService.AmbilDaftarTopUpAdmin(status);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di Controller saat mengambil daftar transaksi: " + ex.Message);
            }
        }

        public void KonfirmasiTopUp(int idTopup, int idUser)
        {
            try
            {
                _loginService.KonfirmasiTopUp(idTopup, idUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di Controller saat konfirmasi top up: " + ex.Message);
            }
        }

        // ====================================================================
        // PENYESUAIAN: Fungsi baru agar View tidak langsung akses ke Service
        // ====================================================================
        public int GetIdUserByUsername(string username)
        {
            try
            {
                return _loginService.AmbilIdUser(username);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di Controller saat mencari ID User: " + ex.Message);
            }
        }
    }
}
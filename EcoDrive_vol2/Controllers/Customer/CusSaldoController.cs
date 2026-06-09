using System;
using System.Data;
using EcoDrive_vol2.Service;
using EcoDrive_vol2.Views.Admin;
using EcoDrive_vol2.Context; // <-- 1. PASTIKAN TAMBAHIN INI

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusSaldoController
    {
        private readonly LoginService _loginService = new LoginService();
        private readonly TopUpContext _topUpContext = new TopUpContext(); // <-- 2. TAMBAHIN INI

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
        // JEMBATAN BARU: Digunakan oleh View CusSaldo untuk mengambil riwayat figma
        // ====================================================================
        public DataTable AmbilRiwayatTopUp(int idUser)
        {
            try
            {
                return _topUpContext.GetRiwayatTopUpByCustomer(idUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di Controller saat mengambil riwayat top up: " + ex.Message);
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
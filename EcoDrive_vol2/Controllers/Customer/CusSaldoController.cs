using System;
using System.Data;
using EcoDrive_vol2.Service;
using EcoDrive_vol2.Views.Admin;
using EcoDrive_vol2.Context;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusSaldoController
    {
        private readonly LoginService _loginService = new LoginService();
        private readonly TopUpContext _topUpContext = new TopUpContext();

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

        // ====================================================================
        // 1. FUNGSI UNTUK BAYAR SEKARANG (LANGSUNG MASUK KE SALDO & RIWAYAT BERHASIL)
        // ====================================================================
        public void TopupSaldoLangsung(int idUser, decimal nominal)
        {
            try
            {
                // Memanggil service bawaanmu untuk eksekusi instant topup (tambah saldo + insert record)
                _loginService.ProsesTopupSaldo(idUser, nominal);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di Controller saat top up saldo langsung: " + ex.Message);
            }
        }

        // ====================================================================
        // 2. FUNGSI UNTUK BAYAR NANTI (MASUK DAFTAR PENDING, SALDO TIDAK BERTAMBAH)
        // ====================================================================
        public void TopupSaldoPending(int idUser, decimal nominal)
        {
            try
            {
                // Kita buat fungsi eksekusi penampung pending langsung melalui database context-mu
                _topUpContext.InsertTopUpPending(idUser, nominal);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di Controller saat membuat invoice pending: " + ex.Message);
            }
        }

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
using EcoDrive_vol2.Context;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Service;
using Npgsql;
using System;
using System.Data;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusSaldoController
    {
        private readonly LoginService _loginService = new LoginService();
        private TopUpContext _topUpContext = new TopUpContext();

        // 1. Fungsi bawaan ambil saldo customer
        public decimal GetSaldo(int idUser)
        {
            using var conn = DatabaseHelper.GetConnection();
            string query = "SELECT saldo FROM users WHERE id_user = @idUser";
            try
            {
                conn.Open();
                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUser", idUser);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal mengambil saldo: " + ex.Message);
            }
        }

        // 2. Ambil riwayat untuk dimasukkan ke data grid view asli lu
        public DataTable AmbilRiwayatTopUp(int idUser)
        {
            return _topUpContext.GetRiwayatTopUpByCustomer(idUser);
        }

        // 3. Fungsi Top up langsung masuk tanpa pending
        public void TopupSaldoLangsung(int idUser, decimal nominal)
        {
            using var conn = DatabaseHelper.GetConnection();
            string queryInsert = "INSERT INTO topup_saldo (id_customer, jumlah_topup, status_topup, sudah_bayar) VALUES (@idUser, @nominal, 'sukses', true)";
            string queryUpdate = "UPDATE users SET saldo = saldo + @nominal WHERE id_user = @idUser";
            try
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(queryInsert, conn))
                {
                    cmd.Parameters.AddWithValue("@idUser", idUser);
                    cmd.Parameters.AddWithValue("@nominal", Convert.ToInt32(nominal));
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new NpgsqlCommand(queryUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@idUser", idUser);
                    cmd.Parameters.AddWithValue("@nominal", Convert.ToInt32(nominal));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 4. Fungsi Top up pending (Bayar nanti)
        public void TopupSaldoPending(int idUser, decimal nominal)
        {
            _topUpContext.InsertTopUpPending(idUser, nominal);
        }

        // ====================================================================
        // PENYELAMATAN ADMIN: Menyembuhkan Error TolakTopUp & GetIdUserByUsername
        // ====================================================================
        public void TolakTopUp(int idTopup)
        {
            string query = "UPDATE topup_saldo SET status_topup = 'gagal' WHERE id_topup_saldo = @idTopup";
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTopup", idTopup);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error saat menolak top up: " + ex.Message);
            }
        }
        public int GetIdUserByUsername(string username)
        {
            using var conn = DatabaseHelper.GetConnection();
            string query = "SELECT id_user FROM users WHERE username = @username";
            try
            {
                conn.Open();
                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Ambil ID User: " + ex.Message);
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
    }
}
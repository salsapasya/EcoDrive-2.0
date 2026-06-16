using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using Npgsql;
using System;
using System.Data;

namespace EcoDrive_vol2.Context
{
    public class TopUpContext
    {
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
                throw new Exception("Error di TopUpContext (GetSaldo): " + ex.Message);
            }
        }
        public DataTable GetRiwayatTopUpByCustomer(int idUser)
        {
            DataTable dt = new DataTable();
            using var conn = DatabaseHelper.GetConnection();

            // Sesuai fungsionalitas DB lu, kolom relasi di topup_saldo adalah id_customer
            string query = @"SELECT id_topup_saldo, jumlah_topup, status_topup, sudah_bayar, minta_batal 
                            FROM topup_saldo 
                            WHERE id_user = @idUser 
                            ORDER BY id_topup_saldo DESC";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idUser", idUser);

            try
            {
                conn.Open();
                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error di TopUpContext saat mengambil riwayat: " + ex.Message);
            }

            return dt;
        }

        public void InsertTopUpLangsung(int idUser, decimal nominal)
        {
            using var conn = DatabaseHelper.GetConnection();
            string queryInsert = @"INSERT INTO topup_saldo (id_user, jumlah_topup, status_topup, sudah_bayar, minta_batal) 
                                   VALUES (@idUser, @nominal, 'berhasil', true, false)";
            string queryUpdateUser = "UPDATE users SET saldo = saldo + @nominal WHERE id_user = @idUser";

            try
            {
                conn.Open();
                // Simpan transaksi status langsung berhasil
                using (var cmd = new NpgsqlCommand(queryInsert, conn))
                {
                    cmd.Parameters.AddWithValue("@idUser", idUser);
                    cmd.Parameters.AddWithValue("@nominal", Convert.ToInt32(nominal));
                    cmd.ExecuteNonQuery();
                }
                // Langsung tambahkan dompet saldo user
                using (var cmd = new NpgsqlCommand(queryUpdateUser, conn))
                {
                    cmd.Parameters.AddWithValue("@idUser", idUser);
                    cmd.Parameters.AddWithValue("@nominal", Convert.ToInt32(nominal));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error di TopUpContext (InsertTopUpLangsung): " + ex.Message);
            }
        }

        public void SimpanTransaksiTopUp(TopupSaldo data)
        {
            using var conn = DatabaseHelper.GetConnection();
            string query = "INSERT INTO topup_saldo (id_user, jumlah_topup, status_topup) VALUES (@id, @jml, 'pending')";

            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", data.IdCustomer);
            cmd.Parameters.AddWithValue("@jml", data.JumlahTopup);
            cmd.ExecuteNonQuery();
        }

        public void InsertTopUpPending(int idUser, decimal nominal)
        {
            using var conn = DatabaseHelper.GetConnection();

            string queryInsert = @"INSERT INTO topup_saldo (id_user, jumlah_topup, status_topup, sudah_bayar, minta_batal) 
                                  VALUES (@idUser, @nominal, 'pending', false, false)";

            try
            {
                conn.Open();

                using (var cmdInsert = new NpgsqlCommand(queryInsert, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@idUser", idUser);
                    cmdInsert.Parameters.AddWithValue("@nominal", Convert.ToInt32(nominal));
                    cmdInsert.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error di TopUpContext saat membuat transaksi pending: " + ex.Message);
            }
        }
        //Eksekusi BAYAR LANGSUNG dari List Riwayat (Pending -> Berhasil & Saldo Masuk)
        public void BayarPendingLangsung(int idTopup, int idUser, decimal nominal)
        {
            using var conn = DatabaseHelper.GetConnection();
            string queryUpdateTopUp = "UPDATE topup_saldo SET status_topup = 'berhasil', sudah_bayar = true WHERE id_topup_saldo = @idTopup";
            string queryUpdateUser = "UPDATE users SET saldo = saldo + @nominal WHERE id_user = @idUser";

            try
            {
                conn.Open();
                // Ubah status tabel topup_saldo
                using (var cmd = new NpgsqlCommand(queryUpdateTopUp, conn))
                {
                    cmd.Parameters.AddWithValue("@idTopup", idTopup);
                    cmd.ExecuteNonQuery();
                }
                // Tambah saldo di tabel users
                using (var cmd = new NpgsqlCommand(queryUpdateUser, conn))
                {
                    cmd.Parameters.AddWithValue("@idUser", idUser);
                    cmd.Parameters.AddWithValue("@nominal", Convert.ToInt32(nominal));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal memproses pembayaran dari riwayat: " + ex.Message);
            }
        }
        public void UpdateMintaBatalCustomer(int idTopup)
        {
            using var conn = DatabaseHelper.GetConnection();
            string query = "UPDATE topup_saldo SET minta_batal = true WHERE id_topup_saldo = @idTopup";
            try
            {
                conn.Open();
                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTopup", idTopup);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal memproses minta batal: " + ex.Message);
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
                throw new Exception("Error di Context (GetIdUserByUsername): " + ex.Message);
            }
        }

        public List<TopUp> GetAllTopup()
        {
            List<TopUp> list = new List<TopUp>();
            return list;
        }
    }
}
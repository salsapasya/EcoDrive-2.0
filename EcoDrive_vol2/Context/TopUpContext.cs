using EcoDrive_vol2.Helpers;
using Npgsql;
using System;
using System.Data;

namespace EcoDrive_vol2.Context
{
    public class TopUpContext
    {
        // Fungsi mengambil riwayat top up bawaan proyekmu
        public DataTable GetRiwayatTopUpByCustomer(int idUser)
        {
            DataTable dt = new DataTable();
            using var conn = DatabaseHelper.GetConnection();

            // Sesuai fungsionalitas DB lu, kolom relasi di topup_saldo adalah id_customer
            string query = @"SELECT id_topup_saldo, jumlah_topup, status_topup 
                            FROM topup_saldo 
                            WHERE id_customer = @idUser 
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

        // Fungsi membuat invoice pending dan saldo bertambah (menggunakan id_user untuk tabel users)
        public void InsertTopUpPending(int idUser, decimal nominal)
        {
            using var conn = DatabaseHelper.GetConnection();

            string queryInsert = @"INSERT INTO topup_saldo (id_customer, jumlah_topup, status_topup, sudah_bayar) 
                                  VALUES (@idUser, @nominal, 'pending', false)";

            // Menggunakan id_user sesuai skema database users milikmu
            string queryUpdate = @"UPDATE users SET saldo = saldo + @nominal WHERE id_user = @idUser";

            try
            {
                conn.Open();

                using (var cmdInsert = new NpgsqlCommand(queryInsert, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@idUser", idUser);
                    cmdInsert.Parameters.AddWithValue("@nominal", Convert.ToInt32(nominal));
                    cmdInsert.ExecuteNonQuery();
                }

                using (var cmdUpdate = new NpgsqlCommand(queryUpdate, conn))
                {
                    cmdUpdate.Parameters.AddWithValue("@idUser", idUser);
                    cmdUpdate.Parameters.AddWithValue("@nominal", Convert.ToInt32(nominal));
                    cmdUpdate.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error di TopUpContext saat membuat transaksi pending: " + ex.Message);
            }
        }
    }
}
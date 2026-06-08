using EcoDrive_vol2.Helpers;
using Npgsql;
using System;
using System.Data;

namespace EcoDrive_vol2.Context
{
    public class TopUpContext
    {
        // Fungsi untuk mengambil seluruh riwayat top up milik si customer tertentu
        public DataTable GetRiwayatTopUpByCustomer(int idUser)
        {
            DataTable dt = new DataTable();
            using var conn = DatabaseHelper.GetConnection();

            // Query disesuaikan dengan nama kolom yang terdeteksi di UserContext kamu
            string query = @"SELECT id_topup_saldo, jumlah_topup, status_topup 
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
    }
}
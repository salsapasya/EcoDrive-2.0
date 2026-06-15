using EcoDrive_vol2.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.AbstractandInterface.Interface;

namespace EcoDrive_vol2.Context.Admin
{
    // OOP (INHERITANCE) = merealisakikannya di class context
    public class AdTopUpCustomerContext : IAdTopUpRepository
    {
        public List<TopUp> GetDaftarTopUpFromView(string statusFilter)
        {
            var listTopUp = new List<TopUp>();
            using var conn = DatabaseHelper.GetConnection();

            string query = "SELECT * FROM view_admin_topup";

            if (!string.IsNullOrEmpty(statusFilter))
            {
                query += " WHERE status = LOWER(@status)";
            }

            using var cmd = new NpgsqlCommand(query, conn);
            if (!string.IsNullOrEmpty(statusFilter))
            {
                cmd.Parameters.AddWithValue("@status", statusFilter);
            }

            try
            {
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // PARSING ENUM: Ubah teks DB (pending/berhasil/gagal) ke lowercase agar cocok dengan enum 
                    string statusDariDB = reader["status"].ToString().Trim().ToLower();
                    TopupStatus parsedStatus = Enum.Parse<TopupStatus>(statusDariDB, true);

                    var topup = new TopUp
                    (
                        Convert.ToInt32(reader["id_topup_saldo"]),
                        reader["username"].ToString(),
                        reader["nama_user"].ToString(),
                        reader["no_telp_user"].ToString(),
                        Convert.ToDecimal(reader["jumlah_topup"]),
                        parsedStatus,
                        Convert.ToBoolean(reader["minta_batal"])
                    );

                    listTopUp.Add(topup);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error saat mengambil data dari view_admin_topup: " + ex.Message);
            }

            return listTopUp;
        }

        public void KonfirmasiTopUp(int idTopupSaldo, int idUser)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT fn_konfirmasi_topup(@idTopup, @idUser)";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTopup", idTopupSaldo);
                cmd.Parameters.AddWithValue("@idUser", idUser);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal memproses konfirmasi top up di database: " + ex.Message);
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
    }
}

using EcoDrive_vol2.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EcoDrive_vol2.Context.Admin
{
    public class TopUpCustomerContext
    {
        public DataTable GetDaftarTopUpFromView(string statusFilter)
        {
            DataTable dt = new DataTable();
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
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saat mengambil data dari view_admin_topup: " + ex.Message);
            }

            return dt;
        }

        public void KonfirmasiTopUp(int idTopup, int idUser)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT fn_konfirmasi_topup(@idTopup, @idUser)";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTopup", idTopup);
                cmd.Parameters.AddWithValue("@idUser", idUser);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal memproses konfirmasi top up di database: " + ex.Message);
            }
        }
    }
}

using EcoDrive_vol2.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EcoDrive_vol2.Context.Customer
{
    public class RiwayatContext
    {
        public DataTable GetRiwayatSewa(int idUser)
        {
            DataTable dt = new DataTable();
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();

                string query = "SELECT * FROM view_riwayat_customer " +
                                "WHERE id_user = @idUser " +
                                "ORDER BY id_transaksi_sewa DESC";
                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUser", idUser);

                using var adapter = new NpgsqlDataAdapter(cmd); 
                adapter.Fill(dt);
            }
            catch (Exception ex) 
            { 
                throw new Exception("Error Sewa: " + ex.Message); 
            }
            return dt;
        }

        public DataTable GetRiwayatCharging(int idUser)
        {
            DataTable dt = new DataTable();
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();

                string query = "SELECT * FROM view_riwayat_charging " +
                                "WHERE id_user = @idUser " +
                                "ORDER BY id_transaksi_charging DESC";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUser", idUser);

                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Charging: " + ex.Message);
            }
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using Npgsql;

namespace EcoDrive_vol2.Context
{
    public class AdTransaksiContext
    {
        public List<AdminGridModel> GetAdTransaksi(string filter)
        {
            List<AdminGridModel> list = new List<AdminGridModel>();
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT * FROM view_admin_transaksi";

                if (filter == "Sewa")
                {
                    query += " WHERE kategori = 'Sewa' ORDER BY tanggal DESC";
                }
                else if (filter == "Charging")
                {
                    query += " WHERE kategori = 'Charging' ORDER BY tanggal DESC";
                }
                else
                {
                    query += " ORDER BY tanggal DESC";
                }

                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AdminGridModel item = new AdminGridModel
                    {
                        RawId = reader.GetInt32(0),
                        Kategori = reader.GetString(1),
                        ID_Transaksi = reader.GetString(2),
                        Username = reader.GetString(3),
                        Nama = reader.GetString(4),
                        Kontak = reader.GetString(5),
                        Waktu = reader.GetString(6),
                        Detail = reader.GetString(7),
                        Status = reader.GetString(8)
                    };
                    list.Add(item);
                }   
            }
            catch (Exception ex)
            {
                throw new Exception("Error Get Ad Transaksi : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
    }
}

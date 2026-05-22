using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EcoDrive_vol2.Helpers;

namespace EcoDrive_vol2.Controllers
{
    public class AdKendaraanController
    {
        public DataTable GetStatusKendaraan()
        {
            DataTable dt = new DataTable();
            using var conn = DatabaseHelper.GetConnection();
            {
                try
                {
                    conn.Open();
                    string query = "SELECT k.idKendaraan, k.NamaKendaraan, tk.NamaTipeKendaraan, k.HargaSewa, " +
                                   "CASE WHEN EXISTS (SELECT 1 FROM transaksi t WHERE t.idKendaraan = k.idKendaraan AND t.StatusTransaksi = 'Aktif') THEN 'Tidak Tersedia' ELSE 'Tersedia' END AS StatusKetersediaan " +
                                   "FROM kendaraan k JOIN tipe_kendaraan tk ON k.idTipeKendaraan = tk.idTipeKendaraan";
                    using var cmd = new Npgsql.NpgsqlCommand(query, conn);
                    using var adapter = new Npgsql.NpgsqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            return dt;
        }

        internal object GetKendaraan()
        {
            throw new NotImplementedException();
        }
    }
}

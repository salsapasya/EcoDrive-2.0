using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms; 

namespace EcoDrive_vol2.Context
{
    public class AdTransaksiContext : ITransaksi
    {
        public List<TransaksiModel> GetAllTransaksi()
        {
            return GetTransaksiBerdasarkanFilter("Semua");
        }

        public List<TransaksiModel> GetTransaksiBerdasarkanFilter(string filterMode)
        {
            List<TransaksiModel> listTransaksi = new List<TransaksiModel>();
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT * FROM view_admin_transaksi";

                if (filterMode == "Sewa")
                    query += " WHERE kategori = 'Sewa'";
                else if (filterMode == "Charging")
                    query += " WHERE kategori = 'Charging'";

                query += " ORDER BY id_transaksi DESC";

                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransaksiModel trx = new TransaksiModel
                    {
                        IdTransaksi = reader["id_transaksi"]?.ToString() ?? "",
                        Kategori = reader["kategori"]?.ToString() ?? "",
                        Username = reader["username"]?.ToString() ?? "",
                        Nama = reader["nama"]?.ToString() ?? "",
                        Kontak = reader["kontak"]?.ToString() ?? "",

                        NamaKendaraan = reader["nama_kendaraan"] != DBNull.Value ? reader["nama_kendaraan"].ToString() : "-",
                        TipeKendaraan = reader["tipe_kendaraan"] != DBNull.Value ? reader["tipe_kendaraan"].ToString() : "-",
                        NomorPlat = reader["nomor_plat"] != DBNull.Value ? reader["nomor_plat"].ToString() : "-",

                        TanggalSewa = KonversiTanggal(reader["tanggal_sewa"]),
                        TanggalKembali = KonversiTanggal(reader["tanggal_kembali"]),
                        TanggalCharging = KonversiTanggal(reader["tanggal_charging"]),

                        NamaStation = reader["nama_station"] != DBNull.Value ? reader["nama_station"].ToString() : "-",

                        // Ensure DurasiTransaksi is a string to match TransaksiModel
                        DurasiTransaksi = reader["durasi_transaksi"] != DBNull.Value
                                          ? reader["durasi_transaksi"].ToString()
                                          : "0",

                        Status = reader["status"]?.ToString() ?? "-",

                        TotalBiaya = reader["total_biaya"] != DBNull.Value
                                     ? Convert.ToDecimal(reader["total_biaya"])
                                     : 0m,

                        RawId = reader["raw_id"] != DBNull.Value
                                ? Convert.ToInt32(reader["raw_id"])
                                : 0
                    };

                    listTransaksi.Add(trx);
                }
            }
            catch (Exception ex)
            {
                // Gunakan MessageBox untuk debugging, pastikan namespace System.Windows.Forms di-import
                MessageBox.Show("Error saat memuat data: " + ex.Message, "DEBUG ERROR");
                throw;
            }

            return listTransaksi;
        }

        private string KonversiTanggal(object obj)
        {
            if (obj == null || obj == DBNull.Value) return "-";

            try
            {
                if (obj is DateOnly d) return d.ToString("yyyy-MM-dd");
                if (obj is DateTime dt) return dt.ToString("yyyy-MM-dd");
                return obj.ToString();
            }
            catch
            {
                return "-";
            }
        }

        public void UpdateStatusCharging(int rawId)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            string query = "UPDATE transaksi_charging SET status_charging = 'mengisi daya'::charging_status WHERE id_transaksi_charging = @id";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", rawId);
            cmd.ExecuteNonQuery();
        }

        public void UpdateStatusPengembalian(int rawId)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();

                string query = @"
                UPDATE transaksi_sewa
                SET status_pengembalian = 'sudah kembali'::status_kembali
                WHERE id_transaksi_sewa = @id";

                using var cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", rawId);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
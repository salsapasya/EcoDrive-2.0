using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace EcoDrive_vol2.Context.Admin
{
    public class AdTransaksiContext : ITransaksi
    {
        public List<Transaksi> GetAllTransaksi()
        {
            return GetTransaksiBerdasarkanFilter("Semua");
        }

        public List<Transaksi> GetTransaksiBerdasarkanFilter(string filterMode)
        {
            List<Transaksi> listTransaksi = new List<Transaksi>();
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
                    Transaksi model = new Transaksi();
                    model.Kategori = reader["kategori"].ToString();
                    model.IdTransaksi = model.Kategori + "-" + reader["id_transaksi"].ToString();
                    model.Username = reader["username"].ToString();
                    model.Nama = reader["nama"].ToString();
                    model.Kontak = reader["kontak"].ToString();
                    model.NamaKendaraan = reader["nama_kendaraan"].ToString();
                    model.TipeKendaraan = reader["tipe_kendaraan"]?.ToString() ?? "-";
                    model.NomorPlat = reader["nomor_plat"]?.ToString() ?? "-";
                    string durasiAsli = reader["durasi_transaksi"].ToString();
                    if (model.Kategori == "Sewa")
                    {
                        model.DurasiTransaksi = durasiAsli + " Hari";
                    }
                    else if (model.Kategori == "Charging")
                    {
                        model.DurasiTransaksi = durasiAsli + " Menit";
                    }
                    else
                    {
                        model.DurasiTransaksi = durasiAsli; // Jaga-jaga jika ada kategori lain
                    }
                    model.Status = reader["status"].ToString();
                    model.NamaStation = reader["nama_station"] != DBNull.Value ? reader["nama_station"].ToString() : "-";

                    // Mapping Tanggal (Mencegah error jika NULL)
                    model.TanggalSewa = reader["tanggal_sewa"] != DBNull.Value ? (reader["tanggal_sewa"] is DateOnly tglSewa ? tglSewa.ToString("dd MMM yyyy") : Convert.ToDateTime(reader["tanggal_sewa"]).ToString("dd MMM yyyy")) : "-";
                    model.TanggalKembali = reader["tanggal_kembali"] != DBNull.Value ? (reader["tanggal_kembali"] is DateOnly tglKembali ? tglKembali.ToString("dd MMM yyyy") : Convert.ToDateTime(reader["tanggal_kembali"]).ToString("dd MMM yyyy")) : "-";
                    model.TanggalCharging = reader["tanggal_charging"] != DBNull.Value ? (reader["tanggal_charging"] is DateOnly tglCharging ? tglCharging.ToString("dd MMM yyyy") : Convert.ToDateTime(reader["tanggal_charging"]).ToString("dd MMM yyyy")) : "-";

                    model.TotalBiaya = reader["total_biaya"] != DBNull.Value ? Convert.ToDecimal(reader["total_biaya"]) : 0;

                    // Mengambil RawId (Misal "Charging-15" diambil angka 15-nya)
                    string[] pisahId = model.IdTransaksi.Split('-');
                    if (reader["raw_id"] != DBNull.Value)
                    {
                        model.RawId = Convert.ToInt32(reader["raw_id"]);
                    }

                    listTransaksi.Add(model);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error load view_admin_transaksi : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return listTransaksi;
        }

        public void UpdateStatusCharging(int rawId)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("sp_konfirmasi_charging", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_raw_id", rawId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            

        public void UpdateStatusPengembalian(int rawId)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand("sp_penyelesaian_sewa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_raw_id", rawId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
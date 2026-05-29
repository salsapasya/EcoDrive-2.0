using System;
using System.Collections.Generic;
using System.Text;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.AbstractandInterface.Interface;
using Npgsql;

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
                {
                    query += " WHERE kategori_transaksi = 'Sewa'";
                }
                else if (filterMode == "Charging")
                {
                    query += " WHERE kategori_transaksi = 'Charging'";
                }

                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransaksiModel model = new TransaksiModel();

                    model.IdTransaksi = reader["id_transaksi"].ToString();
                    model.Kategori = reader["kategori_transaksi"].ToString();
                    model.Username = reader["username_customer"].ToString();
                    model.Nama = reader["nama_customer"].ToString();
                    model.Kontak = reader["kontak_customer"].ToString();
                    model.NamaKendaraan = reader["nama_kendaraan"].ToString();
                    model.TipeKendaraan = reader["tipe_kendaraan"]?.ToString() ?? "-";
                    model.NomorPlat = reader["nomor_plat"]?.ToString() ?? "-";
                    model.DurasiTransaksi = reader["durasi_transaksi"].ToString();
                    model.Status = reader["status_transaksi"].ToString();
                    model.NamaStation = reader["nama_station"] != DBNull.Value ? reader["nama_station"].ToString() : "-";

                    // Mapping Tanggal (Mencegah error jika NULL)
                    model.TanggalSewa = reader["tanggal_sewa"] != DBNull.Value ? (reader["tanggal_sewa"] is DateOnly tglSewa ? tglSewa.ToString("dd MMM yyyy") : Convert.ToDateTime(reader["tanggal_sewa"]).ToString("dd MMM yyyy")) : "-";
                    model.TanggalKembali = reader["tanggal_kembali"] != DBNull.Value ? (reader["tanggal_kembali"] is DateOnly tglKembali ? tglKembali.ToString("dd MMM yyyy") : Convert.ToDateTime(reader["tanggal_kembali"]).ToString("dd MMM yyyy")) : "-";
                    model.TanggalCharging = reader["tanggal_charging"] != DBNull.Value ? (reader["tanggal_charging"] is DateOnly tglCharging ? tglCharging.ToString("dd MMM yyyy") : Convert.ToDateTime(reader["tanggal_charging"]).ToString("dd MMM yyyy")) : "-";

                    model.TotalBiaya = reader["total_biaya"] != DBNull.Value ? Convert.ToDecimal(reader["total_biaya"]) : 0;

                    // Mengambil RawId (Misal "Charging-15" diambil angka 15-nya)
                    string[] pisahId = model.IdTransaksi.Split('-');
                    if (pisahId.Length == 2 && int.TryParse(pisahId[1], out int rawId))
                    {
                        model.RawId = rawId;
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
    }
}

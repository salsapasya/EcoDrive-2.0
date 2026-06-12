using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Vehicles;
using Npgsql;
using System;
using System.Collections.Generic;

namespace EcoDrive_vol2.Context.Admin
{
    class AdKendaraanContext
    {
        public List<Kendaraan> GetAllKendaraan()
        {
            List<Kendaraan> kendaraanList = new List<Kendaraan>();

            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();

                string query = @"SELECT id_kendaraan, id_merk_kendaraan, nomor_plat_kendaraan, nama_kendaraan, 
                                        stok_kendaraan, harga_sewa, tipe_kendaraan, status_kendaraan 
                                 FROM kendaraan 
                                 WHERE is_deleted = false";

                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Kendaraan kendaraan = new Kendaraan
                    {
                        IdKendaraan = Convert.ToInt32(reader["id_kendaraan"]),
                        IdMerkKendaraan = Convert.ToInt32(reader["id_merk_kendaraan"]),
                        NomorPlatKendaraan = reader["nomor_plat_kendaraan"].ToString(),
                        NamaKendaraan = reader["nama_kendaraan"].ToString(),
                        StokKendaraan = Convert.ToInt32(reader["stok_kendaraan"]),
                        HargaSewa = Convert.ToDecimal(reader["harga_sewa"]),

                        TipeKendaraan = Enum.Parse<KendaraanTipe>(
                            reader["tipe_kendaraan"].ToString(), true
                        ),

                        StatusKendaraan = Enum.Parse<OptionStatus>(
                            reader["status_kendaraan"].ToString().Replace(" ", "_"), true
                        )
                    };

                    kendaraanList.Add(kendaraan);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Ambil Kendaraan: " + ex.Message);
            }

            return kendaraanList;
        }

        public void AddKendaraan(Kendaraan kendaraan)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();

                string query = @"
                    INSERT INTO kendaraan
                    (
                        id_merk_kendaraan,
                        nomor_plat_kendaraan,
                        nama_kendaraan,
                        stok_kendaraan,
                        harga_sewa,
                        tipe_kendaraan,
                        status_kendaraan
                    )
                    VALUES
                    (
                        @id_merk_kendaraan,
                        @nomor_plat_kendaraan,
                        @nama_kendaraan,
                        @stok_kendaraan,
                        @harga_sewa,
                        @tipe_kendaraan::tipe_kendaraan, 
                        @status_kendaraan::option_status
                    )";

                using var cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id_merk_kendaraan", kendaraan.IdMerkKendaraan);
                cmd.Parameters.AddWithValue("@nomor_plat_kendaraan", kendaraan.NomorPlatKendaraan);
                cmd.Parameters.AddWithValue("@nama_kendaraan", kendaraan.NamaKendaraan);
                cmd.Parameters.AddWithValue("@stok_kendaraan", kendaraan.StokKendaraan);
                cmd.Parameters.AddWithValue("@harga_sewa", kendaraan.HargaSewa);

                cmd.Parameters.AddWithValue("@tipe_kendaraan", kendaraan.TipeKendaraan.ToString().ToLower());
                cmd.Parameters.AddWithValue("@status_kendaraan", kendaraan.StatusKendaraan.ToString().ToLower().Replace("_", " "));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Tambah Kendaraan: " + ex.Message);
            }
        }

        public void UpdateKendaraan(Kendaraan kendaraan)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();

                string query = @"
                    UPDATE kendaraan
                    SET
                        nama_kendaraan = @nama_kendaraan,
                        harga_sewa = @harga_sewa,
                        status_kendaraan = @status_kendaraan::option_status
                    WHERE id_kendaraan = @id_kendaraan";

                using var cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nama_kendaraan", kendaraan.NamaKendaraan);
                cmd.Parameters.AddWithValue("@harga_sewa", kendaraan.HargaSewa);
                cmd.Parameters.AddWithValue("@status_kendaraan", kendaraan.StatusKendaraan.ToString().ToLower().Replace("_", " "));
                cmd.Parameters.AddWithValue("@id_kendaraan", kendaraan.IdKendaraan);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Update Kendaraan: " + ex.Message);
            }
        }

        public void DeleteKendaraan(int idKendaraan)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();

                string query = "UPDATE kendaraan SET is_deleted = true WHERE id_kendaraan = @id_kendaraan";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_kendaraan", idKendaraan);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Delete Kendaraan (Soft Delete): " + ex.Message);
            }
        }
    }
}
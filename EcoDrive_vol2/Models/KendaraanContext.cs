using EcoDrive_vol2.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace EcoDrive_vol2.Models
{
    class KendaraanContext
    {
        public List<Kendaraan> GetAllKendaraan()
        {
            List<Kendaraan> kendaraanlist = new List<Kendaraan>();
            using var conn = DatabaseHelper.GetConnection();
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM kendaraan";
                    using var cmd = new NpgsqlCommand(query, conn);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Kendaraan kendaraan = new Kendaraan
                        {
                            idKendaraan = reader.GetInt32(0),
                            idTipeKendaraan = reader.GetInt32(1),
                            NamaKendaraan = reader.GetString(2),
                            HargaSewa = reader.GetDecimal(3)
                        };
                        kendaraanlist.Add(kendaraan);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            // Implementasi untuk mengambil semua kendaraan dari database
            return kendaraanlist;
        }
        public void AddKendaraan(Kendaraan kendaraan)
        {
            using var conn = DatabaseHelper.GetConnection();
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO kendaraan (idTipeKendaraan, NamaKendaraan, HargaSewa) VALUES (@idTipeKendaraan, @NamaKendaraan, @HargaSewa)";
                    using var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("idTipeKendaraan", kendaraan.idTipeKendaraan);
                    cmd.Parameters.AddWithValue("NamaKendaraan", kendaraan.NamaKendaraan);
                    cmd.Parameters.AddWithValue("HargaSewa", kendaraan.HargaSewa);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            // Implementasi untuk menambahkan kendaraan ke database
        }
        public void UpdateKendaraan(Kendaraan kendaraan)
        {
            using var conn = DatabaseHelper.GetConnection();
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE kendaraan SET idTipeKendaraan = @idTipeKendaraan, NamaKendaraan = @NamaKendaraan, HargaSewa = @HargaSewa WHERE idKendaraan = @idKendaraan";
                    using var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("idTipeKendaraan", kendaraan.idTipeKendaraan);
                    cmd.Parameters.AddWithValue("NamaKendaraan", kendaraan.NamaKendaraan);
                    cmd.Parameters.AddWithValue("HargaSewa", kendaraan.HargaSewa);
                    cmd.Parameters.AddWithValue("idKendaraan", kendaraan.idKendaraan);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            // Implementasi untuk memperbarui data kendaraan di database
        }
        public void DeleteKendaraan(int idKendaraan)
        {
            using var conn = DatabaseHelper.GetConnection();
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM kendaraan WHERE idKendaraan = @idKendaraan";
                    using var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("idKendaraan", idKendaraan);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            // Implementasi untuk menghapus kendaraan dari database
        }
    }
}

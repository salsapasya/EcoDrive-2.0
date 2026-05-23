using EcoDrive_vol2.Helpers;
using Npgsql;
using EcoDrive_vol2.Models;

namespace EcoDrive_vol2.Context
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
                        Kendaraan kendaraan =
                            new Kendaraan
                            {
                                IdKendaraan =
                                    reader.GetInt32(0),

                                IdTipeKendaraan =
                                    reader.GetInt32(1),

                                IdMerkKendaraan =
                                    reader.GetInt32(2),

                                NamaKendaraan =
                                    reader.GetString(3),

                                StokKendaraan =
                                    reader.GetInt32(4),

                                HargaSewa =
                                    reader.GetInt32(5),

                                StatusKendaraan =
                                    reader.GetString(6)
                            };

                        kendaraanlist.Add( kendaraan);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
                return kendaraanlist;
            }
        }
        public void AddKendaraan(Kendaraan kendaraan)
        {
            using var conn = DatabaseHelper.GetConnection();
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO kendaraan (idTipeKendaraan, NamaKendaraan, HargaSewa, StatusKetersediaan, StokKendaraan, idMerkKendaraan)" +
                       " VALUES (@idTipeKendaraan, @NamaKendaraan, @HargaSewa, @StatusKetersediaan, @StokKendaraan, @idMerkKendaraan)";
                    using var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("idTipeKendaraan", kendaraan.IdTipeKendaraan);
                    cmd.Parameters.AddWithValue("NamaKendaraan", kendaraan.NamaKendaraan);
                    cmd.Parameters.AddWithValue("HargaSewa", kendaraan.HargaSewa);
                    cmd.Parameters.AddWithValue("StatusKetersediaan", kendaraan.StatusKendaraan);
                    cmd.Parameters.AddWithValue("StokKendaraan", kendaraan.StokKendaraan);
                    cmd.Parameters.AddWithValue("idMerkKendaraan", kendaraan.IdMerkKendaraan);
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
                    cmd.Parameters.AddWithValue("idTipeKendaraan", kendaraan.IdTipeKendaraan);
                    cmd.Parameters.AddWithValue("NamaKendaraan", kendaraan.NamaKendaraan);
                    cmd.Parameters.AddWithValue("HargaSewa", kendaraan.HargaSewa);
                    cmd.Parameters.AddWithValue("idKendaraan", kendaraan.IdKendaraan);
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
    


        

using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Vehicles;
using Npgsql;

namespace EcoDrive_vol2.Context.Admin
{
    class KendaraanContext
    {
        public List<Kendaraan> GetAllKendaraan()
        {
            List<Kendaraan> kendaraanList = new List<Kendaraan>();

            using var conn = DatabaseHelper.GetConnection();

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
                        IdKendaraan = reader.GetInt32(0),

                        IdMerkKendaraan = reader.GetInt32(1),

                        NomorPlatKendaraan = reader.GetString(2),

                        NamaKendaraan = reader.GetString(3),

                        StokKendaraan = reader.GetInt32(4),

                        HargaSewa = reader.GetDecimal(5),

                        TipeKendaraan =
                            Enum.Parse<KendaraanTipe>(
                                reader.GetString(6)
                            ),

                        StatusKendaraan =
                            Enum.Parse<OptionStatus>(
                                reader.GetString(7)
                                    .Replace(" ", "_")
                            )
                    };

                    kendaraanList.Add(kendaraan);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return kendaraanList;
        }


        public void AddKendaraan(Kendaraan kendaraan)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();

                string query =
                    @"INSERT INTO kendaraan
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
                        @tipe_kendaraan,
                        @status_kendaraan
                    )";

                using var cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@id_merk_kendaraan",
                    kendaraan.IdMerkKendaraan
                );

                cmd.Parameters.AddWithValue(
                    "@nomor_plat_kendaraan",
                    kendaraan.NomorPlatKendaraan
                );

                cmd.Parameters.AddWithValue(
                    "@nama_kendaraan",
                    kendaraan.NamaKendaraan
                );

                cmd.Parameters.AddWithValue(
                    "@stok_kendaraan",
                    kendaraan.StokKendaraan
                );

                cmd.Parameters.AddWithValue(
                    "@harga_sewa",
                    kendaraan.HargaSewa
                );

                cmd.Parameters.AddWithValue(
                    "@tipe_kendaraan",
                    kendaraan.TipeKendaraan.ToString()
                );

                cmd.Parameters.AddWithValue(
                    "@status_kendaraan",
                    kendaraan.StatusKendaraan.ToString()
                        .Replace("_", " ")
                );

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
        public void UpdateKendaraan(Kendaraan kendaraan)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();

                string query =
                @"UPDATE kendaraan
          SET
            nama_kendaraan = @nama_kendaraan,
            harga_sewa = @harga_sewa,
            status_kendaraan = @status_kendaraan
          WHERE id_kendaraan = @id_kendaraan";

                using var cmd =
                    new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@nama_kendaraan",
                    kendaraan.NamaKendaraan
                );

                cmd.Parameters.AddWithValue(
                    "@harga_sewa",
                    kendaraan.HargaSewa
                );

                cmd.Parameters.AddWithValue(
                    "@status_kendaraan",
                    kendaraan.StatusKendaraan
                        .ToString()
                        .Replace("_", " ")
                );

                cmd.Parameters.AddWithValue(
                    "@id_kendaraan",
                    kendaraan.IdKendaraan
                );

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error Update Kendaraan: "
                    + ex.Message
                );
            }
        }
        public void DeleteKendaraan(int idKendaraan)
        {
            using var conn =
                DatabaseHelper.GetConnection();

            try
            {
                conn.Open();

                string query =
                    @"DELETE FROM kendaraan
              WHERE id_kendaraan =
              @id_kendaraan";

                using var cmd =
                    new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@id_kendaraan",
                    idKendaraan
                );

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error Delete Kendaraan: "
                    + ex.Message
                );
            }
        }
    }
}
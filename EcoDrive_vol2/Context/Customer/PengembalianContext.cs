using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Transaksi;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Context.Customer
{
    public class PengembalianContext
    {
        public List<TransaksiSewa> GetSewaAktifUser(int idUser)
        {
            var list = new List<TransaksiSewa>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = "SELECT * FROM view_pengembalian_sewa_user" +
                " WHERE id_user = @idUser " +
                "AND status_pengembalian::text != 'sudah kembali'";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idUser", idUser);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string statusDB = reader["status_pengembalian"].ToString();
                string statusAman = statusDB.Replace(" ", "_");
                StatusKembali parsedStatus = Enum.Parse<StatusKembali>(statusAman, true);

                var tglSewaDb = (DateOnly)reader["tanggal_sewa"];
                var tglKembaliDb = (DateOnly)reader["tanggal_kembali"];
                list.Add(new TransaksiSewa
                {
                    IdTransaksiSewa = Convert.ToInt32(reader["id_transaksi_sewa"]),
                    IdUser = Convert.ToInt32(reader["id_user"]),
                    IdKendaraan = Convert.ToInt32(reader["id_kendaraan"]),
                    NamaKendaraan = reader["nama_kendaraan"].ToString(),
                    NomorPlatKendaraan = reader["nomor_plat_kendaraan"].ToString(),
                    TanggalSewa = tglSewaDb.ToDateTime(TimeOnly.MinValue),
                    TanggalKembali = tglKembaliDb.ToDateTime(TimeOnly.MinValue),
                    DurasiSewa = Convert.ToInt32(reader["durasi_sewa"]),
                    StatusPengembalian = parsedStatus
                });
            }
            return list;
        }
        public void AjukanPengembalian(int idTransaksiSewa)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = "CALL sp_ajukan_pengembalian(@idSewa)";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("idSewa", idTransaksiSewa);
            cmd.ExecuteNonQuery();
        }
    }
}

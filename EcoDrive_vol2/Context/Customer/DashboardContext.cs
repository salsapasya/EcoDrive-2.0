using System;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Users;
using Npgsql;

namespace EcoDrive_vol2.Context.Customer
{
    public class DashboardContext
    {
        public decimal GetSaldoUser(int idUser)
        {
            decimal saldo = 0;
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = "SELECT saldo FROM users WHERE id_user = @idUser";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idUser", idUser);

            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                saldo = Convert.ToDecimal(result);
            }
            return saldo;
        }

        public int GetTotalRiwayatSewa(int idUser)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = "SELECT COUNT(*) FROM transaksi_sewa WHERE id_user = @idUser";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idUser", idUser);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public RentalAktifDto GetRentalAktif(int idUser)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = @"
                SELECT k.nama_kendaraan, k.nomor_plat_kendaraan, ts.tanggal_kembali
                FROM transaksi_sewa ts
                JOIN kendaraan k ON ts.id_kendaraan = k.id_kendaraan
                WHERE ts.id_user = @idUser AND ts.status_pengembalian = 'belum kembali'::status_kembali
                ORDER BY ts.id_transaksi_sewa DESC LIMIT 1";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idUser", idUser);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                DateTime tanggalFix;
                var rawTanggal = reader["tanggal_kembali"];

                if (rawTanggal is DateOnly dateOnly)
                {
                    tanggalFix = dateOnly.ToDateTime(TimeOnly.MinValue);
                }
                else
                {
                    tanggalFix = Convert.ToDateTime(rawTanggal);
                }

                return new RentalAktifDto
                {
                    IsActive = true,
                    NamaKendaraan = reader["nama_kendaraan"].ToString(),
                    NomorPlat = reader["nomor_plat_kendaraan"].ToString(),
                    TanggalKembali = tanggalFix 
                };
            }

            return new RentalAktifDto { IsActive = false };
        }
        public dynamic GetAdminDashboardStats()
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = @"
            SELECT
            (SELECT COUNT(*) FROM users) AS total_customer,
            (SELECT COUNT(*) FROM kendaraan) AS total_kendaraan,
            (SELECT COUNT(*)
             FROM transaksi_sewa
             WHERE status_pengembalian = 'belum kembali') AS total_disewa,

            (SELECT COUNT(*)
             FROM kendaraan
             WHERE status_kendaraan = 'tersedia') AS tersedia,

            (SELECT COUNT(*)
             FROM kendaraan
             WHERE status_kendaraan = 'disewa') AS disewa,

            (SELECT COUNT(*)
             FROM kendaraan
             WHERE status_kendaraan = 'rusak') AS rusak,

            (SELECT COUNT(*)
             FROM kendaraan
             WHERE status_kendaraan = 'dalam perbaikan') AS maintenance";

            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new
                {
                    TotalCustomer = Convert.ToInt32(reader["total_customer"]),
                    TotalKendaraan = Convert.ToInt32(reader["total_kendaraan"]),
                    TotalDisewa = Convert.ToInt32(reader["total_disewa"]),
                    Tersedia = Convert.ToInt32(reader["tersedia"]),
                    Disewa = Convert.ToInt32(reader["disewa"]),
                    Rusak = Convert.ToInt32(reader["rusak"]),
                    Maintenance = Convert.ToInt32(reader["maintenance"])
                };
            }

            return null;
        }
    }

    public class RentalAktifDto
    {
        public bool IsActive { get; set; }
        public string NamaKendaraan { get; set; }
        public string NomorPlat { get; set; }
        public DateTime TanggalKembali { get; set; }
    }
}
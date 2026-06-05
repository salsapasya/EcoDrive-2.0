using EcoDrive_vol2.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Context
{
    public class RentalContext
    {
        public decimal GetEstimasiBiaya(int idKendaraan, int durasi)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = "SELECT * FROM hitung_estimasi_biaya(@idKendaraan, @durasi)";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idKendaraan", idKendaraan);
            cmd.Parameters.AddWithValue("@durasi", durasi);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        public void EksekusiPembayaranSewa(int idUser, int idKendaraan, int durasi, decimal totalBiaya)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var transaction = conn.BeginTransaction();

            try
            {
                string potongSaldo = "UPDATE users SET saldo = saldo - @totalBiaya WHERE id_user = @idUser";
                using (var cmdSaldo = new NpgsqlCommand(potongSaldo, conn, transaction))
                {
                    cmdSaldo.Parameters.AddWithValue("@totalBiaya", totalBiaya);
                    cmdSaldo.Parameters.AddWithValue("@idUser", idUser);
                    cmdSaldo.ExecuteNonQuery();
                }

                DateTime tanggalSewa = DateTime.Now;
                DateTime tanggalKembali = tanggalSewa.AddDays(durasi);

                string insertTransaks = @"INSERT INTO transaksi_sewa (id_user, id_kendaraan, durasi_sewa, tanggal_sewa, tanggal_kembali, status_pengembalian) 
                                   VALUES (@idUser, @idKendaraan, @durasi, @tanggal_sewa, @tanggal_kembali, 'belum kembali'::status_pengembalian)";
                using (var cmdInsert = new NpgsqlCommand(insertTransaks, conn, transaction))
                {
                    cmdInsert.Parameters.AddWithValue("@idUser", idUser);
                    cmdInsert.Parameters.AddWithValue("@idKendaraan", idKendaraan);
                    cmdInsert.Parameters.AddWithValue("@durasi", durasi);
                    cmdInsert.Parameters.AddWithValue("@tanggal_sewa", tanggalSewa);
                    cmdInsert.Parameters.AddWithValue("@tanggal_kembali", tanggalKembali);
                    cmdInsert.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Gagal melakukan pembayaran: " + ex.Message);
            }
        }
    }
}

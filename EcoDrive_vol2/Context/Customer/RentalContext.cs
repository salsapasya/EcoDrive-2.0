using EcoDrive_vol2.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Context.Customer
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

        // bagian baris parameter ini menerima objek TransaksiSewa
        public void EksekusiPembayaranSewa(EcoDrive_vol2.Models.Transaksi.TransaksiSewa transaksi)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var transaction = conn.BeginTransaction();

            try
            {
                string potongSaldo = "UPDATE users SET saldo = saldo - @totalBiaya WHERE id_user = @idUser";
                using (var cmdSaldo = new NpgsqlCommand(potongSaldo, conn, transaction))
                {
                    // Ambil data langsung dari properti objek transaksi
                    cmdSaldo.Parameters.AddWithValue("@totalBiaya", transaksi.TotalBiaya);
                    cmdSaldo.Parameters.AddWithValue("@idUser", transaksi.IdUser);
                    cmdSaldo.ExecuteNonQuery();
                }

                DateTime tanggalSewa = DateTime.Now;
                DateTime tanggalKembali = tanggalSewa.AddDays(transaksi.DurasiSewa);

                string insertTransaks = @"INSERT INTO transaksi_sewa (id_user, id_kendaraan, durasi_sewa, tanggal_sewa, tanggal_kembali, status_pengembalian) 
                                   VALUES (@idUser, @idKendaraan, @durasi, @tanggal_sewa, @tanggal_kembali, @statusPengembalian::status_kembali)";

                using (var cmdInsert = new NpgsqlCommand(insertTransaks, conn, transaction))
                {
                    cmdInsert.Parameters.AddWithValue("@idUser", transaksi.IdUser);
                    cmdInsert.Parameters.AddWithValue("@idKendaraan", transaksi.IdKendaraan);
                    cmdInsert.Parameters.AddWithValue("@durasi", transaksi.DurasiSewa);
                    cmdInsert.Parameters.AddWithValue("@tanggal_sewa", tanggalSewa);
                    cmdInsert.Parameters.AddWithValue("@tanggal_kembali", tanggalKembali);

                    cmdInsert.Parameters.AddWithValue("@statusPengembalian", "belum kembali");

                    cmdInsert.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}

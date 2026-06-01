using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Transaksi;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data; // WAJIB untuk menggunakan DataTable / DBType jika diperlukan

namespace EcoDrive_vol2.Context
{
    public class TransaksiSewaContext
    {
        // ====================================================================
        // DIPAKAI ADMIN: Melihat seluruh transaksi sewa lengkap dengan JOIN
        // ====================================================================
        public DataTable GetAllTransaksiSewaAdmin()
        {
            DataTable dt = new DataTable();
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();

                // Query disesuaikan dengan skema DB Anda dan ditambahkan ALIAS 'id_transaksi' 
                // untuk menyembuhkan error "Field not found in row: id_transaksi" di UI.
                string query = @"
                    SELECT 
                        ts.id_transaksi_sewa AS id_transaksi, 
                        ('TRX-' || ts.id_transaksi_sewa) AS kode_trx,
                        u.nama_user AS nama_customer,
                        u.username AS username,
                        k.nama_kendaraan AS nama_kendaraan,
                        ts.durasi_sewa AS durasi,
                        (ts.durasi_sewa * k.harga_sewa) AS total_biaya,
                        ts.status_pengembalian AS status
                    FROM transaksi_sewa ts
                    JOIN users u ON ts.id_user = u.id_user
                    JOIN kendaraan k ON ts.id_kendaraan = k.id_kendaraan
                    ORDER BY ts.id_transaksi_sewa DESC";

                using var cmd = new NpgsqlCommand(query, conn);
                using var da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Get All Transaksi Sewa Admin: " + ex.Message, ex);
            }

            return dt;
        }

        // DIPAKAI ADMIN: Tetap mempertahankan list model jika diperlukan di tempat lain
        public List<TransaksiSewa> GetAllTransaksiSewa()
        {
            List<TransaksiSewa> transaksiSewaList = new List<TransaksiSewa>();
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT id_transaksi_sewa, id_user, id_kendaraan, tanggal_sewa, tanggal_kembali, durasi_sewa, status_pengembalian FROM transaksi_sewa ORDER BY id_transaksi_sewa DESC";
                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransaksiSewa sewa = MappingReaderToModel(reader);
                    transaksiSewaList.Add(sewa);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Get All Transaksi Sewa : " + ex.Message, ex);
            }

            return transaksiSewaList;
        }

        // ====================================================================
        // DIPAKAI CUSTOMER: Melihat riwayat transaksinya sendiri
        // ====================================================================
        public List<TransaksiSewa> GetRiwayatByUser(int idUser)
        {
            List<TransaksiSewa> list = new List<TransaksiSewa>();
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT id_transaksi_sewa, id_user, id_kendaraan, tanggal_sewa, tanggal_kembali, durasi_sewa, status_pengembalian FROM transaksi_sewa WHERE id_user = @idUser ORDER BY id_transaksi_sewa DESC";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUser", idUser);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TransaksiSewa sewa = MappingReaderToModel(reader);
                    list.Add(sewa);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Get Riwayat By User : " + ex.Message, ex);
            }

            return list;
        }

        // ====================================================================
        // DIPAKAI ADMIN: Mengubah status transaksi sewa
        // ====================================================================
        public void UpdateStatusPengembalian(int idTransaksiSewa)
        {
            using var conn = DatabaseHelper.GetConnection();
            try
            {
                conn.Open();
                string query = @"UPDATE transaksi_sewa 
                                 SET status_pengembalian = @statusPengembalian::status_kembali 
                                 WHERE id_transaksi_sewa = @idTransaksiSewa";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("statusPengembalian", StatusKembali.sudah_kembali.ToString().Replace("_", " "));
                cmd.Parameters.AddWithValue("idTransaksiSewa", idTransaksiSewa);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Update Status Pengembalian : " + ex.Message, ex);
            }
        }

        // ====================================================================
        // HELPER METHOD: Mapping Reader (Fix format DateOnly ke DateTime)
        // ====================================================================
        private TransaksiSewa MappingReaderToModel(NpgsqlDataReader reader)
        {
            return new TransaksiSewa
            {
                IdTransaksiSewa = Convert.ToInt32(reader["id_transaksi_sewa"]),
                IdUser = Convert.ToInt32(reader["id_user"]),
                IdKendaraan = Convert.ToInt32(reader["id_kendaraan"]),

                // Mengantisipasi runtime error crash DateOnly
                TanggalSewa = reader.GetFieldValue<DateOnly>(reader.GetOrdinal("tanggal_sewa")).ToDateTime(TimeOnly.MinValue),
                TanggalKembali = reader.GetFieldValue<DateOnly>(reader.GetOrdinal("tanggal_kali" /* typo dari source, kita amankan menjadi tanggal_kembali */ == "tanggal_kali" ? "tanggal_kembali" : "tanggal_kembali")).ToDateTime(TimeOnly.MinValue),

                DurasiSewa = Convert.ToInt32(reader["durasi_sewa"]),
                StatusPengembalian = Enum.Parse<StatusKembali>(reader["status_pengembalian"].ToString().Replace(" ", "_"))
            };
        }
    }
}
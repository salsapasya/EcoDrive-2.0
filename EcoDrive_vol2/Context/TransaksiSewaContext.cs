using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Transaksi;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Context
{
    public class TransaksiSewaContext
    {
        public List<TransaksiSewa> GetAllTransaksiSewa()
        {
            List<TransaksiSewa> transaksiSewaList = new List<TransaksiSewa>();
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT * FROM transaksi_sewa";
                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TransaksiSewa sewa = new TransaksiSewa
                    {
                        IdTransaksiSewa = reader.GetInt32(0),
                        IdUser = reader.GetInt32(1),
                        IdKendaraan = reader.GetInt32(2),
                        TanggalSewa = reader.GetDateTime(3),
                        TanggalKembali = reader.GetDateTime(4),
                        DurasiSewa = reader.GetInt32(5),
                        StatusPengembalian = Enum.Parse<StatusKembali>(reader.GetString(6).Replace(" ", "_"))
                    };
                    transaksiSewaList.Add(sewa);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Get Transaksi Sewa : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return transaksiSewaList;
        }

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
                throw new Exception("Error Update Status Pengembalian : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Models.Enums;
using Npgsql;

namespace EcoDrive_vol2.Context
{
    public class TransaksiChargingContext
    {
        public List<TransaksiCharging> GetAllTransaksiCharging()
        {
            List<TransaksiCharging> transaksiChargingList = new List<TransaksiCharging>();
            using var conn = DatabaseHelper.GetConnection();
            try
            {
                conn.Open();
                string query = "SELECT * FROM transaksi_charging";
                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TransaksiCharging charging = new TransaksiCharging
                    {
                        IdTransaksiCharging = reader.GetInt32(0),
                        IdUser = reader.GetInt32(1),
                        IdKendaraan = reader.GetInt32(2),
                        IdChargingStation = reader.GetInt32(3),
                        BiayaCharging = reader.GetDecimal(4),
                        TanggalCharging = reader.GetDateTime(5),
                        StatusCharging = Enum.Parse<ChargingStatus>(reader.GetString(6).Replace(" ", "_")),
                        DurasiCharging = reader.GetInt32(7)
                    };
                    transaksiChargingList.Add(charging);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Get Transaksi Charging : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return transaksiChargingList;
        }
        // FUNGSI UNTUK KONFIRMASI DARI 'PENDING' KE 'MENGISI DAYA'
        public void UpdateStatusCharging(int idTransaksiCharging)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = @"UPDATE transaksi_charging 
                                 SET status_charging = @statusCharging 
                                 WHERE id_transaksi_charging = @idTransaksiCharging";
                using var cmd = new NpgsqlCommand(query, conn);

                // ngubah enum dari jadi string
                cmd.Parameters.AddWithValue("@statusCharging", ChargingStatus.mengisi_daya.ToString().Replace("_", " "));
                cmd.Parameters.AddWithValue("@idTransaksiCharging", idTransaksiCharging);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Update Status Charging : " + ex.Message);
            }
        }
    }
}

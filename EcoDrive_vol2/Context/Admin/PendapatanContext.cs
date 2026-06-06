using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Admin;
using Npgsql;

namespace EcoDrive_vol2.Context.Admin
{
    public class PendapatanContext
    {
        public CardPendapatanModel GetCardPendapatanByTahun(int tahun)
        {
            CardPendapatanModel model = new CardPendapatanModel();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = "SELECT * FROM get_card_total_by_tahun(@p_tahun)";
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("p_tahun", tahun);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model.TotalSewaTahunan = reader["total_sewa_tahunan"] != DBNull.Value ? Convert.ToDecimal(reader["total_sewa_tahunan"]) : 0;
                        model.TotalChargingTahunan = reader["total_charging_tahunan"] != DBNull.Value ? Convert.ToDecimal(reader["total_charging_tahunan"]) : 0;
                        model.TotalGabunganTahunan = reader["total_gabungan_tahunan"] != DBNull.Value ? Convert.ToDecimal(reader["total_gabungan_tahunan"]) : 0;
                        model.TotalUnitTahunan = reader["total_unit_tahunan"] != DBNull.Value ? Convert.ToInt64(reader["total_unit_tahunan"]) : 0;
                        model.TotalBanyakChargingTahunan = reader["total_banyak_charging_tahunan"] != DBNull.Value ? Convert.ToInt64(reader["total_banyak_charging_tahunan"]) : 0;
                    }
                }
            }
            return model;
        }
        public List<RincianPendapatanModel> GetRincianPendapatanByBulanTahun (int bulan, int tahun)
        {
            List<RincianPendapatanModel> listRincian = new List<RincianPendapatanModel>();

            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = "SELECT * FROM get_rincian_pendapatan_by_bulan_tahun(@p_bulan, @p_tahun)";
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("p_bulan", bulan);
                cmd.Parameters.AddWithValue("p_tahun", tahun);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateOnly tanggalDb = reader["tanggal_hari"] != DBNull.Value ? (DateOnly)reader["tanggal_hari"] : DateOnly.MinValue;
                        listRincian.Add(new RincianPendapatanModel
                        {
                            TanggalHari = tanggalDb.ToDateTime(TimeOnly.MinValue),
                            PendapatanSewa = reader["pendapatan_sewa"] != DBNull.Value ? Convert.ToDecimal(reader["pendapatan_sewa"]) : 0,
                            PendapatanCharging = reader["pendapatan_charging"] != DBNull.Value ? Convert.ToDecimal(reader["pendapatan_charging"]) : 0,
                            TotalHarian = reader["total_harian"] != DBNull.Value ? Convert.ToDecimal(reader["total_harian"]) : 0
                        });
                    }
                }
            }
            return listRincian;
        }
    }
}

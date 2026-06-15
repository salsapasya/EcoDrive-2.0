using EcoDrive.Models.Vehicles;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Models.Vehicles;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EcoDrive_vol2.Context.Customer
{
    public class ChargingContext
    {
        public List<ChargingStation> GetSemuaStation()
        {
            var list = new List<ChargingStation>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = "SELECT * FROM charging_station";
            using var cmd = new Npgsql.NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ChargingStation
                {
                    IdChargingStation = Convert.ToInt32(reader["id_charging_station"]),
                    NamaStation = reader["nama_station"].ToString(),
                    Lokasi = reader["lokasi"].ToString(),
                    TarifPer15Menit = Convert.ToDecimal(reader["tarif_per_15_menit"]),
                    JumlahSlot = Convert.ToInt32(reader["jumlah_slot"])
                });
            }
            return list;
        }

        public List<Kendaraan> GetKendaraanSewaUser(int idUser)
        {
            var list = new List<Kendaraan>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = "SELECT * FROM view_kendaraan_sewa_aktif WHERE id_user = @idUser";
            using var cmd = new Npgsql.NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idUser", idUser);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string namaKendaraan = reader["nama_kendaraan"].ToString();
                Kendaraan knd;

                // OOP Polimorfisme: Deteksi tipe objek konkrit saat mengambil dari database
                if (namaKendaraan.ToLower().Contains("mobil"))
                {
                    knd = new ElectricCar
                    {
                        IdKendaraan = Convert.ToInt32(reader["id_kendaraan"]),
                        NamaKendaraan = namaKendaraan,
                        NomorPlatKendaraan = reader["nomor_plat_kendaraan"].ToString()
                    };
                }
                else
                {
                    knd = new ElectricMotor
                    {
                        IdKendaraan = Convert.ToInt32(reader["id_kendaraan"]),
                        NamaKendaraan = namaKendaraan,
                        NomorPlatKendaraan = reader["nomor_plat_kendaraan"].ToString()
                    };
                }

                list.Add(knd);
            }
                return list;
        }

        public List<TransaksiCharging> GetTransaksiAktif(int idUser)
        {
            var list = new List<TransaksiCharging>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = "SELECT * FROM view_transaksi_charging_aktif WHERE id_user = @idUser";
            using var cmd = new Npgsql.NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idUser", idUser);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string statusCharging = reader["status_charging"].ToString();
                string statusAman = statusCharging.Replace(" ", "_");
                ChargingStatus parsedStatus = (ChargingStatus)Enum.Parse(typeof(ChargingStatus), statusAman, true);

                list.Add(new TransaksiCharging
                {
                    IdTransaksiCharging = Convert.ToInt32(reader["id_transaksi_charging"]),
                    BiayaCharging = Convert.ToDecimal(reader["biaya_charging"]),
                    StatusCharging = parsedStatus,

                    // Kolom tambahan hasil JOIN di dalam view database
                    NamaStation = reader["nama_station"].ToString(),
                    NamaKendaraan = reader["nama_kendaraan"].ToString(),
                    NomorPlat = reader["nomor_plat_kendaraan"].ToString()
                });
            }
            return list;
        }

        public void BuatTransaksiCharging (int idUser, int idKendaraan, int idStation, int durasi)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            
            string query = "CALL sp_buat_transaksi_charging(@idUser, @idKendaraan, @idStation, @durasi)";
            using var cmd = new Npgsql.NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idUser", idUser);
            cmd.Parameters.AddWithValue("@idKendaraan", idKendaraan);
            cmd.Parameters.AddWithValue("@idStation", idStation);
            cmd.Parameters.AddWithValue("@durasi", durasi);
            cmd.ExecuteNonQuery();
        }

        public void SelesaikanCharging(int idTransaksi)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            string query = "CALL sp_selesaikan_charging(@idTransaksi)";
            using var cmd = new Npgsql.NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idTransaksi", idTransaksi);
            cmd.ExecuteNonQuery();
        }
    }
}

using EcoDrive_vol2.Context.Admin;
using EcoDrive_vol2.Models;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Vehicles;
using System;
using System.Collections.Generic;

namespace EcoDrive_vol2.Services
{
    public class KendaraanService
    {
        private readonly AdKendaraanContext context = new AdKendaraanContext();

        public List<Kendaraan> GetAllKendaraan()
        {
            List<Kendaraan> data = context.GetAllKendaraan();
            List<Kendaraan> hasil = new List<Kendaraan>();

            if (data == null) return hasil;

            foreach (var item in data)
            {
                // Polimorfisme & Inheritance
                Kendaraan kendaraan = item.TipeKendaraan == KendaraanTipe.mobil ? new ElectricCar
                {
                    IdKendaraan = item.IdKendaraan,
                    IdMerkKendaraan = item.IdMerkKendaraan,
                    NomorPlatKendaraan = item.NomorPlatKendaraan,
                    NamaKendaraan = item.NamaKendaraan,
                    StokKendaraan = item.StokKendaraan,
                    HargaSewa = item.HargaSewa,
                    TipeKendaraan = KendaraanTipe.mobil,
                    StatusKendaraan = item.StatusKendaraan,
                } : new ElectricMotor
                {
                    IdKendaraan = item.IdKendaraan,
                    IdMerkKendaraan = item.IdMerkKendaraan,
                    NomorPlatKendaraan = item.NomorPlatKendaraan,
                    NamaKendaraan = item.NamaKendaraan,
                    StokKendaraan = item.StokKendaraan,
                    HargaSewa = item.HargaSewa,
                    TipeKendaraan = KendaraanTipe.motor,
                    StatusKendaraan = item.StatusKendaraan,
                };

                hasil.Add(kendaraan);
            }

            return hasil;
        }

        public List<Kendaraan> GetAvailableKendaraan(string filterAktif, string keyword)
        {
            List<Kendaraan> semuakendaraan = GetAllKendaraan();
            if (semuakendaraan == null) return new List<Kendaraan>();

            if (!string.IsNullOrEmpty(filterAktif) && filterAktif.Equals("Mobil", StringComparison.OrdinalIgnoreCase))
            {
                semuakendaraan = semuakendaraan.FindAll(x => x.TipeKendaraan == KendaraanTipe.mobil);
            }
            else if (!string.IsNullOrEmpty(filterAktif) && filterAktif.Equals("Motor", StringComparison.OrdinalIgnoreCase))
            {
                semuakendaraan = semuakendaraan.FindAll(x => x.TipeKendaraan == KendaraanTipe.motor);
            }

            string cleanKeyword = keyword?.Trim().ToLower();
            if (!string.IsNullOrEmpty(cleanKeyword))
            {
                semuakendaraan = semuakendaraan.FindAll(x =>
                    x.NamaKendaraan.ToLower().Contains(cleanKeyword) ||
                    x.TipeKendaraan.ToString().ToLower().Contains(cleanKeyword) ||
                    x.NomorPlatKendaraan.ToLower().Contains(cleanKeyword));
            }
            return semuakendaraan;
        }

        public void AddKendaraan(Kendaraan kendaraan)
        {
            if (kendaraan.StatusKendaraan != OptionStatus.tersedia)
            {
                throw new Exception("Kendaraan baru harus memiliki status 'tersedia'.");
            }

            if (context.GetAllKendaraan() != null && context.GetAllKendaraan().Exists(k => k.NomorPlatKendaraan.Equals(kendaraan.NomorPlatKendaraan, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Nomor plat sudah terdaftar.");
            }
            context.AddKendaraan(kendaraan);
        }

        public void UpdateKendaraan(Kendaraan kendaraan)
        {
            Kendaraan dataLama = context.GetById(kendaraan.IdKendaraan);

            if (dataLama == null)
            {
                throw new Exception("Kendaraan tidak ditemukan.");
            }

            if (dataLama.StatusKendaraan == OptionStatus.disewa && kendaraan.StatusKendaraan != OptionStatus.disewa)
            {
                throw new Exception("Status tidak dapat diubah karena kendaraan masih dalam status disewa oleh pelanggan.");
            }

            if (kendaraan.NomorPlatKendaraan != dataLama.NomorPlatKendaraan)
            {
                throw new Exception("Nomor plat tidak dapat diubah.");
            }

            if (kendaraan.NamaKendaraan != dataLama.NamaKendaraan)
            {
                throw new Exception("Nama kendaraan tidak dapat diubah.");
            }

            if (kendaraan.TipeKendaraan != dataLama.TipeKendaraan)
            {
                throw new Exception("Tipe kendaraan tidak dapat diubah.");
            }

            context.UpdateKendaraan(kendaraan);
        }

        public void DeleteKendaraan(int id)
        {
            context.DeleteKendaraan(id);
        }
    }
}
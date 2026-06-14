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
                Kendaraan kendaraan = (item.TipeKendaraan == KendaraanTipe.mobil)
                    ? new ElectricCar()
                    : new ElectricMotor();

                kendaraan = item.TipeKendaraan == KendaraanTipe.mobil ? new ElectricCar {
                    IdKendaraan = item.IdKendaraan,
                    IdMerkKendaraan = item.IdMerkKendaraan,
                    NomorPlatKendaraan = item.NomorPlatKendaraan,
                    NamaKendaraan = item.NamaKendaraan,
                    StokKendaraan = item.StokKendaraan,
                    HargaSewa = item.HargaSewa,
                    TipeKendaraan = item.TipeKendaraan,
                    StatusKendaraan = item.StatusKendaraan,
                } : new ElectricMotor
                {
                    IdKendaraan = item.IdKendaraan,
                    IdMerkKendaraan = item.IdMerkKendaraan,
                    NomorPlatKendaraan = item.NomorPlatKendaraan,
                    NamaKendaraan = item.NamaKendaraan,
                    StokKendaraan = item.StokKendaraan,
                    HargaSewa = item.HargaSewa,
                    TipeKendaraan = item.TipeKendaraan,
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

            if (filterAktif == "Mobil")
            {
                semuakendaraan = semuakendaraan.FindAll(x => x.TipeKendaraan == KendaraanTipe.mobil);
            }
            else if (filterAktif == "Motor")
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
            context.AddKendaraan(kendaraan);
        }

        public void UpdateKendaraan(Kendaraan kendaraan)
        {
            context.UpdateKendaraan(kendaraan);
        }

        public void DeleteKendaraan(int id)
        {
            context.DeleteKendaraan(id);
        }
    }
}
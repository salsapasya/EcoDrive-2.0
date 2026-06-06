using EcoDrive_vol2.Context.Admin;
using EcoDrive_vol2.Models;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Vehicles;

namespace EcoDrive_vol2.Services
{
    public class KendaraanService
    {
        private KendaraanContext context =
            new KendaraanContext();

        public List<Kendaraan> GetAllKendaraan()
        {
            List<Kendaraan> data =
                context.GetAllKendaraan();

            List<Kendaraan> hasil =
                new List<Kendaraan>();

            foreach (var item in data)
            {
                Kendaraan kendaraan;

                // INHERITANCE
                if (item.TipeKendaraan ==
                    KendaraanTipe.mobil)
                {
                    kendaraan = new ElectricCar();
                }
                else
                {
                    kendaraan = new ElectricMotor();
                }

                kendaraan.IdKendaraan =
                    item.IdKendaraan;

                kendaraan.IdMerkKendaraan =
                    item.IdMerkKendaraan;

                kendaraan.NomorPlatKendaraan =
                    item.NomorPlatKendaraan;

                kendaraan.NamaKendaraan =
                    item.NamaKendaraan;

                kendaraan.StokKendaraan =
                    item.StokKendaraan;

                kendaraan.HargaSewa =
                    item.HargaSewa;

                kendaraan.TipeKendaraan =
                    item.TipeKendaraan;

                kendaraan.StatusKendaraan =
                    item.StatusKendaraan;

                hasil.Add(kendaraan);
            }

            return hasil;
        }

        public List<Kendaraan>
            GetAvailableKendaraan()
        {
            return GetAllKendaraan()

                .Where(k =>
                    k.StatusKendaraan ==
                    OptionStatus.tersedia
                )

                .ToList();
        }

        public void AddKendaraan(
            Kendaraan kendaraan)
        {
            context.AddKendaraan(kendaraan);
        }

        public void UpdateKendaraan(
            Kendaraan kendaraan)
        {
            context.UpdateKendaraan(kendaraan);
        }

        public void DeleteKendaraan(int id)
        {
            context.DeleteKendaraan(id);
        }
    }
}
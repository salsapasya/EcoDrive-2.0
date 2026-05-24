using EcoDrive_vol2.Context;
using EcoDrive_vol2.Controllers.Admin;
using EcoDrive_vol2.Models.Kendaraan;

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
                if (item.NamaKendaraan.Contains("Tesla") ||
                    item.NamaKendaraan.Contains("Ioniq"))
                {
                    kendaraan = new ElectricCar();
                }
                else
                {
                    kendaraan = new ElectricMotor();
                }

                kendaraan.IdKendaraan = item.IdKendaraan;
                kendaraan.NamaKendaraan = item.NamaKendaraan;
                kendaraan.HargaSewa = item.HargaSewa;
                kendaraan.StatusKendaraan = item.StatusKendaraan;
                kendaraan.BatteryPercentage = item.BatteryPercentage;

                hasil.Add(kendaraan);
            }

            return hasil;
        }

        public List<Kendaraan> GetAvailableKendaraan()
        {
            return GetAllKendaraan()
                .Where(k => k.StatusKendaraan == "Available")
                .ToList();
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
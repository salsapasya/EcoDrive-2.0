using EcoDrive_vol2.Models.Vehicles;
using EcoDrive_vol2.Services;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusKendaraanController
    {
        private KendaraanService service =
            new KendaraanService();

        public List<Kendaraan> GetAvailableKendaraan()
        {
            return service.GetAvailableKendaraan("Semua", string.Empty);
        }

        public List<Kendaraan> GetAvailableKendaraan(string filterAktif, string keyword)
        {
            return service.GetAvailableKendaraan(filterAktif, keyword);
        }
    }
}
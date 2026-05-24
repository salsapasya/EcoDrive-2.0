using EcoDrive_vol2.Models;
using EcoDrive_vol2.Services;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusKendaraanController
    {
        private KendaraanService service =
            new KendaraanService();

        public List<Kendaraan> GetAvailableKendaraan()
        {
            return service.GetAvailableKendaraan();
        }
    }
}
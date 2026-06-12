using EcoDrive_vol2.Models.Vehicles;
using EcoDrive_vol2.Services;

namespace EcoDrive_vol2.Controllers.Admin
{
    public class AdKendaraanController
    {
        private KendaraanService service = new KendaraanService();

        public List<Kendaraan> GetKendaraanTerfilter(string filterAktif, string keyword)
        {
            return service.GetAvailableKendaraan(filterAktif, keyword);
        }

        public void AddKendaraan(Kendaraan kendaraan)
        {
            service.AddKendaraan(kendaraan);
        }

        public void UpdateKendaraan(Kendaraan kendaraan)
        {
            service.UpdateKendaraan(kendaraan);
        }

        public void DeleteKendaraan(int id)
        {
            service.DeleteKendaraan(id);
        }
    }
}
using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models;

namespace EcoDrive_vol2.Controllers
{
    public class AdKendaraanController
    {
        KendaraanContext context =
            new KendaraanContext();

        // GET
        public List<Kendaraan> GetKendaraan()
        {
            return context.GetAllKendaraan();
        }

        // ADD
        public void AddKendaraan(
            Kendaraan kendaraan)
        {
            context.AddKendaraan(
                kendaraan);
        }

        // DELETE
        public void DeleteKendaraan(
            int id)
        {
            context.DeleteKendaraan(id);
        }
    }
}
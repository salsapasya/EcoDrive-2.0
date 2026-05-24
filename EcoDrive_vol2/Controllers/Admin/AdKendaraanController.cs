using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models;
using System.Collections.Generic;

namespace EcoDrive_vol2.Controllers.Admin
{
    public class AdKendaraanController
    {
        KendaraanContext context = new KendaraanContext();

        // GET
        public List<Kendaraan> GetKendaraan()
        {
            return context.GetAllKendaraan();
        }

        // ADD
        public void AddKendaraan(Kendaraan kendaraan)
        {
            context.AddKendaraan(kendaraan);
        }

        // UPDATE (TAMBAHKAN METHOD INI)
        public void UpdateKendaraan(Kendaraan kendaraan)
        {
            // Pastikan di dalam KendaraanContext Anda sudah ada method UpdateKendaraan
            context.UpdateKendaraan(kendaraan);
        }

        // DELETE
        public void DeleteKendaraan(int id)
        {
            context.DeleteKendaraan(id);
        }
    }
}
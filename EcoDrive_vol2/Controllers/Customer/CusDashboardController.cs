using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.Services.Customer;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusDashboardController
    {
        private readonly DashboardService _service;

        public CusDashboardController()
        {
            _service = new DashboardService();
        }

        public decimal GetSaldo()
        {
            return _service.AmbilSaldoTerbaru(UserSession.IdUserAktif);
        }

        public int GetTotalSewa()
        {
            return _service.HitungTotalSewa(UserSession.IdUserAktif);
        }

        public RentalAktifData GetRentalStatus()
        {
            return _service.GetInformasiRental(UserSession.IdUserAktif);
        }
    }
}
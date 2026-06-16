using System;
using EcoDrive_vol2.Context.Customer;
using EcoDrive_vol2.Context.Admin;

namespace EcoDrive_vol2.Controllers.Admin
{
    public class AdDashboardController
    {
        private readonly DashboardContext _dashboardContext;
        private readonly AdPendapatanContext _pendapatanDb;

        public AdDashboardController()
        {
            _dashboardContext = new DashboardContext();
            _pendapatanDb = new AdPendapatanContext();
        }

        public dynamic GetDashboardData()
        {
            try
            {
                var stats = _dashboardContext.GetAdminDashboardStats();

                if (stats == null)
                    return null;

                var pendapatan =
                    _pendapatanDb.GetCardPendapatanByTahun(
                        DateTime.Now.Year
                    );

                return new
                {
                    TotalCustomer = stats.TotalCustomer,
                    TotalKendaraan = stats.TotalKendaraan,
                    TotalDisewa = stats.TotalDisewa,
                    TotalPendapatan = pendapatan.TotalGabunganTahunan,
                    Tersedia = stats.Tersedia,
                    Disewa = stats.Disewa,
                    Charging = stats.Rusak,
                    Maintenance = stats.Maintenance
                };
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error saat mengambil data dashboard: "
                    + ex.Message
                );
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using EcoDrive_vol2.Services.Customer;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    public interface IDashboardService
    {
        decimal AmbilSaldoTerbaru(int idUser);

        int HitungTotalSewa(int idUser);

        RentalAktifData GetInformasiRental(int idUser);
    }
}
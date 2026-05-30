using System;
using System.Collections.Generic;
using System.Text;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Service;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusRiwayatController
    {
        private CustomerService service =
            new CustomerService();

        public List<TransaksiSewa>
            GetRiwayat(int idUser)
        {
            return service
                .GetRiwayat(idUser);
        }
    }
}

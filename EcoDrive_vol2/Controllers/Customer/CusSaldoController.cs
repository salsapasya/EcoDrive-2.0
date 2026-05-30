using EcoDrive_vol2.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusSaldoController
    {
        private CustomerService service =
            new CustomerService();

        public decimal GetSaldo(int idUser)
        {
            return service
                .GetSaldo(idUser);
        }

        public void TopupSaldo(int idUser,decimal jumlah)
        {
            service.TopupSaldo(idUser,jumlah);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models.Transaksi
{
    public class TopUpSaldo
    {
        public int idSaldo { get; set; }
        public int idCustomer { get; set; }
        public decimal JumlahSaldo { get; set; }
    }
}

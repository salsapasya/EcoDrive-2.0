using System;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Transaksi 
{
    public class TopupSaldo
    {
        public int IdTopupSaldo { get; set; }

        public int IdCustomer { get; set; }

        public int JumlahTopup { get; set; }

        public TopupStatus StatusTopup { get; set; }
    }
}
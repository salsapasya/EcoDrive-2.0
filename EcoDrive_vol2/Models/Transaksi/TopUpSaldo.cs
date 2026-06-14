using System;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Transaksi
{
    public class TopupSaldo
    {
        public TopupSaldo(int idCustomer, int jumlahTopup)
        {
            IdCustomer = idCustomer;
            JumlahTopup = jumlahTopup;
            IdTopupsaldo = 0; 
            StatusTopup = TopupStatus.pending;
        }
        public int IdTopupsaldo { get; set; }
        public int IdCustomer { get; set; }
        public int JumlahTopup { get; set; }
        public TopupStatus StatusTopup { get; set; }
    }
}
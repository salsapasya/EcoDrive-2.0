using System;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Transaksi
{
    //INHERITANCE: blueprint, kl nnti ada model transaksi lain
    public class TopupSaldo
    {
        public TopupSaldo(int idCustomer, int jumlahTopup)
        {
            IdCustomer = idCustomer;
            JumlahTopup = jumlahTopup;
            IdTopupsaldo = 0; 
            StatusTopup = TopupStatus.pending;
        }
        //ENCAP: data diproteksi lewat get, set
        public int IdTopupsaldo { get; set; }
        public int IdCustomer { get; set; }
        public int JumlahTopup { get; set; }
        public TopupStatus StatusTopup { get; set; }
    }
}
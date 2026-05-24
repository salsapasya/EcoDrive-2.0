using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models.Transaksi
{
    public class TransaksiCharging
    {
        public int idTransaksiCharging { get; set; }
        public int idChargingStation { get; set; }
        public int idCustomer { get; set; }
        public int idKendaraan { get; set; }
        public DateTime TanggalCharging { get; set; }
        public decimal JumlahPembayaran { get; set; }
    }
}

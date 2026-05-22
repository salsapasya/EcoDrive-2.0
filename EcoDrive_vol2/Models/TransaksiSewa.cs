using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models
{
    public class TransaksiSewa
    {
        public int idPembayaran { get; set; }
        public int idCustomer { get; set; }
        public int idKendaraan { get; set; }
        public DateTime TanggalSewa { get; set; }
        public DateTime TanggalKembali { get; set; }
        public TimeOnly DurasiSewa { get; set; }
        public decimal JumlahPembayaran { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models.Admin
{
    public class TopUp
    {
        public string IdTopup { get; set; }
        public string KodeTopup { get;set;  }
        public string Username { get; set; }
        public string Nama { get; set; }
        public string Kontak { get; set; }
        public decimal JumlahTopup { get; set; }
        public string Status { get; set; }
        public decimal Saldo { get; set; }
    }
}

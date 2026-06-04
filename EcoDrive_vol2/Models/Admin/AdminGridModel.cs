using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models.Admin
{
    public class AdminGridModel
    {
        public int RawId { get; set; }
        public string Kategori { get; set; }
        public string ID_Transaksi { get; set; }
        public string Username { get; set; }
        public string Nama { get; set; }
        public string Kontak { get; set; }
        public string Waktu { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
    }
}

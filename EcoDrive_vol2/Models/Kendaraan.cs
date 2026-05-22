using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models
{
    public class Kendaraan
    {
        public int idKendaraan { get; set; }
        public int idTipeKendaraan { get; set; }
        public string NamaKendaraan { get; set; }
        public decimal HargaSewa { get; set; }
    }
}

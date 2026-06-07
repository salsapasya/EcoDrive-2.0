using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models.Admin
{
    public class CardPendapatanModel 
    {
        public decimal TotalSewaTahunan { get; set; }
        public decimal TotalChargingTahunan { get; set; }
        public decimal TotalGabunganTahunan { get; set; }
        public long TotalUnitTahunan { get; set; }
        public long TotalBanyakChargingTahunan { get; set; }
    }

    public class RincianPendapatanModel 
    {
        public DateTime TanggalHari { get; set; }
        public decimal PendapatanSewa { get; set; }
        public decimal PendapatanCharging { get; set; }
        public decimal TotalHarian { get; set; }
    }
}

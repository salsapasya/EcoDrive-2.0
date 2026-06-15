using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Context.Admin;
using EcoDrive_vol2.Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Service
{
    public class AdPendapatanService : IPendapatanService
    {
        private readonly AdPendapatanContext _context;

        public AdPendapatanService()
        {
            _context = new AdPendapatanContext();
        }
        public CardPendapatanModel GetCardTotalByTahun(int tahun)
        {
            return _context.GetCardPendapatanByTahun(tahun);
        }
        public List<RincianPendapatanModel> GetRincianPendapatanByBulanTahun(int bulan, int tahun)
        {
            return _context.GetRincianPendapatanByBulanTahun(bulan, tahun);
        }
        public int HitungIndexBulanSistem()
        {
            string[] namaBulan = { "Januari", "Februari", "Maret", "April", "Mei", "Juni",
                           "Juli", "Agustus", "September", "Oktober", "November", "Desember" };
            string bulanSekarang = namaBulan[DateTime.Now.Month - 1];

            // Mengembalikan nilai indeks berbasis array bulan untuk dicocokkan ComboBox
            return Array.IndexOf(namaBulan, bulanSekarang);
        }
    }
}

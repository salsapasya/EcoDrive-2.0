using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Context.Admin;
using EcoDrive_vol2.Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Service
{
    public class PendapatanService : IPendapatanService
    {
        private readonly PendapatanContext _context;

        public PendapatanService()
        {
            _context = new PendapatanContext();
        }
        public CardPendapatanModel GetCardTotalByTahun(int tahun)
        {
            return _context.GetCardPendapatanByTahun(tahun);
        }
        public List<RincianPendapatanModel> GetRincianPendapatanByBulanTahun(int bulan, int tahun)
        {
            return _context.GetRincianPendapatanByBulanTahun(bulan, tahun);
        }
    }
}

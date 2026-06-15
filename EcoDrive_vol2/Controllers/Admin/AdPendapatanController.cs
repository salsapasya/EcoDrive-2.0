using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Controllers.Admin
{
    public class AdPendapatanController
    {
        private readonly IPendapatanService _service;

        public AdPendapatanController(IPendapatanService service)
        {
            _service = service;
        }
        public CardPendapatanModel LoadCardTahun(int tahun)
        {
            return _service.GetCardTotalByTahun(tahun);
        }
        public List<RincianPendapatanModel> LoadRincianBulanTahun(int bulan, int tahun)
        {
            return _service.GetRincianPendapatanByBulanTahun(bulan, tahun);
        }
        public int AmbilIndexBulanSekarang()
        {
            return _service.HitungIndexBulanSistem();
        }
    }
}

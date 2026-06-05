using EcoDrive.Models.Vehicles;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Models.Vehicles;
using EcoDrive_vol2.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusChargingController
    {
        private readonly ChargingService _service = new ChargingService();
        public List<ChargingStation> AmbilSemuaStation()
        {
            return _service.AmbilSemuaStation();
        }
        public List<Kendaraan> AmbilKendaraanSewaUser(int idUser)
        {
            return _service.AmbilKendaraanSewaUser(idUser);
        }
        public List<TransaksiCharging> AmbilTransaksiAktif (int idUser)
        {
            return _service.AmbilTransaksiAktif(idUser);
        }
        public void ProsesBuatCharging (int idUser, int idKendaraan, int idStation, decimal totalBiaya, int durasi)
        {
            _service.ProsesBuatCharging(idUser, idKendaraan, idStation, totalBiaya, durasi);
        }
        public void SelesaikanCharging(int idTransaksi)
        {
            _service.SelesaikanCharging(idTransaksi);
        }
    }
}

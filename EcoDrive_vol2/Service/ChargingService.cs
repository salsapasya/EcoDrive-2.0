using EcoDrive.Models.Vehicles;
using EcoDrive_vol2.Context.Customer;
using EcoDrive_vol2.Models.Transaksi;
using EcoDrive_vol2.Models.Vehicles;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Service
{
    public class ChargingService
    {
        private readonly ChargingContext _context = new ChargingContext();
        public List<ChargingStation> AmbilSemuaStation()
        {
            return _context.GetSemuaStation();
        }
        public List<Kendaraan> AmbilKendaraanSewaUser (int idUser)
        {
            return _context.GetKendaraanSewaUser(idUser);
        }
        public List<TransaksiCharging> AmbilTransaksiAktif(int idUser)
        {
            return _context.GetTransaksiAktif(idUser);
        }
        public void ProsesBuatCharging(int idUser, int idKendaraan,int idStation, decimal totalBiaya, int durasi)
        {
            _context.BuatTransaksiCharging(idUser, idKendaraan, idStation, totalBiaya, durasi);
        }
        public void SelesaikanCharging(int idTransaksi)
        {
            _context.SelesaikanCharging(idTransaksi);
        }
    }
}
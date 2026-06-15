using EcoDrive.Models.Vehicles;
using EcoDrive_vol2.AbstractandInterface.Interface;
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
        public decimal HitungEstimasiBiayaModel(int durasiMenit)
        {
            var modelSementara = new TransaksiCharging(0, 0, 0, 0, durasiMenit, Models.Enums.ChargingStatus.pending, "", "", "");
            return modelSementara.BiayaCharging;
        }
        // Logic Skema Warna Visual dipusatkan di Controller 
        public (Color WarnaTeks, string TeksStatus, bool TombolAktif) DapatkanSkemaVisualStatus(TransaksiCharging trx)
        {
            string statusString = trx.StatusCharging.ToString().Trim().ToLower();
            Color warnaUI = Color.Orange;
            string teksUI = trx.StatusCharging.ToString().ToUpper().Replace("_", " ");
            bool bisaDiKlik = true;

            if (statusString.Contains("mengisi") || statusString.Contains("daya"))
            {
                warnaUI = Color.FromArgb(46, 139, 87); // SeaGreen
                teksUI = "⚡ MENGISI DAYA";
                bisaDiKlik = true;
            }
            else if (statusString.Contains("pending"))
            {
                warnaUI = Color.Orange;
                teksUI = "⏳ MENUNGGU KONFIRMASI ADMIN";
                bisaDiKlik = false;
            }
            else if (statusString.Contains("selesai"))
            {
                warnaUI = Color.Gray;
                teksUI = "✅ SELESAI";
                bisaDiKlik = false;
            }

            return (warnaUI, teksUI, bisaDiKlik);
        }
        public void ProsesBuatCharging (int idUser, int idKendaraan, int idStation, int durasi, List<Kendaraan> listKendaraan)
        {
            _service.ProsesBuatCharging(idUser, idKendaraan, idStation, durasi);

            Kendaraan kendaraanDipilih = listKendaraan.Find(k => k.IdKendaraan == idKendaraan);
            if (kendaraanDipilih is IChargeable chargeableVehicle)
            {
                chargeableVehicle.Plugin(); // Mengubah status objek kendaraan menjadi "mengisi_daya"
            }
        }
        public void SelesaikanCharging(TransaksiCharging trx, List<Kendaraan> listKendaraan)
        {
            _service.SelesaikanCharging(trx.IdTransaksiCharging);

            Kendaraan kendaraanDipilih = listKendaraan.Find(k => k.Status != null && k.Status.ToLower() == "charging");

            if (kendaraanDipilih is IChargeable chargeableVehicle)
            {
                chargeableVehicle.Unplug(); // Mengubah status objek "selesai"
            }
        }
    }
}

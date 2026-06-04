using EcoDrive_vol2.Service;
using EcoDrive_vol2.AbstractandInterface.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusRentalController
    {
        private readonly IRental _rentalService;

        public CusRentalController()
        {
            _rentalService = new RentalService();
        }

        public decimal DapatkanEstimasiBiaya(int idKendaraan, int durasi)
        {
            return _rentalService.DapatkanEstimasiBiaya(idKendaraan, durasi);
        }

        public void KonfirmasiSewa(int idUser, int idKendaraan, int durasi, decimal totalBiaya)
        {
            _rentalService.ProsesSewaKendaraan(idUser, idKendaraan, durasi, totalBiaya);
        }
    }
}

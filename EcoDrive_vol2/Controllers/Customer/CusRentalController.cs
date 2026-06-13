using EcoDrive_vol2.Service;
using EcoDrive_vol2.AbstractandInterface.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusRentalController
    {
        // ENCAPSULATION: Membatasi akses data dari RentalService
        private readonly IRental _rentalService;

        public CusRentalController()
        {
            _rentalService = new RentalService();
        }

        public decimal DapatkanEstimasiBiaya(int idKendaraan, int durasi)
        {
            return _rentalService.DapatkanEstimasiBiaya(idKendaraan, durasi);
        }

        // OOP: Menerima objek utuh dari View dan meneruskannya ke Service
        public void KonfirmasiSewa(EcoDrive_vol2.Models.Transaksi.TransaksiSewa transaksi)
        {
            _rentalService.ProsesSewaKendaraan(transaksi);
        }
    }
}

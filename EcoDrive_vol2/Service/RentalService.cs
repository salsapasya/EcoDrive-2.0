using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Service
{
    public class RentalService : IRental
    {
        private readonly RentalContext _rentalContext = new RentalContext();
        private readonly UserContext _userContext = new UserContext();
        
        public decimal DapatkanEstimasiBiaya(int idKendaraan, int durasi)
        {
            if (durasi <= 0) throw new ArgumentException("Durasi tidak valid!");
            return _rentalContext.GetEstimasiBiaya(idKendaraan, durasi);
        }

        public void ProsesSewaKendaraan(int idUser, int idKendaraan, int durasi, decimal totalBiaya)
        {
            //Validasi Saldo Cukup atau Tidak
            decimal saldoSaatIni = _userContext.GetSaldo(idUser);
            if (saldoSaatIni < totalBiaya)
            {
                throw new Exception("SALDO_KURANG");
            }

            _rentalContext.EksekusiPembayaranSewa(idUser, idKendaraan, durasi, totalBiaya);
        }
    }
}

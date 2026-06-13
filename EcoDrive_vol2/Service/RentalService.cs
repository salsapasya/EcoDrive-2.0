using EcoDrive_vol2.AbstractandInterface.Interface;
using EcoDrive_vol2.Context;
using EcoDrive_vol2.Context.Customer;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Transaksi;
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

        // OOP (Polimorfisme & Class Object): Menerima satu objek utuh 
        public void ProsesSewaKendaraan(TransaksiSewa transaksi)
        {
            decimal saldoSaatIni = _userContext.GetSaldo(transaksi.IdUser);

            // OOP (Polimorfisme): Memanggil fungsi override HitungBiaya() bawaan dari model TransaksiSewa
            transaksi.HitungBiaya();

            if (saldoSaatIni < transaksi.TotalBiaya)
            {
                throw new Exception("Saldo Anda tidak mencukupi untuk melakukan transaksi sewa.");
            }

            _rentalContext.EksekusiPembayaranSewa(transaksi);
        }
    }
}

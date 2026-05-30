using System;
using System.Collections.Generic;
using System.Text;
using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models.Transaksi;

namespace EcoDrive_vol2.Service
{
    public class CustomerService
    {
        private UserContext userContext =
            new UserContext();

        private TransaksiSewaContext transaksiContext =
            new TransaksiSewaContext();

        public decimal GetSaldo(
            int idUser)
        {
            return userContext
                .GetSaldo(idUser);
        }

        public void TopupSaldo(int idUser, decimal jumlah)
        {
            userContext.TopupSaldo(idUser, jumlah);
        }

        public List<TransaksiSewa>
            GetRiwayat(int idUser)
        {
            return transaksiContext
                .GetAllTransaksiSewa();
        }

        public int GetIdUser(string username)
        {
            return userContext
                .GetIdUser(username);
        }

    }
}

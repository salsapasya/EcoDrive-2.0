using EcoDrive_vol2.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EcoDrive_vol2.Service
{
    public class TopUpCustomerService
    {
        private readonly TopUpContext _topUpContext = new TopUpContext(); //ENCAP

        public decimal AmbilSaldoUser(int idUser)
        {
            if (idUser <= 0) throw new ArgumentException("ID User tidak valid.");
            return _topUpContext.GetSaldo(idUser);
        }

        public DataTable AmbilRiwayatTopUp(int idUser)
        {
            if (idUser <= 0) throw new ArgumentException("ID User tidak valid.");
            return _topUpContext.GetRiwayatTopUpByCustomer(idUser);
        }

        public void ProsesTopUpLangsung(int idUser, decimal nominal)
        {
            if (nominal <= 0) throw new ArgumentException("Nominal harus lebih dari 0.");
            _topUpContext.InsertTopUpLangsung(idUser, nominal);
        }

        public void ProsesTopUpPending(int idUser, decimal nominal)
        {
            if (nominal <= 0) throw new ArgumentException("Nominal harus lebih dari 0.");
            _topUpContext.InsertTopUpPending(idUser, nominal);
        }

        public void ProsesBayarDariRiwayat(int idTopup, int idUser, decimal nominal)
        {
            if (idTopup <= 0 || idUser <= 0) throw new ArgumentException("Data transaksi cacat.");
            _topUpContext.BayarPendingLangsung(idTopup, idUser, nominal);
        }

        public void ProsesMintaBatalDariRiwayat(int idTopup) //ABSTRAC
        {
            if (idTopup <= 0) throw new ArgumentException("ID Transaksi tidak valid.");
            _topUpContext.UpdateMintaBatalCustomer(idTopup);
        }
    }
}

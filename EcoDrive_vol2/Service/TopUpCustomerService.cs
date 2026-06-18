using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models.Transaksi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EcoDrive_vol2.Service
{
    public class TopUpCustomerService
    {
        //ENCAP: data context bersifat private
        private readonly TopUpContext _topUpContext = new TopUpContext(); //ENCAP

        public void ProsesTopupSaldo(int idUser, decimal jumlah)
        {
            if (jumlah <= 0) throw new ArgumentException("Jumlah top up harus lebih besar dari 0!");
            _topUpContext.InsertTopUpLangsung(idUser, jumlah);
        }

        public void BuatTopUp(int idCustomer, int jumlah)
        {
            TopupSaldo baru = new TopupSaldo(idCustomer, jumlah);
            _topUpContext.SimpanTransaksiTopUp(baru);
        }

        //ABSTRAK: buat jembatan 
        public void SimpanTopUp(TopupSaldo dataTopup)
        {
            if (dataTopup.JumlahTopup <= 0) throw new ArgumentException("Jumlah tidak valid.");
            _topUpContext.InsertTopUpLangsung(dataTopup.IdCustomer, (decimal)dataTopup.JumlahTopup);
        }

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

        //ABSTRAK: ngubah proses yg rumit
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

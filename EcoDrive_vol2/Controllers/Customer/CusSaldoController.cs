using EcoDrive_vol2.Context;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Service;
using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Data;

namespace EcoDrive_vol2.Controllers.Customer
{
    public class CusSaldoController
    {
        private readonly LoginService _loginService = new LoginService();
        private TopUpContext _topUpContext = new TopUpContext();
        private readonly TopUpCustomerService _topUpCustomerService = new TopUpCustomerService();

        public decimal GetSaldo(int idUser)
        {
            return _topUpCustomerService.AmbilSaldoUser(idUser);
        }

        public DataTable AmbilRiwayatTopUp(int idUser)
        {
            return _topUpCustomerService.AmbilRiwayatTopUp(idUser);
        }
        public void TopupSaldoLangsung(int idUser, decimal nominal)
        {
            _topUpCustomerService.ProsesTopUpLangsung(idUser, nominal);
        }
        public void TopupSaldoPending(int idUser, decimal nominal)
        {
            _topUpCustomerService.ProsesTopUpPending(idUser, nominal);
        }
        public void BayarPendingLangsung(int idTopup, int idUser, decimal nominal)
        {
            _topUpCustomerService.ProsesBayarDariRiwayat(idTopup, idUser, nominal);
        }
        public void UbahMintaBatalCustomer(int idTopup)
        {
            _topUpCustomerService.ProsesMintaBatalDariRiwayat(idTopup);
        }
    }
}
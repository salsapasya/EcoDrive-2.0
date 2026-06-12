using EcoDrive_vol2.Context;
using System;
using System.Data; 
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.AbstractandInterface.Interface;

namespace EcoDrive_vol2.Service
{
    // Penerapan Polymorphism: Implementasi interface ILoginService untuk menyediakan layanan login dan manajemen saldo
    public class LoginService : ILoginService
    {
        // Abstraction
        private readonly UserContext _userContext = new UserContext();
        private readonly LoginContext _loginContext = new LoginContext();

        public decimal AmbilSaldoUser(int idUser)
        {
            return _userContext.GetSaldo(idUser);
        }

        public void ProsesTopupSaldo(int idUser, decimal jumlah)
        {
            if (jumlah <= 0) throw new ArgumentException("Jumlah top up harus lebih besar dari 0!");
            _userContext.TopupSaldo(idUser, jumlah);
        }

        public int AmbilIdUser(string username)
        {
            return _userContext.GetIdUser(username);
        }

        public DataTable AmbilDaftarTopUpAdmin(string statusFilter = "")
        {
            return _userContext.GetDaftarTopUpFromView(statusFilter);
        }
        public void KonfirmasiTopUp(int idTopup, int idUser)
        {
            if (idTopup <= 0) throw new ArgumentException("ID Top Up tidak valid!");
            if (idUser <= 0) throw new ArgumentException("ID User tidak valid!");

            _userContext.KonfirmasiTopUp(idTopup, idUser);
        }

        public void TolakTopUp(int idTopup)
        {
            if (idTopup <= 0) throw new ArgumentException("ID Top Up tidak valid!");

            _userContext.TolakTopUp(idTopup);
        }

        public Users Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            return _loginContext.Login(username, password);
        }
    }
}
using EcoDrive_vol2.Context;
using System;
using System.Data; // WAJIB untuk menggunakan DataTable
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.Context.Admin;

namespace EcoDrive_vol2.Service
{
    public class LoginService
    {
        // Satukan instansiasi context agar rapi dan tidak duplikat
        private readonly UserContext _userContext = new UserContext();
        private readonly LoginContext _loginContext = new LoginContext();
        private readonly TopUpCustomerContext _topUpCustomerContext = new TopUpCustomerContext();

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
            // Diarahkan ke UserContext yang bertugas mengambil data dari SQL View
            return _topUpCustomerContext.GetDaftarTopUpFromView(statusFilter);
        }
        public void KonfirmasiTopUp(int idTopup, int idUser)
        {
            if (idTopup <= 0) throw new ArgumentException("ID Top Up tidak valid!");
            if (idUser <= 0) throw new ArgumentException("ID User tidak valid!");

            // Meneruskan perintah eksekusi ke UserContext
            _topUpCustomerContext.KonfirmasiTopUp(idTopup, idUser);
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
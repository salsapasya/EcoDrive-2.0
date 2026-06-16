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

        public int AmbilIdUser(string username)
        {
            return _userContext.GetIdUser(username);
        }

        public Users Login(string username, string password)
        {
            var loggedInUser = _loginContext.Login(username, password);

            if (loggedInUser == null)
            {
                throw new Exception("Username atau password salah!");
            }

            // Pengecekan Status Blokir (Sesuaikan properti status di model Users kamu, misal: StatusUser atau Status)
            if (loggedInUser.StatusAkun != null && Convert.ToString(loggedInUser.StatusAkun).Equals("diblokir", StringComparison.OrdinalIgnoreCase))
            {
                // Kita lempar exception spesifik teksnya agar nanti ditangkap UI untuk redirect
                throw new Exception("AKUN_DIBLOKIR: Akun Anda ditangguhkan. Silakan buat akun baru!");
            }

            return loggedInUser;
        }
    }
}
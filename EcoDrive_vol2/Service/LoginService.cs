using EcoDrive_vol2.Context;
using System;
using System.Data; 
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.AbstractandInterface.Interface;

namespace EcoDrive_vol2.Service
{
    //Polymorphism: mengimplementasikan ILoginService untuk kontrak agar fitur login bisa dikembangkan tanpa merusak komponen lain
    public class LoginService : ILoginService
    {
        // Abstraction: buat nyembunyiin detail operasional dari UI
        //ENCAP: objek usercontext sama logincontext dibuat private readonly biar gabisa diakses dari kelas luar
        private readonly UserContext _userContext = new UserContext();
        private readonly LoginContext _loginContext = new LoginContext();

        public decimal AmbilSaldoUser(int idUser)
        {
            return _userContext.GetSaldo(idUser);
        }

        //ENCAP: validasi bisnis 'if (jumlah <= 0')
        public void ProsesTopupSaldo(int idUser, decimal jumlah)
        {
            if (jumlah <= 0) throw new ArgumentException("Jumlah top up harus lebih besar dari 0!");
            _userContext.TopupSaldo(idUser, jumlah);
        }

        public int AmbilIdUser(string username)
        {
            return _userContext.GetIdUser(username);
        }

        public Users Login(string username, string password)
        {
            //ABSTRAK: cukup panggil method, dapet objek user atau exception
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
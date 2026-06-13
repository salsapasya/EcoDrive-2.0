using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models.Users;

namespace EcoDrive_vol2.Service
{
    public class RegisterService
    {
        private readonly UserContext _context = new UserContext();

        //SEMUA LOGIC DI VIEW PINDAH KESINI
        public void ValidasiDanRegistrasiCustomer(string nama, string noTelp, string username, string password)
        {
            // 1. Validasi Kekosongan Data
            if (string.IsNullOrWhiteSpace(nama))
                throw new Exception("Nama tidak boleh kosong!");

            if (string.IsNullOrWhiteSpace(noTelp))
                throw new Exception("Nomor telepon tidak boleh kosong!");

            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Username tidak boleh kosong!");

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password tidak boleh kosong!");

            // 2. Validasi Format Nomor Telepon
            if (!long.TryParse(noTelp, out _))
                throw new Exception("Nomor telepon harus berupa angka!");

            if (noTelp.Length > 20)
                throw new Exception("Nomor telepon maksimal 20 digit!");

            // 3. Validasi Ketersediaan Username
            if (_context.UsernameExists(username))
                throw new Exception("Username sudah digunakan, gunakan username lain!");

            // 4. OOP Penerapan: Instansiasi langsung lewat Class Subclass Customer (Bukan kosongan pajangan)
            Customer newCustomer = new Customer
            {
                NamaUser = nama,
                NoTelpUser = noTelp,
                Username = username,
                PasswordUser = password
            };

            // Simpan ke database via context
            _context.AddUser(newCustomer);
        }
    }
}
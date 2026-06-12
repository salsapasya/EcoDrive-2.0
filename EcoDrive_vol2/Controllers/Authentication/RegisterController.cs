using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.Service;

namespace EcoDrive_vol2.Controllers.Authentication
{
    public class RegisterController
    {
        private readonly RegisterService service = new RegisterService();
        private readonly UserContext _context = new UserContext(); // Ditambahkan untuk fungsi UsernameExists

        // 1. Menyesuaikan fungsi Register agar memanggil ValidasiDanRegistrasiCustomer
        public void Register(Users user)
        {
            // Karena fungsi aslimu butuh string terpisah (nama, noTelp, username, password), 
            // kita pecah objek 'user' menjadi parameter yang dibutuhkan.
            service.ValidasiDanRegistrasiCustomer(
                user.NamaUser,
                user.NoTelpUser,
                user.Username,
                user.PasswordUser
            );
        }

        // 2. Menyesuaikan fungsi UsernameExists agar mengambil langsung dari database context
        public bool UsernameExists(string username)
        {
            return _context.UsernameExists(username);
        }
    }
}
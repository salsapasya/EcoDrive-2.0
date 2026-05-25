using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Service;
using Npgsql;

namespace EcoDrive_vol2.Controllers.Authentication
{
    public class LoginController
    {
        private LoginService service =
            new LoginService();

        public string Login(
            string username,
            string password)
        {
            return service.Login(
                username,
                password);
        }
    }
}
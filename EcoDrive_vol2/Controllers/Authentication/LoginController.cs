using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.Service;
using Npgsql;

namespace EcoDrive_vol2.Controllers.Authentication
{
    public class LoginController
    {
        private readonly LoginService _loginService = new LoginService();

        public Users Login(string username, string password)
        {
            return _loginService.Login(username, password);
        }

    }
}
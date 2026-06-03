using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.Service;

namespace EcoDrive_vol2.Controllers.Authentication
{
    public class RegisterController
    {
        private RegisterService service =
            new RegisterService();

        public void Register(
            Users user)
        {
            service.Register(user);
        }
    }
}
using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models.Users;

namespace EcoDrive_vol2.Service
{
    public class RegisterService
    {
        private UserContext context =
            new UserContext();

        public void Register(
            Users user)
        {
            context.AddUser(user);
        }

        public bool UsernameExists(
            string username)
        {
            return context
                .UsernameExists(username);
        }
    }
}
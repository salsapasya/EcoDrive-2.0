using System;
using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models.Users;

namespace EcoDrive_vol2.Controllers.Admin
{
    class AdCustomerController
    {
        private UserContext userContext = new UserContext();
        public List<Users> GetAllUsers()
        {
            return userContext.GetAllUsers();
        }
        public void DeleteUser(Users user)
        {
            if (user.IdUser <= 0)
            {
                throw new Exception("Id tidak valid");
            }
            userContext.DeleteUser(user.IdUser);
        }
        public void AddUser(Users user)
        {
            if (string.IsNullOrEmpty(user.NamaUser) || string.IsNullOrEmpty(user.NoTelpUser) || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.PasswordUser))
            {
                throw new Exception("Data tidak lengkap");
            }
            userContext.AddUser(user);
        }
        public void UpdateUser(Users user)
        {
            if (user.IdUser <= 0)
            {
                throw new Exception("Id tidak valid");
            }
            if (string.IsNullOrEmpty(user.NamaUser) || string.IsNullOrEmpty(user.NoTelpUser) || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.PasswordUser   ))
            {
                throw new Exception("Data tidak lengkap");
            }
            userContext.UpdateUser(user);
        }
    }
}

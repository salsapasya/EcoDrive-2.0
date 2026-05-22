using System;
using System.Collections.Generic;
using System.Text;
using EcoDrive_vol2.Models;

namespace EcoDrive_vol2.Controllers
{
    class UserController
    {
        private UserContext userContext = new UserContext();
        public List<Users> GetAllUsers()
        {
            return userContext.GetAllUsers();
        }
        public void DeleteUser(Users user)
        {
            if (user.idUser <= 0)
            {
                throw new Exception("Id tidak valid");
            }
            userContext.DeleteUser(user.idUser);
        }
        public void AddUser(Users user)
        {
            if (string.IsNullOrEmpty(user.NamaUser) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                throw new Exception("Data tidak lengkap");
            }
            userContext.AddUser(user);
        }
        public void UpdateUser(Users user)
        {
            if (user.idUser <= 0)
            {
                throw new Exception("Id tidak valid");
            }
            if (string.IsNullOrEmpty(user.NamaUser) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                throw new Exception("Data tidak lengkap");
            }
            userContext.UpdateUser(user);
        }
    }
}

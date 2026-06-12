using System;
using System.Collections.Generic;
using System.Text;
using EcoDrive_vol2.Models.Users;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    public interface IUserService
    {
        List<Users> GetAllUsers();
        void AddUser(Users user);
    }
}

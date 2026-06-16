using System;
using System.Collections.Generic;
using System.Text;
using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Service
{
    internal class CustomerManagementService
    {
        private readonly UserContext _context = new UserContext();

        public void AktifkanCustomer(int idUser)
        {
            if (idUser <= 0) throw new ArgumentException("ID Customer tidak valid!");

            Users user = _context.GetAllUsers().Find(u => u.IdUser == idUser);
            if (user == null) throw new Exception("Customer tidak ditemukan!");

            user.StatusAkun = StatusAkun.aktif;
            _context.UpdateUser(user);
        }

        public void BlokirCustomer(int idUser)
        {
            if (idUser <= 0) throw new ArgumentException("ID Customer tidak valid!");

            Users user = _context.GetAllUsers().Find(u => u.IdUser == idUser);
            if (user == null) throw new Exception("Customer tidak ditemukan!");

            user.StatusAkun = StatusAkun.diblokir; 
            _context.UpdateUser(user);
        }

        public void HapusCustomerDariDatabase(int idUser)
        {
            if (idUser <= 0) throw new ArgumentException("ID Customer tidak valid!");

            Users user = _context.GetAllUsers().Find(u => u.IdUser == idUser);
            if (user == null) throw new Exception("Data customer sudah tidak ada di database!");

            _context.DeleteUser(idUser);
        }
    }
}

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

        // Pindahkan logika mengubah status menjadi AKTIF dari View ke Service
        public void AktifkanCustomer(int idUser)
        {
            if (idUser <= 0) throw new ArgumentException("ID Customer tidak valid!");

            Users user = _context.GetAllUsers().Find(u => u.IdUser == idUser);
            if (user == null) throw new Exception("Customer tidak ditemukan!");

            // Mengubah status memanfaatkan tipe data Enum secara aman
            user.StatusAkun = StatusAkun.aktif;
            _context.UpdateUser(user);
        }

        // Pindahkan logika mengubah status menjadi INACTIVE dari View ke Service
        public void NonAktifkanCustomer(int idUser)
        {
            if (idUser <= 0) throw new ArgumentException("ID Customer tidak valid!");

            Users user = _context.GetAllUsers().Find(u => u.IdUser == idUser);
            if (user == null) throw new Exception("Customer tidak ditemukan!");

            user.StatusAkun = StatusAkun.non_aktif;
            _context.UpdateUser(user);
        }

        // Pindahkan logika HAPUS customer dari View ke Service
        public void HapusCustomerDariDatabase(int idUser)
        {
            if (idUser <= 0) throw new ArgumentException("ID Customer tidak valid!");

            // Cek dulu apakah user memang eksis sebelum dihapus
            Users user = _context.GetAllUsers().Find(u => u.IdUser == idUser);
            if (user == null) throw new Exception("Data customer sudah tidak ada di database!");

            _context.DeleteUser(idUser);
        }
    }
}

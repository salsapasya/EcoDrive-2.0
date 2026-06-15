using System;
using System.Collections.Generic;
using System.Text;
using EcoDrive_vol2.Models.Admin;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    // OOP (ABSTRACTION) = memisahkan definisi fungsi dengan detail implementasi databasenya
    public interface IAdTopUpRepository
    {
        List<TopUp> GetDaftarTopUpFromView(string statusFilter);
        void KonfirmasiTopUp(int idTopupSaldo, int idUser);
        int GetIdUserByUsername(string username);
    }
}

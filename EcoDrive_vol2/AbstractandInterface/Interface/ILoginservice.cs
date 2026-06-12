using System.Data;
using EcoDrive_vol2.Models.Users;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    public interface ILoginService
    {
        decimal AmbilSaldoUser(int idUser);

        void ProsesTopupSaldo(int idUser, decimal jumlah);

        int AmbilIdUser(string username);

        DataTable AmbilDaftarTopUpAdmin(string statusFilter = "");

        void KonfirmasiTopUp(int idTopup, int idUser);

        void TolakTopUp(int idTopup);

        Users Login(string username, string password);
    }
}
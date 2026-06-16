using System.Data;
using EcoDrive_vol2.Models.Users;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    public interface ILoginService
    {
        decimal AmbilSaldoUser(int idUser);

        int AmbilIdUser(string username);

        Users Login(string username, string password);
    }
}
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Users
{
    public class Users
    {
        public int IdUser { get; set; }

        public Roles RoleUser { get; set; }

        public string NamaUser { get; set; }

        public string NoTelpUser { get; set; }

        public string Username { get; set; }

        public string PasswordUser { get; set; }

        public decimal Saldo { get; set; }

        public StatusAkun StatusAkun { get; set; }

        // CONSTRUCTOR KOSONG
        public Users()
        {

        }

        // CONSTRUCTOR BERPARAMETER
        public Users(
            int idUser,
            Roles roleUser,
            string namaUser,
            string noTelpUser,
            string username,
            string passwordUser,
            decimal saldo,
            StatusAkun statusAkun
        )
        {
            IdUser = idUser;
            RoleUser = roleUser;
            NamaUser = namaUser;
            NoTelpUser = noTelpUser;
            Username = username;
            PasswordUser = passwordUser;
            Saldo = saldo;
            StatusAkun = statusAkun;
        }
    }
}
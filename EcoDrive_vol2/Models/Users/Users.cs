using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.AbstractandInterface.Abstract;

namespace EcoDrive_vol2.Models.Users
{
    public class Users : AbsUser
    {
        public Roles RoleUser { get; set; }
        public string Username { get; set; }
        public string NoTelpUser { get; set; }
        public string PasswordUser { get; set; }
        public decimal Saldo { get; set; }
        public StatusAkun StatusAkun { get; set; }

        public override string GetRole()
        {
            return RoleUser.ToString();
        }

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

    //INHERITANCE
    public class Admin : Users
    {
        public Admin()
        {
            this.RoleUser = Roles.admin;
            this.StatusAkun = StatusAkun.aktif;
        }
        public override string GetRole() => "Admin";
    }

    public class Customer : Users
    {
        public Customer()
        {
            this.RoleUser = Roles.customer;
            this.Saldo = 0;
            this.StatusAkun = StatusAkun.aktif;
        }
        public override string GetRole() => "Customer";
    }
}
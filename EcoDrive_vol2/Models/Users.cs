using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models
{
    public class Users
    {
        public int idUser { get; set; }
        public string NamaUser { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Saldo { get; set; }
        public int idUserRole { get; set; }

        public Users(int idUser, string NamaUser, string Email, string Username, string Password, int Saldo, int idUserRole)
        {
            this.idUser = idUser;
            this.NamaUser = NamaUser;
            this.Email = Email;
            this.Username = Username;
            this.Password = Password;
            this.Saldo = Saldo;
            this.idUserRole = idUserRole;
        }
    }
}

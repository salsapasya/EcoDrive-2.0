using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EcoDrive_vol2.Helpers;
using Npgsql;

namespace EcoDrive_vol2.Models
{
    class UserContext
    {
        public List<Users> GetAllUsers()
        {
            List<Users> usersList = new List<Users>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM users", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                usersList.Add(new Users(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetInt32(5),
                    reader.GetInt32(6)
                ));
            }
            return usersList;
        }
        public void AddUser(Users user)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("INSERT INTO users (NamaUser, Email, Username, Password, Saldo, idUserRole) VALUES (@NamaUser, @Email, @Username, @Password, @Saldo, @idUserRole)", conn);
            cmd.Parameters.AddWithValue("NamaUser", user.NamaUser);
            cmd.Parameters.AddWithValue("Email", user.Email);
            cmd.Parameters.AddWithValue("Username", user.Username);
            cmd.Parameters.AddWithValue("Password", user.Password);
            cmd.Parameters.AddWithValue("Saldo", user.Saldo);
            cmd.Parameters.AddWithValue("idUserRole", user.idUserRole);
            cmd.ExecuteNonQuery();
        }
        public void UpdateUser(Users user)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("UPDATE users SET NamaUser = @NamaUser, Email = @Email, Username = @Username, Password = @Password, Saldo = @Saldo, idUserRole = @idUserRole WHERE idUser = @idUser", conn);
            cmd.Parameters.AddWithValue("NamaUser", user.NamaUser);
            cmd.Parameters.AddWithValue("Email", user.Email);
            cmd.Parameters.AddWithValue("Username", user.Username);
            cmd.Parameters.AddWithValue("Password", user.Password);
            cmd.Parameters.AddWithValue("Saldo", user.Saldo);
            cmd.Parameters.AddWithValue("idUserRole", user.idUserRole);
            cmd.Parameters.AddWithValue("idUser", user.idUser);
            cmd.ExecuteNonQuery();
        }
        public void DeleteUser(int idUser)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("DELETE FROM users WHERE idUser = @idUser", conn);
            cmd.Parameters.AddWithValue("idUser", idUser);
            cmd.ExecuteNonQuery();
        }
    }
}

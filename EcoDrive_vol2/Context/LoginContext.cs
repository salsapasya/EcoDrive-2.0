using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Users;
using Npgsql;
using System;

namespace EcoDrive_vol2.Context
{
    public class LoginContext
    {
        public Users Login(string username, string password)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();

                string query = @"
                    SELECT
                        id_user,
                        role_user,
                        username,
                        nama_user
                    FROM users
                    WHERE username = @username
                    AND password_user = @password";

                using var cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Users user = new Users();

                    user.IdUser =
                        Convert.ToInt32(reader["id_user"]);

                    user.Username =
                        reader["username"].ToString();

                    user.NamaUser =
                        reader["nama_user"].ToString();

                    string role =
                        reader["role_user"].ToString();

                    if (role.ToLower() == "admin")
                    {
                        user.RoleUser = Roles.admin;
                    }
                    else
                    {
                        user.RoleUser = Roles.customer;
                    }

                    return user;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Login gagal : " + ex.Message);
            }
        }
    }
}
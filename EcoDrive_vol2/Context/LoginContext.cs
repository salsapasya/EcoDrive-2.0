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
                        nama_user,
                        status_akun
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

                    user.IdUser = Convert.ToInt32(reader["id_user"]);
                    user.Username = reader["username"].ToString();
                    user.NamaUser = reader["nama_user"].ToString();

                    // --- FIX: AMBIL DATA STATUS DARI DATABASE ---
                    string rawStatus = reader["status_akun"].ToString().Trim().ToLower().Replace(" ", "_");

                    if (Enum.TryParse<StatusAkun>(rawStatus, true, out StatusAkun result))
                    {
                        user.StatusAkun = result;
                    }
                    else
                    {
                        // Kalau status di database gak jelas, anggap aktif saja supaya aplikasi tetap jalan
                        user.StatusAkun = StatusAkun.aktif;
                    }

                    string role = reader["role_user"].ToString();
                    user.RoleUser = (role.ToLower() == "admin") ? Roles.admin : Roles.customer;

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
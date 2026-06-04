using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Users;
using Npgsql;
using System.Windows.Forms;

namespace EcoDrive_vol2.Context
{
    public class LoginContext
    {
        public Users Login(string username, string password)
        {
            try
            {
                using NpgsqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                string query = @"
                SELECT id_user, role_user::text, username
                FROM users
                WHERE username = @username
                AND password_user = @password";

                using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                // ExecuteReader karena kita mau baca lebih dari 1 kolom
                using NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Users loggedInUser = new Users();
                    loggedInUser.IdUser = Convert.ToInt32(reader["id_user"]);
                    loggedInUser.Username = reader["username"].ToString();

                    string roleString = reader["role_user"].ToString();
                    if (Enum.TryParse(roleString, true, out Roles parsedRole))
                    {
                        loggedInUser.RoleUser = parsedRole;
                    }

                    return loggedInUser;
                }

                return null; // Jika username/password salah
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error : " + ex.Message);
                return null;
            }
        }
    }
}
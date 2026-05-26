using EcoDrive_vol2.Helpers;
using Npgsql;
using System.Windows.Forms;

namespace EcoDrive_vol2.Context
{
    public class LoginContext
    {
        public string Login(
            string username,
            string password)
        {
            try
            {
                using NpgsqlConnection conn =
                    DatabaseHelper.GetConnection();

                conn.Open();

                string query =
                @"SELECT role_user::text
                  FROM users
                  WHERE username = @username
                  AND password_user = @password";

                using NpgsqlCommand cmd =
                    new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@username",
                    username
                );

                cmd.Parameters.AddWithValue(
                    "@password",
                    password
                );

                object result =
                    cmd.ExecuteScalar();

                if (result != null)
                {
                    return result.ToString();
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Login Error : "
                    + ex.Message
                );

                return null;
            }
        }
    }
}
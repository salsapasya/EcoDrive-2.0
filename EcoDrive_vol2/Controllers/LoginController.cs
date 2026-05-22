using Npgsql;
using EcoDrive_vol2.Helpers;

namespace EcoDrive_vol2.Controllers
{
    public class LoginController
    {
        public string Login(
            string username,
            string password)
        {
            try
            {
                using (var conn =
                    DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT ru.user_role
                    FROM users u
                    JOIN role_user ru
                    ON u.id_user_role = ru.id_user_role
                    WHERE u.username = @username
                    AND u.password_user = @password";

                    using (var cmd =
                        new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@username",
                            username);

                        cmd.Parameters.AddWithValue(
                            "@password",
                            password);

                        var result =
                            cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return result.ToString();
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message);

                return null;
            }
        }
    }
}
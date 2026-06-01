using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.Models.Enums;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data; // WAJIB: Ditambahkan untuk tipe data DataTable

namespace EcoDrive_vol2.Context
{
    public class UserContext
    {
        public List<Users> GetAllUsers()
        {
            List<Users> usersList = new List<Users>();
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT * FROM users";

                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Users user = new Users()
                    {
                        IdUser = Convert.ToInt32(reader["id_user"]),
                        RoleUser = Enum.Parse<Roles>(reader["role_user"].ToString()),
                        NamaUser = reader["nama_user"].ToString(),
                        NoTelpUser = reader["no_telp_user"].ToString(),
                        Username = reader["username"].ToString(),
                        PasswordUser = reader["password_user"].ToString(),
                        Saldo = Convert.ToDecimal(reader["saldo"]),
                        StatusAkun = Enum.Parse<StatusAkun>(reader["status_akun"].ToString().Replace(" ", "_"))
                    };
                    usersList.Add(user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Get Users: " + ex.Message);
            }

            return usersList;
        }

        public void AddUser(Users user)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = @"INSERT INTO users (role_user, nama_user, no_telp_user, username, password_user, saldo, status_akun)
                                 VALUES (@role_user, @nama_user, @no_telp_user, @username, @password_user, @saldo, @status_akun)";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@role_user", user.RoleUser.ToString());
                cmd.Parameters.AddWithValue("@nama_user", user.NamaUser);
                cmd.Parameters.AddWithValue("@no_telp_user", user.NoTelpUser);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password_user", user.PasswordUser);
                cmd.Parameters.AddWithValue("@saldo", user.Saldo);
                cmd.Parameters.AddWithValue("@status_akun", user.StatusAkun.ToString().Replace("_", " "));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Add User: " + ex.Message);
            }
        }

        public void UpdateUser(Users user)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = @"UPDATE users SET role_user = @role_user, nama_user = @nama_user, no_telp_user = @no_telp_user,
                                 username = @username, password_user = @password_user, saldo = @saldo, status_akun = @status_akun
                                 WHERE id_user = @id_user";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@role_user", user.RoleUser.ToString());
                cmd.Parameters.AddWithValue("@nama_user", user.NamaUser);
                cmd.Parameters.AddWithValue("@no_telp_user", user.NoTelpUser);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password_user", user.PasswordUser);
                cmd.Parameters.AddWithValue("@saldo", user.Saldo);
                cmd.Parameters.AddWithValue("@status_akun", user.StatusAkun.ToString().Replace("_", " "));
                cmd.Parameters.AddWithValue("@id_user", user.IdUser);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Update User: " + ex.Message);
            }
        }

        public void DeleteUser(int idUser)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = @"DELETE FROM users WHERE id_user = @id_user";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_user", idUser);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Delete User: " + ex.Message);
            }
        }

        public decimal GetSaldo(int idUser)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = @"SELECT saldo FROM users WHERE id_user = @idUser";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idUser", idUser);

            object result = cmd.ExecuteScalar();
            return Convert.ToDecimal(result);
        }

        public void TopupSaldo(int idUser, decimal jumlah)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = @"UPDATE users SET saldo = saldo + @jumlah WHERE id_user = @idUser";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@jumlah", jumlah);
            cmd.Parameters.AddWithValue("@idUser", idUser);

            cmd.ExecuteNonQuery();
        }

        public int GetIdUser(string username)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = @"SELECT id_user FROM users WHERE username = @username";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        // ====================================================================
        // FUNGSI BARU: MENGAMBIL DATA DARI VIEW DATABASE (MENGGUNAKAN HELPER)
        // ====================================================================
        public DataTable GetDaftarTopUpFromView(string statusFilter)
        {
            DataTable dt = new DataTable();
            using var conn = DatabaseHelper.GetConnection();

            // Pastikan query ini sesuai dengan nama View yang Anda buat di PostgreSQL
            string query = "SELECT * FROM view_admin_topup";

            if (!string.IsNullOrEmpty(statusFilter))
            {
                // Sesuaikan nama kolom status di View Anda
                query += " WHERE \"Status\" = @status";
            }

            using var cmd = new NpgsqlCommand(query, conn);
            if (!string.IsNullOrEmpty(statusFilter))
            {
                cmd.Parameters.AddWithValue("@status", statusFilter);
            }

            try
            {
                conn.Open();
                using var reader = cmd.ExecuteReader();
                dt.Load(reader); // Memuat data hasil query ke dalam DataTable
            }
            catch (Exception ex)
            {
                throw new Exception("Error saat mengambil data dari view_admin_topup: " + ex.Message);
            }

            return dt;
        }
    }
}
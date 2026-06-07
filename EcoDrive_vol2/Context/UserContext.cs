using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.Models.Enums;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

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
                string query = "SELECT id_user, role_user, nama_user, no_telp_user, username, password_user, saldo, status_akun FROM users";

                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Ambil string mentah dari DB, bersihkan spasi ujung, dan ubah ke lowercase
                    string rawStatus = reader["status_akun"].ToString().Trim().ToLower().Replace(" ", "_");

                    Users user = new Users()
                    {
                        IdUser = Convert.ToInt32(reader["id_user"]),

                        // Parsing string enum roles ('admin' / 'customer') ke Enum C#
                        RoleUser = reader["role_user"].ToString().Trim().ToLower() == "admin" ? Roles.admin : Roles.customer,

                        NamaUser = reader["nama_user"].ToString(),
                        NoTelpUser = reader["no_telp_user"].ToString(),
                        Username = reader["username"].ToString(),
                        PasswordUser = reader["password_user"].ToString(),
                        Saldo = Convert.ToDecimal(reader["saldo"]),

                        // 🛠️ FIX SINKRONISASI: Dipastikan string dikonversi ke lowercase & underscore sebelum masuk Enum.Parse
                        StatusAkun = Enum.Parse<StatusAkun>(rawStatus, true)
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

                string query = @"INSERT INTO users
                (
                    role_user,
                    nama_user,
                    no_telp_user,
                    username,
                    password_user,
                    saldo,
                    status_akun
                )
                VALUES
                (
                    @role_user::roles,
                    @nama_user,
                    @no_telp_user,
                    @username,
                    @password_user,
                    @saldo,
                    @status_akun::status_akun
                )";

                using var cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@role_user", user.RoleUser.ToString().ToLower());
                cmd.Parameters.AddWithValue("@nama_user", user.NamaUser);
                cmd.Parameters.AddWithValue("@no_telp_user", user.NoTelpUser);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password_user", user.PasswordUser);
                cmd.Parameters.AddWithValue("@saldo", user.Saldo);

                // Mengubah format underscore C# menjadi spasi database (misal non_aktif -> 'non aktif')
                cmd.Parameters.AddWithValue("@status_akun", user.StatusAkun.ToString().ToLower().Replace("_", " "));

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

                string query = @"UPDATE users
                                 SET
                                   role_user = @role_user::roles,
                                   nama_user = @nama_user,
                                   no_telp_user = @no_telp_user,
                                   username = @username,
                                   password_user = @password_user,
                                   saldo = @saldo,
                                   status_akun = @status_akun::status_akun
                                 WHERE id_user = @id_user";

                using var cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@role_user", user.RoleUser == Roles.admin ? "admin" : "customer");
                cmd.Parameters.AddWithValue("@nama_user", user.NamaUser);
                cmd.Parameters.AddWithValue("@no_telp_user", user.NoTelpUser);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password_user", user.PasswordUser);
                cmd.Parameters.AddWithValue("@saldo", user.Saldo);

                // Sinkronisasi data enum C# ke format spasi text di PostgreSQL database
                cmd.Parameters.AddWithValue("@status_akun", user.StatusAkun.ToString().ToLower().Replace("_", " "));
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

        public bool UsernameExists(string username)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            string query = @"SELECT COUNT(*) FROM users WHERE username = @username";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        public DataTable GetDaftarTopUpFromView(string statusFilter)
        {
            DataTable dt = new DataTable();
            using var conn = DatabaseHelper.GetConnection();

            string query = "SELECT * FROM view_admin_topup";

            if (!string.IsNullOrEmpty(statusFilter))
            {
                query += " WHERE status = LOWER(@status)";
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
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                throw new Exception("Error saat mengambil data dari view_admin_topup: " + ex.Message);
            }

            return dt;
        }

        public void KonfirmasiTopUp(int idTopup, int idUser)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT fn_konfirmasi_topup(@idTopup, @idUser)";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTopup", idTopup);
                cmd.Parameters.AddWithValue("@idUser", idUser);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal memproses konfirmasi top up di database: " + ex.Message);
            }
        }

        public void TolakTopUp(int idTopup)
        {
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT fn_tolak_topup(@idTopup)";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idTopup", idTopup);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal memproses penolakan top up di database: " + ex.Message);
            }
        }

        public DataTable GetAllCustomersForGrid()
        {
            DataTable dt = new DataTable();
            using var conn = DatabaseHelper.GetConnection();

            try
            {
                conn.Open();
                string query = @"SELECT id_user, 
                                        (nama_user || '|' || username) AS customer_data, 
                                        no_telp_user AS kontak, 
                                        'Member' AS bergabung, 
                                        '0 trip' AS total_sewa, 
                                        status_akun AS status,
                                        '👁  ✏  🗑' AS aksi
                                 FROM users 
                                 WHERE role_user = 'customer'::roles
                                 ORDER BY id_user DESC";

                using var cmd = new NpgsqlCommand(query, conn);
                using var adapter = new NpgsqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Ambil Data Customer ke Grid: " + ex.Message);
            }

            return dt;
        }

        public Dictionary<string, string> GetTopUpSummary()
        {
            var summary = new Dictionary<string, string>
            {
                { "TotalNominal", "Rp 0" },
                { "Pending", "0" },
                { "Sukses", "0" }
            };

            using var conn = DatabaseHelper.GetConnection();
            try
            {
                conn.Open();

                string queryTotal = "SELECT COALESCE(SUM(jumlah_topup), 0) FROM topup_saldo WHERE status_topup = 'berhasil'";
                string queryPending = "SELECT COUNT(*) FROM topup_saldo WHERE status_topup = 'pending'";
                string querySukses = "SELECT COUNT(*) FROM topup_saldo WHERE status_topup = 'berhasil'";

                using (var cmd = new NpgsqlCommand(queryTotal, conn))
                {
                    decimal totalNominal = Convert.ToDecimal(cmd.ExecuteScalar());
                    summary["TotalNominal"] = "Rp " + totalNominal.ToString("N0");
                }

                using (var cmd = new NpgsqlCommand(queryPending, conn))
                {
                    summary["Pending"] = cmd.ExecuteScalar().ToString();
                }

                using (var cmd = new NpgsqlCommand(querySukses, conn))
                {
                    summary["Sukses"] = cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error summary database: " + ex.Message);
            }

            return summary;
        }
    }
}
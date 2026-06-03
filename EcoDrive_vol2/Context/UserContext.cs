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
                string query = "SELECT * FROM users";

                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Users user = new Users()
                    {
                        IdUser = Convert.ToInt32(reader["id_user"]),
                        RoleUser = Convert.ToInt32(reader["id_user_role"]) == 1 ? Roles.admin : Roles.customer,
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

                string query =
                @"INSERT INTO users
                (
                    id_user_role,
                    nama_user,
                    no_telp_user,
                    username,
                    password_user,
                    saldo,
                    status_akun
                )
                VALUES
                (
                    @id_user_role,
                    @nama_user,
                    @no_telp_user,
                    @username,
                    @password_user,
                    @saldo,
                    @status_akun
                )";

                using var cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id_user_role", user.RoleUser == Roles.admin ? 1 : 2);
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

                string query =
                @"UPDATE users
                  SET
                    id_user_role = @id_user_role,
                    nama_user = @nama_user,
                    no_telp_user = @no_telp_user,
                    username = @username,
                    password_user = @password_user,
                    saldo = @saldo,
                    status_akun = @status_akun
                  WHERE id_user = @id_user";

                using var cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id_user_role", user.RoleUser == Roles.admin ? 1 : 2);
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
        // PENYESUAIAN: Ambil data dari SQL View (Dipastikan case-safe untuk Postgres)
        // ====================================================================
        public DataTable GetDaftarTopUpFromView(string statusFilter)
        {
            DataTable dt = new DataTable();
            using var conn = DatabaseHelper.GetConnection();

            string query = "SELECT * FROM view_admin_topup";

            // SINKRONISASI: Menggunakan lowercase "status" agar sesuai standar penamaan kolom di PostgreSQL View
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

        // ====================================================================
        // FUNGSI BARU: Konfirmasi Top Up dengan Database Transaction (ACID)
        // ====================================================================
        public void KonfirmasiTopUp(int idTopup, int idUser)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            // Menggunakan transaksi agar jika query pertama berhasil tetapi query kedua gagal, data di-rollback otomatis
            using var transaction = conn.BeginTransaction();

            try
            {
                // 1. Ambil jumlah nominal top up dari id_transaksi tersebut terlebih dahulu
                string queryGetJumlah = "SELECT jumlah_topup FROM transaksi_topup WHERE id_transaksi = @idTopup";
                decimal jumlahTopup = 0;

                using (var cmdGet = new NpgsqlCommand(queryGetJumlah, conn, transaction))
                {
                    cmdGet.Parameters.AddWithValue("@idTopup", idTopup);
                    object res = cmdGet.ExecuteScalar();
                    if (res == null || res == DBNull.Value)
                    {
                        throw new Exception("Transaksi top up tidak ditemukan!");
                    }
                    jumlahTopup = Convert.ToDecimal(res);
                }

                // 2. Update status transaksi top-up menjadi 'berhasil'
                string queryUpdateStatus = "UPDATE transaksi_topup SET status = 'berhasil' WHERE id_transaksi = @idTopup";
                using (var cmdUpdateTrans = new NpgsqlCommand(queryUpdateStatus, conn, transaction))
                {
                    cmdUpdateTrans.Parameters.AddWithValue("@idTopup", idTopup);
                    cmdUpdateTrans.ExecuteNonQuery();
                }

                // 3. Tambahkan nominal tersebut ke saldo akun user
                string queryUpdateSaldo = "UPDATE users SET saldo = saldo + @jumlah WHERE id_user = @idUser";
                using (var cmdUpdateSaldo = new NpgsqlCommand(queryUpdateSaldo, conn, transaction))
                {
                    cmdUpdateSaldo.Parameters.AddWithValue("@jumlah", jumlahTopup);
                    cmdUpdateSaldo.Parameters.AddWithValue("@idUser", idUser);
                    cmdUpdateSaldo.ExecuteNonQuery();
                }

                // Jika semua langkah di atas aman tanpa error, kunci perubahan ke database
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Jika di tengah jalan ada yang gagal, batalkan semua perubahan demi keamanan data
                transaction.Rollback();
                throw new Exception("Gagal memproses konfirmasi top up di database: " + ex.Message);
            }
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

                // QUERY 1: Total nominal akumulasi dari semua top up yang BERHASIL
                string queryTotal = "SELECT COALESCE(SUM(jumlah_topup), 0) FROM topup_saldo WHERE status_topup = 'berhasil'";

                // QUERY 2: Jumlah baris data yang berstatus PENDING
                string queryPending = "SELECT COUNT(*) FROM topup_saldo WHERE status_topup = 'pending'";

                // QUERY 3: Jumlah baris data yang berstatus BERHASIL
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
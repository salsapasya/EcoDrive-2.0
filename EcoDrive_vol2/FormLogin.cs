using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace EcoDrive_vol2
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Role
            CmbRole.Items.Add("Admin");
            CmbRole.Items.Add("Customer");

            CmbRole.SelectedIndex = 0;

            // Password
            TxtPassword.UseSystemPasswordChar = true;

            // Placeholder Username
            TxtUsername.Text = "Masukkan Username";
            TxtUsername.ForeColor = Color.Gray;

            // Placeholder Password
            TxtPassword.Text = "Masukkan Password";
            TxtPassword.ForeColor = Color.Gray;
            TxtPassword.UseSystemPasswordChar = false;
        }

        private void LblLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister frm = new FormRegister();

            frm.Show();

            this.Hide();
        }

        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            if (TxtUsername.Text == "Masukkan Username")
            {
                TxtUsername.Text = "";
                TxtUsername.ForeColor = Color.Black;
            }
        }
        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            if (TxtUsername.Text == "")
            {
                TxtUsername.Text = "Masukkan Username";
                TxtUsername.ForeColor = Color.Gray;
            }
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "Masukkan Password")
            {
                TxtPassword.Text = "";
                TxtPassword.ForeColor = Color.Black;
                TxtPassword.UseSystemPasswordChar = true;
            }
        }
        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "")
            {
                TxtPassword.UseSystemPasswordChar = false;
                TxtPassword.Text = "Masukkan Password";
                TxtPassword.ForeColor = Color.Gray;
            }
        }

        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Validasi kosong
            if (TxtUsername.Text == "" ||
                TxtPassword.Text == "" ||
                TxtUsername.Text == "Masukkan Username" ||
                TxtPassword.Text == "Masukkan Password")
            {
                MessageBox.Show("Username dan Password wajib diisi");
                return;
            }

            try
            {
                Koneksi.buka();

                string query = "SELECT * FROM users " +
                               "WHERE username=@username " +
                               "AND password=@password " +
                               "AND role=@role " +
                               "AND status='aktif'";

                NpgsqlCommand cmd =
                    new NpgsqlCommand(query, Koneksi.conn);

                cmd.Parameters.AddWithValue(
                    "@username", TxtUsername.Text);

                cmd.Parameters.AddWithValue(
                    "@password", TxtPassword.Text);

                cmd.Parameters.AddWithValue(
                    "@role", CmbRole.Text);

                NpgsqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    // Session
                    Session.idUser =
                        Convert.ToInt32(rd["user_id"]);

                    Session.username =
                        rd["username"].ToString();

                    Session.role =
                        rd["role"].ToString();

                    MessageBox.Show("Login berhasil");

                    // Role Admin
                    if (CmbRole.Text == "Admin")
                    {
                        FormDashboardAdmin frm =
                            new FormDashboardAdmin();

                        frm.Show();
                    }

                    // Role Customer
                    else
                    {
                        FormDashboardCustomer frm =
                            new FormDashboardCustomer();

                        frm.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Username, password, atau role salah");
                }

                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Koneksi.tutup();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EcoDrive_vol2.Controllers.Authentication;
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2
{
    public partial class FormRegister : Form
    {
        private RegisterController controller =
            new RegisterController();

        public FormRegister()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi Nama
                if (string.IsNullOrWhiteSpace(txtNama.Text))
                {
                    MessageBox.Show("Nama tidak boleh kosong");
                    return;
                }

                // Validasi Nomor Telepon
                if (string.IsNullOrWhiteSpace(txtTelp.Text))
                {
                    MessageBox.Show("Nomor telepon tidak boleh kosong");
                    return;
                }

                if (!long.TryParse(txtTelp.Text, out _))
                {
                    MessageBox.Show("Nomor telepon harus berupa angka");
                    return;
                }

                if (txtTelp.Text.Length > 20)
                {
                    MessageBox.Show("Nomor telepon maksimal 20 digit");
                    return;
                }

                // Validasi Username
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Username tidak boleh kosong");
                    return;
                }

                // Validasi Password
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Password tidak boleh kosong");
                    return;
                }

                if (controller.UsernameExists(txtUsername.Text))
                {
                    MessageBox.Show("Username sudah digunakan, gunakan username lain");
                    return;
                }

                Users user = new Users();

                // Role otomatis customer
                user.RoleUser = Roles.customer;

                user.NamaUser = txtNama.Text;
                user.NoTelpUser = txtTelp.Text;
                user.Username = txtUsername.Text;
                user.PasswordUser = txtPassword.Text;
                user.Saldo = 0;
                user.StatusAkun = StatusAkun.aktif;

                controller.Register(user);

                MessageBox.Show("Register Berhasil");

                FormLogin login = new FormLogin();
                login.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;

            LblSignUp.Cursor = Cursors.Hand;
            LblSignUp.ForeColor = Color.Blue;

            txtNama.Text = "Nama";
            txtNama.ForeColor = Color.Gray;

            txtTelp.Text = "No Telp";
            txtTelp.ForeColor = Color.Gray;

            txtUsername.Text = "Username";
            txtUsername.ForeColor = Color.Gray;

            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.Gray;
        }

        private void LblSignUp_Click(object sender, EventArgs e)
        {
            FormLogin login =
                new FormLogin();

            login.Show();

            this.Hide();
        }

        private void txtTelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();

            login.Show();

            this.Close();
        }
    }
}
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

        private void btnSignUp_Click(object sender,EventArgs e)
        {
            try
            {
                Users user =
                    new Users();

                user.RoleUser =
                    Roles.customer;

                user.NamaUser =
                    txtNama.Text;

                user.NoTelpUser =
                    txtTelp.Text;

                user.Username =
                    txtUsername.Text;

                user.PasswordUser =
                    txtPassword.Text;

                user.Saldo = 0;

                user.StatusAkun =
                    StatusAkun.aktif;

                controller.Register(user);

                MessageBox.Show(
                    "Register Berhasil");

                FormLogin login =
                    new FormLogin();

                login.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
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
    }
}
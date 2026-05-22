using EcoDrive_vol2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EcoDrive_vol2.Controllers;

namespace EcoDrive_vol2
{
    public partial class FormLogin : Form
    {
        private LoginController controller = new LoginController();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Password jadi bintang
            TxtPassword.UseSystemPasswordChar = true;

            // Isi ComboBox Role
            CmbRole.Items.Add("Admin");
            CmbRole.Items.Add("Customer");

            CmbRole.SelectedIndex = -1;

            // Cursor Sign Up
            lblSignUp.Cursor = Cursors.Hand;
            lblSignUp.ForeColor = Color.Blue;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Label Username
            TxtUsername.Focus();
        }

        private void linkLabelRegis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister register =
        new FormRegister();

            register.Show();

            this.Hide();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username =
                    TxtUsername.Text;

                string password =
                    TxtPassword.Text;

                string role =
                    controller.Login(
                        username,
                        password);

                if (role == "admin")
                {
                    MessageBox.Show(
                        "Login Admin Berhasil");

                    AdDashboard admin =
                        new AdDashboard();

                    admin.Show();

                    this.Hide();
                }
                else if (role == "customer")
                {
                    MessageBox.Show(
                        "Login Customer Berhasil");

                    CusDasboard customer =
                        new CusDasboard();

                    customer.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Username atau Password Salah");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            TxtPassword.PasswordChar = '*';
        }
        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            TxtUsername_TextChanged(sender, e);
        }
        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtUsername.Text))
            {
                TxtUsername.Text = "Username";
                TxtUsername.ForeColor = Color.Gray;
            }
        }
        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            if (TxtUsername.Text == "Username")
            {
                TxtUsername.Text = "";
                TxtUsername.ForeColor = Color.Black;
            }
        }
        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                TxtPassword.Text = "Password";
                TxtPassword.ForeColor = Color.Gray;
                TxtPassword.PasswordChar = '\0';
            }
        }
        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "Password")
            {
                TxtPassword.Text = "";
                TxtPassword.ForeColor = Color.Black;
                TxtPassword.PasswordChar = '*';
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            // Label Password
            TxtPassword.Focus();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void TxtUsername_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void FrmJudul_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        "Selamat Datang di EcoDrive");
        }
    }
}

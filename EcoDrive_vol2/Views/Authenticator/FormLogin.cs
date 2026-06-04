using EcoDrive_vol2.Controllers.Authentication;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EcoDrive_vol2
{
    public partial class FormLogin : Form
    {
        private readonly LoginController _loginController = new LoginController();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = true;

            if (CmbRole != null)
            {
                CmbRole.SelectedIndex = -1;
            }

            lblSignUp.Cursor = Cursors.Hand;
            lblSignUp.ForeColor = Color.Blue;

            btnTogglePassword.Click += BtnTogglePassword_Click;
        }

        private void BtnTogglePassword_Click(object sender, EventArgs e)
        {

            TxtPassword.UseSystemPasswordChar = !TxtPassword.UseSystemPasswordChar;
            btnTogglePassword.Text = TxtPassword.UseSystemPasswordChar ? "SHOW" : "HIDE";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = TxtUsername.Text;
                string password = TxtPassword.Text;

                Users userLogin = _loginController.Login(username, password);

                if (userLogin != null)
                {
                    // SIMPAN ID KE SESSION GLOBAL SEKARANG
                    UserSession.IdUserAktif = userLogin.IdUser;
                    UserSession.UsernameAktif = userLogin.Username;
                    UserSession.Role = userLogin.RoleUser.ToString();

                    MessageBox.Show($"Selamat datang, {userLogin.Username}!", "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (userLogin.RoleUser == Roles.admin)
                    {
                        AdDashboard admin = new AdDashboard();
                        admin.Show();
                        this.Hide();
                    }
                    else if (userLogin.RoleUser == Roles.customer)
                    {
                        CusDasboard customer = new CusDasboard(username);
                        customer.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Username atau Password Salah!", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // NAVIGATION: Buka Form Registrasi
        private void linkLabelRegis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister register = new FormRegister();
            register.Show();
            this.Hide();
        }

        private void lblSignUp_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister register = new FormRegister();
            register.Show();
            this.Hide();
        }

        // PLACEHOLDER SYSTEM: USERNAME
        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            if (TxtUsername.Text == "Username")
            {
                TxtUsername.Text = "";
                TxtUsername.ForeColor = Color.Black;
            }
        }

        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtUsername.Text))
            {
                TxtUsername.Text = "Username";
                TxtUsername.ForeColor = Color.Gray;
            }
        }

        // PLACEHOLDER SYSTEM: PASSWORD
        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "Password")
            {
                TxtPassword.Text = "";
                TxtPassword.ForeColor = Color.Black;
                TxtPassword.PasswordChar = '*';
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

        private void label1_Click(object sender, EventArgs e)
        {
            TxtUsername.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            TxtPassword.Focus();
        }

        private void FrmJudul_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selamat Datang di EcoDrive", "Apps Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
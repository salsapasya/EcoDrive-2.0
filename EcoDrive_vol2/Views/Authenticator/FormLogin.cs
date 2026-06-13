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
        private readonly LoginController _loginController = new LoginController();  //ENCAP BIAR YG DILUAR LINGKUP KELAS INI GABISA MENGUBAH

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = true;

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
                string username = TxtUsername.Text.Trim();
                string password = TxtPassword.Text.Trim();

                // Validasi input kosong langsung di UI agar lebih responsif
                if (username == "Username" || string.IsNullOrWhiteSpace(username) ||
                    password == "Password" || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Username dan Password wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Memanggil login. Jika akun diblokir/salah password, service akan melempar Exception ke blok catch di bawah.
                Users userLogin = _loginController.Login(username, password);  //ABSTRAC BCS VIEW BAKAL MANGGIL LOGIN() YG ADA DI CONTROLLER

                // Jika berhasil lolos dari Exception, berarti user dijamin valid dan aktif!
                // SIMPAN KE SESSION GLOBAL
                UserSession.IdUserAktif = userLogin.IdUser;
                UserSession.UsernameAktif = userLogin.Username;
                UserSession.Role = userLogin.GetRole(); // pake fungsi override OOP

                MessageBox.Show($"Selamat datang, {userLogin.Username}!", "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Pengecekan Hak Akses (Enum Roles)
                if (userLogin.RoleUser == Roles.admin)
                {
                    AdDashboard admin = new AdDashboard();
                    admin.Show();
                    this.Hide();
                }
                else if (userLogin.RoleUser == Roles.customer)
                {
                    CusDasboard customer = new CusDasboard(userLogin.NamaUser);
                    customer.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                // Menangkap pesan khusus: "AKUN_DIBLOKIR: ..." atau "Username atau password salah!"
                // Menampilkan MessageBox Icon Warning/Error agar UI terlihat dinamis
                if (ex.Message.Contains("AKUN_DIBLOKIR"))
                {
                    // 1. Tampilkan peringatan
                    MessageBox.Show(ex.Message, "Akun Ditangguhkan", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    // 2. Redirect ke halaman registrasi (Sesuaikan dengan nama Form Registrasi kamu)
                    FormRegister formReg = new FormRegister();
                    formReg.Show();
                    // 3. Sembunyikan form login
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // NAVIGATION: Buka Form Registrasi
        private void linkLabelRegis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)  //POLYMOR BCS PARAMETER OBJECT SENDER BUAT NANGANIN MACAM MACAM KOMPONEN
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
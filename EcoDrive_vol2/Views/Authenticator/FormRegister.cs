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
using EcoDrive_vol2.Service;

namespace EcoDrive_vol2
{
    public partial class FormRegister : Form
    {
        private readonly RegisterService _registerService = new RegisterService();
           
        public FormRegister()
        {
            InitializeComponent();

            this.Shown += (s, ev) => { this.ActiveControl = FrmJudul; };
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil data mentah dari textfield UI
                string nama = txtNama.Text.Trim();
                string telp = txtTelp.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                // View tinggal manggil service, ga perlu mikir logic if-else validasi lagi!
                _registerService.ValidasiDanRegistrasiCustomer(nama, telp, username, password);

                MessageBox.Show("Register Berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormLogin login = new FormLogin();
                login.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Menangkap pesan error dari throw Exception yang ada di Service
                MessageBox.Show(ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            btnSignUp.Cursor = Cursors.Hand;
            btnBack.Cursor = Cursors.Hand;

            txtPassword.UseSystemPasswordChar = true;

            this.ActiveControl = FrmJudul;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();

            login.Show();

            this.Close();
        }

        // Metode kosong sisa generate otomatis dikosongkan
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtTelp_TextChanged(object sender, EventArgs e) { }
        private void txtNama_TextChanged(object sender, EventArgs e) { }
    }
}
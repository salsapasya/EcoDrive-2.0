using EcoDrive_vol2.Views.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class AdDashboard : Form
    {
        private Form activeForm = null;
        private Color bgUtama = Color.FromArgb(255, 253, 246);

        public AdDashboard()
        {
            InitializeComponent();

            btDasboard.Click += btDasboard_Click;
            btKendaraan.Click += btKendaraan_Click;
            btCustomer.Click += btCustomer_Click;
            btTransaksi.Click += btTransaksi_Click;
            btPendapatan.Click += btPendapatan_Click;
            btTopUp.Click += btTopUp_Click;
        }

        // --- FUNGSI UTAMA PINDAH FORM ---
        private void OpenForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;

            childForm.Size = pnContentAdmin.ClientSize;

            childForm.Dock = DockStyle.Fill;

            pnContentAdmin.Controls.Clear();
            pnContentAdmin.Controls.Add(childForm);
            pnContentAdmin.Tag = childForm;

            childForm.Location = new Point(0, 0);

            pnContentAdmin.PerformLayout();
            childForm.Refresh();

            childForm.BringToFront();
            childForm.Show();
        }

        // RESET WARNA BUTTON SIDEBAR
        private void ResetButton()
        {
            btDasboard.BackColor = Color.White;
            btKendaraan.BackColor = Color.White;
            btTransaksi.BackColor = Color.White;
            btPendapatan.BackColor = Color.White;
            btCustomer.BackColor = Color.White;
            btTopUp.BackColor = Color.White;
        }

        // DASHBOARD MENU
        private void btDasboard_Click(object sender, EventArgs e)
        {
            ResetButton();
            btDasboard.BackColor = Color.FromArgb(191, 219, 120);

            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
                activeForm = null;
            }
            pnContentAdmin.Controls.Clear();
        }

        // KENDARAAN MENU
        private void btKendaraan_Click(object sender, EventArgs e)
        {
            ResetButton();
            btKendaraan.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdKendaraan());
        }

        // CUSTOMER MENU
        private void btCustomer_Click(object sender, EventArgs e)
        {
            ResetButton();
            btCustomer.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdCustomer());
        }

        // TRANSAKSI MENU
        private void btTransaksi_Click(object sender, EventArgs e)
        {
            ResetButton();
            btTransaksi.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdTransaksi());
        }

        // PENDAPATAN MENU
        private void btPendapatan_Click(object sender, EventArgs e)
        {
            ResetButton();
            btPendapatan.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdPendapatan());
        }

        private void pnContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btDasboard_Click_1(object sender, EventArgs e)
        {

        }

        private void AdDashboard_Load(object sender, EventArgs e)
        {

        }


        private void btPendapatan_Click_1(object sender, EventArgs e)
        {

        }

        private void btLogoutAd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // buka login
                FormLogin login = new FormLogin();
                login.Show();

                // tutup dashboard
                this.Close();
            }
        }

        private void btTopUp_Click(object sender, EventArgs e)
        {
            ResetButton();
            btTopUp.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdTopUpCustomer());
        }
    }
}
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
        }
        // FUNCTION PINDAH FORM
        private void OpenForm(Form childForm)
        {
            // Tutup form sebelumnya
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnContentAdmin.Controls.Clear();
            pnContentAdmin.Controls.Add(childForm);

            childForm.BringToFront();
            childForm.Show();
        }

        // RESET WARNA BUTTON
        private void ResetButton()
        {
            btDasboard.BackColor = Color.White;
            btKendaraan.BackColor = Color.White;
            btTransaksi.BackColor = Color.White;
            btPendapatan.BackColor = Color.White;
            btCustomer.BackColor = Color.White;
        }

        // DASHBOARD
        private void btDasboard_Click(object sender, EventArgs e)
        {
            ResetButton();

            btDasboard.BackColor = Color.FromArgb(191, 219, 120);

            if (activeForm != null)
            {
                activeForm.Close();
            }
            else
            {
                OpenForm(new AdDashboard());
            }
        }

        // KENDARAAN
        private void btKendaraan_Click(object sender, EventArgs e)
        {
            ResetButton();

            btKendaraan.BackColor = Color.FromArgb(191, 219, 120);

            OpenForm(new AdKendaraan());
        }

        // CUSTOMER
        private void btCustomer_Click(object sender, EventArgs e)
        {
            ResetButton();

            btCustomer.BackColor = Color.FromArgb(191, 219, 120);

            OpenForm(new AdCustomer());
        }

        // TRANSAKSI
        private void btTransaksi_Click(object sender, EventArgs e)
        {
            ResetButton();

            btTransaksi.BackColor = Color.FromArgb(191, 219, 120);

            OpenForm(new AdTransaksi());
        }

        // PENDAPATAN
        private void btPendapatan_Click(object sender, EventArgs e)
        {
            ResetButton();

            btPendapatan.BackColor = Color.FromArgb(191, 219, 120);

            OpenForm(new AdPendapatan());
        }

    }
}

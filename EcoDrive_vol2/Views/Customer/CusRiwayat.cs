using EcoDrive_vol2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class CusRiwayat : Form
    {
        private Color bgUtama = Color.FromArgb(255, 253, 246);
        public CusRiwayat()
        {
            InitializeComponent();
            this.BackColor = bgUtama;
        }

        private void CusRiwayat_Load(object sender, EventArgs e)
        {
            // Tampilan DataGridView
            dgvRiwayat.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvRiwayat.AllowUserToAddRows =
                false;

            dgvRiwayat.RowHeadersVisible =
                false;

            dgvRiwayat.ReadOnly =
                true;

            dgvRiwayat.CellBorderStyle =
                DataGridViewCellBorderStyle.Single;

            dgvRiwayat.GridColor =
                Color.Black;

            // Dummy Data Riwayat
            dgvRiwayat.Rows.Add(
                "TRX001",
                "Tesla Model 3",
                "27 Mei 2026",
                "2 Hari",
                "Rp 800.000",
                "Selesai");

            dgvRiwayat.Rows.Add(
                "TRX002",
                "Ioniq 5",
                "20 Mei 2026",
                "1 Hari",
                "Rp 400.000",
                "Selesai");

            dgvRiwayat.Rows.Add(
                "TRX003",
                "Motor Gesits",
                "15 Mei 2026",
                "3 Hari",
                "Rp 300.000",
                "Selesai");
        }

        private void dgvRiwayat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnKembali_Click(
            object sender,
            EventArgs e)
        {
            CusDasboard dashboard =
                new CusDasboard();

            dashboard.Show();

            this.Hide();
        }
    }
}
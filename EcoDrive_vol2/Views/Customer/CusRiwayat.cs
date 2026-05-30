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

        private Controllers.Customer.CusRiwayatController controller =
        new Controllers.Customer.CusRiwayatController();
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

            dgvRiwayat.Rows.Clear();

            var dataRiwayat =
                controller.GetRiwayat(2);

            foreach (var item in dataRiwayat)
            {
                dgvRiwayat.Rows.Add(
                    item.IdTransaksiSewa,
                    item.IdKendaraan,
                    item.TanggalSewa.ToString("dd/MM/yyyy"),
                    item.DurasiSewa + " Hari",
                    "-",
                    item.StatusPengembalian);
            }
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
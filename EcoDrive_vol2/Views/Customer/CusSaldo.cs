using EcoDrive_vol2.Models.Transaksi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class CusSaldo : Form
    {
        private Color bgUtama = Color.FromArgb(255, 253, 246);
        private object txtIdCustomer;

        private int saldo = 0;

        public CusSaldo()
        {
            InitializeComponent();
            this.BackColor = bgUtama;

        }
        private void btnTopup_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (txtTopUp.Text == "")
                {
                    MessageBox.Show(
                        "Masukkan jumlah top up");

                    return;
                }

                int jumlahTopUp =
                    Convert.ToInt32(
                        txtTopUp.Text);

                saldo += jumlahTopUp;

                lblSaldo.Text =
                    "Rp " +
                    saldo.ToString("N0");

                MessageBox.Show(
                    "Top Up Berhasil");

                txtTopUp.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " +
                    ex.Message);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTopUp_Click_1(object sender, EventArgs e)
        {
            btnTopup_Click(sender,e);
        }

        private void CusSaldo_Load(object sender, EventArgs e)
        {
            lblSaldo.Text ="Rp 0";
        }

        private void lblSaldo_Click(object sender, EventArgs e)
        {

        }

        private void txtTopUp_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Halaman Saldo Customer");
        }
    }
}

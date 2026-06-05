using EcoDrive_vol2.Models.Transaksi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EcoDrive_vol2.Controllers.Customer;
using EcoDrive_vol2.Helpers;

namespace EcoDrive_vol2.Views
{
    public partial class CusSaldo : Form
    {
        private Color bgUtama = Color.FromArgb(255, 253, 246);
        private object txtIdCustomer;

        private int idUser = UserSession.IdUserAktif;
        private decimal saldo = 0;

        private CusSaldoController controller =
            new CusSaldoController();

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
                    MessageBox.Show("Masukkan jumlah top up");

                    return;
                }

                decimal jumlahTopUp = Convert.ToDecimal(txtTopUp.Text);

                controller.TopupSaldo(idUser,jumlahTopUp);

                saldo = controller.GetSaldo(idUser);

                lblSaldo.Text =
                    "Rp " + saldo.ToString("N0");

                MessageBox.Show("Top Up Berhasil! Menunggu Konfirmasi Admin");

                txtTopUp.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
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
            idUser = UserSession.IdUserAktif;
            saldo = controller.GetSaldo(idUser);

            lblSaldo.Text = "Rp " + saldo.ToString("N0");
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

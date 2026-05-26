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
                TopupSaldo topup = new TopupSaldo();           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

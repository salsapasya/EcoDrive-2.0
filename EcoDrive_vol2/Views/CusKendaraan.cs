using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class CusKendaraan : Form
    {
        private Color bgUtama = Color.FromArgb(255, 253, 246);
        public CusKendaraan()
        {
            InitializeComponent();
            this.BackColor = bgUtama;
            LoadCard();
        }

        private void CusKendaraan_Load(object sender, EventArgs e)
        {

        }
        private void LoadCard()
        {
            // CARD
            Panel card = new Panel();
            card.Size = new Size(220, 250);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(20);

            // LABEL NAMA
            Label lblNama = new Label();
            lblNama.Text = "Tesla Model 3";
            lblNama.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblNama.Location = new Point(10, 20);
            lblNama.AutoSize = true;

            // LABEL HARGA
            Label lblHarga = new Label();
            lblHarga.Text = "Rp 500.000 / hari";
            lblHarga.Location = new Point(10, 60);
            lblHarga.AutoSize = true;

            // BUTTON
            Button btn = new Button();
            btn.Text = "Sewa";
            btn.Location = new Point(10, 100);
            btn.Size = new Size(100, 35);

            // MASUKKAN KE CARD
            card.Controls.Add(lblNama);
            card.Controls.Add(lblHarga);
            card.Controls.Add(btn);

            // TAMPILKAN CARD
            flowLayoutPanel1.Controls.Add(card);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

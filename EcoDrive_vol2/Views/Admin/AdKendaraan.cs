using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EcoDrive_vol2.Controllers.Admin;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Vehicles;
using EcoDriveUI;
using EcoDrive_vol2.Views.Admin;

namespace EcoDrive_vol2.Views
{
    public partial class AdKendaraan : Form
    {
        private readonly AdKendaraanController _controller;
        private string _filterAktif = "Semua";

        public AdKendaraan()
        {
            InitializeComponent();
            _controller = new AdKendaraanController();

            this.Load += AdKendaraan_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnSemua.Click += FilterButton_Click;
            btnMobil.Click += FilterButton_Click;
            btnMotor.Click += FilterButton_Click;
            btnTambah.Click += BtnTambah_Click;
        }

        private void AdKendaraan_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            SetupUIStyles();
            RefreshDataDariDatabase();
        }

        private void SetupUIStyles()
        {
            // --- Search TextBox ---
            txtSearch.BackColor = Color.FromArgb(245, 245, 240);
            txtSearch.ForeColor = Color.Black;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.PlaceholderText = "🔍 Cari kendaraan...";

            // --- Filter Buttons ---
            btnSemua.Text = "Semua";
            btnMobil.Text = "Mobil";
            btnMotor.Text = "Motor";

            btnSemua.BackColor = Color.FromArgb(92, 184, 92);
            btnSemua.ForeColor = Color.White;
            btnMobil.BackColor = btnMotor.BackColor = Color.FromArgb(248, 244, 238);
            btnMobil.ForeColor = btnMotor.ForeColor = Color.FromArgb(35, 35, 35);

            btnSemua.FlatStyle = btnMobil.FlatStyle = btnMotor.FlatStyle = FlatStyle.Flat;
            btnSemua.FlatAppearance.BorderSize = btnMobil.FlatAppearance.BorderSize = btnMotor.FlatAppearance.BorderSize = 0;

            // --- Button Tambah ---
            btnTambah.Text = "+ Tambah Kendaraan";
            btnTambah.BackColor = Color.FromArgb(92, 184, 92);
            btnTambah.ForeColor = Color.White;
            btnTambah.FlatStyle = FlatStyle.Flat;
            btnTambah.FlatAppearance.BorderSize = 0;

            // --- FlowLayoutPanel ---
            if (flowKendaraan != null)
            {
                flowKendaraan.AutoScroll = true;
                flowKendaraan.FlowDirection = FlowDirection.LeftToRight;
                flowKendaraan.WrapContents = true;
            }
        }

        private void RefreshDataDariDatabase()
        {
            ApplyFilterDanPencarian();
        }

        private void ApplyFilterDanPencarian()
        {
            string keyword = txtSearch.Text.Trim();
            List<Kendaraan> dataTerfilter = _controller.GetKendaraanTerfilter(_filterAktif, keyword);
            RenderVehicleCards(dataTerfilter);
        }

        private void RenderVehicleCards(List<Kendaraan> dataKendaraan)
        {
            flowKendaraan.Controls.Clear();
            if (dataKendaraan == null) return;

            flowKendaraan.HorizontalScroll.Maximum = 0;
            flowKendaraan.AutoScroll = false;
            flowKendaraan.VerticalScroll.Visible = true;
            flowKendaraan.AutoScroll = true;

            foreach (var vh in dataKendaraan)
            {
                var card = CreateVehicleCard(vh);
                flowKendaraan.Controls.Add(card);
            }
        }

        private RoundedPanel CreateVehicleCard(Kendaraan vh)
        {
            RoundedPanel card = new RoundedPanel
            {
                Size = new Size(270, 170),
                BackColor = Color.White,
                BorderRadius = 15,
                Margin = new Padding(6)
            };

            Label lblNama = new Label { Text = vh.NamaKendaraan, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.FromArgb(45, 45, 45), Location = new Point(15, 15), AutoSize = true };
            string tipeTeks = vh.TipeKendaraan == KendaraanTipe.mobil ? "Mobil" : "Motor";
            Label lblInfo = new Label { Text = $"{tipeTeks} • Rp {vh.HargaSewa:N0}/hari", Font = new Font("Segoe UI", 9F), ForeColor = Color.Gray, Location = new Point(15, 45), AutoSize = true };
            Label lblPlat = new Label { Text = $"Plat : {vh.NomorPlatKendaraan}", Font = new Font("Segoe UI", 9F), ForeColor = Color.DimGray, Location = new Point(15, 70), AutoSize = true };
            Label lblStok = new Label { Text = $"Stok : {vh.StokKendaraan}", Font = new Font("Segoe UI", 9F), ForeColor = Color.DimGray, Location = new Point(15, 92), AutoSize = true };

            string statusDb = vh.StatusKendaraan.ToString().Replace("_", " ");
            GetStatusColors(statusDb.ToLower(), out Color bgStatus, out Color fgStatus);

            Label lblStatus = new Label
            {
                Text = statusDb,
                Size = new Size(110, 25),
                Location = new Point(15, 125),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                BackColor = bgStatus,
                ForeColor = fgStatus
            };

            Button btnKelola = new Button
            {
                Text = "Kelola ⚙",
                Size = new Size(95, 30),
                Location = new Point(155, 120),
                BackColor = Color.FromArgb(245, 245, 245),
                FlatStyle = FlatStyle.Flat
            };
            btnKelola.FlatAppearance.BorderSize = 0;

            btnKelola.Click += (s, e) =>
            {
                using (var frm = new FrmDetailKendaraan(_controller, vh))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        RefreshDataDariDatabase();
                    }
                }
            };

            card.Controls.AddRange(new Control[] { lblNama, lblInfo, lblPlat, lblStok, lblStatus, btnKelola });
            return card;
        }

        private void GetStatusColors(string status, out Color bg, out Color fg)
        {
            switch (status)
            {
                case "disewa":
                    bg = Color.FromArgb(255, 244, 229); fg = Color.FromArgb(255, 152, 0); break;
                case "rusak":
                    bg = Color.FromArgb(255, 235, 238); fg = Color.FromArgb(244, 67, 54); break;
                case "dalam perbaikan":
                    bg = Color.FromArgb(227, 242, 253); fg = Color.FromArgb(30, 136, 229); break;
                default: // tersedia
                    bg = Color.FromArgb(232, 245, 233); fg = Color.FromArgb(67, 160, 71); break;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) => ApplyFilterDanPencarian();

        private void FilterButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btnSemua.BackColor = btnMobil.BackColor = btnMotor.BackColor = Color.FromArgb(248, 244, 238);
            btnSemua.ForeColor = btnMobil.ForeColor = btnMotor.ForeColor = Color.FromArgb(35, 35, 35);

            btn.BackColor = Color.FromArgb(92, 184, 92);
            btn.ForeColor = Color.White;

            _filterAktif = btn.Text; 
            ApplyFilterDanPencarian();
        }

        private void BtnTambah_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmDetailKendaraan(_controller, null))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshDataDariDatabase();
                }
            }
        }

        private void flowKendaraan_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtSearch_Load(object sender, EventArgs e)
        {
        }
    }
}
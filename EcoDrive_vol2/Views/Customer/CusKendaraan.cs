using EcoDrive_vol2.Controllers.Customer;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Vehicles;
using EcoDrive_vol2.Service;
using EcoDrive_vol2.Services;
using EcoDriveUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class CusKendaraan : Form
    {
        // composisi
        private readonly CusKendaraanController kendaraanController = new CusKendaraanController();
        private readonly CusRentalController _cusRentalController = new CusRentalController();

        // agregasi
        private List<Kendaraan> _masterListKendaraan = new List<Kendaraan>();
        private List<Kendaraan> _filteredListKendaraan = new List<Kendaraan>();
        private string _kategoriAktif = "Semua";

        public CusKendaraan()
        {
            InitializeComponent();
            SetupSearchBoxEffects();

            LoadDataProduk();
            ApplyFilterDanPencarian();
        }

        private void CusKendaraan_Load(object sender, EventArgs e) { }

        private void SetupSearchBoxEffects()
        {
            if (txtSearch == null) return;
            txtSearch.Enter += (s, e) => { txtSearch.BackColor = Color.FromArgb(238, 238, 233); };
            txtSearch.Leave += (s, e) => { txtSearch.BackColor = Color.FromArgb(245, 245, 240); };
        }

        private void LoadDataProduk()
        {
            try
            {
                _masterListKendaraan.Clear();
                _masterListKendaraan = kendaraanController.GetAvailableKendaraan();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data: {ex.Message}", "Error Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilterDanPencarian()
        {
            string kataKunci = txtSearch != null ? txtSearch.Text : "";
            _filteredListKendaraan = kendaraanController.GetAvailableKendaraan(_kategoriAktif, kataKunci);
            RenderKendaraanCards();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) => ApplyFilterDanPencarian();
        private void BtnSemua_Click(object sender, EventArgs e) => UbahFilterKategori("Semua", btnSemua);
        private void BtnMobil_Click(object sender, EventArgs e) => UbahFilterKategori("Mobil", btnMobil);
        private void BtnMotor_Click(object sender, EventArgs e) => UbahFilterKategori("Motor", btnMotor);

        private void UbahFilterKategori(string kategori, Button btnAktif)
        {
            _kategoriAktif = kategori;
            Button[] semuaTombol = { btnSemua, btnMobil, btnMotor };
            foreach (var btn in semuaTombol)
            {
                if (btn == null) continue;
                bool isTarget = (btn == btnAktif);
                btn.BackColor = isTarget ? Color.FromArgb(76, 175, 80) : Color.White;
                btn.ForeColor = isTarget ? Color.White : Color.FromArgb(45, 45, 45);
            }
            ApplyFilterDanPencarian();
        }

        private void RenderKendaraanCards()
        {
            flowLayoutPanel1.Controls.Clear();
            if (_filteredListKendaraan.Count == 0)
            {
                flowLayoutPanel1.Controls.Add(CreateEmptyStateLabel());
                return;
            }
            foreach (Kendaraan kendaraan in _filteredListKendaraan)
            {
                flowLayoutPanel1.Controls.Add(CreateKendaraanCard(kendaraan));
            }
        }

        private Panel CreateKendaraanCard(Kendaraan kendaraan)
        {
            RoundedPanel card = new RoundedPanel 
            { 
                Size = new Size(270, 170), 
                BackColor = Color.White, 
                BorderRadius = 15, 
                Margin = new Padding(6) 
            };
            Label lblNama = new Label 
            { 
                Text = kendaraan.NamaKendaraan, 
                Font = new Font("Segoe UI", 11F, FontStyle.Bold), 
                ForeColor = Color.FromArgb(45, 45, 45), 
                Location = new Point(15, 15), 
                AutoSize = true 
            };

            string tipeTeks = _cusRentalController.DapatkanTipeTeks(kendaraan);
            Label lblInfo = new Label 
            { 
                Text = $"{tipeTeks} • Rp {kendaraan.HargaSewa:N0}/hari", 
                Font = new Font("Segoe UI", 9F), 
                ForeColor = Color.Gray, 
                Location = new Point(15, 45), 
                AutoSize = true 
            };
            Label lblPlat = new Label 
            { 
                Text = $"Plat : {kendaraan.NomorPlatKendaraan}", 
                Font = new Font("Segoe UI", 9F), 
                ForeColor = Color.DimGray, 
                Location = new Point(15, 70), 
                AutoSize = true 
            };
            Label lblStok = new Label 
            { 
                Text = $"Stok : {kendaraan.StokKendaraan}", 
                Font = new Font("Segoe UI", 9F), 
                ForeColor = Color.DimGray, 
                Location = new Point(15, 92), 
                AutoSize = true 
            };

            var statusVisual = _cusRentalController.DapatkanVisualStatus(kendaraan);
            bool isReady;
            try
            {
                // Reuse controller validation to determine availability without duplicating enum checks
                _cusRentalController.ValidasiKesiapanSewa(kendaraan);
                isReady = true;
            }
            catch
            {
                isReady = false;
            }

            Label lblStatus = new Label 
            { 
                Text = statusVisual.Text, 
                Size = new Size(110, 25), 
                Location = new Point(15, 125), 
                TextAlign = ContentAlignment.MiddleCenter, 
                Font = new Font("Segoe UI", 8F, FontStyle.Bold), 
                BackColor = statusVisual.BgColor, 
                ForeColor = statusVisual.FgColor
            };
            Button btnSewa = new Button 
            { 
                Text = isReady ? "Sewa ➔" : "Tidak Tersedia", 
                Size = new Size(110, 30), 
                Location = new Point(145, 120), 
                BackColor = isReady ? Color.FromArgb(76, 175, 80) : Color.FromArgb(240, 240, 240), 
                ForeColor = isReady ? Color.White : Color.Gray, 
                FlatStyle = FlatStyle.Flat, 
                Cursor = isReady ? Cursors.Hand : Cursors.No, 
                Enabled = isReady, 
                Font = new Font("Segoe UI", 9F, FontStyle.Bold), 
                Tag = kendaraan 
            };
            btnSewa.FlatAppearance.BorderSize = 0;
            btnSewa.Click += BtnSewa_Click;

            card.Controls.AddRange(new Control[] { lblNama, lblInfo, lblPlat, lblStok, lblStatus, btnSewa });
            return card;
        }

        private Label CreateEmptyStateLabel() => new Label 
        { 
            Text = "Tidak ada kendaraan listrik yang cocok.", 
            Font = new Font("Segoe UI", 10, FontStyle.Italic), 
            ForeColor = Color.DarkGray, AutoSize = true, 
            Margin = new Padding(30, 20, 0, 0) 
        };

        private void BtnSewa_Click(object sender, EventArgs e)
        {
            if (sender is Button btnTarget && btnTarget.Tag is Kendaraan dataKendaraan)
            {
                try
                {
                    _cusRentalController.ValidasiKesiapanSewa(dataKendaraan);
                    TampilkanPopUpDetail(dataKendaraan);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Tidak Tersedia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal memproses permintaan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TampilkanPopUpDetail(Kendaraan dataKendaraan)
        {
            Form detailForm = new Form { Text = "Informasi Detail Spesifikasi", Size = new Size(460, 560), StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false, MinimizeBox = false, BackColor = Color.FromArgb(250, 248, 242) };
            Panel innerCard = new Panel { Size = new Size(400, 460), Location = new Point(22, 25), BackColor = Color.White, Padding = new Padding(20) };

            string tipeTeks = _cusRentalController.DapatkanTipeTeks(dataKendaraan);
            Label lblPopTitle = new Label { Text = dataKendaraan.NamaKendaraan, Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = Color.FromArgb(45, 45, 45), Dock = DockStyle.Top, Height = 35 };
            Label lblPopSub = new Label { Text = $"Kategori Kendaraan Listrik: {tipeTeks}", Font = new Font("Segoe UI", 9.5F, FontStyle.Italic), ForeColor = Color.Gray, Dock = DockStyle.Top, Height = 25 };
            Panel lineSeparator = new Panel { BackColor = Color.FromArgb(235, 230, 220), Dock = DockStyle.Top, Height = 2, Margin = new Padding(0, 5, 0, 15) };

            Label lblGridSpesifikasi = new Label { Text = $" Nomor Registrasi Plat  :  {dataKendaraan.NomorPlatKendaraan}\n\n Kapasitas Unit Ready   :  {dataKendaraan.StokKendaraan} Unit\n\n Tarif Dasar Sewa       :  Rp {dataKendaraan.HargaSewa:N0} / Hari\n\n", Font = new Font("Segoe UI", 10.5F), ForeColor = Color.FromArgb(60, 60, 60), Location = new Point(20, 85), Size = new Size(360, 110) };
            Label lblDurasiSewa = new Label { Text = "Durasi Sewa (Hari):", Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(20, 210), AutoSize = true };
            NumericUpDown numDurasi = new NumericUpDown { Location = new Point(170, 207), Size = new Size(70, 25), Font = new Font("Segoe UI", 10F), Minimum = 1, Maximum = 30, Value = 1 };
            Label lblInfoTanggal = new Label { Text = "Tanggal Sewa   : -\nTanggal Kembali: -", Font = new Font("Segoe UI", 9.5F, FontStyle.Italic), ForeColor = Color.DimGray, Location = new Point(20, 255), Size = new Size(360, 40) };
            Label lblTotalEstimasi = new Label { Text = "Total Estimasi: Rp 0", Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.FromArgb(46, 139, 87), Location = new Point(20, 315), AutoSize = true };
            Button btnBooking = new Button { Text = "Konfirmasi & Bayar Sekarang", Font = new Font("Segoe UI", 10.5F, FontStyle.Bold), BackColor = Color.FromArgb(76, 175, 80), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Size = new Size(360, 48), Location = new Point(20, 360), Cursor = Cursors.Hand };
            btnBooking.FlatAppearance.BorderSize = 0;

            decimal totalBiayaFix = 0;

            void UpdateEstimasiBiaya()
            {
                int durasiInput = (int)numDurasi.Value;
                
                try
                {
                    totalBiayaFix = _cusRentalController.DapatkanEstimasiBiaya(dataKendaraan.IdKendaraan, durasiInput);
                    lblTotalEstimasi.Text = $"Total Estimasi: Rp {totalBiayaFix:N0}";

                    DateTime tanggalSewa = DateTime.Now;
                    DateTime tanggalKembali = tanggalSewa.AddDays(durasiInput);
                    lblInfoTanggal.Text = $"Tanggal Sewa   : {tanggalSewa:dd MMMM yyyy}\nTanggal Kembali: {tanggalKembali:dd MMMM yyyy}";
                }
                catch (Exception ex)
                {
                    lblTotalEstimasi.Text = "Error Estimasi";
                    MessageBox.Show(ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            numDurasi.ValueChanged += (s, ev) => UpdateEstimasiBiaya();
            UpdateEstimasiBiaya();

            btnBooking.Click += (s, ev) =>
            {
                try
                {
                    // Build TransaksiSewa object and pass the whole object to controller
                    var sewaBaru = new EcoDrive_vol2.Models.Transaksi.TransaksiSewa(
                        UserSession.IdUserAktif,
                        dataKendaraan.IdKendaraan,
                        (int)numDurasi.Value,
                        dataKendaraan.HargaSewa
                    );

                    _cusRentalController.KonfirmasiSewa(sewaBaru);

                    detailForm.Close();
                    MessageBox.Show($"Pembayaran Berhasil!\n\nSaldo Anda telah dipotong sebesar Rp {totalBiayaFix:N0}.\nKendaraan {dataKendaraan.NamaKendaraan} siap digunakan.", "Transaksi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadDataProduk();
                    ApplyFilterDanPencarian();
                }
                catch (Exception ex)
                {
                    HandleTransaksiError(ex, detailForm);
                }
            };

            innerCard.Controls.Add(lblPopTitle); innerCard.Controls.Add(lblPopSub); innerCard.Controls.Add(lineSeparator);
            innerCard.Controls.AddRange(new Control[] { lblGridSpesifikasi, lblDurasiSewa, numDurasi, lblInfoTanggal, lblTotalEstimasi, btnBooking });
            detailForm.Controls.Add(innerCard);
            detailForm.ShowDialog();
        }

        private void HandleTransaksiError(Exception ex, Form detailForm)
        {
            _cusRentalController.ProsesErrorTransaksi(ex,
                aksiTopUp: () =>
                {
                    DialogResult response = MessageBox.Show(
                        "Saldo Anda tidak mencukupi.\nApakah Anda ingin mengisi saldo (Top Up) sekarang?",
                        "Saldo Tidak Cukup",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
                    if (response == DialogResult.Yes)
                    {
                        if (detailForm != null) detailForm.Close();
                        if (Application.OpenForms["CusDasboard"] is CusDasboard dashboard)
                        {
                            dashboard.BukaHalamanSaldo();
                        }
                    }
                },
                aksiTampilkanPesan: (pesanDariController) =>
                {
                    MessageBox.Show(pesanDariController, "Informasi Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            );
        }
        
    }
}
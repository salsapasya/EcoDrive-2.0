using System;
using System.Drawing;
using System.Windows.Forms;
using EcoDrive_vol2.Controllers.Customer; // Hubungkan ke Controller
using EcoDrive_vol2.Views;
using EcoDrive_vol2.Views.Customer;

namespace EcoDrive_vol2
{
    public partial class CusDasboard : Form
    {
        private Form activeForm = null;
        private readonly Color bgUtama = Color.FromArgb(255, 253, 246);
        private readonly string _namaCustomer;

        // Deklarasi Controller Dashboard
        private readonly CusDashboardController _controller;

        public CusDasboard(string namaLogin)
        {
            _namaCustomer = namaLogin;
            _controller = new CusDashboardController(); // Inisialisasi

            InitializeComponent();
            RegisterNavigationEvents();
            TampilkanDashboardUtama();
        }

        private void CusDasboard_Load(object sender, EventArgs e) { }

        private void RegisterNavigationEvents()
        {
            btDasboard.Click += btDasboard_Click;
            btKendaraan.Click += btKendaraan_Click;
            btCharging.Click += btCharging_Click;
            btRiwayat.Click += btRiwayat_Click;
            btSaldo.Click += btSaldo_Click;
            btKembalikanSewa.Click += btKembalikanSewa_Click_1;
        }

        public void BukaHalamanSaldo() => btSaldo_Click(btSaldo, EventArgs.Empty);
        public void BukaHalamanKendaraan() => btKendaraan_Click(btKendaraan, EventArgs.Empty);

        private void OpenForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnContentCustomer.Controls.Clear();
            pnContentCustomer.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void ResetButtonColors()
        {
            Color warnaDefault = Color.White;
            btDasboard.BackColor = warnaDefault;
            btKendaraan.BackColor = warnaDefault;
            btCharging.BackColor = warnaDefault;
            btRiwayat.BackColor = warnaDefault;
            btSaldo.BackColor = warnaDefault;
            btKembalikanSewa.BackColor = warnaDefault;
        }

        private void SetActiveButton(Button btn)
        {
            ResetButtonColors();
            btn.BackColor = Color.FromArgb(191, 219, 120);
        }

        private void TampilkanDashboardUtama()
        {
            SetActiveButton(btDasboard);
            if (activeForm != null) { activeForm.Close(); activeForm = null; }

            pnContentCustomer.Controls.Clear();
            pnContentCustomer.BackColor = bgUtama;

            // 1. Header
            Label lblWelcome = new Label { Text = $"Selamat Datang, {_namaCustomer}!", Font = new Font("Segoe UI", 20, FontStyle.Bold), ForeColor = Color.FromArgb(45, 45, 45), Location = new Point(25, 20), AutoSize = true };
            Label lblSubtitle = new Label { Text = "Pantau performa berkendara hijau Anda hari ini di EcoDrive.", Font = new Font("Segoe UI", 10), ForeColor = Color.Gray, Location = new Point(28, 62), AutoSize = true };

            // 2. KARTU SALDO
            Panel pnlWallet = new Panel { Size = new Size(700, 140), Location = new Point(30, 110), BackColor = Color.FromArgb(44, 62, 80), Padding = new Padding(20) };
            Label lblWalletTitle = new Label { Text = "SALDO ECO-WALLET", Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.LightGray, Location = new Point(20, 25), AutoSize = true };

            // Mengambil saldo lewat controller
            decimal saldoUser = _controller.GetSaldo();
            Label lblSaldoValue = new Label { Text = $"Rp {saldoUser:N0}", Font = new Font("Segoe UI", 26, FontStyle.Bold), ForeColor = Color.White, Location = new Point(16, 55), AutoSize = true };

            Button btnQuickTopUp = new Button { Text = "Isi Saldo", Font = new Font("Segoe UI", 9F, FontStyle.Bold), BackColor = Color.FromArgb(76, 175, 80), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Size = new Size(100, 32), Location = new Point(570, 20), Cursor = Cursors.Hand };
            btnQuickTopUp.FlatAppearance.BorderSize = 0;
            btnQuickTopUp.Click += (s, ev) => btSaldo_Click(btSaldo, EventArgs.Empty);
            pnlWallet.Controls.AddRange(new Control[] { btnQuickTopUp, lblSaldoValue, lblWalletTitle });

            // 3. KARTU STATUS RENTAL AKTIF (BERSIH & AMAN)
            Panel pnlActiveRental = new Panel { Size = new Size(340, 160), Location = new Point(30, 275), BackColor = Color.White, Padding = new Padding(20) };
            Label lblRentalTitle = new Label { Text = "STATUS RENTAL AKTIF", Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), ForeColor = Color.Gray, Location = new Point(20, 20), AutoSize = true };

            Label lblVehicleName;
            Label lblTimeLeft;

            // Mengambil data rental melalui controller
            var rental = _controller.GetRentalStatus();

            if (rental.IsActive)
            {
                lblVehicleName = new Label { Text = rental.KendaraanInfo, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.FromArgb(50, 50, 50), Location = new Point(18, 50), Size = new Size(300, 50) };
                lblTimeLeft = new Label { Text = rental.TeksSisaWaktu, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), ForeColor = rental.SisaHari >= 0 ? Color.FromArgb(76, 175, 80) : Color.Red, Location = new Point(20, 115), AutoSize = true };
            }
            else
            {
                lblVehicleName = new Label { Text = "Tidak Ada Rental Aktif", Font = new Font("Segoe UI", 12, FontStyle.Italic), ForeColor = Color.Silver, Location = new Point(18, 55), AutoSize = true };
                lblTimeLeft = new Label { Text = "Silakan pilih unit di menu kendaraan.", Font = new Font("Segoe UI", 9, FontStyle.Regular), ForeColor = Color.Gray, Location = new Point(20, 115), AutoSize = true };
            }
            pnlActiveRental.Controls.AddRange(new Control[] { lblTimeLeft, lblVehicleName, lblRentalTitle });

            // 4. KARTU RINGKASAN AKTIVITAS
            Panel pnlQuickStats = new Panel { Size = new Size(340, 160), Location = new Point(390, 275), BackColor = Color.White, Padding = new Padding(20) };

            // Mengambil total sewa lewat controller
            int totalSewa = _controller.GetTotalSewa();

            Label lblStatsTitle = new Label { Text = "RINGKASAN AKTIVITAS", Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), ForeColor = Color.Gray, Location = new Point(20, 20), AutoSize = true };
            Label lblTotalRentals = new Label { Text = $"• Total Riwayat Sewa : {totalSewa} Kali", Font = new Font("Segoe UI", 10), ForeColor = Color.FromArgb(70, 70, 70), Location = new Point(20, 58), AutoSize = true };
            Label lblTotalCharging = new Label { Text = "• Sesi Pengisian Daya  : Terhubung", Font = new Font("Segoe UI", 10), ForeColor = Color.FromArgb(70, 70, 70), Location = new Point(20, 92), AutoSize = true };
            pnlQuickStats.Controls.AddRange(new Control[] { lblTotalCharging, lblTotalRentals, lblStatsTitle });

            pnContentCustomer.Controls.AddRange(new Control[] { lblWelcome, lblSubtitle, pnlWallet, pnlActiveRental, pnlQuickStats });
        }

        private void btDasboard_Click(object sender, EventArgs e) => TampilkanDashboardUtama();
        private void btKendaraan_Click(object sender, EventArgs e) { SetActiveButton(btKendaraan); OpenForm(new CusKendaraan()); }
        private void btCharging_Click(object sender, EventArgs e) { SetActiveButton(btCharging); OpenForm(new CusCharging()); }
        private void btRiwayat_Click(object sender, EventArgs e) { SetActiveButton(btRiwayat); OpenForm(new CusRiwayat()); }
        private void btSaldo_Click(object sender, EventArgs e) { SetActiveButton(btSaldo); OpenForm(new CusSaldo()); }
        private void btKembalikanSewa_Click_1(object sender, EventArgs e) { SetActiveButton(btKembalikanSewa); OpenForm(new CusKembalikanSewa()); }

        private void btLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new FormLogin().Show();
                this.Close();
            }
        }
    }
}
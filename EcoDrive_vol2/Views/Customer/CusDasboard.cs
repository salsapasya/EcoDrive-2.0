using System;
using System.Drawing;
using System.Windows.Forms;
using EcoDrive_vol2.Views;
using EcoDrive_vol2.Views.Customer;

namespace EcoDrive_vol2
{
    public partial class CusDasboard : Form
    {
        private Form activeForm = null;
        private readonly Color bgUtama = Color.FromArgb(255, 253, 246);

        private readonly string _namaCustomer;

        public CusDasboard(string namaLogin)
        {
            _namaCustomer = namaLogin;
            InitializeComponent();
            RegisterNavigationEvents();

            TampilkanDashboardUtama();
        }

        private void CusDasboard_Load(object sender, EventArgs e)
        {
        }

        private void RegisterNavigationEvents()
        {
            btDasboard.Click += btDasboard_Click;
            btKendaraan.Click += btKendaraan_Click;
            btCharging.Click += btCharging_Click;
            btRiwayat.Click += btRiwayat_Click;
            btSaldo.Click += btSaldo_Click;
            btKembalikanSewa.Click += btKembalikanSewa_Click_1;
        }

        public void BukaHalamanSaldo()
        {
            btSaldo_Click(btSaldo, EventArgs.Empty);
        }

        public void BukaHalamanKendaraan()
        {
            btKendaraan_Click(btKendaraan, EventArgs.Empty);
        }
        private void OpenForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnContentCustomer.Controls.Clear();
            pnContentCustomer.Controls.Add(childForm);
            pnContentCustomer.Tag = childForm;

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

            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            pnContentCustomer.Controls.Clear();
            pnContentCustomer.BackColor = bgUtama;

            // 1. Label Judul & Subtitle
            Label lblWelcome = new Label
            {
                Text = $"Selamat Datang, {_namaCustomer}!",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 45),
                Location = new Point(25, 20),
                AutoSize = true
            };

            Label lblSubtitle = new Label
            {
                Text = "Pantau performa berkendara hijau Anda hari ini di EcoDrive.",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(28, 62),
                AutoSize = true
            };

            // 2. KARTU SALDO (ECO-WALLET)
            Panel pnlWallet = new Panel
            {
                Size = new Size(340, 140),
                Location = new Point(30, 110),
                BackColor = Color.FromArgb(44, 62, 80),
                Padding = new Padding(20)
            };

            Label lblWalletTitle = new Label { Text = "SALDO ECO-WALLET", Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), ForeColor = Color.LightGray, Location = new Point(20, 20), AutoSize = true };
            Label lblSaldoValue = new Label { Text = "Rp 750,000", Font = new Font("Segoe UI", 22, FontStyle.Bold), ForeColor = Color.White, Location = new Point(16, 50), AutoSize = true };

            Button btnQuickTopUp = new Button
            {
                Text = "Isi Saldo",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(85, 28),
                Location = new Point(235, 16),
                Cursor = Cursors.Hand
            };
            btnQuickTopUp.FlatAppearance.BorderSize = 0;
            btnQuickTopUp.Click += (s, ev) => btSaldo_Click(this, EventArgs.Empty); // Alihkan langsung ke halaman saldo asli jika diklik

            pnlWallet.Controls.AddRange(new Control[] { btnQuickTopUp, lblSaldoValue, lblWalletTitle });

            // 3. KARTU ECO-POINTS (GAMIFICATION)
            Panel pnlEcoPoints = new Panel
            {
                Size = new Size(340, 140),
                Location = new Point(390, 110),
                BackColor = Color.FromArgb(230, 245, 233),
                Padding = new Padding(20)
            };

            Label lblEcoTitle = new Label { Text = "TOTAL ECO-POINTS", Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), ForeColor = Color.FromArgb(46, 125, 50), Location = new Point(20, 20), AutoSize = true };
            Label lblPointsValue = new Label { Text = "1,420 Pts", Font = new Font("Segoe UI", 22, FontStyle.Bold), ForeColor = Color.FromArgb(46, 125, 50), Location = new Point(16, 50), AutoSize = true };
            Label lblCarbonSaved = new Label { Text = "Anda menghemat ± 45.2 Kg CO₂", Font = new Font("Segoe UI", 8.5F, FontStyle.Italic), ForeColor = Color.Gray, Location = new Point(20, 105), AutoSize = true };

            pnlEcoPoints.Controls.AddRange(new Control[] { lblCarbonSaved, lblPointsValue, lblEcoTitle });

            // 4. KARTU STATUS RENTAL AKTIF
            Panel pnlActiveRental = new Panel
            {
                Size = new Size(340, 150),
                Location = new Point(30, 275),
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            Label lblRentalTitle = new Label { Text = "STATUS RENTAL AKTIF", Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), ForeColor = Color.Gray, Location = new Point(20, 20), AutoSize = true };
            Label lblVehicleName = new Label { Text = "Hyundai Ioniq 5 (B 9999 EV)", Font = new Font("Segoe UI", 13, FontStyle.Bold), ForeColor = Color.FromArgb(50, 50, 50), Location = new Point(18, 55), AutoSize = true };
            Label lblTimeLeft = new Label { Text = "Sisa Waktu Sewa: 04 Jam 15 Menit", Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), ForeColor = Color.FromArgb(231, 76, 60), Location = new Point(20, 105), AutoSize = true };

            pnlActiveRental.Controls.AddRange(new Control[] { lblTimeLeft, lblVehicleName, lblRentalTitle });

            // 5. KARTU RINGKASAN AKTIVITAS CEPAT
            Panel pnlQuickStats = new Panel
            {
                Size = new Size(340, 150),
                Location = new Point(390, 275),
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            Label lblStatsTitle = new Label { Text = "RINGKASAN AKTIVITAS", Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), ForeColor = Color.Gray, Location = new Point(20, 20), AutoSize = true };
            Label lblTotalRentals = new Label { Text = "• Total Transaksi Sewa : 12 Kali", Font = new Font("Segoe UI", 10), ForeColor = Color.FromArgb(70, 70, 70), Location = new Point(20, 58), AutoSize = true };
            Label lblTotalCharging = new Label { Text = "• Sesi Pengisian Daya  : 5 Kali", Font = new Font("Segoe UI", 10), ForeColor = Color.FromArgb(70, 70, 70), Location = new Point(20, 92), AutoSize = true };

            pnlQuickStats.Controls.AddRange(new Control[] { lblTotalCharging, lblTotalRentals, lblStatsTitle });

            // Masukkan seluruh komponen ke dalam panel konten utama dashboard
            pnContentCustomer.Controls.AddRange(new Control[] { lblWelcome, lblSubtitle, pnlWallet, pnlEcoPoints, pnlActiveRental, pnlQuickStats });
        }

        private void btDasboard_Click(object sender, EventArgs e)
        {
            TampilkanDashboardUtama();
        }

        private void btKendaraan_Click(object sender, EventArgs e)
        {
            SetActiveButton(btKendaraan);
            OpenForm(new CusKendaraan());
        }

        private void btCharging_Click(object sender, EventArgs e)
        {
            SetActiveButton(btCharging);
            OpenForm(new CusCharging());
        }

        private void btRiwayat_Click(object sender, EventArgs e)
        {
            SetActiveButton(btRiwayat);
            OpenForm(new CusRiwayat());
        }

        private void btSaldo_Click(object sender, EventArgs e)
        {
            SetActiveButton(btSaldo);
            OpenForm(new CusSaldo());
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin logout dari aplikasi EcoDrive?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FormLogin login = new FormLogin();
                login.Show();
                this.Close();
            }
        }

        private void btKembalikanSewa_Click_1(object sender, EventArgs e)
        {
            SetActiveButton(btKembalikanSewa);
            OpenForm(new CusKembalikanSewa());
        }
    }
}
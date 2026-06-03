using EcoDrive_vol2.Context;
using EcoDrive_vol2.Controllers.Customer;
using EcoDrive_vol2.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views.Admin
{
    public partial class AdTopUpCustomer : Form
    {
        private Color bgUtama = Color.FromArgb(255, 253, 246);
        private readonly CusSaldoController _saldoController = new CusSaldoController();

        // Memanggil UserContext untuk summary card atas
        private readonly UserContext _userContext = new UserContext();

        private int _idUserTarget = 0;
        private int _idTopupDipilih = 0;
        private decimal _nominalTopupDipilih = 0;
        private string _currentFilter = "";

        // Kultur Indonesia untuk format mata uang Rupiah yang konsisten
        private readonly CultureInfo _idCulture = new CultureInfo("id-ID");

        public AdTopUpCustomer()
        {
            InitializeComponent();
            this.BackColor = bgUtama;

            // Registrasi event
            this.Load += AdTopUpCustomer_Load;
            dgvTransaksi.CellClick += dgvTransaksi_CellClick;

            btnSemua.Click += (s, e) => { _currentFilter = ""; LoadDataTransaksi(); };
            btnPending.Click += (s, e) => { _currentFilter = "pending"; LoadDataTransaksi(); };
            btnBerhasil.Click += (s, e) => { _currentFilter = "berhasil"; LoadDataTransaksi(); };
            btnGagal.Click += (s, e) => { _currentFilter = "gagal"; LoadDataTransaksi(); };
        }

        private void AdTopUpCustomer_Load(object sender, EventArgs e)
        {
            LoadDataTransaksi();
            ResetFormTampilan();
        }

        private void LoadDataTransaksi()
        {
            try
            {
                // 1. Ambil data transaksi menggunakan filter yang aktif dari Controller
                DataTable dt = _saldoController.GetDaftarTransaksiTopUp(_currentFilter);

                if (dt == null) return;

                dgvTransaksi.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    decimal nominal = row["jumlah_topup"] != DBNull.Value ? Convert.ToDecimal(row["jumlah_topup"]) : 0;

                    dgvTransaksi.Rows.Add(
                        row["id_transaksi"].ToString(),
                        row["username"].ToString(),
                        row["nama"].ToString(),
                        row["kontak"].ToString(),
                        nominal.ToString("N0", _idCulture),
                        row["status"].ToString().ToUpper()
                    );
                }

                // 2. LOGIKA BARU: Ambil total summary untuk diletakkan di Card Atas
                UpdateDashboardSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat data top up.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDashboardSummary()
        {
            try
            {
                var summary = _userContext.GetTopUpSummary();

                lblCardTitle1.Text = "Total Top Up Sukses";
                lblCardValue1.Text = summary["TotalNominal"];
                lblCardValue2.Text = summary["Pending"];
                lblCardValue3.Text = summary["Sukses"];
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Gagal update card summary: " + ex.Message);
            }
        }

        private void dgvTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvTransaksi.Rows[e.RowIndex];

                if (row.Cells["colIdTransaksi"].Value == null || row.Cells["colIdTransaksi"].Value == DBNull.Value)
                    return;

                _idTopupDipilih = Convert.ToInt32(row.Cells["colIdTransaksi"].Value);
                string username = row.Cells["colUsername"].Value?.ToString() ?? "";
                string nominalText = row.Cells["colJumlahTopup"].Value?.ToString() ?? "0";
                string status = row.Cells["colStatus"].Value?.ToString() ?? "";

                if (decimal.TryParse(nominalText, NumberStyles.Number, _idCulture, out decimal hasilParsing))
                {
                    _nominalTopupDipilih = hasilParsing;
                }
                else
                {
                    _nominalTopupDipilih = 0;
                }

                txtUsernameCari.Text = username;
                ProsesCariCustomer(username);

                // ====================================================================
                // LOGIKA UTAMA: VALIDASI STATUS UNTUK MENGUNCI TOMBOL AKSI
                // ====================================================================
                if (status == "BERHASIL" || status == "GAGAL")
                {
                    btnKonfirmasiTopUp.Enabled = false;
                    btnKonfirmasiTopUp.BackColor = Color.DarkGray; // Berubah warna menjadi abu-abu tanda terkunci
                    btnKonfirmasiTopUp.Text = $"✔ {status} (DIKUNCI)";
                }
                else
                {
                    btnKonfirmasiTopUp.Enabled = true;
                    btnKonfirmasiTopUp.BackColor = Color.FromArgb(46, 125, 50); // Kembalikan ke warna hijau EcoDrive
                    btnKonfirmasiTopUp.Text = "✔ SETUJUI TOP UP";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal membaca data transaksi.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProsesCariCustomer(string usernameInput)
        {
            try
            {
                _idUserTarget = _saldoController.GetIdUserByUsername(usernameInput);

                if (_idUserTarget <= 0)
                {
                    MessageBox.Show("Customer dengan username tersebut tidak ditemukan!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFormTampilan();
                    return;
                }

                decimal saldoSekarang = _saldoController.GetSaldo(_idUserTarget);

                lblNamaCustomer.Text = usernameInput;
                lblSaldoAktif.Text = saldoSekarang.ToString("C0", _idCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengambil data customer.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string usernameInput = txtUsernameCari.Text.Trim();

            if (string.IsNullOrEmpty(usernameInput))
            {
                MessageBox.Show("Silakan masukkan username customer terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProsesCariCustomer(usernameInput);
        }

        private void btnKonfirmasiTopUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idTopupDipilih <= 0 || _idUserTarget <= 0)
                {
                    MessageBox.Show("Data transaksi atau customer tidak valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Setujui top up sebesar {_nominalTopupDipilih.ToString("C0", _idCulture)} ke user {lblNamaCustomer.Text}?",
                    "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                // Eksekusi Konfirmasi ke Database melalui Controller
                _saldoController.KonfirmasiTopUp(_idTopupDipilih, _idUserTarget);

                MessageBox.Show("Top up berhasil dikonfirmasi.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetFormTampilan();
                txtUsernameCari.Clear();
                LoadDataTransaksi(); // Refresh tabel & counter summary card secara otomatis
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengonfirmasi top up.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFormTampilan()
        {
            _idUserTarget = 0;
            _idTopupDipilih = 0;
            _nominalTopupDipilih = 0;

            lblNamaCustomer.Text = "-";
            lblSaldoAktif.Text = "Rp 0";

            btnKonfirmasiTopUp.Enabled = false;
            btnKonfirmasiTopUp.BackColor = Color.DarkGray;
            btnKonfirmasiTopUp.Text = "✔ SETUJUI TOP UP";
        }
    }
}
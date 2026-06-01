using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EcoDrive_vol2.Controllers.Customer;

namespace EcoDrive_vol2.Views.Admin
{
    public partial class AdTopUpCustomer : Form
    {
        private Color bgUtama = Color.FromArgb(255, 253, 246);
        private readonly CusSaldoController _saldoController = new CusSaldoController();
        private int _idUserTarget = 0;

        public AdTopUpCustomer()
        {
            InitializeComponent();
            this.BackColor = bgUtama;

            // Registrasi event klik pada tabel & tombol filter
            this.Load += AdTopUpCustomer_Load;
            dgvTransaksi.CellClick += dgvTransaksi_CellClick;

            btnSemua.Click += (s, e) => LoadDataTransaksi("");
            btnPending.Click += (s, e) => LoadDataTransaksi("pending");
            btnBerhasil.Click += (s, e) => LoadDataTransaksi("berhasil");
            btnGagal.Click += (s, e) => LoadDataTransaksi("gagal");
        }

        private void AdTopUpCustomer_Load(object sender, EventArgs e)
        {
            LoadDataTransaksi(); // Ambil data saat form pertama kali dibuka
        }

        // ====================================================================
        // FUNGSI UTAMA: LOAD DATA DARI CONTROLLER (Mencocokkan SQL View Baru)
        // ====================================================================
        private void LoadDataTransaksi(string statusFilter = "")
        {
            try
            {
                // 1. Ambil data dari controller
                DataTable dt = _saldoController.GetDaftarTransaksiTopUp(statusFilter);

                if (dt == null) return;

                // 2. Bersihkan tabel sebelum mengisi data baru
                dgvTransaksi.Rows.Clear();

                // 3. Gunakan foreach untuk looping data dari DataTable ke DataGridView
                foreach (DataRow row in dt.Rows)
                {
                    // Gunakan nama kolom yang sudah sesuai dengan VIEW
                    dgvTransaksi.Rows.Add(
                        row["id_transaksi"].ToString(),       // Sesuai dengan alias 'id_transaksi' di VIEW
                        row["kategori"].ToString(),          // Tambahkan kategori jika perlu
                        row["username"].ToString(),
                        row["nama"].ToString(),
                        row["kontak"].ToString(),
                        row["nama_kendaraan"].ToString(),
                        row["total_biaya"].ToString(),       // Sesuaikan dengan nama kolom di VIEW
                        row["status"].ToString().ToUpper()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Memuat Data : Gagal memproses data di tingkat Controller: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        // EVENT: SAAT BARIS TABEL DIKLIK (Otomatis deteksi data customer)
        // ====================================================================
        private void dgvTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTransaksi.Rows[e.RowIndex];

                // Ambil data username langsung dari baris tabel yang di-klik admin
                string usernameInput = row.Cells["colUsername"].Value.ToString();
                txtUsernameCari.Text = usernameInput;

                ProsesCariCustomer(usernameInput);
            }
        }

        private void ProsesCariCustomer(string usernameInput)
        {
            try
            {
                EcoDrive_vol2.Service.LoginService loginService = new EcoDrive_vol2.Service.LoginService();
                _idUserTarget = loginService.AmbilIdUser(usernameInput);

                if (_idUserTarget > 0)
                {
                    decimal saldoSekarang = _saldoController.GetSaldo(_idUserTarget);
                    lblNamaCustomer.Text = usernameInput;
                    lblSaldoAktif.Text = saldoSekarang.ToString("C0", new System.Globalization.CultureInfo("id-ID"));
                    btnKonfirmasiTopUp.Enabled = true;
                }
                else
                {
                    ResetFormTampilan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        // EVENT 1: TOMBOL CARI CUSTOMER MANUAL
        // ====================================================================
        private void btnCari_Click(object sender, EventArgs e)
        {
            string usernameInput = txtUsernameCari.Text;

            if (string.IsNullOrEmpty(usernameInput))
            {
                MessageBox.Show("Silakan masukkan username customer terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProsesCariCustomer(usernameInput);
        }

        // ====================================================================
        // EVENT 2: TOMBOL KONFIRMASI TOP UP
        // ====================================================================
        private void btnKonfirmasiTopUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idUserTarget <= 0) return;

                if (!decimal.TryParse(txtNominalTopUp.Text, out decimal nominal) || nominal <= 0)
                {
                    MessageBox.Show("Masukkan nominal top up yang valid dan lebih dari Rp 0!", "Input Salah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string usernameInput = txtUsernameCari.Text;

                DialogResult yakin = MessageBox.Show($"Apakah Anda yakin ingin menyetujui Top Up sebesar {nominal.ToString("C0", new System.Globalization.CultureInfo("id-ID"))} ke akun {usernameInput}?",
                    "Konfirmasi Admin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (yakin == DialogResult.Yes)
                {
                    _saldoController.TopupSaldo(_idUserTarget, nominal);

                    MessageBox.Show("Top Up saldo customer berhasil dikonfirmasi!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    decimal saldoTerbaru = _saldoController.GetSaldo(_idUserTarget);

                    lblSaldoAktif.Text = saldoTerbaru.ToString("C0", new System.Globalization.CultureInfo("id-ID"));
                    txtNominalTopUp.Clear();

                    // Refresh data tabel setelah saldo berhasil ditambahkan
                    LoadDataTransaksi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal melakukan proses top up: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFormTampilan()
        {
            _idUserTarget = 0;
            lblNamaCustomer.Text = "-";
            lblSaldoAktif.Text = "Rp 0";
            btnKonfirmasiTopUp.Enabled = false;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }
    }
}
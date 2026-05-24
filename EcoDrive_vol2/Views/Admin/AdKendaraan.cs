using EcoDriveUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EcoDrive_vol2.Controllers.Admin;
using EcoDrive_vol2.Models.Kendaraan; // Hubungkan ke folder Controllers

namespace EcoDrive_vol2.Views
{
    public partial class AdKendaraan : Form
    {
        private AdKendaraanController controller;
        private List<Kendaraan> listMasterKendaraan;

        public AdKendaraan()
        {
            InitializeComponent();

            // Inisialisasi controller asli Anda
            controller = new AdKendaraanController();

            // Setup Event Handlers
            this.Load += AdKendaraan_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnSemua.Click += FilterButton_Click;
            btnMobil.Click += FilterButton_Click;
            btnMotor.Click += FilterButton_Click;
        }

        private void AdKendaraan_Load(object sender, EventArgs e)
        {
            // 1. Atur form agar memenuhi area panel utama dashboard Anda
            this.Dock = DockStyle.Fill;
            if (this.Parent != null)
            {
                this.Size = this.Parent.ClientSize;
            }

            // 2. FORCE STYLE RE-INITIALIZATION (Mengembalikan Warna Tombol Atas yang Memutih)
            // Sesuaikan nama variabel komponen di bawah ini dengan nama di file Designer.cs Anda jika berbeda

            // Kembalikan warna text box pencarian
            if (txtSearch != null)
            {
                txtSearch.BackColor = Color.FromArgb(245, 245, 240); // Abu-abu muda khas search bar
                txtSearch.ForeColor = Color.DimGray;
                txtSearch.Text = "🔍 Cari nama, tipe, ID...";
            }

            // Kembalikan warna Button Filter "Semua" (Default Aktif - Hijau)
            if (btnSemua != null)
            {
                btnSemua.BackColor = Color.FromArgb(92, 184, 92);
                btnSemua.ForeColor = Color.White;
                btnSemua.Text = "Semua";
            }

            // Kembalikan warna Button Filter "Mobil"
            if (btnMobil != null)
            {
                btnMobil.BackColor = Color.FromArgb(248, 244, 238);
                btnMobil.ForeColor = Color.FromArgb(35, 35, 35);
                btnMobil.Text = "Mobil";
            }

            // Kembalikan warna Button Filter "Motor"
            if (btnMotor != null)
            {
                btnMotor.BackColor = Color.FromArgb(248, 244, 238);
                btnMotor.ForeColor = Color.FromArgb(35, 35, 35);
                btnMotor.Text = "Motor";
            }

            // Kembalikan warna Button "+ Tambah Kendaraan" (Hijau)
            // *Catatan: Ganti 'btnTambah' dengan nama variabel tombol tambah milik Anda yang asli*
            if (btnTambah != null)
            {
                btnTambah.BackColor = Color.FromArgb(92, 184, 92);
                btnTambah.ForeColor = Color.White;
                btnTambah.Text = "+ Tambah Kendaraan";
            }

            // 3. Pastikan area kartu kendaraan bisa di-scroll dengan aman
            if (this.flowKendaraan != null)
            {
                this.flowKendaraan.AutoScroll = true;
            }

            // Jalankan penyusunan ulang grafis
            this.PerformLayout();
            this.Invalidate();
            this.Refresh();

            // 4. Ambil data dari database melalui controller Anda
            RefreshDataDariDatabase();
        }

        private void RefreshDataDariDatabase()
        {
            // Menyesuaikan dengan method asli controller Anda: GetKendaraan()
            listMasterKendaraan = controller.GetKendaraan();
            RenderVehicleCards(listMasterKendaraan);
        }

        // --- FUNGSI UTAMA Pembuat Card UI Dinamis ---
        private void RenderVehicleCards(List<Kendaraan> dataKendaraan)
        {
            flowKendaraan.Controls.Clear();

            if (dataKendaraan == null) return;

            foreach (var vh in dataKendaraan)
            {
                // 1. Kotak Luar Card (RoundedPanel)
                RoundedPanel card = new RoundedPanel
                {
                    Size = new Size(270, 160),
                    BackColor = Color.White,
                    BorderRadius = 15,
                    Margin = new Padding(12)
                };

                // 2. Label Nama Kendaraan (Dari database)
                Label lblNama = new Label
                {
                    Text = !string.IsNullOrEmpty(vh.NamaKendaraan) ? vh.NamaKendaraan : "Tanpa Nama",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(45, 45, 45),
                    Location = new Point(15, 15),
                    AutoSize = true
                };

                // 3. Sub-Label Tipe Kendaraan (Deteksi berdasarkan IdTipeKendaraan di DB)
                // 1 = motor, 2 = mobil (sesuai urutan insert data script SQL Anda)
                string tipeTeks = (vh.IdTipeKendaraan == 2) ? "Mobil" : "Motor";
                string infoSewa = $"Rp {vh.HargaSewa:N0}/hari"; // Menampilkan harga sewa dari DB

                Label lblSubInfo = new Label
                {
                    Text = $"{tipeTeks} • {infoSewa}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.Gray,
                    Location = new Point(15, 40),
                    AutoSize = true
                };

                // 4. Visualisasi Baterai (Gunakan properti simulasi atau kustomisasi default)
                // Misal kita set simulasi: jika status 'dalam perbaikan' dianggap 0%, sisanya 85% - 98%
                int persenBaterai = vh.StatusKendaraan == "dalam perbaikan" ? 0 : (vh.NamaKendaraan.Contains("Tesla") ? 15 : 92);

                Color batteryColor = persenBaterai > 50 ? Color.FromArgb(67, 160, 71) :
                                     (persenBaterai > 20 ? Color.Orange : Color.Red);

                Label lblBaterai = new Label
                {
                    Text = $"🔋 {persenBaterai}%",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = batteryColor,
                    Location = new Point(15, 75),
                    AutoSize = true
                };

                // 5. Badge Status Kendaraan (Menyesuaikan ENUM option_status PostgreSQL Anda)
                string statusDb = !string.IsNullOrEmpty(vh.StatusKendaraan) ? vh.StatusKendaraan.ToLower() : "tersedia";

                Color bgStatus, fgStatus;
                switch (statusDb)
                {
                    case "tersedia":
                        bgStatus = Color.FromArgb(232, 245, 233); // Hijau Muda
                        fgStatus = Color.FromArgb(67, 160, 71);   // Hijau Tua
                        break;
                    case "disewa":
                        bgStatus = Color.FromArgb(255, 243, 224); // Orange Muda
                        fgStatus = Color.OrangeRed;               // Orange Tua
                        break;
                    case "dalam perbaikan":
                    case "rusak":
                        bgStatus = Color.FromArgb(255, 235, 235); // Merah Muda
                        fgStatus = Color.Red;                     // Merah Tua
                        break;
                    default:
                        bgStatus = Color.FromArgb(227, 242, 253); // Biru Muda
                        fgStatus = Color.FromArgb(30, 136, 229);  // Biru Tua
                        break;
                }

                Label lblStatusBadge = new Label
                {
                    Text = statusDb, // Menampilkan teks asli DB ('tersedia', 'disewa', dll)
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    BackColor = bgStatus,
                    ForeColor = fgStatus,
                    Location = new Point(15, 115),
                    Size = new Size(110, 25), // Ukuran dilebarkan sedikit agar muat tulisan "dalam perbaikan"
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // 6. Tombol Kelola
                Button btnDetailCard = new Button
                {
                    Text = "Kelola ⚙",
                    Size = new Size(95, 30),
                    Location = new Point(155, 112),
                    BackColor = Color.FromArgb(245, 245, 242),
                    ForeColor = Color.FromArgb(45, 45, 45),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
                };
                btnDetailCard.FlatAppearance.BorderSize = 0;

                // EVENT CLICK KELOLA -> POPUP FORM EDIT
                btnDetailCard.Click += (s, e) =>
                {
                    Form frm = new Form();
                    frm.Text = "Kelola Kendaraan";
                    frm.Size = new Size(500, 520);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.BackColor = Color.White;
                    frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    frm.MaximizeBox = false;

                    Label lblFormTitle = new Label { Text = "Informasi Kendaraan", Font = new Font("Segoe UI", 16, FontStyle.Bold), Location = new Point(25, 20), AutoSize = true };

                    Label lblNamaKendaraan = new Label { Text = "Nama Kendaraan", Location = new Point(30, 80), Font = new Font("Segoe UI", 9F, FontStyle.Bold), AutoSize = true };
                    TextBox txtNama = new TextBox { Size = new Size(400, 30), Location = new Point(30, 105), Text = vh.NamaKendaraan };

                    Label lblHarga = new Label { Text = "Harga Sewa (Rp)", Location = new Point(30, 150), Font = new Font("Segoe UI", 9F, FontStyle.Bold), AutoSize = true };
                    NumericUpDown numHarga = new NumericUpDown { Location = new Point(30, 175), Size = new Size(400, 30), Minimum = 0, Maximum = 10000000, Value = vh.HargaSewa };

                    Label lblStatus = new Label { Text = "Status Kendaraan", Location = new Point(30, 220), Font = new Font("Segoe UI", 9F, FontStyle.Bold), AutoSize = true };
                    ComboBox cbStatus = new ComboBox { Location = new Point(30, 245), Size = new Size(400, 30), DropDownStyle = ComboBoxStyle.DropDownList };
                    cbStatus.Items.AddRange(new string[] { "tersedia", "disewa", "rusak", "dalam perbaikan" }); // Sesuai ENUM database
                    cbStatus.SelectedItem = statusDb;

                    Button btnSimpan = new Button { Text = "Simpan", Size = new Size(130, 42), Location = new Point(300, 410), BackColor = Color.FromArgb(123, 201, 111), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
                    btnSimpan.FlatAppearance.BorderSize = 0;

                    btnSimpan.Click += (sender2, ev2) =>
                    {
                        try
                        {
                            vh.NamaKendaraan = txtNama.Text;
                            vh.HargaSewa = (int)numHarga.Value;
                            vh.StatusKendaraan = cbStatus.SelectedItem.ToString();

                            controller.UpdateKendaraan(vh);

                            MessageBox.Show("Data database berhasil diperbarui!", "EcoDrive", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frm.Close();
                            RefreshDataDariDatabase();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Gagal menyimpan data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    frm.Controls.AddRange(new Control[] {
                lblFormTitle, lblNamaKendaraan, txtNama, lblHarga, numHarga, lblStatus, cbStatus, btnSimpan
            });

                    frm.ShowDialog();
                };

                card.Controls.AddRange(new Control[] { lblNama, lblSubInfo, lblBaterai, lblStatusBadge, btnDetailCard });
                flowKendaraan.Controls.Add(card);
            }
        }

        // --- FITUR REAL-TIME SEARCH ---
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (keyword == "🔍 cari nama, tipe, id..." || string.IsNullOrEmpty(keyword))
            {
                RenderVehicleCards(listMasterKendaraan);
                return;
            }

            var hasilFilter = listMasterKendaraan.FindAll(x =>
                x.Nama.ToLower().Contains(keyword) ||
                x.Tipe.ToLower().Contains(keyword) ||
                x.Lokasi.ToLower().Contains(keyword)
            );

            RenderVehicleCards(hasilFilter);
        }

        // --- FITUR TAB FILTER BUTTONS ---
        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (listMasterKendaraan == null) return;
            Button btnKlik = (Button)sender;

            btnSemua.BackColor = btnMobil.BackColor = btnMotor.BackColor = Color.FromArgb(248, 244, 238);
            btnSemua.ForeColor = btnMobil.ForeColor = btnMotor.ForeColor = Color.FromArgb(35, 35, 35);

            btnKlik.BackColor = Color.FromArgb(92, 184, 92);
            btnKlik.ForeColor = Color.White;

            if (btnKlik == btnSemua)
                RenderVehicleCards(listMasterKendaraan);
            else if (btnKlik == btnMobil)
                RenderVehicleCards(listMasterKendaraan.FindAll(x => x.IdTipeKendaraan == 2)); // 2 adalah Mobil
            else if (btnKlik == btnMotor)
                RenderVehicleCards(listMasterKendaraan.FindAll(x => x.IdTipeKendaraan == 1)); // 1 adalah Motor
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {

        }
    }
}
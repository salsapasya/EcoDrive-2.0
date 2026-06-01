using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EcoDrive_vol2.Models.Vehicles;
using EcoDrive_vol2.Controllers.Customer;

namespace EcoDrive_vol2.Views
{
    public partial class CusKendaraan : Form
    {
        private readonly Color _bgUtama = Color.FromArgb(255, 253, 246);
        private readonly CusKendaraanController _controller = new CusKendaraanController();

        private List<Kendaraan> _masterListKendaraan = new List<Kendaraan>();
        private List<Kendaraan> _filteredListKendaraan = new List<Kendaraan>();
        private string _kategoriAktif = "Semua";

        public CusKendaraan()
        {
            InitializeComponent();
            this.BackColor = _bgUtama;

            RegisterEventHandlers();
            LoadDataProduk();
            ApplyFilterDanPencarian();
        }

        private void CusKendaraan_Load(object sender, EventArgs e)
        {
        }

        private void RegisterEventHandlers()
        {
            if (txtSearch != null) txtSearch.TextChanged += TxtSearch_TextChanged;
            if (btnSemua != null) btnSemua.Click += (s, e) => UbahFilterKategori("Semua", btnSemua);
            if (btnMobil != null) btnMobil.Click += (s, e) => UbahFilterKategori("Mobil", btnMobil);
            if (btnMotor != null) btnMotor.Click += (s, e) => UbahFilterKategori("Motor", btnMotor);
        }

        private void LoadDataProduk()
        {
            try
            {
                _masterListKendaraan.Clear();
                _masterListKendaraan = _controller.GetAvailableKendaraan();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data: {ex.Message}", "Error Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilterDanPencarian()
        {
            string kataKunci = txtSearch != null ? txtSearch.Text.Trim().ToLower() : "";

            _filteredListKendaraan = _masterListKendaraan.Where(k =>
            {
                bool cocokKategori = _kategoriAktif == "Semua" ||
                                     k.Tipe.Equals(_kategoriAktif, StringComparison.OrdinalIgnoreCase);

                bool cocokKataKunci = string.IsNullOrEmpty(kataKunci) ||
                                      k.Nama.ToLower().Contains(kataKunci) ||
                                      k.NomorPlatKendaraan.ToLower().Contains(kataKunci);

                return cocokKategori && cocokKataKunci;
            }).ToList();

            RenderKendaraanCards();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterDanPencarian();
        }

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
                Panel card = CreateKendaraanCard(kendaraan);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        // REFACTOR: Memisahkan pembuatan komponen Card UI agar method Render tidak terlalu gemuk
        private Panel CreateKendaraanCard(Kendaraan kendaraan)
        {
            Panel card = new Panel
            {
                Size = new Size(240, 270),
                BackColor = Color.White,
                Margin = new Padding(15),
                Padding = new Padding(15)
            };

            Label lblNama = new Label
            {
                Text = kendaraan.Nama,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 45),
                Dock = DockStyle.Top,
                Height = 30
            };

            Label lblDetail = new Label
            {
                Text = $"{kendaraan.Tipe} • {kendaraan.NomorPlatKendaraan}\nStok: {kendaraan.StokKendaraan} Unit",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Gray,
                Dock = DockStyle.Top,
                Height = 40
            };

            Label lblHarga = new Label
            {
                Text = $"Rp {kendaraan.HargaSewa:N0} / hari",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 139, 87),
                Dock = DockStyle.Top,
                Height = 30
            };

            Label lblStatus = new Label
            {
                Text = kendaraan.Status.ToUpper().Replace("_", " "),
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(15, 160),
                BackColor = Color.FromArgb(230, 245, 233),
                ForeColor = Color.Green,
                Padding = new Padding(5, 3, 5, 3)
            };

            Button btnSewa = new Button
            {
                Text = "Detail Sewa",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Size = new Size(210, 38),
                Location = new Point(15, 210),
                Tag = kendaraan
            };
            btnSewa.FlatAppearance.BorderSize = 0;
            btnSewa.Click += BtnSewa_Click;

            card.Controls.AddRange(new Control[] { btnSewa, lblStatus, lblHarga, lblDetail, lblNama });

            lblNama.BringToFront();
            lblDetail.BringToFront();
            lblHarga.BringToFront();

            return card;
        }

        private Label CreateEmptyStateLabel()
        {
            return new Label
            {
                Text = "Tidak ada kendaraan listrik yang cocok dengan pencarian Anda.",
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.DarkGray,
                AutoSize = true,
                Margin = new Padding(30, 20, 0, 0)
            };
        }

        private void BtnSewa_Click(object sender, EventArgs e)
        {
            if (sender is Button btnTarget && btnTarget.Tag is Kendaraan dataKendaraan)
            {
                if (dataKendaraan.StokKendaraan <= 0)
                {
                    MessageBox.Show("Maaf, stok unit ini sedang kosong.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TampilkanPopUpDetail(dataKendaraan);
            }
        }

        // REFACTOR: Memisahkan penyusunan struktur UI Dialog Detail Box
        private void TampilkanPopUpDetail(Kendaraan dataKendaraan)
        {
            Form detailForm = new Form
            {
                Text = "Informasi Detail Spesifikasi",
                Size = new Size(460, 480),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(250, 248, 242)
            };

            Panel innerCard = new Panel
            {
                Size = new Size(400, 380),
                Location = new Point(22, 25),
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            Label lblPopTitle = new Label
            {
                Text = dataKendaraan.Nama,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 45),
                Dock = DockStyle.Top,
                Height = 35
            };

            Label lblPopSub = new Label
            {
                Text = $"Kategori Kendaraan Listrik: {dataKendaraan.Tipe}",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Italic),
                ForeColor = Color.Gray,
                Dock = DockStyle.Top,
                Height = 25
            };

            Panel lineSeparator = new Panel
            {
                BackColor = Color.FromArgb(235, 230, 220),
                Dock = DockStyle.Top,
                Height = 2,
                Margin = new Padding(0, 5, 0, 15)
            };

            Label lblGridSpesifikasi = new Label
            {
                Text = $" Nomor Registrasi Plat  :  {dataKendaraan.NomorPlatKendaraan}\n\n" +
                       $" Kapasitas Unit Ready   :  {dataKendaraan.StokKendaraan} Unit\n\n" +
                       $" Tarif Dasar Sewa         :  Rp {dataKendaraan.HargaSewa:N0} / Hari\n\n" +
                       $" Simulasi 24 Jam Penuh :  Rp {dataKendaraan.BiayaRental(24):N0}",
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(20, 100),
                Size = new Size(360, 150)
            };

            Button btnBooking = new Button
            {
                Text = "Konfirmasi Pemesanan Kendaraan",
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(360, 48),
                Location = new Point(20, 280),
                Cursor = Cursors.Hand
            };
            btnBooking.FlatAppearance.BorderSize = 0;

            btnBooking.Click += (s, ev) =>
            {
                detailForm.Close();
                MessageBox.Show($"Booking {dataKendaraan.Nama} berhasil dicatat! Lanjutkan ke pembayaran.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            innerCard.Controls.AddRange(new Control[] { btnBooking, lblGridSpesifikasi, lineSeparator, lblPopSub, lblPopTitle });
            detailForm.Controls.Add(innerCard);

            detailForm.ShowDialog();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
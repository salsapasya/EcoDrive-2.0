using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.Controllers.Customer;
using EcoDrive_vol2.Helpers;
using EcoDrive.Models.Vehicles;
using EcoDrive_vol2.Models.Vehicles;
using EcoDrive_vol2.Models.Transaksi;

namespace EcoDrive_vol2.Views
{
    // OOP (Pewarisan / Inheritance): Menurunkan semua sifat & tampilan dari induk 'Form' .NET
    public partial class CusCharging : Form
    {
        private Color bgUtama = Color.FromArgb(255, 253, 246);
        private string _modeAktif = "STATION";

        // OOP (Objek): Membuat objek Controller baru khusus untuk halaman ini
        private readonly CusChargingController _chargingController = new CusChargingController();
        private List<ChargingStation> _listStation = new List<ChargingStation>();
        private List<Kendaraan> _listKendaraanUser = new List<Kendaraan>();
        private List<TransaksiCharging> _listSedangCharging = new List<TransaksiCharging>();
        public CusCharging()
        {
            InitializeComponent();
            this.BackColor = bgUtama;

            RegisterEventHandlers();
            LoadDataDariDatabase();
            RenderCards();
        }
        private void RegisterEventHandlers()
        {
            if (btnFilterStation != null) btnFilterStation.Click += (s, e) => UbahMode("STATION", btnFilterStation);
            if (btnFilterKendaraan != null) btnFilterKendaraan.Click += (s, e) => UbahMode("KENDARAAN", btnFilterKendaraan);
        }
        private void UbahMode(string mode, Button btnAktif)
        {
            _modeAktif = mode;

            Button[] semuaTombol = { btnFilterStation, btnFilterKendaraan };
            foreach (var btn in semuaTombol)
            {
                if (btn == null) continue;
                bool isTarget = (btn == btnAktif);
                btn.BackColor = isTarget ? Color.FromArgb(76, 175, 80) : Color.White;
                btn.ForeColor = isTarget ? Color.White : Color.FromArgb(45, 45, 45);
            }

            LoadDataDariDatabase(); // Refresh data setiap pindah mode
            RenderCards();
        }

        private void LoadDataDariDatabase()
        {
            try
            {
                int idUserLogin = UserSession.IdUserAktif;

                _listStation = _chargingController.AmbilSemuaStation();
                _listKendaraanUser = _chargingController.AmbilKendaraanSewaUser(idUserLogin);
                _listSedangCharging = _chargingController.AmbilTransaksiAktif(idUserLogin);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data dari data base : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RenderCards()
        {
            flpChargingContainer.Controls.Clear();

            if (_modeAktif == "STATION")
            {
                foreach (var station in _listStation)
                {
                    flpChargingContainer.Controls.Add(CreateStationCard(station));
                }
            }
            else if (_modeAktif == "KENDARAAN")
            {
                if (_listSedangCharging.Count == 0)
                {
                    flpChargingContainer.Controls.Add(new Label
                    {
                        Text = "Tidak ada kendaraan yang sedang di-charge saat ini.",
                        AutoSize = true,
                        Margin = new Padding(20),
                        Font = new Font("Segoe UI", 10, FontStyle.Italic),
                        ForeColor = Color.Gray
                    });
                }

                foreach (var trx in _listSedangCharging)
                {
                    flpChargingContainer.Controls.Add(CreateKendaraanChargingCard(trx));
                }
            }
        }
        private Panel CreateStationCard(ChargingStation station)
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
                Text = station.NamaStation, 
                Font = new Font("Segoe UI", 12, FontStyle.Bold), 
                Dock = DockStyle.Top, 
                Height = 45 
            };
            Label lblDetail = new Label 
            { 
                Text = $"{station.Lokasi}\n\nSlot Tersedia: {station.JumlahSlot}", 
                Font = new Font("Segoe UI", 9), 
                ForeColor = Color.Gray, 
                Dock = DockStyle.Top, 
                Height = 45 
            };
            Label lblHarga = new Label 
            { 
                Text = $"Rp {station.TarifPer15Menit:N0} / menit", 
                Font = new Font("Segoe UI", 10, FontStyle.Bold), 
                ForeColor = Color.FromArgb(46, 139, 87), 
                Dock = DockStyle.Top, 
                Height = 30 
            };

            Button btnMulai = new Button
            {
                Text = "Pilih & Mulai",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(210, 38),
                Location = new Point(15, 210),
                Tag = station
            };
            btnMulai.FlatAppearance.BorderSize = 0;
            btnMulai.Click += (s, e) => TampilkanPopUpMulaiCharging(station);

            card.Controls.AddRange(new Control[] { btnMulai, lblHarga, lblDetail, lblNama });
            lblNama.BringToFront(); lblDetail.BringToFront(); lblHarga.BringToFront();
            return card;
        }
        private void TampilkanPopUpMulaiCharging(ChargingStation station)
        {
            Form detailForm = new Form
            {
                Text = "Mulai Pengisian Daya",
                Size = new Size(450, 640),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            Label lblTitle = new Label
            {
                Text = station.NamaStation,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            Label lblLok = new Label
            {
                Text = $"{station.Lokasi}\nTarif: Rp 50.000 /15 Menit",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(20, 55),
                AutoSize = true
            };

            Label lblPilihKendaraan = new Label
            {
                Text = "Pilih Kendaraan Anda:",
                Location = new Point(20, 110),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            ComboBox cmbKendaraan = new ComboBox
            {
                Location = new Point(20, 135),
                Size = new Size(390, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Load Kendaraan ke ComboBox
            cmbKendaraan.DataSource = _listKendaraanUser;
            cmbKendaraan.DisplayMember = "NamaKendaraan";
            cmbKendaraan.ValueMember = "IdKendaraan";

            Label lblDurasi = new Label
            {
                Text = "Pilih Durasi Charging:",
                Location = new Point(20, 195),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // variabel untuk menyimpan durasi dalam menit
            int durasiTerpilih = 15; // default 15 menit
            Label lblEstimasi = new Label
            {
                Text = "Total Biaya : Rp 50.000",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 139, 87),
                Location = new Point(20, 380),
                AutoSize = true
            };

            // TOMBOL PILIHAN DURASI
            Panel pnlButtonsContainer = new Panel 
            { 
                Location = new Point(20, 225), 
                Size = new Size(390, 130), 
                BackColor = Color.White 
            };

            int[] pilihanDurasi = { 15, 30, 45, 60, 75, 90 };
            List<Button> tombolDurasiList = new List<Button>();

            int xOffset = 0;
            int yOffset = 0;
            int buttonWidth = 120;
            int buttonHeight = 45;
            int padding = 15;

            for (int i = 0; i < pilihanDurasi.Length; i++)
            {
                int menit = pilihanDurasi[i];

                Button btnDurasi = new Button
                {
                    Text = $"{menit} Menit",
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(xOffset, yOffset),
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = i == 0 ? Color.FromArgb(76, 175, 80) : Color.White, // Default 15 Menit warna hijau
                    ForeColor = i == 0 ? Color.White : Color.FromArgb(45, 45, 45),
                    Tag = menit
                };
                btnDurasi.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);

                // Aksi ketika salah satu tombol menit diklik
                btnDurasi.Click += (s, e) =>
                {
                    Button btnKlik = (Button)s;
                    durasiTerpilih = (int)btnKlik.Tag;

                    foreach (var btn in tombolDurasiList) // reset warna jd putih
                    {
                        btn.BackColor = Color.White;
                        btn.ForeColor = Color.FromArgb(45, 45, 45);
                    }

                    btnKlik.BackColor = Color.FromArgb(76, 175, 80); // ubah jadi ijo
                    btnKlik.ForeColor = Color.White;

                    // OOP: Meminta Controller menghitung nominal estimasi lewat model internalnya
                    decimal totalBiaya = _chargingController.HitungEstimasiBiayaModel(durasiTerpilih);
                    lblEstimasi.Text = $"Total Biaya: Rp {totalBiaya:N0}";
                };

                tombolDurasiList.Add(btnDurasi);
                pnlButtonsContainer.Controls.Add(btnDurasi);

                // Atur posisi grid tombol (3 Kolom, 2 Baris)
                xOffset += buttonWidth + padding;
                if ((i + 1) % 3 == 0)
                {
                    xOffset = 0;
                    yOffset += buttonHeight + padding;
                }
            }
            Button btnProses = new Button
            {
                Text = "Bayar & Mulai Charging",
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(390, 48),
                Location = new Point(20, 440)
            };
            btnProses.FlatAppearance.BorderSize = 0;

            btnProses.Click += (s, e) =>
            {
                int idKendaraanTerpilih = 0;

                if (cmbKendaraan.SelectedItem is Kendaraan kendaraanTerpilih)
                {
                    idKendaraanTerpilih = kendaraanTerpilih.IdKendaraan;

                    // Cek apakah ada plat yang sama di dalam list transaksi aktif (Pending/Mengisi Daya)
                    bool isSudahCharging = _listSedangCharging.Exists(trx => trx.NomorPlat == kendaraanTerpilih.NomorPlatKendaraan);

                    if (isSudahCharging)
                    {
                        MessageBox.Show(
                            $"Kendaraan {kendaraanTerpilih.NamaKendaraan} ({kendaraanTerpilih.NomorPlatKendaraan}) saat ini masih dalam status PENDING atau MENGISI DAYA.\n\nSelesaikan transaksi sebelumnya terlebih dahulu!",
                            "Transaksi Ditolak",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return; // Menghentikan eksekusi kode di bawahnya (tidak jadi bayar & call SP)
                    }
                }

                try
                {
                    _chargingController.ProsesBuatCharging(UserSession.IdUserAktif, idKendaraanTerpilih, station.IdChargingStation, durasiTerpilih, _listKendaraanUser);

                    MessageBox.Show("Pembayaran Berhasil! Status saat ini: PENDING. \nSilakan tunggu konfirmasi Admin.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    detailForm.Close();

                    UbahMode("KENDARAAN", btnFilterKendaraan); // Otomatis pindah halaman 
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("SALDO_KURANG"))
                    {
                        DialogResult response = MessageBox.Show("Saldo Anda tidak mencukupi untuk melakukan transaksi ini.\nApakah Anda ingin mengisi saldo (Top Up) sekarang?", "Saldo Tidak Cukup", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (response == DialogResult.Yes)
                        {
                            detailForm.Close();
                            if (Application.OpenForms["CusDasboard"] is CusDasboard dashboard)
                            {
                                dashboard.BukaHalamanSaldo();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            };

            detailForm.Controls.Add(lblTitle);
            detailForm.Controls.Add(lblLok);
            detailForm.Controls.Add(lblPilihKendaraan);
            detailForm.Controls.Add(cmbKendaraan);
            detailForm.Controls.Add(lblDurasi);
            detailForm.Controls.Add(pnlButtonsContainer);
            detailForm.Controls.Add(lblEstimasi);
            detailForm.Controls.Add(btnProses); detailForm.ShowDialog();
        }
        private Panel CreateKendaraanChargingCard(TransaksiCharging trx)
        {
            Panel card = new Panel
            {
                Size = new Size(280, 270),
                BackColor = Color.FromArgb(240, 248, 255),
                Margin = new Padding(15),
                Padding = new Padding(15)
            };

            Label lblNama = new Label 
            { 
                Text = trx.NamaKendaraan, 
                Font = new Font("Segoe UI", 12, FontStyle.Bold), 
                Dock = DockStyle.Top, Height = 30 
            };
            Label lblDetail = new Label 
            { 
                Text = $"Plat: {trx.NomorPlat}\nLokasi: {trx.NamaStation}", 
                Font = new Font("Segoe UI", 9), 
                ForeColor = Color.Gray, Dock = DockStyle.Top, Height = 40
            };

            var skemaVisual = _chargingController.DapatkanSkemaVisualStatus(trx);

            Label lblStatus = new Label 
            { 
                Text = $"⚡ STATUS: {trx.StatusCharging.ToString().ToUpper().Replace("_", " ")}",
                Font = new Font("Segoe UI", 9, FontStyle.Bold), 
                ForeColor = skemaVisual.WarnaTeks, 
                Dock = DockStyle.Top, 
                Height = 30 
            };

            Button btnSelesai = new Button
            {
                Text = "Selesai Charging",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                BackColor = Color.FromArgb(192, 57, 43),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(250, 38),
                Location = new Point(15, 210),
                Enabled = skemaVisual.TombolAktif,
                Tag = trx
            };
            btnSelesai.FlatAppearance.BorderSize = 0;

            // TOMBOL SELESAI HANYA BISA DIKLIK KALAU STATUSNYA "MENGISI DAYA" (SUDAH DI-ACC ADMIN)
            if (skemaVisual.TombolAktif == false)
            {
                btnSelesai.Text = "Menunggu Konfirmasi Admin";
                btnSelesai.BackColor = Color.Gray;
                btnSelesai.Enabled = false;
            }

            btnSelesai.Click += (s, e) => {
                DialogResult res = MessageBox.Show($"Apakah Anda yakin ingin menghentikan pengisian daya untuk {trx.NamaKendaraan}?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    _chargingController.SelesaikanCharging(trx, _listKendaraanUser);

                    MessageBox.Show("Pengisian daya selesai. Terima kasih!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UbahMode("STATION", btnFilterStation); // Refresh
                }
            };

            card.Controls.AddRange(new Control[] { btnSelesai, lblStatus, lblDetail, lblNama });
            lblNama.BringToFront(); lblDetail.BringToFront(); lblStatus.BringToFront();
            return card;
        }
    }
}
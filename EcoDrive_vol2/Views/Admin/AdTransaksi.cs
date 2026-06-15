using EcoDrive_vol2.Context.Admin;
using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Service;
using EcoDrive_vol2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class AdTransaksi : Form
    {
        private Color bgUtama = Color.FromArgb(255, 253, 246);
        private bool _isProcessing = false;

        private Controllers.Admin.AdTransaksiController _transaksiController;

        public AdTransaksi()
        {
            InitializeComponent();
            this.BackColor = bgUtama;
            _transaksiController = new Controllers.Admin.AdTransaksiController();

            // Binding Event Filter Tombol Atas
            btnSemua.Click += FilterButton_Click;
            btnSewa.Click += FilterButton_Click;
            btnCharging.Click += FilterButton_Click;

            if (!dgvTransaksi.Columns.Contains("btnKonfirmasi"))
            {
                var btnKonfirmasi = new DataGridViewButtonColumn
                {
                    HeaderText = "Aksi Konfirmasi",
                    Name = "btnKonfirmasi",
                    Text = "Konfirmasi",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    Width = 90
                };
                dgvTransaksi.Columns.Add(btnKonfirmasi);
            }

            if (!dgvTransaksi.Columns.Contains("btnSelesai"))
            {
                var btnSelesai = new DataGridViewButtonColumn
                {
                    HeaderText = "Aksi Selesai",
                    Name = "btnSelesai",
                    Text = "Selesaikan",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    Width = 90
                };
                dgvTransaksi.Columns.Add(btnSelesai);
            }

            dgvTransaksi.CellFormatting += DgvTransaksi_CellFormatting;
            dgvTransaksi.CellContentClick += dgvTransaksi_CellContentClick;

            this.Load += AdTransaksi_Load;
        }

        private void AdTransaksi_Load(object sender, EventArgs e)
        {
            TampilkanData("Semua");
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            Button btnKlik = (Button)sender;
            ResetFilterButtonStyles();

            btnKlik.BackColor = Color.FromArgb(92, 184, 92);
            btnKlik.ForeColor = Color.White;

            TampilkanData(btnKlik.Text);
        }

        private void ResetFilterButtonStyles()
        {
            Color defaultBg = Color.FromArgb(248, 246, 242);
            Color defaultFg = Color.FromArgb(47, 47, 47);

            btnSemua.BackColor = defaultBg; btnSemua.ForeColor = defaultFg;
            btnSewa.BackColor = defaultBg; btnSewa.ForeColor = defaultFg;
            btnCharging.BackColor = defaultBg; btnCharging.ForeColor = defaultFg;
        }

        // ====================================================================
        // FUNGSI UTAMA: MENAMPILKAN DATA LAPORAN 
        // ====================================================================
        private void TampilkanData(string filterMode)
        {
            try
            {
                dgvTransaksi.Rows.Clear();
                List<Transaksi> dataList = _transaksiController.AmbilLaporanKeuanganAdmin(filterMode);

                foreach (var item in dataList)
                {
                    dgvTransaksi.Rows.Add(
                        item.IdTransaksi,
                        item.Kategori,
                        item.Username,
                        item.Nama,
                        item.Kontak,
                        item.NamaKendaraan,
                        item.TipeKendaraan,
                        item.NomorPlat,
                        item.TanggalSewa,
                        item.TanggalKembali,
                        item.TanggalCharging,
                        item.NamaStation,
                        item.DurasiTransaksi,
                        item.Status,
                        item.TotalBiaya.ToString("C0", new System.Globalization.CultureInfo("id-ID"))
                    );

                    // Simpan objek model data ke dalam Tag baris (Sama fungsinya seperti DataBoundItem di contohmu)
                    dgvTransaksi.Rows[dgvTransaksi.Rows.Count - 1].Tag = item;
                }
                AturVisibilitasKolom(filterMode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Memuat Data : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AturVisibilitasKolom(string filterMode)
        {
            int idxTglSewa = 8;
            int idxTglKembali = 9;
            int idxTglCharging = 10;
            int idxNamaStation = 11;

            if (filterMode == "Sewa")
            {
                // Jika tombol Sewa diklik = Tampilkan kolom sewa, sembunyikan kolom charging
                dgvTransaksi.Columns[idxTglSewa].Visible = true;
                dgvTransaksi.Columns[idxTglKembali].Visible = true;

                dgvTransaksi.Columns[idxTglCharging].Visible = false;
                dgvTransaksi.Columns[idxNamaStation].Visible = false;

                // Sembunyikan tombol aksi konfirmasi charging 
                if (dgvTransaksi.Columns.Contains("btnKonfirmasi")) dgvTransaksi.Columns["btnKonfirmasi"].Visible = false;
                if (dgvTransaksi.Columns.Contains("btnSelesai")) dgvTransaksi.Columns["btnSelesai"].Visible = true;
            }
            else if (filterMode == "Charging")
            {
                // Jika tombol Charging diklik = Sembunyikan kolom sewa, tampilkan kolom charging
                dgvTransaksi.Columns[idxTglSewa].Visible = false;
                dgvTransaksi.Columns[idxTglKembali].Visible = false;

                dgvTransaksi.Columns[idxTglCharging].Visible = true;
                dgvTransaksi.Columns[idxNamaStation].Visible = true;

                // Sembunyikan tombol aksi penyelesaian sewa
                if (dgvTransaksi.Columns.Contains("btnKonfirmasi")) dgvTransaksi.Columns["btnKonfirmasi"].Visible = true;
                if (dgvTransaksi.Columns.Contains("btnSelesai")) dgvTransaksi.Columns["btnSelesai"].Visible = false;
            }
            else
            {
                // Jika tombol Semua diklik = Tampilkan seluruh kolom tanpa terkecuali
                dgvTransaksi.Columns[idxTglSewa].Visible = true;
                dgvTransaksi.Columns[idxTglKembali].Visible = true;
                dgvTransaksi.Columns[idxTglCharging].Visible = true;
                dgvTransaksi.Columns[idxNamaStation].Visible = true;

                if (dgvTransaksi.Columns.Contains("btnKonfirmasi")) dgvTransaksi.Columns["btnKonfirmasi"].Visible = true;
                if (dgvTransaksi.Columns.Contains("btnSelesai")) dgvTransaksi.Columns["btnSelesai"].Visible = true;
            }
        }

        private void DgvTransaksi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = dgvTransaksi.Rows[e.RowIndex].Tag as Transaksi;
            if (item == null) return;

            // Cukup panggil skema visual hasil olahan Controller
            var visual = _transaksiController.SkemaVisualStatus(item);

            // Mewarnai teks Kolom Status (Index 13)
            if (e.ColumnIndex == 13 && e.Value != null)
            {
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                e.CellStyle.ForeColor = visual.Warna;
            }

            // Memformat warna Tombol Konfirmasi berdasarkan izin dari Controller
            if (dgvTransaksi.Columns[e.ColumnIndex].Name == "btnKonfirmasi")
            {
                e.CellStyle.BackColor = visual.BisaKonfirmasi ? Color.FromArgb(0, 123, 255) : Color.LightGray;
                e.CellStyle.ForeColor = visual.BisaKonfirmasi ? Color.White : Color.DarkGray;
            }

            // Memformat warna Tombol Selesaikan berdasarkan izin dari Controller
            if (dgvTransaksi.Columns[e.ColumnIndex].Name == "btnSelesai")
            {
                e.CellStyle.BackColor = visual.BisaSelesai ? Color.FromArgb(92, 184, 92) : Color.LightGray;
                e.CellStyle.ForeColor = visual.BisaSelesai ? Color.White : Color.DarkGray;
            }
        }

        private void dgvTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (_isProcessing) return;

            var item = dgvTransaksi.Rows[e.RowIndex].Tag as Transaksi;
            if (item == null) return;

            try
            {
                _isProcessing = true;
                var colName = dgvTransaksi.Columns[e.ColumnIndex].Name;
                var visual = _transaksiController.SkemaVisualStatus(item);

                // 1. EVENT TOMBOL KONFIRMASI (PROSES CHARGING)
                if (colName == "btnKonfirmasi")
                {
                    if (!visual.BisaKonfirmasi)
                    {
                        MessageBox.Show("Transaksi ini tidak dalam status pending!", "EcoDrive Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (MessageBox.Show($"Konfirmasi transaksi charging ini?", "EcoDrive Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _transaksiController.ProsesKonfirmasiCharging(item);
                        MessageBox.Show("Status Charging berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataSesuaiFilterAktif();
                    }
                }

                // 2. EVENT TOMBOL SELESAI (PROSES PENGEMBALIAN SEWA)
                if (colName == "btnSelesai")
                {
                    if (!visual.BisaSelesai)
                    {
                        MessageBox.Show("Tombol ini hanya untuk transaksi Sewa yang berstatus 'Menunggu Konfirmasi'!", "EcoDrive Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (MessageBox.Show($"Selesaikan transaksi sewa ini?", "EcoDrive Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _transaksiController.ProsesPenyelesaianSewa(item);
                        MessageBox.Show("Status Pengembalian berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataSesuaiFilterAktif();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
            }
        }

        private void RefreshDataSesuaiFilterAktif()
        {
            if (btnSewa.BackColor == Color.FromArgb(92, 184, 92)) TampilkanData("Sewa");
            else if (btnCharging.BackColor == Color.FromArgb(92, 184, 92)) TampilkanData("Charging");
            else TampilkanData("Semua");
        }
    }
}
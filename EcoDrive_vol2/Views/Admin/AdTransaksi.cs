using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models.Admin;
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

            // =======================================================
            // 🟩 DUA KOLOM BUTTON AKSI (Dibuat Unique Agar Tidak Duplikat)
            // =======================================================
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

            // Daftarkan Event ke Grid
            dgvTransaksi.CellFormatting += DgvTransaksi_CellFormatting;
            dgvTransaksi.CellContentClick += dgvTransaksi_CellContentClick;

            // Jalankan load data awal
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
        // FUNGSI UTAMA: MENAMPILKAN DATA LAPORAN (FIX URUTAN KOLOM)
        // ====================================================================
        private void TampilkanData(string filterMode)
        {
            try
            {
                dgvTransaksi.Rows.Clear();
                List<TransaksiModel> dataList = _transaksiController.AmbilLaporanKeuanganAdmin(filterMode);

                if (dataList == null) return;

                foreach (var item in dataList)
                {
                    // Membuat baris baru kosong terlebih dahulu untuk menghindari bentrokan indeks kolom desainer
                    int rowIndex = dgvTransaksi.Rows.Add();
                    DataGridViewRow row = dgvTransaksi.Rows[rowIndex];

                    // Pemetaan data secara eksplisit menggunakan Name Kolom / Indeks demi mencegah error "Field not found"
                    row.Cells[0].Value = item.IdTransaksi;

                    // Mengamankan pengisian sel bertahap jika jumlah kolom desainer Anda dinamis
                    if (row.Cells.Count > 1) row.Cells[1].Value = item.Kategori;
                    if (row.Cells.Count > 2) row.Cells[2].Value = item.Username;
                    if (row.Cells.Count > 3) row.Cells[3].Value = item.Nama;
                    if (row.Cells.Count > 4) row.Cells[4].Value = item.Kontak;
                    if (row.Cells.Count > 5) row.Cells[5].Value = item.NamaKendaraan;
                    if (row.Cells.Count > 6) row.Cells[6].Value = item.TipeKendaraan;
                    if (row.Cells.Count > 7) row.Cells[7].Value = item.NomorPlat;
                    if (row.Cells.Count > 8) row.Cells[8].Value = item.TanggalSewa;
                    if (row.Cells.Count > 9) row.Cells[9].Value = item.TanggalKembali;
                    if (row.Cells.Count > 10) row.Cells[10].Value = item.TanggalCharging;
                    if (row.Cells.Count > 11) row.Cells[11].Value = item.NamaStation;
                    if (row.Cells.Count > 12) row.Cells[12].Value = item.DurasiTransaksi;
                    if (row.Cells.Count > 13) row.Cells[13].Value = item.Status;
                    if (row.Cells.Count > 14) row.Cells[14].Value = item.TotalBiaya.ToString("C0", new System.Globalization.CultureInfo("id-ID"));

                    // Simpan data aslinya ke dalam properti Tag baris
                    row.Tag = item;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Memuat Data : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvTransaksi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Mewarnai teks status pada kolom indeks ke-13
            if (e.ColumnIndex == 13 && e.Value != null)
            {
                // Menetralkan string: mengubah underscore menjadi spasi dan huruf kecil semua
                string status = e.Value.ToString().ToLower().Replace("_", " ").Trim();
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                if (status == "selesai" || status == "sudah kembali" || status == "berhasil")
                    e.CellStyle.ForeColor = Color.FromArgb(92, 184, 92); // Hijau
                else if (status == "pending" || status == "belum kembali" || status == "mengisi daya")
                    e.CellStyle.ForeColor = Color.Orange; // Oranye
                else
                    e.CellStyle.ForeColor = Color.Red; // Merah jika gagal
            }
        }

        private void dgvTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (_isProcessing) return;

            try
            {
                _isProcessing = true;
                var colName = dgvTransaksi.Columns[e.ColumnIndex].Name;
                var p = dgvTransaksi.Rows[e.RowIndex].Tag as TransaksiModel;

                if (p == null) return;

                // 1. EVENT TOMBOL KONFIRMASI (PROSES CHARGING)
                if (colName == "btnKonfirmasi")
                {
                    string statusBersih = p.Status.ToLower().Replace("_", " ");

                    if (statusBersih != "pending")
                    {
                        MessageBox.Show("Transaksi ini sudah dikonfirmasi sebelumnya!", "EcoDrive Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult konfirmasi = MessageBox.Show($"Konfirmasi transaksi charging ini menjadi 'Mengisi Daya' untuk ID {p.IdTransaksi}?",
                        "EcoDrive Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (konfirmasi == DialogResult.Yes)
                    {
                        _transaksiController.ProsesKonfirmasiCharging(p.RawId);
                        MessageBox.Show($"Status Charging berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataSesuaiFilterAktif();
                    }
                }

                // 2. EVENT TOMBOL SELESAI (PROSES PENGEMBALIAN SEWA)
                if (colName == "btnSelesai")
                {
                    string statusBersih = p.Status.ToLower().Replace("_", " ");

                    if (statusBersih != "belum kembali" && statusBersih != "belum")
                    {
                        MessageBox.Show("Tombol ini hanya untuk transaksi Sewa yang berstatus 'Belum Kembali'!", "EcoDrive Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult konfirmasi = MessageBox.Show($"Selesaikan transaksi sewa ini menjadi 'Sudah Kembali' untuk ID {p.IdTransaksi}?",
                        "EcoDrive Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (konfirmasi == DialogResult.Yes)
                    {
                        _transaksiController.ProsesPenyelesaianSewa(p.RawId);
                        MessageBox.Show($"Status Pengembalian berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
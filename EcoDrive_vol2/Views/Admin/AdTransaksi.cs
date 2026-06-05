using EcoDrive_vol2.Context;
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

        private TransaksiService _transaksiService;
        private AdTransaksiContext _transaksiContext;
        private TransaksiChargingContext _chargingContext;
        private TransaksiSewaContext _sewaContext;
        private Controllers.Admin.AdTransaksiController _transaksiController;

        public AdTransaksi()
        {
            InitializeComponent();
            this.BackColor = bgUtama;
            _transaksiContext = new AdTransaksiContext();
            _chargingContext = new TransaksiChargingContext();
            _sewaContext = new TransaksiSewaContext();
            _transaksiService = new TransaksiService();
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
                List<TransaksiModel> dataList = _transaksiController.AmbilLaporanKeuanganAdmin(filterMode);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Memuat Data : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvTransaksi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = dgvTransaksi.Rows[e.RowIndex].Tag as TransaksiModel;
            if (item == null) return;

            string status = item.Status.ToLower().Replace("_", " ").Trim();

            if (e.ColumnIndex == 13 && e.Value != null)
            {
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                if (status == "selesai" || status == "sudah kembali" || status == "berhasil")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(92, 184, 92); // Hijau
                }

                else if (status == "pending" || status == "menunggu konfirmasi")
                {
                    e.CellStyle.ForeColor = Color.Blue; // blue
                }
                else if (status == "mengisi daya" || status == "belum kembali")
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
                else
                    e.CellStyle.ForeColor = Color.Red; // Merah jika gagal
            }
            if (dgvTransaksi.Columns[e.ColumnIndex].Name == "btnKonfirmasi")
            {
                var cell = dgvTransaksi.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
                if (cell != null)
                {
                    cell.FlatStyle = FlatStyle.Flat;
                    if (status == "pending")
                    {
                        e.CellStyle.BackColor = Color.FromArgb(0, 123, 255); // Blue
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.SelectionBackColor = Color.FromArgb(0, 105, 217);
                        e.CellStyle.SelectionForeColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.DarkGray;
                        e.CellStyle.SelectionBackColor = Color.LightGray;
                        e.CellStyle.SelectionForeColor = Color.DarkGray;
                    }
                }
            }
            if (dgvTransaksi.Columns[e.ColumnIndex].Name == "btnSelesai")
            {
                var cell = dgvTransaksi.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
                if (cell != null)
                {
                    cell.FlatStyle = FlatStyle.Flat;
                    if (status == "menunggu konfirmasi")
                    {
                        e.CellStyle.BackColor = Color.FromArgb(92, 184, 92); // ijo
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.SelectionBackColor = Color.FromArgb(68, 157, 68);
                        e.CellStyle.SelectionForeColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.DarkGray;
                        e.CellStyle.SelectionBackColor = Color.LightGray;
                        e.CellStyle.SelectionForeColor = Color.DarkGray;
                    }
                }
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
                var itemSewa = dgvTransaksi.Rows[e.RowIndex].Tag as TransaksiModel;

                if (itemSewa == null) return;

                // 1. EVENT TOMBOL KONFIRMASI (PROSES CHARGING)
                if (colName == "btnKonfirmasi")
                {
                    string statusBersih = itemSewa.Status.ToLower().Replace("_", " ");

                    if (statusBersih != "pending")
                    {
                        MessageBox.Show("Transaksi ini sudah dikonfirmasi sebelumnya!", "EcoDrive Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult konfirmasi = MessageBox.Show($"Konfirmasi transaksi charging ini menjadi 'Mengisi Daya' untuk ID {itemSewa.IdTransaksi}?",
                        "EcoDrive Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (konfirmasi == DialogResult.Yes)
                    {
                        _transaksiService.EksekusiKonfirmasiPengisianDaya(itemSewa);
                        MessageBox.Show($"Status Charging berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataSesuaiFilterAktif();
                    }
                }

                // 2. EVENT TOMBOL SELESAI (PROSES PENGEMBALIAN SEWA)
                if (colName == "btnSelesai")
                {
                    string statusBersih = itemSewa.Status.ToLower().Replace("_", " ");

                    if (statusBersih != "menunggu konfirmasi")
                    {
                        MessageBox.Show("Tombol ini hanya untuk transaksi Sewa yang berstatus 'Menunggu Konfirmasi'!", "EcoDrive Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult konfirmasi = MessageBox.Show($"Selesaikan transaksi sewa ini menjadi 'Sudah Kembali' untuk ID {itemSewa.IdTransaksi}?",
                        "EcoDrive Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (konfirmasi == DialogResult.Yes)
                    {
                        _transaksiService.EksekusiPenyelesaianSewa(itemSewa);
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
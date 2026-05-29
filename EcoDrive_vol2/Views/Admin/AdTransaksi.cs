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
        private AdTransaksiContext _transaksiContext;
        private TransaksiChargingContext _chargingContext;
        private TransaksiSewaContext _sewaContext;

        public AdTransaksi()
        {
            InitializeComponent();
            this.BackColor = bgUtama;

            _transaksiContext = new AdTransaksiContext();
            _chargingContext = new TransaksiChargingContext();
            _sewaContext = new TransaksiSewaContext();

            // Binding Event Filter Tombol Atas
            btnSemua.Click += FilterButton_Click;
            btnSewa.Click += FilterButton_Click;
            btnCharging.Click += FilterButton_Click;

            // =======================================================
            // 🟩 1. BUAT DUA KOLOM BUTTON DENGAN HEADER "AKSI"
            // =======================================================
            var btnKonfirmasi = new DataGridViewButtonColumn
            {
                HeaderText = "Aksi",       // Judul atas kolom tetap Aksi
                Name = "btnKonfirmasi",    // Nama ID Kolom untuk dibaca saat diklik
                Text = "Konfirmasi",       // Tulisan di dalam tombol
                UseColumnTextForButtonValue = true, // Kunci teks agar muncul di tombol
                FlatStyle = FlatStyle.Flat,
                Width = 90
            };
            dgvTransaksi.Columns.Add(btnKonfirmasi);

            var btnSelesai = new DataGridViewButtonColumn
            {
                HeaderText = "Aksi",       // Judul atas kolom tetap Aksi
                Name = "btnSelesai",       // Nama ID Kolom untuk dibaca saat diklik
                Text = "Selesaikan",       // Tulisan di dalam tombol
                UseColumnTextForButtonValue = true, // Kunci teks agar muncul di tombol
                FlatStyle = FlatStyle.Flat,
                Width = 90
            };
            dgvTransaksi.Columns.Add(btnSelesai);

            // Daftarkan Event ke Grid
            dgvTransaksi.CellFormatting += DgvTransaksi_CellFormatting;
            dgvTransaksi.CellContentClick += dgvTransaksi_CellContentClick; // Menggunakan CellContentClick pas sesuai contohmu

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

        private void TampilkanData(string filterMode)
        {
            try
            {
                dgvTransaksi.Rows.Clear();
                List<TransaksiModel> dataList = _transaksiContext.GetTransaksiBerdasarkanFilter(filterMode);

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
                MessageBox.Show("Error Memuat Data : " + ex.Message);
            }
        }

        private void DgvTransaksi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Logika mewarnai status (Misal kolom status ada di indeks 13)
            if (e.ColumnIndex == 13 && e.Value != null)
            {
                string status = e.Value.ToString().ToLower();
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                if (status == "selesai" || status == "sudah_kembali")
                    e.CellStyle.ForeColor = Color.FromArgb(92, 184, 92);
                else if (status == "pending" || status == "belum_kembali")
                    e.CellStyle.ForeColor = Color.Orange;
                else
                    e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void dgvTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (_isProcessing) return;

            try
            {
                var colName = dgvTransaksi.Columns[e.ColumnIndex].Name;
                var p = dgvTransaksi.Rows[e.RowIndex].Tag as TransaksiModel;
                if (p == null) return;

                // JIKA YANG DIKLIK ADALAH TOMBOL KONFIRMASI
                if (colName == "btnKonfirmasi")
                {
                    // Netralkan teks: ubah underscore menjadi spasi agar aman
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
                        try
                        {
                            _chargingContext.UpdateStatusCharging(p.RawId);
                            MessageBox.Show($"Status Charging berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshDataSesuaiFilterAktif();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                // JIKA YANG DIKLIK ADALAH TOMBOL SELESAI
                if (colName == "btnSelesai")
                {
                    // PERBAIKAN DI SINI: Ubah underscore menjadi spasi, lalu bandingkan dengan "belum kembali"
                    string statusBersih = p.Status.ToLower().Replace("_", " ");

                    if (statusBersih != "belum kembali")
                    {
                        MessageBox.Show("Tombol ini hanya untuk transaksi Sewa yang berstatus 'Belum Kembali'!", "EcoDrive Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult konfirmasi = MessageBox.Show($"Selesaikan transaksi sewa ini menjadi 'Sudah Kembali' untuk ID {p.IdTransaksi}?",
                        "EcoDrive Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (konfirmasi == DialogResult.Yes)
                    {
                        try
                        {
                            _sewaContext.UpdateStatusPengembalian(p.RawId);
                            MessageBox.Show($"Status Pengembalian berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshDataSesuaiFilterAktif();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 🔓 Buka kembali gerbang hanya jika MessageBox sudah tertutup dan dgv sukses ter-refresh
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
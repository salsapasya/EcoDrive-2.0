// Pastikan namespace controller customer sudah dipanggil dengan benar
using EcoDrive_vol2.Controllers.Customer;
using EcoDrive_vol2.Helpers;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class CusRiwayat : Form
    {
        private readonly Color bgUtama = Color.FromArgb(255, 253, 246);

        // SESUAIKAN DI SINI: Gunakan CusTransaksiController yang baru kita buat
        private readonly CusTransaksiController _transaksiController = new CusTransaksiController();

        public CusRiwayat()
        {
            InitializeComponent();
            this.BackColor = bgUtama;
        }

        private void CusRiwayat_Load(object sender, EventArgs e)
        {
            //// Konfigurasi Grid Tampilan DataGridView agar Rapi
            //dgvRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvRiwayat.AllowUserToAddRows = false;
            //dgvRiwayat.RowHeadersVisible = false;
            //dgvRiwayat.ReadOnly = true;
            //dgvRiwayat.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //dgvRiwayat.GridColor = Color.LightGray;

            LoadDataRiwayat();
        }

        private void LoadDataRiwayat()
        {
            //    try
            //    {
            ////    ////    //dgvRiwayat.Rows.Clear();

            //    ////    //// Hubungkan ke fungsi baru di controller (AmbilRiwayatSewaSaya)
            //    ////    //// Sementara masih hardcoded ID Customer = 2
            //    ////    //var dataRiwayat = _transaksiController.AmbilRiwayatSewaSaya(UserSession.IdUserAktif);

            //    ////    //foreach (var item in dataRiwayat)
            //    ////    //{
            //    ////    //    // Menampilkan data model TransaksiSewa ke dalam baris DataGridView
            //    ////    //    dgvRiwayat.Rows.Add(
            //    ////    //        item.IdTransaksiSewa,
            //    ////    //        item.NamaKendaraan,
            //    ////    //        item.TanggalSewa.ToString("dd MMM yyyy"), // Menggunakan format teks bulan agar lebih rapi
            //    ////    //        item.TanggalKembali.ToString("dd MMM yyyy"), // Masukkan tanggal kembali asli dari DB (menggantikan tanda "-")
            //    ////    //        item.DurasiSewa + " Hari",
            //    ////    //        item.StatusPengembalian.ToString().Replace("_", " ") // Format Enum agar tulisan '_' hilang saat di UI
            //    ////    //    );
            //    ////    }
            //    ////}
            //    ////catch (Exception ex)
            //    ////{
            //    ////    MessageBox.Show($"Gagal memuat riwayat transaksi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //}
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            // Menutup form riwayat untuk kembali ke tampilan utama panel dashboard
            this.Close();
        }

        private void dgvRiwayat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
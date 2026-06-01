using System;
using System.Drawing;
using System.Windows.Forms;
using EcoDrive_vol2.Controllers.Customer;

namespace EcoDrive_vol2.Views
{
    public partial class CusRiwayat : Form
    {
        private readonly Color bgUtama = Color.FromArgb(255, 253, 246);
        private readonly CusRiwayatController controller = new CusRiwayatController();

        public CusRiwayat()
        {
            InitializeComponent();
            this.BackColor = bgUtama;
        }

        private void CusRiwayat_Load(object sender, EventArgs e)
        {
            // Konfigurasi Grid Tampilan DataGridView agar Rapi
            dgvRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRiwayat.AllowUserToAddRows = false;
            dgvRiwayat.RowHeadersVisible = false;
            dgvRiwayat.ReadOnly = true;
            dgvRiwayat.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvRiwayat.GridColor = Color.LightGray; // Diubah ke abu-abu terang agar lebih modern

            LoadDataRiwayat();
        }

        private void LoadDataRiwayat()
        {
            try
            {
                dgvRiwayat.Rows.Clear();

                // Hardcoded ID Customer 2 untuk sementara
                var dataRiwayat = controller.GetRiwayat(2);

                foreach (var item in dataRiwayat)
                {
                    dgvRiwayat.Rows.Add(
                        item.IdTransaksiSewa,
                        item.IdKendaraan,
                        item.TanggalSewa.ToString("dd/MM/yyyy"),
                        item.DurasiSewa + " Hari",
                        "-",
                        item.StatusPengembalian
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat riwayat transaksi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SOLUSI: Mengikuti sistem arsitektur panel induk
        private void btnKembali_Click(object sender, EventArgs e)
        {
            // Karena form ini menempel di panel konten CusDasboard, 
            // kita cukup menutup form ini saja untuk kembali ke halaman utama dashboard.
            this.Close();
        }

        private void dgvRiwayat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
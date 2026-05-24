using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class AdCustomer : Form
    {
        // DataTable digunakan untuk menampung data master agar fitur pencarian & filter berjalan lancar
        private DataTable dtCustomer;

        public AdCustomer()
        {
            InitializeComponent();

            // Daftarkan event secara manual jika belum didaftarkan di Designer
            this.Load += AdCustomer_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;

            // Daftarkan event klik untuk tombol filter status
            btnSemua.Click += FilterButton_Click;
            btnAktif.Click += FilterButton_Click;
            btnNonAktif.Click += FilterButton_Click;

            // Daftarkan event klik sel untuk mendeteksi aksi (Detail/Edit/Hapus)
            dgvCustomer.CellContentClick += DgvCustomer_CellContentClick;
        }

        private void AdCustomer_Load(object sender, EventArgs e)
        {
            InisialisasiDataMaster();
            TampilkanDataKeGrid(""); // Tampilkan semua data di awal
        }

        private void InisialisasiDataMaster()
        {
            // Membuat struktur penyimpanan memori internal data customer
            dtCustomer = new DataTable();
            dtCustomer.Columns.Add("ID");
            dtCustomer.Columns.Add("CustomerData"); // Format internal: "Nama|Email"
            dtCustomer.Columns.Add("Kontak");
            dtCustomer.Columns.Add("Bergabung");
            dtCustomer.Columns.Add("TotalSewa");
            dtCustomer.Columns.Add("Status");
            dtCustomer.Columns.Add("Aksi");

            // Input Data Dummy sesuai dengan gambar mockup Anda
            dtCustomer.Rows.Add("CST-001", "Rian Pratama|rian@mail.com", "0812-3344-5566", "12 Mar 2024", "24 trip", "Aktif", "👁  ✏  🗑");
            dtCustomer.Rows.Add("CST-002", "Salsa Aulia|salsa@mail.com", "0813-1111-2222", "02 Apr 2024", "16 trip", "Aktif", "👁  ✏  🗑");
            dtCustomer.Rows.Add("CST-003", "Bagas Wicaksono|bagas@mail.com", "0821-9090-1010", "18 Apr 2024", "5 trip", "Non Aktif", "👁  ✏  🗑");
            dtCustomer.Rows.Add("CST-004", "Maya Kusuma|maya@mail.com", "0852-7878-3434", "05 Mei 2024", "31 trip", "Aktif", "👁  ✏  🗑");
            dtCustomer.Rows.Add("CST-005", "Adi Saputra|adi@mail.com", "0857-2323-4545", "11 Jun 2024", "9 trip", "Aktif", "👁  ✏  🗑");
            dtCustomer.Rows.Add("CST-006", "Nadia Lestari|nadia@mail.com", "0822-5656-7878", "23 Jul 2024", "2 trip", "Non Aktif", "👁  ✏  🗑");
        }

        private void TampilkanDataKeGrid(string filterExpression)
        {
            dgvCustomer.Rows.Clear();
            DataRow[] rows = dtCustomer.Select(filterExpression);

            foreach (DataRow row in rows)
            {
                dgvCustomer.Rows.Add(
                    row["ID"],
                    row["CustomerData"],
                    row["Kontak"],
                    row["Bergabung"],
                    row["TotalSewa"],
                    row["Status"],
                    row["Aksi"]
                );
            }
        }

        // --- 1. FITUR REAL-TIME SEARCH BAR ---
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Replace("🔍 Cari nama, email, ID...", "").Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                TampilkanDataKeGrid("");
            }
            else
            {
                // Melakukan pencarian fleksibel pada ID maupun Nama/Email Customer
                string filter = $"ID LIKE '%{keyword}%' OR CustomerData LIKE '%{keyword}%' OR Kontak LIKE '%{keyword}%'";
                TampilkanDataKeGrid(filter);
            }
        }

        // --- 2. FITUR TAB FILTER STATUS (Semua / Aktif / Non Aktif) ---
        private void FilterButton_Click(object sender, EventArgs e)
        {
            Button btnKlik = (Button)sender;

            // Reset semua style tombol filter ke warna dasar abu-abu
            ResetFilterButtonStyles();

            // Ubah tombol aktif menjadi Hijau Premium aplikasi
            btnKlik.BackColor = Color.FromArgb(92, 184, 92);
            btnKlik.ForeColor = Color.White;

            // Eksekusi pemfilteran data tabel
            if (btnKlik == btnSemua)
            {
                TampilkanDataKeGrid("");
            }
            else if (btnKlik == btnAktif)
            {
                TampilkanDataKeGrid("Status = 'Aktif'");
            }
            else if (btnKlik == btnNonAktif)
            {
                TampilkanDataKeGrid("Status = 'Non Aktif'");
            }
        }

        private void ResetFilterButtonStyles()
        {
            Color defaultBg = Color.FromArgb(248, 246, 242);
            Color defaultFg = Color.FromArgb(47, 47, 47);

            btnSemua.BackColor = defaultBg; btnSemua.ForeColor = defaultFg;
            btnAktif.BackColor = defaultBg; btnAktif.ForeColor = defaultFg;
            btnNonAktif.BackColor = defaultBg; btnNonAktif.ForeColor = defaultFg;
        }

        // --- 3. EVENT ACTION CELL CLICK (Mendeteksi klik tombol Detail, Edit, Hapus) ---
        private void DgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan yang diklik adalah baris data, bukan header tabel, dan berada di kolom "Aksi"
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCustomer.Columns["colAksi"].Index)
            {
                string idCustomer = dgvCustomer.Rows[e.RowIndex].Cells["colId"].Value.ToString();
                string fullData = dgvCustomer.Rows[e.RowIndex].Cells["colCustomer"].Value.ToString();
                string namaCustomer = fullData.Split('|')[0];

                // Tips implementasi interaksi aksi kustom:
                // Di sini Anda bisa memunculkan dialog form edit atau mengambil data indeks terpilih
                MessageBox.Show($"Anda memilih data: {namaCustomer} ({idCustomer})", "EcoDrive Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- 4. TOMBOL TAMBAH CUSTOMER ---
        private void btnTambah_Click(object sender, EventArgs e)
        {
            // Contoh simulasi penambahan data baru secara dinamis ke tabel master
            using (Form formPopup = new Form())
            {
                formPopup.Text = "Form Tambah Customer Baru";
                formPopup.Size = new Size(400, 300);
                formPopup.StartPosition = FormStartPosition.CenterParent;
                formPopup.ShowDialog(this);
            }

            // Catatan: Setelah form popup input selesai disimpan, panggil 'InisialisasiDataMaster()' 
            // kembali untuk memperbarui database/data internal Anda.
        }

        private void btnAktif_Click(object sender, EventArgs e)
        {

        }

        private void btnSemua_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

        }
    }
}
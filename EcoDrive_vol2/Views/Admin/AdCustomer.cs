using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models.Users;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Views
{
    public partial class AdCustomer : Form
    {
        private UserContext context;
        private DataTable dtCustomer;
        private string filterAktif = "";

        public AdCustomer()
        {
            InitializeComponent();
            context = new UserContext();

            this.Load += AdCustomer_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;

            btnSemua.Click += FilterButton_Click;
            btnAktif.Click += FilterButton_Click;
            btnNonAktif.Click += FilterButton_Click;

            // ⚙️ Menghubungkan tracking klik mouse untuk mendeteksi tombol "Kelola" di dalam kartu
            dgvCustomer.CellClick += dgvCustomer_CellClick;
        }

        private void AdCustomer_Load(object sender, EventArgs e)
        {
            // Set warna awal tombol 'Semua' agar langsung aktif saat halaman dimuat
            btnSemua.BackColor = Color.FromArgb(76, 175, 80);
            btnSemua.ForeColor = Color.White;

            RefreshDataDariDatabase();
        }

        private void RefreshDataDariDatabase()
        {
            try
            {
                dtCustomer = context.GetAllCustomersForGrid();
                ApplyFilterDanPencarian();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Load Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilterDanPencarian()
        {
            if (dtCustomer == null) return;

            string keyword = txtSearch.Text.Replace("🔍 Cari nama, email, ID...", "").Trim().ToLower();
            string expression = "";

            if (!string.IsNullOrEmpty(filterAktif))
            {
                expression = $"status = '{filterAktif}'";
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                string searchExpr = $"(id_user LIKE '%{keyword}%' OR customer_data LIKE '%{keyword}%' OR kontak LIKE '%{keyword}%')";
                if (!string.IsNullOrEmpty(expression))
                {
                    expression += $" AND {searchExpr}";
                }
                else
                {
                    expression = searchExpr;
                }
            }

            TampilkanDataKeGrid(expression);
        }

        private void TampilkanDataKeGrid(string filterExpression)
        {
            if (dtCustomer == null) return;

            dgvCustomer.Rows.Clear();

            DataRow[] rows = string.IsNullOrWhiteSpace(filterExpression)
                ? dtCustomer.Select()
                : dtCustomer.Select(filterExpression);

            foreach (DataRow row in rows)
            {
                // Satukan semua parameter ke dalam satu sel tersembunyi untuk dibaca oleh CellPainting
                string id = row["id_user"]?.ToString() ?? "0";
                string customerData = row["customer_data"]?.ToString() ?? "Tanpa Nama|";
                string kontak = row["kontak"]?.ToString() ?? "-";
                string bergabung = row["bergabung"]?.ToString() ?? "Member";
                string totalSewa = row["total_sewa"]?.ToString() ?? "0 trip";
                string status = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(row["status"]?.ToString()?.Trim().ToLower() ?? "aktif");

                // Gabungkan seluruh data dengan delimiter '|'
                string paketDataKartu = $"{customerData}|{kontak}|{bergabung}|{totalSewa}|{status}";

                // Tambahkan ke Grid (Hanya ID dan Paket Data)
                dgvCustomer.Rows.Add(id, paketDataKartu);
            }

            dgvCustomer.Invalidate();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterDanPencarian();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            Button btnKlik = (Button)sender;
            ResetFilterButtonStyles();

            // Set tombol aktif menjadi Hijau EcoDrive sesuai referensi UI Kendaraan
            btnKlik.BackColor = Color.FromArgb(76, 175, 80);
            btnKlik.ForeColor = Color.White;

            if (btnKlik == btnSemua) filterAktif = "";
            else if (btnKlik == btnAktif) filterAktif = "aktif";
            else if (btnKlik == btnNonAktif) filterAktif = "non aktif";

            ApplyFilterDanPencarian();
        }

        private void ResetFilterButtonStyles()
        {
            // Mengubah background pasif menjadi abu-abu terang minimalis modern
            Color defaultBg = Color.FromArgb(245, 245, 245);
            Color defaultFg = Color.FromArgb(47, 47, 47);

            btnSemua.BackColor = defaultBg; btnSemua.ForeColor = defaultFg;
            btnAktif.BackColor = defaultBg; btnAktif.ForeColor = defaultFg;
            btnNonAktif.BackColor = defaultBg; btnNonAktif.ForeColor = defaultFg;
        }

        // 🛠️ LOGIKA DIKLIK: HIT-BOX TRACKING UNTUK TOMBOL "KELOLA ⚙️" DI DALAM KARTU
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Hitung koordinat tombol kelola pada kartu baris bersangkutan
            Rectangle rowBounds = dgvCustomer.GetRowDisplayRectangle(e.RowIndex, true);
            int paddingBaris = 8;
            Rectangle cardRect = new Rectangle(rowBounds.X + 15, rowBounds.Y + paddingBaris, dgvCustomer.Width - 50, rowBounds.Height - (paddingBaris * 2));

            int btnW = 110, btnH = 34;
            int btnX = cardRect.Right - btnW - 30;
            int btnY = cardRect.Y + (cardRect.Height - btnH) / 2;

            // Periksa posisi kursor mouse
            Point mousePos = dgvCustomer.PointToClient(Cursor.Position);
            Rectangle btnKelolaHitBox = new Rectangle(btnX, btnY, btnW, btnH);

            // Jika kursor tepat menekan tombol Kelola di dalam area kartu
            if (btnKelolaHitBox.Contains(mousePos))
            {
                string idUser = dgvCustomer.Rows[e.RowIndex].Cells[0].Value?.ToString();
                string fullData = dgvCustomer.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "Customer";
                string namaCustomer = fullData.Split('|')[0];

                // Menampilkan opsi aksi (bisa Anda ganti untuk memanggil sub-form edit/hapus milik Anda)
                MessageBox.Show($"Membuka Panel Kontrol untuk:\nNama: {namaCustomer}\nID Customer: {idUser}", "EcoDrive Manajemen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            // Buka form tambah customer Anda di sini sejenis dengan form kendaraan
            RefreshDataDariDatabase();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kelola Data Customer EcoDrive v2", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- BACKEND LOGIC UNTUK PROSES EDIT STATUS / HAPUS (DAPAT DIPANGGIL DI PANEL MANAJEMEN) ---
        private void UbahStatusKeAktif(int idUser)
        {
            try
            {
                Users user = context.GetAllUsers().Find(u => u.IdUser == idUser);
                if (user != null)
                {
                    user.StatusAkun = StatusAkun.aktif;
                    context.UpdateUser(user);
                    MessageBox.Show("Status customer berhasil diubah menjadi Aktif", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataDariDatabase();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void UbahStatusKeNonAktif(int idUser)
        {
            try
            {
                Users user = context.GetAllUsers().Find(u => u.IdUser == idUser);
                if (user != null)
                {
                    user.StatusAkun = StatusAkun.non_aktif;
                    context.UpdateUser(user);
                    MessageBox.Show("Status customer berhasil diubah menjadi Non Aktif", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataDariDatabase();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void HapusCustomer(int idUser, string nama)
        {
            DialogResult hasil = MessageBox.Show($"Yakin ingin menghapus customer {nama}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hasil == DialogResult.Yes)
            {
                try
                {
                    context.DeleteUser(idUser);
                    MessageBox.Show("Customer berhasil dihapus dari database", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataDariDatabase();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
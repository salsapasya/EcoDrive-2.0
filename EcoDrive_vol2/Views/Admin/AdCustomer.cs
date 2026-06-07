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

            dgvCustomer.CellContentClick += dgvCustomer_CellContentClick;
        }

        private void AdCustomer_Load(object sender, EventArgs e)
        {
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
            dgvCustomer.Rows.Clear();
            DataRow[] rows = dtCustomer.Select(filterExpression);

            foreach (DataRow row in rows)
            {
                string statusTampilan = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(row["status"].ToString());

                dgvCustomer.Rows.Add(
                    row["id_user"],
                    row["customer_data"],
                    row["kontak"],
                    row["bergabung"],
                    row["total_sewa"],
                    statusTampilan,
                    row["aksi"]
                );
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterDanPencarian();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            Button btnKlik = (Button)sender;
            ResetFilterButtonStyles();

            btnKlik.BackColor = Color.FromArgb(92, 184, 92);
            btnKlik.ForeColor = Color.White;

            if (btnKlik == btnSemua) filterAktif = "";
            else if (btnKlik == btnAktif) filterAktif = "aktif";
            else if (btnKlik == btnNonAktif) filterAktif = "non aktif";

            ApplyFilterDanPencarian();
        }

        private void ResetFilterButtonStyles()
        {
            Color defaultBg = Color.FromArgb(248, 246, 242);
            Color defaultFg = Color.FromArgb(47, 47, 47);

            btnSemua.BackColor = defaultBg; btnSemua.ForeColor = defaultFg;
            btnAktif.BackColor = defaultBg; btnAktif.ForeColor = defaultFg;
            btnNonAktif.BackColor = defaultBg; btnNonAktif.ForeColor = defaultFg;
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomer.Columns[e.ColumnIndex].Name == "colAksi")
            {
                string idUser = dgvCustomer.Rows[e.RowIndex].Cells["colId"].Value.ToString();
                string fullData = dgvCustomer.Rows[e.RowIndex].Cells["colCustomer"].Value.ToString();
                string namaCustomer = fullData.Split('|')[0];

                MessageBox.Show($"Kelola data untuk: {namaCustomer} (ID: {idUser})", "EcoDrive Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- TOMBOL AKSI CEPAT: UBAH STATUS JADI AKTIF ---
        private void btnAktifAction_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow != null)
            {
                int idUser = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["colId"].Value);
                try
                {
                    Users user = context.GetAllUsers().Find(u => u.IdUser == idUser);
                    if (user != null)
                    {
                        user.StatusAkun = StatusAkun.aktif; // Menggunakan enum 'aktif' (huruf kecil)
                        context.UpdateUser(user);
                        MessageBox.Show("Status customer berhasil diubah menjadi Aktif", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataDariDatabase();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- TOMBOL AKSI CEPAT: UBAH STATUS JADI NON-AKTIF ---
        private void btnNonAktifAction_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow != null)
            {
                int idUser = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["colId"].Value);
                try
                {
                    Users user = context.GetAllUsers().Find(u => u.IdUser == idUser);
                    if (user != null)
                    {
                        user.StatusAkun = StatusAkun.non_aktif; // Menggunakan enum 'non_aktif' (huruf kecil & underscore)
                        context.UpdateUser(user);
                        MessageBox.Show("Status customer berhasil diubah menjadi Non Aktif", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataDariDatabase();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- TOMBOL AKSI CEPAT: HAPUS CUSTOMER ---
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow != null)
            {
                int idUser = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["colId"].Value);
                string fullData = dgvCustomer.CurrentRow.Cells["colCustomer"].Value.ToString();
                string namaCustomer = fullData.Split('|')[0];

                DialogResult hasil = MessageBox.Show(
                    $"Yakin ingin menghapus customer {namaCustomer}?",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (hasil == DialogResult.Yes)
                {
                    try
                    {
                        context.DeleteUser(idUser);
                        MessageBox.Show("Customer berhasil dihapus dari database", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataDariDatabase();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            RefreshDataDariDatabase();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kelola Data Customer EcoDrive", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
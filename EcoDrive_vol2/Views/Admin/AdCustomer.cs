using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using EcoDrive_vol2.Context;
using EcoDrive_vol2.Service;

namespace EcoDrive_vol2.Views
{
    public partial class AdCustomer : Form
    {
        private UserContext context;
        private DataTable dtCustomer;
        private string filterAktif = "";

        // Daftarkan Service Pengolah Logika Kelola Akun Customer
        private readonly CustomerManagementService _customerService = new CustomerManagementService();

        // 🎨 PALET WARNA MODERN DASHBOARD (Sesuai Referensi Grid)
        private readonly Color COLOR_PRIMARY = Color.FromArgb(76, 175, 80);        // Hijau EcoDrive
        private readonly Color COLOR_HEADER_BG = Color.FromArgb(253, 253, 240);    // Krem Sangat Terang (Header)
        private readonly Color COLOR_TEXT_DARK = Color.FromArgb(47, 47, 47);       // Abu Gelap/Hitam Tulisan Utama
        private readonly Color COLOR_TEXT_MUTED = Color.FromArgb(115, 115, 115);   // Abu-abu Elegan untuk Sub-info
        private readonly Color COLOR_GRID_LINE = Color.FromArgb(238, 238, 238);    // Garis tipis antar baris

        // Warna Status Badge (Pill)
        private readonly Color BG_BADGE_ACTIVE = Color.FromArgb(200, 230, 201);   // Hijau Muda Pastel
        private readonly Color FG_BADGE_ACTIVE = Color.FromArgb(56, 142, 60);     // Hijau Tua Text
        private readonly Color BG_BADGE_INACTIVE = Color.FromArgb(255, 205, 210); // Merah Muda Pastel
        private readonly Color FG_BADGE_INACTIVE = Color.FromArgb(211, 47, 47);   // Merah Tua Text

        // Warna Latar Belakang Avatar Bulat (Bervariasi per baris agar estetik)
        private readonly Color[] AVATAR_COLORS = new Color[] {
            Color.FromArgb(232, 245, 233), // Hijau Soft
            Color.FromArgb(225, 245, 254), // Biru Soft
            Color.FromArgb(255, 243, 224), // Oranye Soft
            Color.FromArgb(243, 229, 245)  // Ungu Soft
        };

        public AdCustomer()
        {
            InitializeComponent();
            context = new UserContext();

            this.Load += AdCustomer_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;

            btnSemua.Click += FilterButton_Click;
            btnAktif.Click += FilterButton_Click;
            btnNonAktif.Click += FilterButton_Click;

            // Daftarkan event penggambaran kustom untuk elemen visual tertentu (Avatar & Status)
            dgvCustomer.CellPainting += dgvCustomer_CellPainting;
            dgvCustomer.CellMouseClick += dgvCustomer_CellMouseClick;
        }

        private void AdCustomer_Load(object sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            UpdateFilterButtonVisuals();
            RefreshDataDariDatabase();
        }

        /// <summary>
        /// Mengatur pembagian section kolom secara rapi, berjarak ideal, dan terstruktur
        /// </summary>
        private void SetupDataGridViewStyle()
        {
            dgvCustomer.BackgroundColor = Color.White;
            dgvCustomer.BorderStyle = BorderStyle.None;
            dgvCustomer.RowHeadersVisible = false;
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AllowUserToResizeRows = false;
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Mengatur tinggi baris agar lega untuk menampung dua tingkat info (Nama & ID/Username)
            dgvCustomer.RowTemplate.Height = 70;
            dgvCustomer.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvCustomer.GridColor = COLOR_GRID_LINE;
            dgvCustomer.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Styling Header Berwarna Krem Lembut sesuai Gambar Referensi
            dgvCustomer.EnableHeadersVisualStyles = false;
            dgvCustomer.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCustomer.ColumnHeadersDefaultCellStyle.BackColor = COLOR_HEADER_BG;
            dgvCustomer.ColumnHeadersDefaultCellStyle.ForeColor = COLOR_TEXT_DARK;
            dgvCustomer.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            dgvCustomer.ColumnHeadersHeight = 45;

            // Styling Default Cell text umum
            dgvCustomer.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 249, 248);
            dgvCustomer.DefaultCellStyle.SelectionForeColor = COLOR_TEXT_DARK;
            dgvCustomer.DefaultCellStyle.ForeColor = COLOR_TEXT_MUTED;
            dgvCustomer.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            // 🏛️ STRUKTURISASI ULANG KOMPONEN PER KOLOM (Disesuaikan penuh secara sinkron)
            dgvCustomer.Columns.Clear();
            dgvCustomer.Columns.Add("id_raw", "ID Murni"); // Kolom bantu tersembunyi
            dgvCustomer.Columns["id_raw"].Visible = false;

            // Daftarkan seluruh kolom secara berurutan agar tidak terjadi crash / data bergeser
            dgvCustomer.Columns.Add("profil_customer", "Pelanggan");
            dgvCustomer.Columns.Add("username", "Username");
            dgvCustomer.Columns.Add("telepon", "No. HP");
            dgvCustomer.Columns.Add("saldo", "Saldo");
            dgvCustomer.Columns.Add("status", "Status");

            // Tombol Kelola Akun berbentuk Kapsul Hijau
            DataGridViewButtonColumn btnKolomAksi = new DataGridViewButtonColumn();
            btnKolomAksi.Name = "btnAksi";
            btnKolomAksi.HeaderText = "Aksi";
            btnKolomAksi.Text = "Kelola ⚙️";
            btnKolomAksi.UseColumnTextForButtonValue = true;
            btnKolomAksi.FlatStyle = FlatStyle.Flat;
            btnKolomAksi.DefaultCellStyle.BackColor = COLOR_PRIMARY;
            btnKolomAksi.DefaultCellStyle.ForeColor = Color.White;
            btnKolomAksi.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 143, 63);
            btnKolomAksi.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvCustomer.Columns.Add(btnKolomAksi);

            // 📐 Pengaturan Proporsi Lebar Section Kolom (Total yang pas dan seimbang)
            dgvCustomer.Columns["profil_customer"].Width = 230;
            dgvCustomer.Columns["username"].Width = 140;
            dgvCustomer.Columns["telepon"].Width = 140;
            dgvCustomer.Columns["saldo"].Width = 140;
            dgvCustomer.Columns["status"].Width = 110;
            dgvCustomer.Columns["btnAksi"].Width = 110;

            // Penyelarasan Posisi Konten Data (Alignment)
            dgvCustomer.Columns["saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCustomer.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomer.Columns["btnAksi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomer.Columns["status"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomer.Columns["btnAksi"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

            string keyword = txtSearch.Text.Trim().ToLower();
            string expression = "";

            if (!string.IsNullOrEmpty(filterAktif))
            {
                expression = $"status_akun = '{filterAktif}'";
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                // Memperbaiki string kustom ekspresi filter agar tidak error compile
                string searchExpr = $"(Convert(id_user, 'System.String') LIKE '%{keyword}%' " +
                                    $"OR nama_user LIKE '%{keyword}%' " +
                                    $"OR username LIKE '%{keyword}%' " +
                                    $"OR no_telp_user LIKE '%{keyword}%')";

                if (!string.IsNullOrEmpty(expression)) expression += $" AND {searchExpr}";
                else expression = searchExpr;
            }

            TampilkanDataKeGrid(expression);
        }

        private void TampilkanDataKeGrid(string filterExpression)
        {
            if (dtCustomer == null || dgvCustomer.Columns.Count == 0) return;

            dgvCustomer.Rows.Clear();

            DataRow[] rows = string.IsNullOrWhiteSpace(filterExpression)
                ? dtCustomer.Select()
                : dtCustomer.Select(filterExpression);

            foreach (DataRow row in rows)
            {
                string rawId = row["id_user"]?.ToString() ?? "0";
                string idFormatted = "CUST-" + rawId.PadLeft(3, '0');
                string nama = row["nama_user"]?.ToString() ?? "Tanpa Nama";
                string username = row["username"]?.ToString() ?? "-";
                string noHp = row["no_telp_user"]?.ToString() ?? "-";

                decimal saldo = row["saldo"] != DBNull.Value ? Convert.ToDecimal(row["saldo"]) : 0;
                string saldoText = "Rp " + saldo.ToString("N0");

                string status = row["status_akun"]?.ToString()?.Trim().ToLower() ?? "aktif";
                status = (status == "aktif") ? "Active" : "Inactive";

                // Memasukkan data HARUS BERURUTAN persis dengan skema dgvCustomer.Columns.Add di atas!
                dgvCustomer.Rows.Add(
                    rawId,              // id_raw (Hidden)
                    $"{nama}|{idFormatted}", // profil_customer (Dipecah di CellPainting)
                    username,           // username
                    noHp,               // telepon
                    saldoText,          // saldo
                    status              // status
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

            if (btnKlik == btnSemua) filterAktif = "";
            else if (btnKlik == btnAktif) filterAktif = "aktif";
            else if (btnKlik == btnNonAktif) filterAktif = "non aktif";

            UpdateFilterButtonVisuals();
            ApplyFilterDanPencarian();
        }

        private void UpdateFilterButtonVisuals()
        {
            Color passifBg = Color.White;
            Color passifFg = COLOR_TEXT_DARK;

            btnSemua.BackColor = passifBg; btnSemua.ForeColor = passifFg;
            btnAktif.BackColor = passifBg; btnAktif.ForeColor = passifFg;
            btnNonAktif.BackColor = passifBg; btnNonAktif.ForeColor = passifFg;

            if (filterAktif == "") { btnSemua.BackColor = COLOR_PRIMARY; btnSemua.ForeColor = Color.White; }
            else if (filterAktif == "aktif") { btnAktif.BackColor = COLOR_PRIMARY; btnAktif.ForeColor = Color.White; }
            else if (filterAktif == "non aktif") { btnNonAktif.BackColor = COLOR_PRIMARY; btnNonAktif.ForeColor = Color.White; }
        }

        /// <summary>
        /// 🎨 CUSTOM CELL PAINTING: Menggambar elemen grafis Avatar Bulat dan Status Badge agar presisi di jalurnya
        /// </summary>
        private void dgvCustomer_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 1. MENGGAMBAR SECTION PROFIL CUSTOMER (Avatar + Nama + ID Bertingkat)
            if (dgvCustomer.Columns[e.ColumnIndex].Name == "profil_customer")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                if (e.Value != null)
                {
                    string[] stringParts = e.Value.ToString().Split('|');
                    string namaPelanggan = stringParts[0];
                    string detailID = stringParts.Length > 1 ? stringParts[1] : "";

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // A. Gambar Avatar Lingkaran
                    int avatarSize = 40;
                    int avatarX = e.CellBounds.X + 12;
                    int avatarY = e.CellBounds.Y + (e.CellBounds.Height - avatarSize) / 2;
                    Rectangle rectAvatar = new Rectangle(avatarX, avatarY, avatarSize, avatarSize);

                    Color bgAvatar = AVATAR_COLORS[e.RowIndex % AVATAR_COLORS.Length];
                    string inisial = namaPelanggan.Length >= 2 ? namaPelanggan.Substring(0, 2).ToUpper() : namaPelanggan.Substring(0, 1).ToUpper();

                    using (SolidBrush brushAvatar = new SolidBrush(bgAvatar))
                    {
                        e.Graphics.FillEllipse(brushAvatar, rectAvatar);
                    }

                    Font fontInisial = new Font("Segoe UI", 10, FontStyle.Bold);
                    TextRenderer.DrawText(e.Graphics, inisial, fontInisial, rectAvatar, FG_BADGE_ACTIVE,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    // B. Tulis Nama Pelanggan (Bold & Gelap)
                    Font fontNama = new Font("Segoe UI", 10, FontStyle.Bold);
                    int textStartX = avatarX + avatarSize + 12;
                    Point posNama = new Point(textStartX, e.CellBounds.Y + 15);
                    TextRenderer.DrawText(e.Graphics, namaPelanggan, fontNama, posNama, COLOR_TEXT_DARK);

                    // C. Tulis Sub-Info ID di bawah Nama (Abu-abu Muted)
                    Font fontSub = new Font("Segoe UI", 8.5f, FontStyle.Regular);
                    Point posSub = new Point(textStartX, e.CellBounds.Y + 37);
                    TextRenderer.DrawText(e.Graphics, detailID, fontSub, posSub, COLOR_TEXT_MUTED);
                }
                e.Handled = true;
            }

            // 2. MENGGAMBAR PILL BADGE ELEGAN DI KOLOM STATUS (Tidak akan bergeser lagi)
            if (dgvCustomer.Columns[e.ColumnIndex].Name == "status")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                if (e.Value != null)
                {
                    string statusText = e.Value.ToString();
                    Color bgBadge = (statusText == "Active") ? BG_BADGE_ACTIVE : BG_BADGE_INACTIVE;
                    Color fgBadge = (statusText == "Active") ? FG_BADGE_ACTIVE : FG_BADGE_INACTIVE;

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    int badgeWidth = 75;
                    int badgeHeight = 24;
                    int badgeX = e.CellBounds.X + (e.CellBounds.Width - badgeWidth) / 2;
                    int badgeY = e.CellBounds.Y + (e.CellBounds.Height - badgeHeight) / 2;
                    Rectangle rectBadge = new Rectangle(badgeX, badgeY, badgeWidth, badgeHeight);

                    using (GraphicsPath path = GetRoundRectPath(rectBadge, 11))
                    using (SolidBrush brushBg = new SolidBrush(bgBadge))
                    {
                        e.Graphics.FillPath(brushBg, path);
                        Font fontBadge = new Font("Segoe UI", 8.5f, FontStyle.Bold);
                        TextRenderer.DrawText(e.Graphics, statusText, fontBadge, rectBadge, fgBadge,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                }
                e.Handled = true;
            }

            // 3. MENGGAMBAR KAPSUL TOMBOL AKSI
            if (dgvCustomer.Columns[e.ColumnIndex].Name == "btnAksi")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int btnW = 95;
                int btnH = 28;
                int btnX = e.CellBounds.X + (e.CellBounds.Width - btnW) / 2;
                int btnY = e.CellBounds.Y + (e.CellBounds.Height - btnH) / 2;
                Rectangle rectBtn = new Rectangle(btnX, btnY, btnW, btnH);

                bool isSelected = dgvCustomer.Rows[e.RowIndex].Selected;
                Color currentBtnBg = isSelected ? Color.FromArgb(60, 143, 63) : COLOR_PRIMARY;

                using (GraphicsPath path = GetRoundRectPath(rectBtn, 8))
                using (SolidBrush brush = new SolidBrush(currentBtnBg))
                {
                    e.Graphics.FillPath(brush, path);
                    Font fontBtn = new Font("Segoe UI", 8.5f, FontStyle.Bold);
                    TextRenderer.DrawText(e.Graphics, "Kelola", fontBtn, rectBtn, Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                e.Handled = true;
            }
        }

        private GraphicsPath GetRoundRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// MANAJEMEN AKSI: Membuka drop-down menu interaktif saat tombol Kelola diklik
        /// </summary>
        private void dgvCustomer_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvCustomer.Columns[e.ColumnIndex].Name != "btnAksi")
                return;

            string idRaw = dgvCustomer.Rows[e.RowIndex].Cells["id_raw"].Value?.ToString() ?? "0";
            int idUser = int.TryParse(idRaw, out int parsed) ? parsed : 0;

            string fullCellInfo = dgvCustomer.Rows[e.RowIndex].Cells["profil_customer"].Value?.ToString() ?? "";
            string namaCustomer = fullCellInfo.Split('|')[0];

            ShowCustomerMenu(idUser, namaCustomer);
        }

        private void ShowCustomerMenu(int idUser, string namaCustomer)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.RenderMode = ToolStripRenderMode.System;
            menu.BackColor = Color.White;
            menu.ShowImageMargin = false;

            ToolStripLabel lblNama = new ToolStripLabel(namaCustomer);
            lblNama.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblNama.ForeColor = COLOR_TEXT_DARK;

            ToolStripLabel lblId = new ToolStripLabel($"ID Customer : {idUser}");
            lblId.ForeColor = COLOR_TEXT_MUTED;

            menu.Items.Add(lblNama);
            menu.Items.Add(lblId);
            menu.Items.Add(new ToolStripSeparator());

            menu.Items.Add("✅ Aktifkan Akun", null, (s, e) => UbahStatusKeAktif(idUser));
            menu.Items.Add("⛔ Nonaktifkan Akun", null, (s, e) => UbahStatusKeNonAktif(idUser));
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("🗑 Hapus Customer", null, (s, e) => HapusCustomer(idUser, namaCustomer));

            menu.Show(Cursor.Position);
        }

        // --- CORE BACKEND DATABASE OPERATION ---
        private void UbahStatusKeAktif(int idUser)
        {
            try
            {
                _customerService.AktifkanCustomer(idUser);
                MessageBox.Show("Status customer berhasil diubah menjadi Active", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataDariDatabase();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void UbahStatusKeNonAktif(int idUser)
        {
            try
            {
                _customerService.AktifkanCustomer(idUser);
                MessageBox.Show("Status customer berhasil diubah menjadi Inactive", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataDariDatabase();
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
                    _customerService.HapusCustomerDariDatabase(idUser);
                    MessageBox.Show("Customer berhasil dihapus dari database", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataDariDatabase();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
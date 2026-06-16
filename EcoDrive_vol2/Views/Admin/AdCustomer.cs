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

        private readonly CustomerManagementService _customerService = new CustomerManagementService();

        private readonly Color COLOR_PRIMARY = Color.FromArgb(76, 175, 80);       
        private readonly Color COLOR_TEXT_DARK = Color.FromArgb(47, 47, 47);     
        private readonly Color COLOR_TEXT_MUTED = Color.FromArgb(140, 140, 140);   
        private readonly Color COLOR_CARD_BORDER = Color.FromArgb(230, 235, 230);
        private readonly Color BG_BADGE_ACTIVE = Color.FromArgb(232, 245, 233);   
        private readonly Color FG_BADGE_ACTIVE = Color.FromArgb(56, 142, 60);     
        private readonly Color BG_BADGE_INACTIVE = Color.FromArgb(255, 235, 235); 
        private readonly Color FG_BADGE_INACTIVE = Color.FromArgb(211, 47, 47); 

        private readonly Color[] AVATAR_COLORS = new Color[] {
            Color.FromArgb(232, 245, 233), 
            Color.FromArgb(225, 245, 254), 
            Color.FromArgb(255, 243, 224), 
            Color.FromArgb(243, 229, 245)  
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

            dgvCustomer.CellPainting += DgvCustomer_CellPainting;
            dgvCustomer.CellMouseClick += dgvCustomer_CellMouseClick;
        }

        private void AdCustomer_Load(object sender, EventArgs e)
        {
            UpdateFilterButtonVisuals();
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

            string keyword = txtSearch.Text.Trim().ToLower();
            string expression = "";

            if (!string.IsNullOrEmpty(filterAktif))
            {
                expression = $"status_akun = '{filterAktif}'";
            }

            if (!string.IsNullOrEmpty(keyword))
            {
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
                status = (status == "aktif" || status == "active") ? "Active" : "Inactive";

                string combinedCardData = $"{nama}|{idFormatted}|{username}|{noHp}|{saldoText}|{status}";

                dgvCustomer.Rows.Add(rawId, combinedCardData);
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
            else if (btnKlik == btnNonAktif) filterAktif = "diblokir";

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
            else if (filterAktif == "diblokir") { btnNonAktif.BackColor = COLOR_PRIMARY; btnNonAktif.ForeColor = Color.White; }
        }

        private void DgvCustomer_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvCustomer.Columns[e.ColumnIndex].Name == "colCard")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background);

                if (e.Value != null)
                {
                    string[] split = e.Value.ToString().Split('|');
                    string namaPelanggan = split[0];
                    string detailID = split.Length > 1 ? split[1] : "";
                    string username = split.Length > 2 ? split[2] : "";
                    string noHp = split.Length > 3 ? split[3] : "";
                    string saldoText = split.Length > 4 ? split[4] : "Rp 0";
                    string statusText = split.Length > 5 ? split[5] : "Active";

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    int margin = 6;
                    Rectangle rectCard = new Rectangle(e.CellBounds.X + margin, e.CellBounds.Y + margin,
                                                       e.CellBounds.Width - (margin * 2), e.CellBounds.Height - (margin * 2));

                    using (GraphicsPath pathCard = GetRoundRectPath(rectCard, 8))
                    using (SolidBrush brushWhite = new SolidBrush(Color.White))
                    using (Pen penBorder = new Pen(COLOR_CARD_BORDER, 1f))
                    {
                        e.Graphics.FillPath(brushWhite, pathCard);
                        e.Graphics.DrawPath(penBorder, pathCard);
                    }

                    int avatarSize = 44;
                    int avatarX = rectCard.X + 16;
                    int avatarY = rectCard.Y + (rectCard.Height - avatarSize) / 2;
                    Rectangle rectAvatar = new Rectangle(avatarX, avatarY, avatarSize, avatarSize);

                    Color bgAvatar = AVATAR_COLORS[e.RowIndex % AVATAR_COLORS.Length];
                    string inisial = namaPelanggan.Length >= 2 ? namaPelanggan.Substring(0, 2).ToUpper() : namaPelanggan.Substring(0, 1).ToUpper();

                    using (SolidBrush brushAvatar = new SolidBrush(bgAvatar))
                    {
                        e.Graphics.FillEllipse(brushAvatar, rectAvatar);
                    }
                    Font fontInisial = new Font("Segoe UI", 10f, FontStyle.Bold);
                    TextRenderer.DrawText(e.Graphics, inisial, fontInisial, rectAvatar, FG_BADGE_ACTIVE,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    int textStartX = avatarX + avatarSize + 16;
                    Font fontNama = new Font("Segoe UI", 11f, FontStyle.Bold);
                    Point posNama = new Point(textStartX, rectCard.Y + 24);
                    TextRenderer.DrawText(e.Graphics, namaPelanggan, fontNama, posNama, COLOR_TEXT_DARK);

                    Font fontSub = new Font("Segoe UI", 9f, FontStyle.Regular);
                    Point posSub = new Point(textStartX, rectCard.Y + 50);
                    TextRenderer.DrawText(e.Graphics, detailID + "  •  @" + username, fontSub, posSub, COLOR_TEXT_MUTED);

                    int infoX = textStartX + 260;
                    Font fontInfoTitle = new Font("Segoe UI", 8.5f, FontStyle.Regular);
                    Font fontInfoValue = new Font("Segoe UI", 10f, FontStyle.Bold);

                    TextRenderer.DrawText(e.Graphics, "NOMOR TELEPON", fontInfoTitle, new Point(infoX, rectCard.Y + 24), COLOR_TEXT_MUTED);
                    TextRenderer.DrawText(e.Graphics, noHp, fontInfoValue, new Point(infoX, rectCard.Y + 46), COLOR_TEXT_DARK);

                    int saldoX = infoX + 180;
                    TextRenderer.DrawText(e.Graphics, "SALDO DOMPET", fontInfoTitle, new Point(saldoX, rectCard.Y + 24), COLOR_TEXT_MUTED);
                    TextRenderer.DrawText(e.Graphics, saldoText, fontInfoValue, new Point(saldoX, rectCard.Y + 46), COLOR_PRIMARY);

                    Color bgBadge = (statusText == "Active") ? BG_BADGE_ACTIVE : BG_BADGE_INACTIVE;
                    Color fgBadge = (statusText == "Active") ? FG_BADGE_ACTIVE : FG_BADGE_INACTIVE;

                    int badgeW = 76;
                    int badgeH = 26;
                    int badgeX = rectCard.Right - badgeW - 150; 
                    int badgeY = rectCard.Y + (rectCard.Height - badgeH) / 2;
                    Rectangle rectBadge = new Rectangle(badgeX, badgeY, badgeW, badgeH);

                    using (GraphicsPath pathBadge = GetRoundRectPath(rectBadge, 13))
                    using (SolidBrush brushBg = new SolidBrush(bgBadge))
                    {
                        e.Graphics.FillPath(brushBg, pathBadge);
                        Font fontBadge = new Font("Segoe UI", 8.5f, FontStyle.Bold);
                        TextRenderer.DrawText(e.Graphics, statusText, fontBadge, rectBadge, fgBadge,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }

                    int btnW = 100;
                    int btnH = 32;
                    int btnX = rectCard.Right - btnW - 20;
                    int btnY = rectCard.Y + (rectCard.Height - btnH) / 2;
                    Rectangle rectBtn = new Rectangle(btnX, btnY, btnW, btnH);

                    using (GraphicsPath pathBtn = GetRoundRectPath(rectBtn, 6))
                    using (SolidBrush brushBtn = new SolidBrush(COLOR_PRIMARY))
                    {
                        e.Graphics.FillPath(brushBtn, pathBtn);
                        Font fontBtn = new Font("Segoe UI", 9f, FontStyle.Bold);
                        TextRenderer.DrawText(e.Graphics, "Kelola ⚙️", fontBtn, rectBtn, Color.White,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
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

        private void dgvCustomer_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 1) return;

            string idRaw = dgvCustomer.Rows[e.RowIndex].Cells["colId"].Value?.ToString() ?? "0";
            int idUser = int.TryParse(idRaw, out int parsed) ? parsed : 0;

            string fullCellInfo = dgvCustomer.Rows[e.RowIndex].Cells["colCard"].Value?.ToString() ?? "";
            string[] split = fullCellInfo.Split('|');
            if (split.Length < 6) return;

            string namaCustomer = split[0];
            string currentStatus = split[5];

            var rowBounds = dgvCustomer.GetRowDisplayRectangle(e.RowIndex, true);
            int margin = 6;
            int cardRight = rowBounds.X + margin + (dgvCustomer.Width - 35) - (margin * 2);
            int btnW = 100;
            int btnX = cardRight - btnW - 20;

            // Periksa apakah X kursor tik masuk ke dalam hit-box tombol "Kelola ⚙️"
            if (e.X >= (btnX - rowBounds.X) && e.X <= (btnX - rowBounds.X + btnW))
            {
                ShowCustomerMenu(idUser, namaCustomer, currentStatus);
            }
        }

        private void ShowCustomerMenu(int idUser, string namaCustomer, string currentStatus)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.RenderMode = ToolStripRenderMode.System;
            menu.BackColor = Color.White;
            menu.ShowImageMargin = false;

            ToolStripLabel lblNama = new ToolStripLabel("  " + namaCustomer);
            lblNama.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblNama.ForeColor = COLOR_TEXT_DARK;

            ToolStripLabel lblId = new ToolStripLabel("  ID Customer : " + idUser);
            lblId.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
            lblId.ForeColor = COLOR_TEXT_MUTED;

            menu.Items.Add(lblNama);
            menu.Items.Add(lblId);
            menu.Items.Add(new ToolStripSeparator());

            // Menu Status pintar bertukar opsi secara otomatis berdasarkan kondisi data real-time
            if (currentStatus == "Active")
            {
                menu.Items.Add("⛔  Blokir Akun", null, (s, e) => UbahStatusKeBlokir(idUser));
            }
            else
            {
                menu.Items.Add("✅  Aktifkan Akun", null, (s, e) => UbahStatusKeAktif(idUser));
            }

            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("🗑  Hapus Customer", null, (s, e) => HapusCustomer(idUser, namaCustomer));

            menu.Show(Cursor.Position);
        }

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

        private void UbahStatusKeBlokir(int idUser)
        {
            try
            {
                _customerService.BlokirCustomer(idUser);
                MessageBox.Show("Status customer berhasil diblokir (Inactive)", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataDariDatabase();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void HapusCustomer(int idUser, string nama)
        {
            DialogResult hasil = MessageBox.Show($"Yakin ingin menghapus customer {nama}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

        private void btnTambah_Click(object sender, EventArgs e) { }
        private void mainPanel_Paint(object sender, PaintEventArgs e) { }
    }
}
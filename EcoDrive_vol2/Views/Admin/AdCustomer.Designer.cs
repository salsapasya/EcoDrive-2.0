using EcoDriveUI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    partial class AdCustomer
    {
        private System.ComponentModel.IContainer components = null;

        private Panel mainPanel;
        private RoundedPanel cardPanel;

        private Label lblTitle;
        private Label lblSubtitle;

        private TextBox txtSearch;

        private Button btnSemua;
        private Button btnAktif;
        private Button btnNonAktif;
        private Button btnTambah;

        private DataGridView dgvCustomer;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Metode pembantu untuk mengonfigurasi gaya visual tombol filter atas secara dinamis
        /// </summary>
        private void SetupButton(Button button, string text, Point location, Color backColor, Color foreColor)
        {
            button.Text = text;
            button.Location = location;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            mainPanel = new Panel();
            cardPanel = new RoundedPanel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            txtSearch = new TextBox();
            btnSemua = new Button();
            btnAktif = new Button();
            btnNonAktif = new Button();
            btnTambah = new Button();
            dgvCustomer = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colCard = new DataGridViewTextBoxColumn();

            mainPanel.SuspendLayout();
            cardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).BeginInit();
            SuspendLayout();

            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(243, 249, 243);
            mainPanel.Controls.Add(cardPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(4, 5, 4, 5);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(43, 33, 43, 50);
            mainPanel.Size = new Size(1829, 1200);
            mainPanel.TabIndex = 0;
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.White;
            cardPanel.Controls.Add(lblTitle);
            cardPanel.Controls.Add(lblSubtitle);
            cardPanel.Controls.Add(txtSearch);
            cardPanel.Controls.Add(btnSemua);
            cardPanel.Controls.Add(btnAktif);
            cardPanel.Controls.Add(btnNonAktif);
            cardPanel.Controls.Add(btnTambah);
            cardPanel.Controls.Add(dgvCustomer);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(43, 33);
            cardPanel.Margin = new Padding(4, 5, 4, 5);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(36, 42, 36, 42);
            cardPanel.Size = new Size(1743, 1117);
            cardPanel.TabIndex = 0;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(47, 47, 47);
            lblTitle.Location = new Point(36, 42);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(366, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kelola Customer";

            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.DarkGray;
            lblSubtitle.Location = new Point(39, 115);
            lblSubtitle.Margin = new Padding(4, 0, 4, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(324, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manajemen data pengguna EcoDrive";

            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(245, 245, 245);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(36, 155);
            txtSearch.Name = "txtSearch";
            txtSearch.Multiline = true;
            txtSearch.PlaceholderText = "    🔍 Cari nama, email, ID...";
            txtSearch.Size = new Size(320, 35);
            txtSearch.TabIndex = 2;

            // 
            // Konfigurasi Filter & Aksi via SetupButton
            // 
            SetupButton(btnSemua, "Semua", new Point(380, 155), Color.FromArgb(76, 175, 80), Color.White);
            btnSemua.Size = new Size(90, 35);
            btnSemua.Name = "btnSemua";
            btnSemua.TabIndex = 3;
            btnSemua.Click += FilterButton_Click;

            SetupButton(btnAktif, "Aktif", new Point(480, 155), Color.FromArgb(245, 245, 245), Color.FromArgb(47, 47, 47));
            btnAktif.Size = new Size(90, 35);
            btnAktif.Name = "btnAktif";
            btnAktif.TabIndex = 4;
            btnAktif.Click += FilterButton_Click;

            SetupButton(btnNonAktif, "Non Aktif", new Point(580, 155), Color.FromArgb(245, 245, 245), Color.FromArgb(47, 47, 47));
            btnNonAktif.Size = new Size(110, 35);
            btnNonAktif.Name = "btnNonAktif";
            btnNonAktif.TabIndex = 5;
            btnNonAktif.Click += FilterButton_Click;

            SetupButton(btnTambah, "+ Tambah Customer", new Point(1480, 155), Color.FromArgb(76, 175, 80), Color.White);
            btnTambah.Size = new Size(220, 35);
            btnTambah.Name = "btnTambah";
            btnTambah.TabIndex = 6;

            // 
            // dgvCustomer
            // 
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AllowUserToDeleteRows = false;
            dgvCustomer.AllowUserToResizeColumns = false;
            dgvCustomer.AllowUserToResizeRows = false;
            dgvCustomer.BackgroundColor = Color.White;
            dgvCustomer.BorderStyle = BorderStyle.None;
            dgvCustomer.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvCustomer.ColumnHeadersVisible = false;
            dgvCustomer.RowHeadersVisible = false;

            dgvCustomer.Columns.Clear();
            dgvCustomer.Columns.AddRange(new DataGridViewColumn[] { colId, colCard });

            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dgvCustomer.DefaultCellStyle = dataGridViewCellStyle4;

            dgvCustomer.Location = new Point(36, 220);
            dgvCustomer.RowTemplate.Height = 115;
            dgvCustomer.Size = new Size(1680, 850);
            dgvCustomer.TabIndex = 7;
            dgvCustomer.CellPainting += DgvCustomer_CellPainting;

            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.Visible = false;

            // 
            // colCard
            // 
            colCard.HeaderText = "Customer";
            colCard.Name = "colCard";
            colCard.Width = 1650;

            // 
            // AdCustomer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 249, 243);
            ClientSize = new Size(1829, 1200);
            Controls.Add(mainPanel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AdCustomer";
            Text = "EcoDrive Management – Data Customer";

            mainPanel.ResumeLayout(false);
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            ResumeLayout(false);
        }

        private void DgvCustomer_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 1) 
            {
                Rectangle rowBounds = dgvCustomer.GetRowDisplayRectangle(e.RowIndex, true);
                int paddingBaris = 8;

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                using (SolidBrush bgBrush = new SolidBrush(dgvCustomer.BackgroundColor))
                {
                    e.Graphics.FillRectangle(bgBrush, e.CellBounds);
                }

                Rectangle cardRect = new Rectangle(
                    rowBounds.X + 10,
                    rowBounds.Y + paddingBaris,
                    dgvCustomer.Width - 35,
                    rowBounds.Height - (paddingBaris * 2)
                );

                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 12;
                    path.AddArc(cardRect.X, cardRect.Y, radius, radius, 180, 90);
                    path.AddArc(cardRect.Right - radius, cardRect.Y, radius, radius, 270, 90);
                    path.AddArc(cardRect.Right - radius, cardRect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(cardRect.X, cardRect.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();

                    using (SolidBrush cardBg = new SolidBrush(Color.White)) e.Graphics.FillPath(cardBg, path);
                    using (Pen borderPen = new Pen(Color.FromArgb(235, 235, 235), 1.5f)) e.Graphics.DrawPath(borderPen, path);
                }

                string rawData = dgvCustomer.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "||||";
                string[] split = rawData.Split('|');

                string nama = split.Length > 0 ? split[0] : "Customer";
                string email = split.Length > 1 ? split[1] : "";
                string kontak = split.Length > 2 ? split[2] : "-";
                string tipeMember = split.Length > 3 ? split[3] : "Member";
                string totalSewa = split.Length > 4 ? split[4] : "0 trip";
                string status = split.Length > 5 ? split[5] : "Aktif";

                // 1. Render Lingkaran Avatar Inisial Nama
                int avSize = 46;
                int avX = cardRect.X + 25;
                int avY = cardRect.Y + (cardRect.Height - avSize) / 2;

                using (SolidBrush avBrush = new SolidBrush(Color.FromArgb(240, 244, 241))) e.Graphics.FillEllipse(avBrush, avX, avY, avSize, avSize);
                string inisial = nama.Length >= 2 ? nama.Substring(0, 2).ToUpper() : "CS";
                TextRenderer.DrawText(e.Graphics, inisial, new Font("Segoe UI", 10F, FontStyle.Bold),
                    new Rectangle(avX, avY, avSize, avSize), Color.FromArgb(76, 175, 80), TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                // 2. Render Informasi Utama (Nama & Email)
                TextRenderer.DrawText(e.Graphics, nama, new Font("Segoe UI", 11F, FontStyle.Bold), new Point(avX + 60, avY - 2), Color.FromArgb(47, 47, 47));
                TextRenderer.DrawText(e.Graphics, email, new Font("Segoe UI", 8.5F), new Point(avX + 60, avY + 24), Color.Gray);

                // 3. Render Metadata Blok Kontak & Tipe Member
                int detailX = cardRect.X + 450;
                TextRenderer.DrawText(e.Graphics, "Kontak & Tipe", new Font("Segoe UI", 8.5F), new Point(detailX, avY - 2), Color.DarkGray);
                TextRenderer.DrawText(e.Graphics, $"{kontak} • {tipeMember}", new Font("Segoe UI", 9.5F), new Point(detailX, avY + 20), Color.FromArgb(70, 70, 70));

                // 4. Render Metadata Total Trip Sewa
                int sewaX = cardRect.X + 800;
                TextRenderer.DrawText(e.Graphics, "Total Sewa", new Font("Segoe UI", 8.5F), new Point(sewaX, avY - 2), Color.DarkGray);
                TextRenderer.DrawText(e.Graphics, totalSewa, new Font("Segoe UI", 9.5F, FontStyle.Bold), new Point(sewaX, avY + 20), Color.FromArgb(47, 47, 47));

                // 5. Render Badge Pil Status Akun (Aktif / Blokir / Pending)
                bool isAktif = status.Trim().ToLower() == "aktif";
                bool isBlokir = status.Trim().ToLower() == "di blokir" || status.Trim().ToLower() == "blokir";
                Color bgBadge = isAktif ? Color.FromArgb(232, 245, 233) : (isBlokir ? Color.FromArgb(254, 241, 242) : Color.FromArgb(255, 248, 225));
                Color txtBadge = isAktif ? Color.FromArgb(67, 160, 71) : (isBlokir ? Color.FromArgb(220, 38, 38) : Color.FromArgb(245, 158, 11));

                int bWidth = 95, bHeight = 26;
                int bX = cardRect.X + 1100;
                int bY = cardRect.Y + (cardRect.Height - bHeight) / 2;

                using (GraphicsPath bPath = new GraphicsPath())
                {
                    int r = bHeight / 2;
                    bPath.AddArc(bX, bY, r * 2, r * 2, 180, 90);
                    bPath.AddArc(bX + bWidth - (r * 2), bY, r * 2, r * 2, 270, 90);
                    bPath.AddArc(bX + bWidth - (r * 2), bY + bHeight - (r * 2), r * 2, r * 2, 0, 90);
                    bPath.AddArc(bX, bY + bHeight - (r * 2), r * 2, r * 2, 90, 90);
                    bPath.CloseFigure();
                    using (SolidBrush br = new SolidBrush(bgBadge)) e.Graphics.FillPath(br, bPath);
                }
                TextRenderer.DrawText(e.Graphics, status, new Font("Segoe UI", 8.5F, FontStyle.Bold), new Rectangle(bX, bY, bWidth, bHeight), txtBadge, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                int btnW = 110, btnH = 34;
                int btnX = cardRect.Right - btnW - 25;
                int btnY = cardRect.Y + (cardRect.Height - btnH) / 2;

                using (GraphicsPath btnPath = new GraphicsPath())
                {
                    int r = 6;
                    btnPath.AddArc(btnX, btnY, r * 2, r * 2, 180, 90);
                    btnPath.AddArc(btnX + btnW - (r * 2), btnY, r * 2, r * 2, 270, 90);
                    btnPath.AddArc(btnX + btnW - (r * 2), btnY + btnH - (r * 2), r * 2, r * 2, 0, 90);
                    btnPath.AddArc(btnX, btnY + btnH - (r * 2), r * 2, r * 2, 90, 90);
                    btnPath.CloseFigure();
                    using (SolidBrush btnBr = new SolidBrush(Color.FromArgb(245, 245, 245))) e.Graphics.FillPath(btnBr, btnPath);
                }
                TextRenderer.DrawText(e.Graphics, "Kelola ⚙", new Font("Segoe UI", 9F, FontStyle.Bold), new Rectangle(btnX, btnY, btnW, btnH), Color.FromArgb(80, 80, 80), TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
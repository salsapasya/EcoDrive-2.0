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
        private RoundedPanel cardPanel; // Menggunakan RoundedPanel agar sudut melengkung halus

        private Label lblTitle;
        private Label lblSubtitle;

        private TextBox txtSearch;

        private Button btnSemua;
        private Button btnAktif;
        private Button btnNonAktif;
        private Button btnFilter;
        private Button btnTambah;

        private DataGridView dgvCustomer;

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn colKontak;
        private DataGridViewTextBoxColumn colBergabung;
        private DataGridViewTextBoxColumn colTrip;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colAksi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            mainPanel = new Panel();
            cardPanel = new RoundedPanel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            txtSearch = new TextBox();
            btnSemua = new Button();
            btnAktif = new Button();
            btnNonAktif = new Button();
            btnFilter = new Button();
            btnTambah = new Button();
            dgvCustomer = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            colKontak = new DataGridViewTextBoxColumn();
            colBergabung = new DataGridViewTextBoxColumn();
            colTrip = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colAksi = new DataGridViewTextBoxColumn();
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
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(30, 20, 30, 30);
            mainPanel.Size = new Size(1280, 720);
            mainPanel.TabIndex = 0;
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.White;
            cardPanel.Controls.Add(btnAktif);
            cardPanel.Controls.Add(lblTitle);
            cardPanel.Controls.Add(lblSubtitle);
            cardPanel.Controls.Add(txtSearch);
            cardPanel.Controls.Add(btnSemua);
            cardPanel.Controls.Add(btnNonAktif);
            cardPanel.Controls.Add(btnFilter);
            cardPanel.Controls.Add(btnTambah);
            cardPanel.Controls.Add(dgvCustomer);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(30, 20);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(25);
            cardPanel.Size = new Size(1220, 670);
            cardPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(47, 47, 47);
            lblTitle.Location = new Point(25, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(248, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kelola Customer";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.DarkGray;
            lblSubtitle.Location = new Point(27, 69);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(224, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manajemen data pengguna EcoDrive";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(248, 246, 242);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(30, 115);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "   🔍 Cari nama, email, ID...";
            txtSearch.Size = new Size(420, 20);
            txtSearch.TabIndex = 2;
            // 
            // btnSemua
            // 
            btnSemua.Location = new Point(666, 107);
            btnSemua.Name = "btnSemua";
            btnSemua.Size = new Size(75, 38);
            btnSemua.TabIndex = 3;
            // 
            // btnAktif
            // 
            btnAktif.Location = new Point(747, 107);
            btnAktif.Name = "btnAktif";
            btnAktif.Size = new Size(70, 38);
            btnAktif.TabIndex = 4;
            btnAktif.Click += btnAktif_Click;
            // 
            // btnNonAktif
            // 
            btnNonAktif.Location = new Point(975, 107);
            btnNonAktif.Name = "btnNonAktif";
            btnNonAktif.Size = new Size(95, 38);
            btnNonAktif.TabIndex = 5;
            // 
            // btnFilter
            // 
            btnFilter.FlatAppearance.BorderColor = Color.Gainsboro;
            btnFilter.Location = new Point(1105, 107);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(85, 38);
            btnFilter.TabIndex = 6;
            // 
            // btnTambah
            // 
            btnTambah.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTambah.Location = new Point(475, 107);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(185, 38);
            btnTambah.TabIndex = 7;
            btnTambah.Click += btnTambah_Click;
            // 
            // dgvCustomer
            // 
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AllowUserToResizeRows = false;
            dgvCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomer.BackgroundColor = Color.White;
            dgvCustomer.BorderStyle = BorderStyle.None;
            dgvCustomer.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomer.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(232, 245, 233);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(232, 245, 233);
            dgvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCustomer.ColumnHeadersHeight = 45;
            dgvCustomer.Columns.AddRange(new DataGridViewColumn[] { colId, colCustomer, colKontak, colBergabung, colTrip, colStatus, colAksi });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(242, 249, 242);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCustomer.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCustomer.EnableHeadersVisualStyles = false;
            dgvCustomer.GridColor = Color.FromArgb(240, 242, 240);
            dgvCustomer.Location = new Point(25, 180);
            dgvCustomer.MultiSelect = false;
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.RowHeadersVisible = false;
            dgvCustomer.RowTemplate.Height = 65;
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.Size = new Size(1165, 450);
            dgvCustomer.TabIndex = 8;
            dgvCustomer.CellPainting += DgvCustomer_CellPainting;
            // 
            // colId
            // 
            colId.FillWeight = 50F;
            colId.HeaderText = "ID";
            colId.Name = "colId";
            // 
            // colCustomer
            // 
            colCustomer.FillWeight = 140F;
            colCustomer.HeaderText = "Customer";
            colCustomer.Name = "colCustomer";
            // 
            // colKontak
            // 
            colKontak.FillWeight = 90F;
            colKontak.HeaderText = "Kontak";
            colKontak.Name = "colKontak";
            // 
            // colBergabung
            // 
            colBergabung.FillWeight = 90F;
            colBergabung.HeaderText = "Bergabung";
            colBergabung.Name = "colBergabung";
            // 
            // colTrip
            // 
            colTrip.FillWeight = 70F;
            colTrip.HeaderText = "Total Sewa";
            colTrip.Name = "colTrip";
            // 
            // colStatus
            // 
            colStatus.FillWeight = 70F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            // 
            // colAksi
            // 
            colAksi.FillWeight = 70F;
            colAksi.HeaderText = "Aksi";
            colAksi.Name = "colAksi";
            // 
            // AdCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 249, 243);
            ClientSize = new Size(1280, 720);
            Controls.Add(mainPanel);
            Name = "AdCustomer";
            Text = "EcoDrive Management – Data Customer";
            mainPanel.ResumeLayout(false);
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            ResumeLayout(false);
        }

        private void SetupButton(Button btn, string text, Point location, Color bg, Color fg)
        {
            btn.Text = text;
            btn.Location = location;
            btn.BackColor = bg;
            btn.ForeColor = fg;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        // Metode penggambaran baris kustom: Avatar inisial & Badge Capsule Status
        private void DgvCustomer_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Render khusus kolom nama customer (Gabungkan nama + email di bawahnya)
            if (e.ColumnIndex == 1 && e.Value != null)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                string[] data = e.Value.ToString().Split('|');
                string nama = data[0];
                string email = data.Length > 1 ? data[1] : "";
                string inisial = nama.Length >= 2 ? nama.Substring(0, 2).ToUpper() : "CS";

                int avatarSize = 38;
                int avatarX = e.CellBounds.X + 10;
                int avatarY = e.CellBounds.Y + (e.CellBounds.Height - avatarSize) / 2;

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Gambar lingkaran avatar
                using (SolidBrush avBrush = new SolidBrush(Color.FromArgb(248, 215, 218)))
                {
                    e.Graphics.FillEllipse(avBrush, avatarX, avatarY, avatarSize, avatarSize);
                }

                // Gambar teks inisial di dalam avatar
                TextRenderer.DrawText(e.Graphics, inisial, new Font("Segoe UI", 9F, FontStyle.Bold),
                    new Rectangle(avatarX, avatarY, avatarSize, avatarSize), Color.FromArgb(180, 80, 90),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                // Cetak Nama utama & Email
                TextRenderer.DrawText(e.Graphics, nama, new Font("Segoe UI", 10F, FontStyle.Bold), new Point(avatarX + 48, e.CellBounds.Y + 12), Color.FromArgb(47, 47, 47));
                TextRenderer.DrawText(e.Graphics, email, new Font("Segoe UI", 8.5F), new Point(avatarX + 48, e.CellBounds.Y + 34), Color.Gray);

                e.Handled = true;
            }

            // Render khusus kolom badge status kapsul melengkung (Aktif/Non Aktif)
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                string status = e.Value.ToString();
                bool isAktif = status.Trim().ToLower() == "aktif";

                Color bgBadge = isAktif ? Color.FromArgb(232, 245, 233) : Color.FromArgb(254, 241, 242);
                Color textBadge = isAktif ? Color.FromArgb(67, 160, 71) : Color.FromArgb(220, 38, 38);

                int bw = 75;
                int bh = 26;
                int bx = e.CellBounds.X + 10;
                int by = e.CellBounds.Y + (e.CellBounds.Height - bh) / 2;

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    int r = bh / 2;
                    path.AddArc(bx, by, r * 2, bh, 180, 90);
                    path.AddArc(bx + bw - (r * 2), by, r * 2, bh, 270, 90);
                    path.AddArc(bx + bw - (r * 2), by + bh - bh, r * 2, bh, 0, 90);
                    path.AddArc(bx, by + bh - bh, r * 2, bh, 90, 90);
                    path.CloseFigure();

                    using (SolidBrush bBrush = new SolidBrush(bgBadge))
                    {
                        e.Graphics.FillPath(bBrush, path);
                    }
                }

                TextRenderer.DrawText(e.Graphics, status, new Font("Segoe UI", 8.5F, FontStyle.Bold),
                    new Rectangle(bx, by, bw, bh), textBadge, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }
    }
}
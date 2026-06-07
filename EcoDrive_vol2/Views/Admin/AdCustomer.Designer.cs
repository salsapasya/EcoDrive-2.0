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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            mainPanel = new Panel();
            cardPanel = new RoundedPanel();
            btnAktif = new Button();
            lblTitle = new Label();
            lblSubtitle = new Label();
            txtSearch = new TextBox();
            btnSemua = new Button();
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
            mainPanel.Margin = new Padding(4, 5, 4, 5);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(43, 33, 43, 50);
            mainPanel.Size = new Size(1829, 1200);
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
            cardPanel.Location = new Point(43, 33);
            cardPanel.Margin = new Padding(4, 5, 4, 5);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(36, 42, 36, 42);
            cardPanel.Size = new Size(1743, 1117);
            cardPanel.TabIndex = 0;
            // 
            // btnAktif
            // 
            btnAktif.Location = new Point(1067, 178);
            btnAktif.Margin = new Padding(4, 5, 4, 5);
            btnAktif.Name = "btnAktif";
            btnAktif.Size = new Size(100, 63);
            btnAktif.TabIndex = 4;
            btnAktif.Click += FilterButton_Click; // 🛠️ FIX: Dialihkan ke event filter yang benar
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
            lblTitle.Click += lblTitle_Click;
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
            txtSearch.BackColor = Color.FromArgb(248, 246, 242);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(43, 192);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "   🔍 Cari nama, email, ID...";
            txtSearch.Size = new Size(600, 30);
            txtSearch.TabIndex = 2;
            // 
            // btnSemua
            // 
            btnSemua.Location = new Point(951, 178);
            btnSemua.Margin = new Padding(4, 5, 4, 5);
            btnSemua.Name = "btnSemua";
            btnSemua.Size = new Size(107, 63);
            btnSemua.TabIndex = 3;
            // 
            // btnNonAktif
            // 
            btnNonAktif.Location = new Point(1393, 178);
            btnNonAktif.Margin = new Padding(4, 5, 4, 5);
            btnNonAktif.Name = "btnNonAktif";
            btnNonAktif.Size = new Size(136, 63);
            btnNonAktif.TabIndex = 5;
            // 
            // btnFilter
            // 
            btnFilter.FlatAppearance.BorderColor = Color.Gainsboro;
            btnFilter.Location = new Point(1579, 178);
            btnFilter.Margin = new Padding(4, 5, 4, 5);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(121, 63);
            btnFilter.TabIndex = 6;
            // 
            // btnTambah
            // 
            btnTambah.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTambah.Location = new Point(679, 178);
            btnTambah.Margin = new Padding(4, 5, 4, 5);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(264, 63);
            btnTambah.TabIndex = 7;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(232, 245, 233);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(232, 245, 233);
            dgvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCustomer.ColumnHeadersHeight = 45;
            dgvCustomer.Columns.AddRange(new DataGridViewColumn[] { colId, colCustomer, colKontak, colBergabung, colTrip, colStatus, colAksi });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(242, 249, 242);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvCustomer.DefaultCellStyle = dataGridViewCellStyle4;
            dgvCustomer.EnableHeadersVisualStyles = false;
            dgvCustomer.GridColor = Color.FromArgb(240, 242, 240);
            dgvCustomer.Location = new Point(36, 300);
            dgvCustomer.Margin = new Padding(4, 5, 4, 5);
            dgvCustomer.MultiSelect = false;
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.RowHeadersVisible = false;
            dgvCustomer.RowHeadersWidth = 62;
            dgvCustomer.RowTemplate.Height = 65;
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.Size = new Size(1664, 750);
            dgvCustomer.TabIndex = 8;
            // 
            // colId
            // 
            colId.FillWeight = 50F;
            colId.HeaderText = "ID";
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            // 
            // colCustomer
            // 
            colCustomer.FillWeight = 140F;
            colCustomer.HeaderText = "Customer";
            colCustomer.MinimumWidth = 8;
            colCustomer.Name = "colCustomer";
            // 
            // colKontak
            // 
            colKontak.FillWeight = 90F;
            colKontak.HeaderText = "Kontak";
            colKontak.MinimumWidth = 8;
            colKontak.Name = "colKontak";
            // 
            // colBergabung
            // 
            colBergabung.FillWeight = 90F;
            colBergabung.HeaderText = "Bergabung";
            colBergabung.MinimumWidth = 8;
            colBergabung.Name = "colBergabung";
            // 
            // colTrip
            // 
            colTrip.FillWeight = 70F;
            colTrip.HeaderText = "Total Sewa";
            colTrip.MinimumWidth = 8;
            colTrip.Name = "colTrip";
            // 
            // colStatus
            // 
            colStatus.FillWeight = 70F;
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            // 
            // colAksi
            // 
            colAksi.FillWeight = 70F;
            colAksi.HeaderText = "Aksi";
            colAksi.MinimumWidth = 8;
            colAksi.Name = "colAksi";
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

                using (SolidBrush avBrush = new SolidBrush(Color.FromArgb(248, 215, 218)))
                {
                    e.Graphics.FillEllipse(avBrush, avatarX, avatarY, avatarSize, avatarSize);
                }

                TextRenderer.DrawText(e.Graphics, inisial, new Font("Segoe UI", 9F, FontStyle.Bold),
                    new Rectangle(avatarX, avatarY, avatarSize, avatarSize), Color.FromArgb(180, 80, 90),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                TextRenderer.DrawText(e.Graphics, nama, new Font("Segoe UI", 10F, FontStyle.Bold), new Point(avatarX + 48, e.CellBounds.Y + 12), Color.FromArgb(47, 47, 47));
                TextRenderer.DrawText(e.Graphics, email, new Font("Segoe UI", 8.5F), new Point(avatarX + 48, e.CellBounds.Y + 34), Color.Gray);

                e.Handled = true;
            }

            if (e.ColumnIndex == 5 && e.Value != null)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                string status = e.Value.ToString().Trim();

                // 🛠️ FIX LOGIKA BADGE: Deteksi fleksibel terhadap format 'Aktif' (TitleCase) maupun 'aktif' (lowercase)
                bool isAktif = string.Equals(status, "aktif", StringComparison.OrdinalIgnoreCase);

                Color bgBadge = isAktif ? Color.FromArgb(232, 245, 233) : Color.FromArgb(254, 241, 242);
                Color textBadge = isAktif ? Color.FromArgb(67, 160, 71) : Color.FromArgb(220, 38, 38);

                int bw = 85; // Sedikit dilebarkan agar teks 'Non Aktif' tidak terpotong
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
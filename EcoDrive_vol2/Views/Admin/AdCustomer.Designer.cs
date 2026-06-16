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
        /// Metode pembantu yang dimodifikasi untuk membuat tombol berbentuk Kapsul/Rounded Modern
        /// </summary>
        private void SetupButton(Button button, string text, Point location, Color backColor, Color foreColor)
        {
            button.Text = text;
            button.Location = location;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.Padding = new Padding(5, 0, 5, 0);

            // 🌟 TRIK MODERN: Menggambar sudut melengkung halus (Kapsul) pada tombol
            button.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rectPath = new Rectangle(0, 0, button.Width, button.Height);

                // Gunakan fungsi internal GetRoundRectPath (Radius 8px)
                using (GraphicsPath path = GetRoundRectPath(rectPath, 8))
                {
                    button.Region = new Region(path);

                    // Khusus untuk tombol putih (Inactive / Active pasif), gambar border tipis estetik
                    if (button.BackColor == Color.White)
                    {
                        using (Pen penBorder = new Pen(Color.FromArgb(215, 220, 215), 1f))
                        {
                            e.Graphics.DrawPath(penBorder, path);
                        }
                    }
                }
            };
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            mainPanel.AutoSize = true;
            mainPanel.BackColor = Color.FromArgb(243, 249, 243);
            mainPanel.Controls.Add(cardPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(30, 20, 30, 30);
            mainPanel.Size = new Size(1280, 709);
            mainPanel.TabIndex = 0;
            mainPanel.Paint += mainPanel_Paint;

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
            cardPanel.Location = new Point(30, 20);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(25);
            cardPanel.Size = new Size(1220, 659);
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
            txtSearch.BackColor = Color.FromArgb(245, 245, 245);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10.5F);
            txtSearch.Location = new Point(27, 102);
            txtSearch.Margin = new Padding(2);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "   🔍   Cari nama, email, ID...";
            txtSearch.Size = new Size(350, 32);
            txtSearch.TabIndex = 2;

            // 🌟 TRIK MODERN: Mengubah struktur TextBox menjadi rounded/oval tipis agar estetik
            txtSearch.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rectPath = new Rectangle(0, 0, txtSearch.Width, txtSearch.Height);
                using (GraphicsPath path = GetRoundRectPath(rectPath, 8))
                {
                    txtSearch.Region = new Region(path);
                }
            };

            // 
            // KONFIGURASI TOMBOL FILTER ATAS (Sudah otomatis melengkung/kapsul premium)
            // 
            SetupButton(btnSemua, "Semua", new Point(395, 102), Color.FromArgb(76, 175, 80), Color.White);
            btnSemua.Size = new Size(80, 32);
            btnSemua.TabIndex = 3;

            SetupButton(btnAktif, "Active", new Point(485, 102), Color.White, Color.FromArgb(47, 47, 47));
            btnAktif.Size = new Size(80, 32);
            btnAktif.TabIndex = 4;

            SetupButton(btnNonAktif, "Inactive", new Point(575, 102), Color.White, Color.FromArgb(47, 47, 47));
            btnNonAktif.Size = new Size(90, 32);
            btnNonAktif.TabIndex = 5;

            SetupButton(btnTambah, "➕ Tambah Akun", new Point(1040, 102), Color.FromArgb(76, 175, 80), Color.White);
            btnTambah.Size = new Size(155, 32);
            btnTambah.TabIndex = 6;

            // 
            // dgvCustomer
            // 
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AllowUserToDeleteRows = false;
            dgvCustomer.AllowUserToResizeColumns = false;
            dgvCustomer.AllowUserToResizeRows = false;
            dgvCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomer.BackgroundColor = Color.White;
            dgvCustomer.BorderStyle = BorderStyle.None;
            dgvCustomer.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvCustomer.ColumnHeadersVisible = false;
            dgvCustomer.Columns.AddRange(new DataGridViewColumn[] { colId, colCard });

            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(248, 249, 248);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;

            dgvCustomer.DefaultCellStyle = dataGridViewCellStyle1;
            dgvCustomer.Location = new Point(25, 155);
            dgvCustomer.Margin = new Padding(2);
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.RowHeadersVisible = false;
            dgvCustomer.RowTemplate.Height = 110;
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.Size = new Size(1170, 480);
            dgvCustomer.TabIndex = 7;

            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.Visible = false;

            // 
            // colCard
            // 
            colCard.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCard.HeaderText = "Customer Card View";
            colCard.Name = "colCard";
            colCard.ReadOnly = true;

            // 
            // AdCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 249, 243);
            ClientSize = new Size(1280, 709);
            Controls.Add(mainPanel);
            Name = "AdCustomer";
            Text = "EcoDrive Management – Data Customer";
            WindowState = FormWindowState.Maximized;
            mainPanel.ResumeLayout(false);
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
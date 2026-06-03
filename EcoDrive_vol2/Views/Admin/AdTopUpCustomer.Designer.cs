namespace EcoDrive_vol2.Views.Admin
{
    partial class AdTopUpCustomer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            this.cardPanel = new EcoDriveUI.RoundedPanel();
            this.mainPanel = new System.Windows.Forms.Panel();

            // Dashboard Summary Cards
            this.panelCard1 = new EcoDriveUI.RoundedPanel();
            this.lblCardTitle1 = new System.Windows.Forms.Label();
            this.lblCardValue1 = new System.Windows.Forms.Label();

            this.panelCard2 = new EcoDriveUI.RoundedPanel();
            this.lblCardTitle2 = new System.Windows.Forms.Label();
            this.lblCardValue2 = new System.Windows.Forms.Label();

            this.panelCard3 = new EcoDriveUI.RoundedPanel();
            this.lblCardTitle3 = new System.Windows.Forms.Label();
            this.lblCardValue3 = new System.Windows.Forms.Label();

            // Elemen Kontrol Filter
            this.btnGagal = new System.Windows.Forms.Button();
            this.btnBerhasil = new System.Windows.Forms.Button();
            this.btnPending = new System.Windows.Forms.Button();
            this.btnSemua = new System.Windows.Forms.Button();

            // Data Grid (Sisi Kiri)
            this.dgvTransaksi = new System.Windows.Forms.DataGridView();
            this.colIdTransaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKontak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJumlahTopup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // Sisi Kanan: Panel Aksi Konfirmasi (Layout Tetap Cantik & Terbaca)
            this.panelAksiSide = new EcoDriveUI.RoundedPanel();
            this.lblAksiTitle = new System.Windows.Forms.Label();
            this.lblHintCari = new System.Windows.Forms.Label();
            this.txtUsernameCari = new System.Windows.Forms.TextBox();
            this.lblNamaCustomerHeader = new System.Windows.Forms.Label();
            this.lblNamaCustomer = new System.Windows.Forms.Label();
            this.lblSaldoAktifHeader = new System.Windows.Forms.Label();
            this.lblSaldoAktif = new System.Windows.Forms.Label();
            this.btnKonfirmasiTopUp = new System.Windows.Forms.Button();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            this.cardPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.panelCard1.SuspendLayout();
            this.panelCard2.SuspendLayout();
            this.panelCard3.SuspendLayout();
            this.panelAksiSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).BeginInit();
            this.SuspendLayout();

            // ==========================================
            // cardPanel & mainPanel CONTAINER
            // ==========================================
            this.cardPanel.BackColor = System.Drawing.Color.FromArgb(250, 252, 250);
            this.cardPanel.Controls.Add(this.mainPanel);
            this.cardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPanel.Location = new System.Drawing.Point(0, 0);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Padding = new System.Windows.Forms.Padding(30);
            this.cardPanel.Size = new System.Drawing.Size(1100, 700);
            this.cardPanel.TabIndex = 2;

            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.panelCard1);
            this.mainPanel.Controls.Add(this.panelCard2);
            this.mainPanel.Controls.Add(this.panelCard3);
            this.mainPanel.Controls.Add(this.btnGagal);
            this.mainPanel.Controls.Add(this.btnBerhasil);
            this.mainPanel.Controls.Add(this.dgvTransaksi);
            this.mainPanel.Controls.Add(this.btnPending);
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Controls.Add(this.btnSemua);
            this.mainPanel.Controls.Add(this.lblSubtitle);
            this.mainPanel.Controls.Add(this.panelAksiSide); // Memasukkan Panel Kanan
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(30, 30);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1040, 640);

            // ==========================================
            // TYPOGRAPHY HEADER
            // ==========================================
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(40, 42, 40);
            this.lblTitle.Location = new System.Drawing.Point(40, 15);
            this.lblTitle.Text = "Transaksi";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.DarkGray;
            this.lblSubtitle.Location = new System.Drawing.Point(44, 58);
            this.lblSubtitle.Text = "Riwayat dan status konfirmasi top up saldo rental";

            // ==========================================
            // DASHBOARD SUMMARY CARDS (ATAS)
            // ==========================================
            // Card 1
            this.panelCard1.BackColor = System.Drawing.Color.White;
            this.panelCard1.Controls.Add(this.lblCardTitle1);
            this.panelCard1.Controls.Add(this.lblCardValue1);
            this.panelCard1.Location = new System.Drawing.Point(45, 100);
            this.panelCard1.Size = new System.Drawing.Size(220, 95);

            this.lblCardTitle1.Text = "Top Up Hari Ini";
            this.lblCardTitle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblCardTitle1.ForeColor = System.Drawing.Color.Gray;
            this.lblCardTitle1.Location = new System.Drawing.Point(15, 15);
            this.lblCardTitle1.AutoSize = true;

            this.lblCardValue1.Text = "Rp 4.8M";
            this.lblCardValue1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCardValue1.ForeColor = System.Drawing.Color.FromArgb(47, 47, 47);
            this.lblCardValue1.Location = new System.Drawing.Point(13, 40);
            this.lblCardValue1.AutoSize = true;

            // Card 2
            this.panelCard2.BackColor = System.Drawing.Color.White;
            this.panelCard2.Controls.Add(this.lblCardTitle2);
            this.panelCard2.Controls.Add(this.lblCardValue2);
            this.panelCard2.Location = new System.Drawing.Point(285, 100);
            this.panelCard2.Size = new System.Drawing.Size(220, 95);

            this.lblCardTitle2.Text = "Permintaan Pending";
            this.lblCardTitle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblCardTitle2.ForeColor = System.Drawing.Color.Gray;
            this.lblCardTitle2.Location = new System.Drawing.Point(15, 15);
            this.lblCardTitle2.AutoSize = true;

            this.lblCardValue2.Text = "14";
            this.lblCardValue2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCardValue2.ForeColor = System.Drawing.Color.FromArgb(47, 47, 47);
            this.lblCardValue2.Location = new System.Drawing.Point(13, 40);
            this.lblCardValue2.AutoSize = true;

            // Card 3
            this.panelCard3.BackColor = System.Drawing.Color.White;
            this.panelCard3.Controls.Add(this.lblCardTitle3);
            this.panelCard3.Controls.Add(this.lblCardValue3);
            this.panelCard3.Location = new System.Drawing.Point(525, 100);
            this.panelCard3.Size = new System.Drawing.Size(220, 95);

            this.lblCardTitle3.Text = "Transaksi Sukses";
            this.lblCardTitle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblCardTitle3.ForeColor = System.Drawing.Color.Gray;
            this.lblCardTitle3.Location = new System.Drawing.Point(15, 15);
            this.lblCardTitle3.AutoSize = true;

            this.lblCardValue3.Text = "128";
            this.lblCardValue3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCardValue3.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.lblCardValue3.Location = new System.Drawing.Point(13, 40);
            this.lblCardValue3.AutoSize = true;

            // ==========================================
            // NAVIGATION FILTER BUTTONS
            // ==========================================
            int btnY = 220;
            this.btnSemua.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.btnSemua.ForeColor = System.Drawing.Color.White;
            this.btnSemua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSemua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSemua.FlatAppearance.BorderSize = 0;
            this.btnSemua.Location = new System.Drawing.Point(45, btnY);
            this.btnSemua.Size = new System.Drawing.Size(90, 32);
            this.btnSemua.Text = "Semua";

            this.btnPending.BackColor = System.Drawing.Color.White;
            this.btnPending.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnPending.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPending.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.btnPending.Location = new System.Drawing.Point(145, btnY);
            this.btnPending.Size = new System.Drawing.Size(95, 32);
            this.btnPending.Text = "⏳ Pending";

            this.btnBerhasil.BackColor = System.Drawing.Color.White;
            this.btnBerhasil.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnBerhasil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnBerhasil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBerhasil.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.btnBerhasil.Location = new System.Drawing.Point(250, btnY);
            this.btnBerhasil.Size = new System.Drawing.Size(95, 32);
            this.btnBerhasil.Text = "✅ Berhasil";

            this.btnGagal.BackColor = System.Drawing.Color.White;
            this.btnGagal.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnGagal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnGagal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGagal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.btnGagal.Location = new System.Drawing.Point(355, btnY);
            this.btnGagal.Size = new System.Drawing.Size(95, 32);
            this.btnGagal.Text = "❌ Gagal";

            // ==========================================
            // DATA GRID VIEW (Tabel Riwayat Sisi Kiri)
            // ==========================================
            this.dgvTransaksi.AllowUserToAddRows = false;
            this.dgvTransaksi.AllowUserToResizeRows = false;
            this.dgvTransaksi.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransaksi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransaksi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTransaksi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(244, 249, 244);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.dgvTransaksi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransaksi.ColumnHeadersHeight = 45;
            this.dgvTransaksi.Columns.AddRange(new DataGridViewColumn[] {
                this.colIdTransaksi,
                this.colUsername,
                this.colNama,
                this.colKontak,
                this.colJumlahTopup,
                this.colStatus
            });

            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(242, 248, 242);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.dgvTransaksi.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransaksi.EnableHeadersVisualStyles = false;
            this.dgvTransaksi.GridColor = System.Drawing.Color.FromArgb(242, 242, 242);
            this.dgvTransaksi.Location = new System.Drawing.Point(45, 270);
            this.dgvTransaksi.Name = "dgvTransaksi";
            this.dgvTransaksi.ReadOnly = true;
            this.dgvTransaksi.RowHeadersVisible = false;
            this.dgvTransaksi.RowTemplate.Height = 52;
            this.dgvTransaksi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransaksi.Size = new System.Drawing.Size(700, 340); // Ukuran disesuaikan agar panel kanan muat

            // Definisi Struktur Kolom Grid
            this.colIdTransaksi.Name = "colIdTransaksi";
            this.colIdTransaksi.HeaderText = "ID";
            this.colIdTransaksi.Width = 50;

            this.colUsername.Name = "colUsername";
            this.colUsername.HeaderText = "Username";
            this.colUsername.Width = 100;

            this.colNama.Name = "colNama";
            this.colNama.HeaderText = "Customer";
            this.colNama.Width = 140;

            this.colKontak.Name = "colKontak";
            this.colKontak.HeaderText = "Kontak";
            this.colKontak.Width = 110;

            this.colJumlahTopup.Name = "colJumlahTopup";
            this.colJumlahTopup.HeaderText = "Nominal";
            this.colJumlahTopup.Width = 110;

            this.colStatus.Name = "colStatus";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Width = 90;

            // ==========================================
            // SISI KANAN: PANEL STRUK KONFIRMASI AKSI
            // ==========================================
            this.panelAksiSide.BackColor = System.Drawing.Color.White;
            this.panelAksiSide.Controls.Add(this.lblAksiTitle);
            this.panelAksiSide.Controls.Add(this.lblHintCari);
            this.panelAksiSide.Controls.Add(this.txtUsernameCari);
            this.panelAksiSide.Controls.Add(this.lblNamaCustomerHeader);
            this.panelAksiSide.Controls.Add(this.lblNamaCustomer);
            this.panelAksiSide.Controls.Add(this.lblSaldoAktifHeader);
            this.panelAksiSide.Controls.Add(this.lblSaldoAktif);
            this.panelAksiSide.Controls.Add(this.btnKonfirmasiTopUp);
            this.panelAksiSide.Location = new System.Drawing.Point(765, 100);
            this.panelAksiSide.Name = "panelAksiSide";
            this.panelAksiSide.Size = new System.Drawing.Size(230, 510);

            this.lblAksiTitle.Text = "Detail Konfirmasi";
            this.lblAksiTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAksiTitle.ForeColor = System.Drawing.Color.FromArgb(47, 47, 47);
            this.lblAksiTitle.Location = new System.Drawing.Point(15, 15);
            this.lblAksiTitle.AutoSize = true;

            this.lblHintCari.Text = "Username Terpilih:";
            this.lblHintCari.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHintCari.ForeColor = System.Drawing.Color.Gray;
            this.lblHintCari.Location = new System.Drawing.Point(15, 55);
            this.lblHintCari.AutoSize = true;

            this.txtUsernameCari.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsernameCari.Location = new System.Drawing.Point(18, 75);
            this.txtUsernameCari.Name = "txtUsernameCari";
            this.txtUsernameCari.Size = new System.Drawing.Size(194, 25);
            this.txtUsernameCari.ReadOnly = true; // Otomatis terisi saat baris tabel di-klik

            this.lblNamaCustomerHeader.Text = "Nama Akun Customer";
            this.lblNamaCustomerHeader.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNamaCustomerHeader.ForeColor = System.Drawing.Color.Gray;
            this.lblNamaCustomerHeader.Location = new System.Drawing.Point(15, 125);
            this.lblNamaCustomerHeader.AutoSize = true;

            this.lblNamaCustomer.Text = "-";
            this.lblNamaCustomer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNamaCustomer.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblNamaCustomer.Location = new System.Drawing.Point(15, 145);
            this.lblNamaCustomer.Size = new System.Drawing.Size(194, 20);

            this.lblSaldoAktifHeader.Text = "Saldo Aktif Saat Ini";
            this.lblSaldoAktifHeader.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSaldoAktifHeader.ForeColor = System.Drawing.Color.Gray;
            this.lblSaldoAktifHeader.Location = new System.Drawing.Point(15, 195);
            this.lblSaldoAktifHeader.AutoSize = true;

            this.lblSaldoAktif.Text = "Rp 0";
            this.lblSaldoAktif.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSaldoAktif.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.lblSaldoAktif.Location = new System.Drawing.Point(13, 215);
            this.lblSaldoAktif.Size = new System.Drawing.Size(194, 25);

            this.btnKonfirmasiTopUp.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.btnKonfirmasiTopUp.ForeColor = System.Drawing.Color.White;
            this.btnKonfirmasiTopUp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKonfirmasiTopUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKonfirmasiTopUp.FlatAppearance.BorderSize = 0;
            this.btnKonfirmasiTopUp.Location = new System.Drawing.Point(18, 445);
            this.btnKonfirmasiTopUp.Name = "btnKonfirmasiTopUp";
            this.btnKonfirmasiTopUp.Size = new System.Drawing.Size(194, 45);
            this.btnKonfirmasiTopUp.Text = "✔ SETUJUI TOP UP";
            this.btnKonfirmasiTopUp.UseVisualStyleBackColor = false;

            // ==========================================
            // FORM SETUP FINAL
            // ==========================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.cardPanel);
            this.Name = "AdTopUpCustomer";
            this.Text = "EcoDrive Admin Portal";

            this.cardPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panelCard1.ResumeLayout(false);
            this.panelCard1.PerformLayout();
            this.panelCard2.ResumeLayout(false);
            this.panelCard2.PerformLayout();
            this.panelCard3.ResumeLayout(false);
            this.panelCard3.PerformLayout();
            this.panelAksiSide.ResumeLayout(false);
            this.panelAksiSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private EcoDriveUI.RoundedPanel cardPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnGagal;
        private System.Windows.Forms.Button btnBerhasil;
        private System.Windows.Forms.Button btnPending;
        private System.Windows.Forms.Button btnSemua;
        private System.Windows.Forms.DataGridView dgvTransaksi;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.DataGridViewTextBoxColumn colIdTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJumlahTopup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNama;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKontak;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;

        private EcoDriveUI.RoundedPanel panelCard1;
        private System.Windows.Forms.Label lblCardTitle1;
        private System.Windows.Forms.Label lblCardValue1;

        private EcoDriveUI.RoundedPanel panelCard2;
        private System.Windows.Forms.Label lblCardTitle2;
        private System.Windows.Forms.Label lblCardValue2;

        private EcoDriveUI.RoundedPanel panelCard3;
        private System.Windows.Forms.Label lblCardTitle3;
        private System.Windows.Forms.Label lblCardValue3;

        private EcoDriveUI.RoundedPanel panelAksiSide;
        private System.Windows.Forms.Label lblAksiTitle;
        private System.Windows.Forms.Label lblHintCari;
        private System.Windows.Forms.TextBox txtUsernameCari;
        private System.Windows.Forms.Label lblNamaCustomerHeader;
        private System.Windows.Forms.Label lblNamaCustomer;
        private System.Windows.Forms.Label lblSaldoAktifHeader;
        private System.Windows.Forms.Label lblSaldoAktif;
        private System.Windows.Forms.Button btnKonfirmasiTopUp;
    }
}
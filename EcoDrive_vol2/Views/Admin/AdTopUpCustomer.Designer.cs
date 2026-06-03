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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            cardPanel = new EcoDriveUI.RoundedPanel();
            mainPanel = new Panel();
            panelCard1 = new EcoDriveUI.RoundedPanel();
            lblCardTitle1 = new Label();
            lblCardValue1 = new Label();
            panelCard2 = new EcoDriveUI.RoundedPanel();
            lblCardTitle2 = new Label();
            lblCardValue2 = new Label();
            panelCard3 = new EcoDriveUI.RoundedPanel();
            lblCardTitle3 = new Label();
            lblCardValue3 = new Label();
            btnGagal = new Button();
            btnBerhasil = new Button();
            dgvTransaksi = new DataGridView();
            colIdTransaksi = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colNama = new DataGridViewTextBoxColumn();
            colKontak = new DataGridViewTextBoxColumn();
            colJumlahTopup = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnPending = new Button();
            lblTitle = new Label();
            btnSemua = new Button();
            lblSubtitle = new Label();
            panelAksiSide = new EcoDriveUI.RoundedPanel();
            lblAksiTitle = new Label();
            lblHintCari = new Label();
            txtUsernameCari = new TextBox();
            lblNamaCustomerHeader = new Label();
            lblNamaCustomer = new Label();
            lblSaldoAktifHeader = new Label();
            lblSaldoAktif = new Label();
            btnKonfirmasiTopUp = new Button();
            btnTolakTopUp = new Button();
            cardPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            panelCard1.SuspendLayout();
            panelCard2.SuspendLayout();
            panelCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).BeginInit();
            panelAksiSide.SuspendLayout();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.FromArgb(250, 252, 250);
            cardPanel.Controls.Add(mainPanel);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(0, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(30);
            cardPanel.Size = new Size(1100, 700);
            cardPanel.TabIndex = 2;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.Transparent;
            mainPanel.Controls.Add(panelCard1);
            mainPanel.Controls.Add(panelCard2);
            mainPanel.Controls.Add(panelCard3);
            mainPanel.Controls.Add(btnGagal);
            mainPanel.Controls.Add(btnBerhasil);
            mainPanel.Controls.Add(dgvTransaksi);
            mainPanel.Controls.Add(btnPending);
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(btnSemua);
            mainPanel.Controls.Add(lblSubtitle);
            mainPanel.Controls.Add(panelAksiSide);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(30, 30);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1040, 640);
            mainPanel.TabIndex = 0;
            // 
            // panelCard1
            // 
            panelCard1.BackColor = Color.White;
            panelCard1.Controls.Add(lblCardTitle1);
            panelCard1.Controls.Add(lblCardValue1);
            panelCard1.Location = new Point(45, 100);
            panelCard1.Name = "panelCard1";
            panelCard1.Size = new Size(220, 95);
            panelCard1.TabIndex = 0;
            // 
            // lblCardTitle1
            // 
            lblCardTitle1.AutoSize = true;
            lblCardTitle1.Font = new Font("Segoe UI", 9F);
            lblCardTitle1.ForeColor = Color.Gray;
            lblCardTitle1.Location = new Point(15, 15);
            lblCardTitle1.Name = "lblCardTitle1";
            lblCardTitle1.Size = new Size(85, 15);
            lblCardTitle1.TabIndex = 0;
            lblCardTitle1.Text = "Top Up Hari Ini";
            // 
            // lblCardValue1
            // 
            lblCardValue1.AutoSize = true;
            lblCardValue1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCardValue1.ForeColor = Color.FromArgb(47, 47, 47);
            lblCardValue1.Location = new Point(13, 40);
            lblCardValue1.Name = "lblCardValue1";
            lblCardValue1.Size = new Size(110, 32);
            lblCardValue1.TabIndex = 1;
            lblCardValue1.Text = "Rp 4.8M";
            // 
            // panelCard2
            // 
            panelCard2.BackColor = Color.White;
            panelCard2.Controls.Add(lblCardTitle2);
            panelCard2.Controls.Add(lblCardValue2);
            panelCard2.Location = new Point(285, 100);
            panelCard2.Name = "panelCard2";
            panelCard2.Size = new Size(220, 95);
            panelCard2.TabIndex = 1;
            // 
            // lblCardTitle2
            // 
            lblCardTitle2.AutoSize = true;
            lblCardTitle2.Font = new Font("Segoe UI", 9F);
            lblCardTitle2.ForeColor = Color.Gray;
            lblCardTitle2.Location = new Point(15, 15);
            lblCardTitle2.Name = "lblCardTitle2";
            lblCardTitle2.Size = new Size(115, 15);
            lblCardTitle2.TabIndex = 0;
            lblCardTitle2.Text = "Permintaan Pending";
            // 
            // lblCardValue2
            // 
            lblCardValue2.AutoSize = true;
            lblCardValue2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCardValue2.ForeColor = Color.FromArgb(47, 47, 47);
            lblCardValue2.Location = new Point(13, 40);
            lblCardValue2.Name = "lblCardValue2";
            lblCardValue2.Size = new Size(42, 32);
            lblCardValue2.TabIndex = 1;
            lblCardValue2.Text = "14";
            // 
            // panelCard3
            // 
            panelCard3.BackColor = Color.White;
            panelCard3.Controls.Add(lblCardTitle3);
            panelCard3.Controls.Add(lblCardValue3);
            panelCard3.Location = new Point(525, 100);
            panelCard3.Name = "panelCard3";
            panelCard3.Size = new Size(220, 95);
            panelCard3.TabIndex = 2;
            // 
            // lblCardTitle3
            // 
            lblCardTitle3.AutoSize = true;
            lblCardTitle3.Font = new Font("Segoe UI", 9F);
            lblCardTitle3.ForeColor = Color.Gray;
            lblCardTitle3.Location = new Point(15, 15);
            lblCardTitle3.Name = "lblCardTitle3";
            lblCardTitle3.Size = new Size(92, 15);
            lblCardTitle3.TabIndex = 0;
            lblCardTitle3.Text = "Transaksi Sukses";
            // 
            // lblCardValue3
            // 
            lblCardValue3.AutoSize = true;
            lblCardValue3.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCardValue3.ForeColor = Color.FromArgb(46, 125, 50);
            lblCardValue3.Location = new Point(13, 40);
            lblCardValue3.Name = "lblCardValue3";
            lblCardValue3.Size = new Size(56, 32);
            lblCardValue3.TabIndex = 1;
            lblCardValue3.Text = "128";
            // 
            // btnGagal
            // 
            btnGagal.BackColor = Color.White;
            btnGagal.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 230);
            btnGagal.FlatStyle = FlatStyle.Flat;
            btnGagal.Font = new Font("Segoe UI", 9F);
            btnGagal.ForeColor = Color.FromArgb(100, 100, 100);
            btnGagal.Location = new Point(355, 220);
            btnGagal.Name = "btnGagal";
            btnGagal.Size = new Size(95, 32);
            btnGagal.TabIndex = 3;
            btnGagal.Text = "❌ Gagal";
            btnGagal.UseVisualStyleBackColor = false;
            // 
            // btnBerhasil
            // 
            btnBerhasil.BackColor = Color.White;
            btnBerhasil.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 230);
            btnBerhasil.FlatStyle = FlatStyle.Flat;
            btnBerhasil.Font = new Font("Segoe UI", 9F);
            btnBerhasil.ForeColor = Color.FromArgb(100, 100, 100);
            btnBerhasil.Location = new Point(250, 220);
            btnBerhasil.Name = "btnBerhasil";
            btnBerhasil.Size = new Size(95, 32);
            btnBerhasil.TabIndex = 4;
            btnBerhasil.Text = "✅ Berhasil";
            btnBerhasil.UseVisualStyleBackColor = false;
            // 
            // dgvTransaksi
            // 
            dgvTransaksi.AllowUserToAddRows = false;
            dgvTransaksi.AllowUserToResizeRows = false;
            dgvTransaksi.BackgroundColor = Color.White;
            dgvTransaksi.BorderStyle = BorderStyle.None;
            dgvTransaksi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransaksi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(244, 249, 244);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(46, 125, 50);
            dgvTransaksi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTransaksi.ColumnHeadersHeight = 45;
            dgvTransaksi.Columns.AddRange(new DataGridViewColumn[] { colIdTransaksi, colUsername, colNama, colKontak, colJumlahTopup, colStatus });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(242, 248, 242);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(46, 125, 50);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvTransaksi.DefaultCellStyle = dataGridViewCellStyle4;
            dgvTransaksi.EnableHeadersVisualStyles = false;
            dgvTransaksi.GridColor = Color.FromArgb(242, 242, 242);
            dgvTransaksi.Location = new Point(45, 270);
            dgvTransaksi.Name = "dgvTransaksi";
            dgvTransaksi.ReadOnly = true;
            dgvTransaksi.RowHeadersVisible = false;
            dgvTransaksi.RowTemplate.Height = 52;
            dgvTransaksi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransaksi.Size = new Size(700, 340);
            dgvTransaksi.TabIndex = 5;
            // 
            // colIdTransaksi
            // 
            colIdTransaksi.HeaderText = "ID";
            colIdTransaksi.Name = "colIdTransaksi";
            colIdTransaksi.ReadOnly = true;
            colIdTransaksi.Width = 50;
            // 
            // colUsername
            // 
            colUsername.HeaderText = "Username";
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            // 
            // colNama
            // 
            colNama.HeaderText = "Customer";
            colNama.Name = "colNama";
            colNama.ReadOnly = true;
            colNama.Width = 140;
            // 
            // colKontak
            // 
            colKontak.HeaderText = "Kontak";
            colKontak.Name = "colKontak";
            colKontak.ReadOnly = true;
            colKontak.Width = 110;
            // 
            // colJumlahTopup
            // 
            colJumlahTopup.HeaderText = "Nominal";
            colJumlahTopup.Name = "colJumlahTopup";
            colJumlahTopup.ReadOnly = true;
            colJumlahTopup.Width = 110;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 90;
            // 
            // btnPending
            // 
            btnPending.BackColor = Color.White;
            btnPending.FlatAppearance.BorderColor = Color.FromArgb(230, 230, 230);
            btnPending.FlatStyle = FlatStyle.Flat;
            btnPending.Font = new Font("Segoe UI", 9F);
            btnPending.ForeColor = Color.FromArgb(100, 100, 100);
            btnPending.Location = new Point(145, 220);
            btnPending.Name = "btnPending";
            btnPending.Size = new Size(95, 32);
            btnPending.TabIndex = 6;
            btnPending.Text = "⏳ Pending";
            btnPending.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(40, 42, 40);
            lblTitle.Location = new Point(40, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(148, 41);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Transaksi";
            // 
            // btnSemua
            // 
            btnSemua.BackColor = Color.FromArgb(46, 125, 50);
            btnSemua.FlatAppearance.BorderSize = 0;
            btnSemua.FlatStyle = FlatStyle.Flat;
            btnSemua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSemua.ForeColor = Color.White;
            btnSemua.Location = new Point(45, 220);
            btnSemua.Name = "btnSemua";
            btnSemua.Size = new Size(90, 32);
            btnSemua.TabIndex = 8;
            btnSemua.Text = "Semua";
            btnSemua.UseVisualStyleBackColor = false;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.DarkGray;
            lblSubtitle.Location = new Point(44, 58);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(296, 17);
            lblSubtitle.TabIndex = 9;
            lblSubtitle.Text = "Riwayat dan status konfirmasi top up saldo rental";
            // 
            // panelAksiSide
            // 
            panelAksiSide.BackColor = Color.White;
            panelAksiSide.Controls.Add(btnTolakTopUp);
            panelAksiSide.Controls.Add(lblAksiTitle);
            panelAksiSide.Controls.Add(lblHintCari);
            panelAksiSide.Controls.Add(txtUsernameCari);
            panelAksiSide.Controls.Add(lblNamaCustomerHeader);
            panelAksiSide.Controls.Add(lblNamaCustomer);
            panelAksiSide.Controls.Add(lblSaldoAktifHeader);
            panelAksiSide.Controls.Add(lblSaldoAktif);
            panelAksiSide.Controls.Add(btnKonfirmasiTopUp);
            panelAksiSide.Location = new Point(765, 100);
            panelAksiSide.Name = "panelAksiSide";
            panelAksiSide.Size = new Size(230, 510);
            panelAksiSide.TabIndex = 10;
            // 
            // lblAksiTitle
            // 
            lblAksiTitle.AutoSize = true;
            lblAksiTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAksiTitle.ForeColor = Color.FromArgb(47, 47, 47);
            lblAksiTitle.Location = new Point(15, 15);
            lblAksiTitle.Name = "lblAksiTitle";
            lblAksiTitle.Size = new Size(143, 21);
            lblAksiTitle.TabIndex = 0;
            lblAksiTitle.Text = "Detail Konfirmasi";
            // 
            // lblHintCari
            // 
            lblHintCari.AutoSize = true;
            lblHintCari.Font = new Font("Segoe UI", 8.5F);
            lblHintCari.ForeColor = Color.Gray;
            lblHintCari.Location = new Point(15, 55);
            lblHintCari.Name = "lblHintCari";
            lblHintCari.Size = new Size(104, 15);
            lblHintCari.TabIndex = 1;
            lblHintCari.Text = "Username Terpilih:";
            // 
            // txtUsernameCari
            // 
            txtUsernameCari.Font = new Font("Segoe UI", 10F);
            txtUsernameCari.Location = new Point(18, 75);
            txtUsernameCari.Name = "txtUsernameCari";
            txtUsernameCari.ReadOnly = true;
            txtUsernameCari.Size = new Size(194, 25);
            txtUsernameCari.TabIndex = 2;
            // 
            // lblNamaCustomerHeader
            // 
            lblNamaCustomerHeader.AutoSize = true;
            lblNamaCustomerHeader.Font = new Font("Segoe UI", 8.5F);
            lblNamaCustomerHeader.ForeColor = Color.Gray;
            lblNamaCustomerHeader.Location = new Point(15, 125);
            lblNamaCustomerHeader.Name = "lblNamaCustomerHeader";
            lblNamaCustomerHeader.Size = new Size(125, 15);
            lblNamaCustomerHeader.TabIndex = 3;
            lblNamaCustomerHeader.Text = "Nama Akun Customer";
            // 
            // lblNamaCustomer
            // 
            lblNamaCustomer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNamaCustomer.ForeColor = Color.FromArgb(50, 50, 50);
            lblNamaCustomer.Location = new Point(15, 145);
            lblNamaCustomer.Name = "lblNamaCustomer";
            lblNamaCustomer.Size = new Size(194, 20);
            lblNamaCustomer.TabIndex = 4;
            lblNamaCustomer.Text = "-";
            // 
            // lblSaldoAktifHeader
            // 
            lblSaldoAktifHeader.AutoSize = true;
            lblSaldoAktifHeader.Font = new Font("Segoe UI", 8.5F);
            lblSaldoAktifHeader.ForeColor = Color.Gray;
            lblSaldoAktifHeader.Location = new Point(15, 195);
            lblSaldoAktifHeader.Name = "lblSaldoAktifHeader";
            lblSaldoAktifHeader.Size = new Size(105, 15);
            lblSaldoAktifHeader.TabIndex = 5;
            lblSaldoAktifHeader.Text = "Saldo Aktif Saat Ini";
            // 
            // lblSaldoAktif
            // 
            lblSaldoAktif.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSaldoAktif.ForeColor = Color.FromArgb(46, 125, 50);
            lblSaldoAktif.Location = new Point(13, 215);
            lblSaldoAktif.Name = "lblSaldoAktif";
            lblSaldoAktif.Size = new Size(194, 25);
            lblSaldoAktif.TabIndex = 6;
            lblSaldoAktif.Text = "Rp 0";
            // 
            // btnKonfirmasiTopUp
            // 
            btnKonfirmasiTopUp.BackColor = Color.FromArgb(46, 125, 50);
            btnKonfirmasiTopUp.FlatAppearance.BorderSize = 0;
            btnKonfirmasiTopUp.FlatStyle = FlatStyle.Flat;
            btnKonfirmasiTopUp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKonfirmasiTopUp.ForeColor = Color.White;
            btnKonfirmasiTopUp.Location = new Point(18, 374);
            btnKonfirmasiTopUp.Name = "btnKonfirmasiTopUp";
            btnKonfirmasiTopUp.Size = new Size(194, 45);
            btnKonfirmasiTopUp.TabIndex = 7;
            btnKonfirmasiTopUp.Text = "✔ SETUJUI TOP UP";
            btnKonfirmasiTopUp.UseVisualStyleBackColor = false;
            // 
            // btnTolakTopUp
            // 
            btnTolakTopUp.BackColor = Color.Firebrick;
            btnTolakTopUp.FlatAppearance.BorderSize = 0;
            btnTolakTopUp.FlatStyle = FlatStyle.Flat;
            btnTolakTopUp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTolakTopUp.ForeColor = Color.White;
            btnTolakTopUp.Location = new Point(18, 425);
            btnTolakTopUp.Name = "btnTolakTopUp";
            btnTolakTopUp.Size = new Size(194, 45);
            btnTolakTopUp.TabIndex = 8;
            btnTolakTopUp.Text = "✖ TOLAK TOP UP";
            btnTolakTopUp.UseVisualStyleBackColor = false;
            btnTolakTopUp.Click += btnTolakTopUp_Click;
            // 
            // AdTopUpCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(cardPanel);
            Name = "AdTopUpCustomer";
            Text = "EcoDrive Admin Portal";
            cardPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            panelCard1.ResumeLayout(false);
            panelCard1.PerformLayout();
            panelCard2.ResumeLayout(false);
            panelCard2.PerformLayout();
            panelCard3.ResumeLayout(false);
            panelCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).EndInit();
            panelAksiSide.ResumeLayout(false);
            panelAksiSide.PerformLayout();
            ResumeLayout(false);
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
        private Button btnTolakTopUp;
    }
}
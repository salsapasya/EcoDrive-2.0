namespace EcoDrive_vol2.Views
{
    partial class AdTransaksi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            mainPanel = new Panel();
            dgvTransaksi = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colKategori = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colNama = new DataGridViewTextBoxColumn();
            colKontak = new DataGridViewTextBoxColumn();
            colKendaraan = new DataGridViewTextBoxColumn();
            colTipe = new DataGridViewTextBoxColumn();
            colPlat = new DataGridViewTextBoxColumn();
            colTglSewa = new DataGridViewTextBoxColumn();
            colTglKembali = new DataGridViewTextBoxColumn();
            colTglCharging = new DataGridViewTextBoxColumn();
            colNamaStation = new DataGridViewTextBoxColumn();
            colDurasi = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colBiaya = new DataGridViewTextBoxColumn();
            lblSubtitle = new Label();
            lblTitle = new Label();
            btnSemua = new Button();
            btnSewa = new Button();
            btnCharging = new Button();
            cardPanel = new EcoDriveUI.RoundedPanel();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).BeginInit();
            cardPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.Transparent;
            mainPanel.Controls.Add(dgvTransaksi);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(25, 25);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(998, 517);
            mainPanel.TabIndex = 12;
            // 
            // dgvTransaksi
            // 
            dgvTransaksi.AllowUserToAddRows = false;
            dgvTransaksi.AllowUserToResizeRows = false;
            dgvTransaksi.BackgroundColor = Color.White;
            dgvTransaksi.BorderStyle = BorderStyle.None;
            dgvTransaksi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransaksi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(232, 245, 233);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(232, 245, 233);
            dgvTransaksi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTransaksi.ColumnHeadersHeight = 45;
            dgvTransaksi.Columns.AddRange(new DataGridViewColumn[] { colId, colKategori, colUsername, colNama, colKontak, colKendaraan, colTipe, colPlat, colTglSewa, colTglKembali, colTglCharging, colNamaStation, colDurasi, colStatus, colBiaya });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(242, 249, 242);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTransaksi.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTransaksi.EnableHeadersVisualStyles = false;
            dgvTransaksi.GridColor = Color.FromArgb(240, 242, 240);
            dgvTransaksi.Location = new Point(34, 123);
            dgvTransaksi.MultiSelect = false;
            dgvTransaksi.Name = "dgvTransaksi";
            dgvTransaksi.RowHeadersVisible = false;
            dgvTransaksi.RowHeadersWidth = 62;
            dgvTransaksi.RowTemplate.Height = 65;
            dgvTransaksi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransaksi.Size = new Size(919, 376);
            dgvTransaksi.TabIndex = 8;
            dgvTransaksi.CellContentClick += dgvTransaksi_CellContentClick;
            // 
            // colId
            // 
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colId.FillWeight = 50F;
            colId.HeaderText = "ID";
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            colId.Width = 80;
            // 
            // colKategori
            // 
            colKategori.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colKategori.HeaderText = "Kategori";
            colKategori.Name = "colKategori";
            colKategori.Visible = false;
            colKategori.Width = 90;
            // 
            // colUsername
            // 
            colUsername.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colUsername.HeaderText = "Username";
            colUsername.Name = "colUsername";
            colUsername.Width = 120;
            // 
            // colNama
            // 
            colNama.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colNama.FillWeight = 140F;
            colNama.HeaderText = "Nama";
            colNama.MinimumWidth = 8;
            colNama.Name = "colNama";
            colNama.Width = 120;
            // 
            // colKontak
            // 
            colKontak.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colKontak.FillWeight = 90F;
            colKontak.HeaderText = "Kontak";
            colKontak.MinimumWidth = 8;
            colKontak.Name = "colKontak";
            colKontak.Width = 120;
            // 
            // colKendaraan
            // 
            colKendaraan.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colKendaraan.HeaderText = "Kendaraan";
            colKendaraan.MinimumWidth = 8;
            colKendaraan.Name = "colKendaraan";
            colKendaraan.Width = 120;
            // 
            // colTipe
            // 
            colTipe.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTipe.HeaderText = "Tipe";
            colTipe.MinimumWidth = 8;
            colTipe.Name = "colTipe";
            // 
            // colPlat
            // 
            colPlat.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPlat.HeaderText = "Plat Nomor";
            colPlat.MinimumWidth = 8;
            colPlat.Name = "colPlat";
            // 
            // colTglSewa
            // 
            colTglSewa.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTglSewa.FillWeight = 70F;
            colTglSewa.HeaderText = "Tgl Sewa";
            colTglSewa.MinimumWidth = 8;
            colTglSewa.Name = "colTglSewa";
            colTglSewa.Width = 110;
            // 
            // colTglKembali
            // 
            colTglKembali.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTglKembali.HeaderText = "Tgl Kembali";
            colTglKembali.MinimumWidth = 8;
            colTglKembali.Name = "colTglKembali";
            colTglKembali.Width = 110;
            // 
            // colTglCharging
            // 
            colTglCharging.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTglCharging.FillWeight = 70F;
            colTglCharging.HeaderText = "Tgl Charging";
            colTglCharging.MinimumWidth = 8;
            colTglCharging.Name = "colTglCharging";
            colTglCharging.Width = 150;
            // 
            // colNamaStation
            // 
            colNamaStation.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colNamaStation.HeaderText = "Nama Station";
            colNamaStation.MinimumWidth = 8;
            colNamaStation.Name = "colNamaStation";
            colNamaStation.Width = 140;
            // 
            // colDurasi
            // 
            colDurasi.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colDurasi.FillWeight = 70F;
            colDurasi.HeaderText = "Durasi";
            colDurasi.MinimumWidth = 8;
            colDurasi.Name = "colDurasi";
            colDurasi.Width = 90;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colStatus.FillWeight = 70F;
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            // 
            // colBiaya
            // 
            colBiaya.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colBiaya.HeaderText = "Biaya";
            colBiaya.MinimumWidth = 8;
            colBiaya.Name = "colBiaya";
            colBiaya.Width = 120;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.DarkGray;
            lblSubtitle.Location = new Point(62, 89);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(188, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manajemen Transaksi EcoDrive";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(47, 47, 47);
            lblTitle.Location = new Point(53, 45);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(243, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kelola Transaksi";
            // 
            // btnSemua
            // 
            btnSemua.Location = new Point(59, 117);
            btnSemua.Name = "btnSemua";
            btnSemua.Size = new Size(75, 23);
            btnSemua.TabIndex = 9;
            btnSemua.Text = "Semua";
            btnSemua.UseVisualStyleBackColor = true;
            // 
            // btnSewa
            // 
            btnSewa.Location = new Point(155, 117);
            btnSewa.Name = "btnSewa";
            btnSewa.Size = new Size(75, 23);
            btnSewa.TabIndex = 10;
            btnSewa.Text = "Sewa";
            btnSewa.UseVisualStyleBackColor = true;
            // 
            // btnCharging
            // 
            btnCharging.Location = new Point(255, 117);
            btnCharging.Name = "btnCharging";
            btnCharging.Size = new Size(75, 23);
            btnCharging.TabIndex = 11;
            btnCharging.Text = "Charging";
            btnCharging.UseVisualStyleBackColor = true;
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.White;
            cardPanel.Controls.Add(btnCharging);
            cardPanel.Controls.Add(btnSewa);
            cardPanel.Controls.Add(btnSemua);
            cardPanel.Controls.Add(lblTitle);
            cardPanel.Controls.Add(lblSubtitle);
            cardPanel.Controls.Add(mainPanel);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(0, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(25);
            cardPanel.Size = new Size(1048, 567);
            cardPanel.TabIndex = 1;
            // 
            // AdTransaksi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 567);
            Controls.Add(cardPanel);
            Name = "AdTransaksi";
            Text = "AdTransaksi";
            Load += AdTransaksi_Load;
            mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).EndInit();
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private DataGridView dgvTransaksi;
        private Label lblSubtitle;
        private Label lblTitle;
        private Button btnSemua;
        private Button btnSewa;
        private Button btnCharging;
        private EcoDriveUI.RoundedPanel cardPanel;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colKategori;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colNama;
        private DataGridViewTextBoxColumn colKontak;
        private DataGridViewTextBoxColumn colKendaraan;
        private DataGridViewTextBoxColumn colTipe;
        private DataGridViewTextBoxColumn colPlat;
        private DataGridViewTextBoxColumn colTglSewa;
        private DataGridViewTextBoxColumn colTglKembali;
        private DataGridViewTextBoxColumn colTglCharging;
        private DataGridViewTextBoxColumn colNamaStation;
        private DataGridViewTextBoxColumn colDurasi;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colBiaya;
    }
}
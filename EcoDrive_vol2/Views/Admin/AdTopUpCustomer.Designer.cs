namespace EcoDrive_vol2.Views.Admin
{
    partial class AdTopUpCustomer
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
            cardPanel = new EcoDriveUI.RoundedPanel();
            mainPanel = new Panel();
            btnGagal = new Button();
            btnBerhasil = new Button();
            dgvTransaksi = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colKode = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colNama = new DataGridViewTextBoxColumn();
            colKontak = new DataGridViewTextBoxColumn();
            colJumlah = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colSaldo = new DataGridViewTextBoxColumn();
            btnPending = new Button();
            lblTitle = new Label();
            btnSemua = new Button();
            lblSubtitle = new Label();
            cardPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).BeginInit();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.White;
            cardPanel.Controls.Add(mainPanel);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(0, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(25);
            cardPanel.Size = new Size(953, 503);
            cardPanel.TabIndex = 2;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.Transparent;
            mainPanel.Controls.Add(btnGagal);
            mainPanel.Controls.Add(btnBerhasil);
            mainPanel.Controls.Add(dgvTransaksi);
            mainPanel.Controls.Add(btnPending);
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(btnSemua);
            mainPanel.Controls.Add(lblSubtitle);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(25, 25);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(903, 453);
            mainPanel.TabIndex = 12;
            // 
            // btnGagal
            // 
            btnGagal.Location = new Point(321, 107);
            btnGagal.Name = "btnGagal";
            btnGagal.Size = new Size(75, 23);
            btnGagal.TabIndex = 12;
            btnGagal.Text = "Gagal";
            btnGagal.UseVisualStyleBackColor = true;
            // 
            // btnBerhasil
            // 
            btnBerhasil.Location = new Point(231, 107);
            btnBerhasil.Name = "btnBerhasil";
            btnBerhasil.Size = new Size(75, 23);
            btnBerhasil.TabIndex = 11;
            btnBerhasil.Text = "Berhasil";
            btnBerhasil.UseVisualStyleBackColor = true;
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
            dgvTransaksi.Columns.AddRange(new DataGridViewColumn[] { colId, colKode, colUsername, colNama, colKontak, colJumlah, colStatus, colSaldo });
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
            dgvTransaksi.Location = new Point(31, 150);
            dgvTransaksi.MultiSelect = false;
            dgvTransaksi.Name = "dgvTransaksi";
            dgvTransaksi.RowHeadersVisible = false;
            dgvTransaksi.RowHeadersWidth = 62;
            dgvTransaksi.RowTemplate.Height = 65;
            dgvTransaksi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransaksi.Size = new Size(869, 300);
            dgvTransaksi.TabIndex = 8;
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
            // colKode
            // 
            colKode.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colKode.HeaderText = "Kode";
            colKode.Name = "colKode";
            colKode.Width = 90;
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
            // colJumlah
            // 
            colJumlah.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colJumlah.HeaderText = "Jumlah Top Up";
            colJumlah.MinimumWidth = 8;
            colJumlah.Name = "colJumlah";
            colJumlah.Width = 120;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colStatus.FillWeight = 70F;
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            // 
            // colSaldo
            // 
            colSaldo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colSaldo.HeaderText = "Saldo";
            colSaldo.MinimumWidth = 8;
            colSaldo.Name = "colSaldo";
            colSaldo.Width = 120;
            // 
            // btnPending
            // 
            btnPending.Location = new Point(140, 107);
            btnPending.Name = "btnPending";
            btnPending.Size = new Size(75, 23);
            btnPending.TabIndex = 10;
            btnPending.Text = "Pending";
            btnPending.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(47, 47, 47);
            lblTitle.Location = new Point(49, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(495, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kelola Transaksi Top Up Customer";
            lblTitle.Click += lblTitle_Click;
            // 
            // btnSemua
            // 
            btnSemua.Location = new Point(49, 107);
            btnSemua.Name = "btnSemua";
            btnSemua.Size = new Size(75, 23);
            btnSemua.TabIndex = 9;
            btnSemua.Text = "Semua";
            btnSemua.UseVisualStyleBackColor = true;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.DarkGray;
            lblSubtitle.Location = new Point(49, 75);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(188, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manajemen Transaksi EcoDrive";
            // 
            // AdTopUpCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 503);
            Controls.Add(cardPanel);
            Name = "AdTopUpCustomer";
            Text = "AdTopUpCustomer";
            cardPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private EcoDriveUI.RoundedPanel cardPanel;
        private Button btnBerhasil;
        private Button btnPending;
        private Panel mainPanel;
        private DataGridView dgvTransaksi;
        private Label lblTitle;
        private Button btnSemua;
        private Label lblSubtitle;
        private Button btnGagal;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colKode;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colNama;
        private DataGridViewTextBoxColumn colKontak;
        private DataGridViewTextBoxColumn colJumlah;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colSaldo;
    }
}
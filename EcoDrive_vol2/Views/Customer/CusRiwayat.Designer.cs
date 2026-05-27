namespace EcoDrive_vol2.Views
{
    partial class CusRiwayat
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
            dgvRiwayat = new DataGridView();
            lblTitle = new Label();
            btnKembali = new Button();
            colId = new DataGridViewTextBoxColumn();
            colKendaraan = new DataGridViewTextBoxColumn();
            colTanggal = new DataGridViewTextBoxColumn();
            colDurasi = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).BeginInit();
            SuspendLayout();
            // 
            // dgvRiwayat
            // 
            dgvRiwayat.AllowUserToAddRows = false;
            dgvRiwayat.AllowUserToOrderColumns = true;
            dgvRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRiwayat.BorderStyle = BorderStyle.Fixed3D;
            dgvRiwayat.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRiwayat.Columns.AddRange(new DataGridViewColumn[] { colId, colKendaraan, colTanggal, colDurasi, colTotal, colStatus });
            dgvRiwayat.EnableHeadersVisualStyles = false;
            dgvRiwayat.GridColor = Color.Black;
            dgvRiwayat.Location = new Point(31, 77);
            dgvRiwayat.Name = "dgvRiwayat";
            dgvRiwayat.ReadOnly = true;
            dgvRiwayat.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvRiwayat.RowHeadersVisible = false;
            dgvRiwayat.Size = new Size(732, 318);
            dgvRiwayat.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Elephant", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkOliveGreen;
            lblTitle.Location = new Point(31, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(226, 27);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Riwayat Transaksi";
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(713, 415);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(75, 23);
            btnKembali.TabIndex = 2;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            // 
            // colId
            // 
            colId.HeaderText = "ID Transaksi";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colKendaraan
            // 
            colKendaraan.HeaderText = "Kendaraan";
            colKendaraan.Name = "colKendaraan";
            colKendaraan.ReadOnly = true;
            // 
            // colTanggal
            // 
            colTanggal.HeaderText = "Tanggal";
            colTanggal.Name = "colTanggal";
            colTanggal.ReadOnly = true;
            // 
            // colDurasi
            // 
            colDurasi.HeaderText = "Durasi";
            colDurasi.Name = "colDurasi";
            colDurasi.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // CusRiwayat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnKembali);
            Controls.Add(lblTitle);
            Controls.Add(dgvRiwayat);
            Name = "CusRiwayat";
            Text = "CusRiwayat";
            Load += CusRiwayat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRiwayat;
        private Label lblTitle;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colKendaraan;
        private DataGridViewTextBoxColumn colTanggal;
        private DataGridViewTextBoxColumn colDurasi;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colStatus;
        private Button btnKembali;
    }
}
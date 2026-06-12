using LiveChartsCore.Measure;
using System.Xml.Linq;

namespace EcoDrive_vol2.Views.Admin
{
    partial class FrmDetailKendaraan
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
            lblNama = new Label();
            txtNama = new TextBox();
            lblPlat = new Label();
            txtPlat = new TextBox();
            lblStok = new Label();
            numStok = new NumericUpDown();
            lblHarga = new Label();
            numHarga = new NumericUpDown();
            lblTipe = new Label();
            cbTipe = new ComboBox();
            lblStatus = new Label();
            cbStatus = new ComboBox();
            btnSimpan = new Button();
            btnHapus = new Button();
            ((System.ComponentModel.ISupportInitialize)numStok).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHarga).BeginInit();
            SuspendLayout();
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Location = new Point(30, 20);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(98, 15);
            lblNama.TabIndex = 0;
            lblNama.Text = "Nama Kendaraan";
            // 
            // txtNama
            // 
            txtNama.Location = new Point(30, 45);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(400, 23);
            txtNama.TabIndex = 1;
            // 
            // lblPlat
            // 
            lblPlat.AutoSize = true;
            lblPlat.Location = new Point(30, 90);
            lblPlat.Name = "lblPlat";
            lblPlat.Size = new Size(68, 15);
            lblPlat.TabIndex = 2;
            lblPlat.Text = "Nomor Plat";
            // 
            // txtPlat
            // 
            txtPlat.Location = new Point(30, 115);
            txtPlat.Name = "txtPlat";
            txtPlat.PlaceholderText = "Contoh: B 1234 ABC";
            txtPlat.Size = new Size(400, 23);
            txtPlat.TabIndex = 3;
            // 
            // lblStok
            // 
            lblStok.AutoSize = true;
            lblStok.Location = new Point(30, 160);
            lblStok.Name = "lblStok";
            lblStok.Size = new Size(91, 15);
            lblStok.TabIndex = 4;
            lblStok.Text = "Stok Kendaraan";
            // 
            // numStok
            // 
            numStok.Location = new Point(30, 185);
            numStok.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numStok.Name = "numStok";
            numStok.Size = new Size(400, 23);
            numStok.TabIndex = 5;
            numStok.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.Location = new Point(30, 230);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(93, 15);
            lblHarga.TabIndex = 6;
            lblHarga.Text = "Harga Sewa (Rp)";
            // 
            // numHarga
            // 
            numHarga.Location = new Point(30, 255);
            numHarga.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numHarga.Name = "numHarga";
            numHarga.Size = new Size(400, 23);
            numHarga.TabIndex = 7;
            // 
            // lblTipe
            // 
            lblTipe.AutoSize = true;
            lblTipe.Location = new Point(30, 300);
            lblTipe.Name = "lblTipe";
            lblTipe.Size = new Size(91, 15);
            lblTipe.TabIndex = 8;
            lblTipe.Text = "Tipe Kendaraan";
            // 
            // cbTipe
            // 
            cbTipe.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipe.FormattingEnabled = true;
            cbTipe.Location = new Point(30, 325);
            cbTipe.Name = "cbTipe";
            cbTipe.Size = new Size(400, 23);
            cbTipe.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(30, 370);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 15);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status Kendaraan";
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(30, 395);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(400, 23);
            cbStatus.TabIndex = 11;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.FromArgb(92, 184, 92);
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.ForeColor = Color.White;
            btnSimpan.Location = new Point(250, 480);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(180, 40);
            btnSimpan.TabIndex = 12;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = false;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.FromArgb(244, 67, 54);
            btnHapus.FlatAppearance.BorderSize = 0;
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHapus.ForeColor = Color.White;
            btnHapus.Location = new Point(30, 480);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(150, 40);
            btnHapus.TabIndex = 13;
            btnHapus.Text = "Hapus Kendaraan";
            btnHapus.UseVisualStyleBackColor = false;
            // 
            // FrmDetailKendaraan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(464, 561);
            Controls.Add(btnHapus);
            Controls.Add(btnSimpan);
            Controls.Add(cbStatus);
            Controls.Add(lblStatus);
            Controls.Add(cbTipe);
            Controls.Add(lblTipe);
            Controls.Add(numHarga);
            Controls.Add(lblHarga);
            Controls.Add(numStok);
            Controls.Add(lblStok);
            Controls.Add(txtPlat);
            Controls.Add(lblPlat);
            Controls.Add(txtNama);
            Controls.Add(lblNama);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmDetailKendaraan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detail Kendaraan";
            ((System.ComponentModel.ISupportInitialize)numStok).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHarga).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Deklarasi variabel komponen agar bisa diakses oleh berkas utama FrmDetailKendaraan.cs
        public Label lblNama;
        public TextBox txtNama;
        public Label lblPlat;
        public TextBox txtPlat;
        public Label lblStok;
        public NumericUpDown numStok;
        public Label lblHarga;
        public NumericUpDown numHarga;
        public Label lblTipe;
        public ComboBox cbTipe;
        public Label lblStatus;
        public ComboBox cbStatus;
        public Button btnSimpan;
        public Button btnHapus;
    }
}
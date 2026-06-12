namespace EcoDrive_vol2.Views
{
    partial class CusKendaraan
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
            txtSearch = new TextBox();
            btnSemua = new Button();
            btnMobil = new Button();
            btnMotor = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(245, 245, 240);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.ForeColor = Color.Black;
            txtSearch.Location = new Point(20, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Cari kendaraan...";
            txtSearch.Size = new Size(300, 20);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // btnSemua
            // 
            btnSemua.BackColor = Color.FromArgb(76, 175, 80);
            btnSemua.FlatStyle = FlatStyle.Flat;
            btnSemua.ForeColor = Color.White;
            btnSemua.Location = new Point(20, 60);
            btnSemua.Name = "btnSemua";
            btnSemua.Size = new Size(80, 30);
            btnSemua.TabIndex = 1;
            btnSemua.Text = "Semua";
            btnSemua.UseVisualStyleBackColor = false;
            btnSemua.Click += BtnSemua_Click;
            // 
            // btnMobil
            // 
            btnMobil.BackColor = Color.White;
            btnMobil.FlatStyle = FlatStyle.Flat;
            btnMobil.ForeColor = Color.FromArgb(45, 45, 45);
            btnMobil.Location = new Point(110, 60);
            btnMobil.Name = "btnMobil";
            btnMobil.Size = new Size(80, 30);
            btnMobil.TabIndex = 2;
            btnMobil.Text = "Mobil";
            btnMobil.UseVisualStyleBackColor = false;
            btnMobil.Click += BtnMobil_Click;
            // 
            // btnMotor
            // 
            btnMotor.BackColor = Color.White;
            btnMotor.FlatStyle = FlatStyle.Flat;
            btnMotor.ForeColor = Color.FromArgb(45, 45, 45);
            btnMotor.Location = new Point(200, 60);
            btnMotor.Name = "btnMotor";
            btnMotor.Size = new Size(80, 30);
            btnMotor.TabIndex = 3;
            btnMotor.Text = "Motor";
            btnMotor.UseVisualStyleBackColor = false;
            btnMotor.Click += BtnMotor_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(20, 110);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(760, 430);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // CusKendaraan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 253, 246);
            ClientSize = new Size(800, 560);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnMotor);
            Controls.Add(btnMobil);
            Controls.Add(btnSemua);
            Controls.Add(txtSearch);
            Name = "CusKendaraan";
            Text = "Katalog Kendaraan Listrik";
            Load += CusKendaraan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Deklarasi komponen agar dapat diakses dari file logika utama (.cs)
        public TextBox txtSearch;
        public Button btnSemua;
        public Button btnMobil;
        public Button btnMotor;
        public FlowLayoutPanel flowLayoutPanel1;
    }
}
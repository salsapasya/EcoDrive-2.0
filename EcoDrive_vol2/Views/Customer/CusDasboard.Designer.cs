namespace EcoDrive_vol2
{
    partial class CusDasboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CusDasboard));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pnDasboard = new Panel();
            btDasboard = new Button();
            pnKendaraan = new Panel();
            btKendaraan = new Button();
            pnCharging = new Panel();
            btCharging = new Button();
            pnSaldo = new Panel();
            btSaldo = new Button();
            pnRiwayat = new Panel();
            btRiwayat = new Button();
            pnLogout = new Panel();
            btLogout = new Button();
            pnContentCustomer = new Panel();
            panel1 = new Panel();
            btKembalikanSewa = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnDasboard.SuspendLayout();
            pnKendaraan.SuspendLayout();
            pnCharging.SuspendLayout();
            pnSaldo.SuspendLayout();
            pnRiwayat.SuspendLayout();
            pnLogout.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(30, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 89);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(143, 83);
            label1.Name = "label1";
            label1.Size = new Size(90, 24);
            label1.TabIndex = 2;
            label1.Text = "EcoDrive";
            // 
            // pnDasboard
            // 
            pnDasboard.BackColor = Color.White;
            pnDasboard.Controls.Add(btDasboard);
            pnDasboard.Location = new Point(30, 189);
            pnDasboard.Name = "pnDasboard";
            pnDasboard.Size = new Size(318, 48);
            pnDasboard.TabIndex = 4;
            // 
            // btDasboard
            // 
            btDasboard.BackColor = Color.White;
            btDasboard.FlatAppearance.BorderColor = Color.White;
            btDasboard.FlatStyle = FlatStyle.Flat;
            btDasboard.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btDasboard.Image = (Image)resources.GetObject("btDasboard.Image");
            btDasboard.ImageAlign = ContentAlignment.MiddleLeft;
            btDasboard.Location = new Point(3, 1);
            btDasboard.Name = "btDasboard";
            btDasboard.Size = new Size(312, 44);
            btDasboard.TabIndex = 4;
            btDasboard.Text = "           Dasboard";
            btDasboard.TextAlign = ContentAlignment.MiddleLeft;
            btDasboard.UseVisualStyleBackColor = false;
            // 
            // pnKendaraan
            // 
            pnKendaraan.BackColor = Color.White;
            pnKendaraan.Controls.Add(btKendaraan);
            pnKendaraan.Location = new Point(30, 268);
            pnKendaraan.Name = "pnKendaraan";
            pnKendaraan.Size = new Size(318, 48);
            pnKendaraan.TabIndex = 5;
            // 
            // btKendaraan
            // 
            btKendaraan.BackColor = Color.White;
            btKendaraan.FlatAppearance.BorderColor = Color.White;
            btKendaraan.FlatStyle = FlatStyle.Flat;
            btKendaraan.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btKendaraan.Image = (Image)resources.GetObject("btKendaraan.Image");
            btKendaraan.ImageAlign = ContentAlignment.MiddleLeft;
            btKendaraan.Location = new Point(3, 1);
            btKendaraan.Name = "btKendaraan";
            btKendaraan.Size = new Size(312, 44);
            btKendaraan.TabIndex = 4;
            btKendaraan.Text = "           Kendaraan";
            btKendaraan.TextAlign = ContentAlignment.MiddleLeft;
            btKendaraan.UseVisualStyleBackColor = false;
            btKendaraan.Click += btKendaraan_Click;
            // 
            // pnCharging
            // 
            pnCharging.BackColor = Color.White;
            pnCharging.Controls.Add(btCharging);
            pnCharging.Location = new Point(30, 411);
            pnCharging.Name = "pnCharging";
            pnCharging.Size = new Size(318, 48);
            pnCharging.TabIndex = 6;
            // 
            // btCharging
            // 
            btCharging.BackColor = Color.White;
            btCharging.FlatAppearance.BorderColor = Color.White;
            btCharging.FlatStyle = FlatStyle.Flat;
            btCharging.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btCharging.Image = (Image)resources.GetObject("btCharging.Image");
            btCharging.ImageAlign = ContentAlignment.MiddleLeft;
            btCharging.Location = new Point(3, 1);
            btCharging.Name = "btCharging";
            btCharging.Size = new Size(312, 44);
            btCharging.TabIndex = 4;
            btCharging.Text = "           Charging";
            btCharging.TextAlign = ContentAlignment.MiddleLeft;
            btCharging.UseVisualStyleBackColor = false;
            // 
            // pnSaldo
            // 
            pnSaldo.BackColor = Color.White;
            pnSaldo.Controls.Add(btSaldo);
            pnSaldo.Location = new Point(30, 493);
            pnSaldo.Name = "pnSaldo";
            pnSaldo.Size = new Size(318, 48);
            pnSaldo.TabIndex = 7;
            // 
            // btSaldo
            // 
            btSaldo.BackColor = Color.White;
            btSaldo.FlatAppearance.BorderColor = Color.White;
            btSaldo.FlatStyle = FlatStyle.Flat;
            btSaldo.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btSaldo.Image = (Image)resources.GetObject("btSaldo.Image");
            btSaldo.ImageAlign = ContentAlignment.MiddleLeft;
            btSaldo.Location = new Point(3, 1);
            btSaldo.Name = "btSaldo";
            btSaldo.Size = new Size(312, 44);
            btSaldo.TabIndex = 4;
            btSaldo.Text = "           Saldo";
            btSaldo.TextAlign = ContentAlignment.MiddleLeft;
            btSaldo.UseVisualStyleBackColor = false;
            btSaldo.Click += btSaldo_Click;
            // 
            // pnRiwayat
            // 
            pnRiwayat.BackColor = Color.White;
            pnRiwayat.Controls.Add(btRiwayat);
            pnRiwayat.Location = new Point(30, 569);
            pnRiwayat.Name = "pnRiwayat";
            pnRiwayat.Size = new Size(318, 48);
            pnRiwayat.TabIndex = 8;
            // 
            // btRiwayat
            // 
            btRiwayat.BackColor = Color.White;
            btRiwayat.FlatAppearance.BorderColor = Color.White;
            btRiwayat.FlatStyle = FlatStyle.Flat;
            btRiwayat.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btRiwayat.Image = (Image)resources.GetObject("btRiwayat.Image");
            btRiwayat.ImageAlign = ContentAlignment.MiddleLeft;
            btRiwayat.Location = new Point(3, 1);
            btRiwayat.Name = "btRiwayat";
            btRiwayat.Size = new Size(312, 44);
            btRiwayat.TabIndex = 4;
            btRiwayat.Text = "          Riwayat";
            btRiwayat.TextAlign = ContentAlignment.MiddleLeft;
            btRiwayat.UseVisualStyleBackColor = false;
            // 
            // pnLogout
            // 
            pnLogout.BackColor = Color.White;
            pnLogout.Controls.Add(btLogout);
            pnLogout.Location = new Point(30, 666);
            pnLogout.Name = "pnLogout";
            pnLogout.Size = new Size(318, 48);
            pnLogout.TabIndex = 9;
            // 
            // btLogout
            // 
            btLogout.BackColor = Color.MistyRose;
            btLogout.FlatAppearance.BorderColor = Color.White;
            btLogout.FlatStyle = FlatStyle.Flat;
            btLogout.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btLogout.ForeColor = Color.Red;
            btLogout.Image = (Image)resources.GetObject("btLogout.Image");
            btLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btLogout.Location = new Point(3, 1);
            btLogout.Name = "btLogout";
            btLogout.Size = new Size(312, 44);
            btLogout.TabIndex = 4;
            btLogout.Text = "           Logout";
            btLogout.TextAlign = ContentAlignment.MiddleLeft;
            btLogout.UseVisualStyleBackColor = false;
            btLogout.Click += btLogout_Click;
            // 
            // pnContentCustomer
            // 
            pnContentCustomer.BackColor = Color.Transparent;
            pnContentCustomer.Location = new Point(364, 97);
            pnContentCustomer.Name = "pnContentCustomer";
            pnContentCustomer.Size = new Size(994, 640);
            pnContentCustomer.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btKembalikanSewa);
            panel1.Location = new Point(30, 339);
            panel1.Name = "panel1";
            panel1.Size = new Size(318, 48);
            panel1.TabIndex = 11;
            // 
            // btKembalikanSewa
            // 
            btKembalikanSewa.BackColor = Color.White;
            btKembalikanSewa.FlatAppearance.BorderColor = Color.White;
            btKembalikanSewa.FlatStyle = FlatStyle.Flat;
            btKembalikanSewa.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btKembalikanSewa.Image = (Image)resources.GetObject("btKembalikanSewa.Image");
            btKembalikanSewa.ImageAlign = ContentAlignment.MiddleLeft;
            btKembalikanSewa.Location = new Point(3, 1);
            btKembalikanSewa.Name = "btKembalikanSewa";
            btKembalikanSewa.Size = new Size(312, 44);
            btKembalikanSewa.TabIndex = 4;
            btKembalikanSewa.Text = "           Kembalikan Sewa";
            btKembalikanSewa.TextAlign = ContentAlignment.MiddleLeft;
            btKembalikanSewa.UseVisualStyleBackColor = false;
            btKembalikanSewa.Click += btKembalikanSewa_Click_1;
            // 
            // CusDasboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1370, 749);
            Controls.Add(panel1);
            Controls.Add(pnContentCustomer);
            Controls.Add(pnLogout);
            Controls.Add(pnRiwayat);
            Controls.Add(pnSaldo);
            Controls.Add(pnCharging);
            Controls.Add(pnKendaraan);
            Controls.Add(pnDasboard);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            Name = "CusDasboard";
            Text = "CusDasboard";
            Load += CusDasboard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnDasboard.ResumeLayout(false);
            pnKendaraan.ResumeLayout(false);
            pnCharging.ResumeLayout(false);
            pnSaldo.ResumeLayout(false);
            pnRiwayat.ResumeLayout(false);
            pnLogout.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label label1;
        private Panel pnDasboard;
        private Button btDasboard;
        private Panel pnKendaraan;
        private Button btKendaraan;
        private Panel pnCharging;
        private Button btCharging;
        private Panel pnSaldo;
        private Button btSaldo;
        private Panel pnRiwayat;
        private Button btRiwayat;
        private Panel pnLogout;
        private Button btLogout;
        private Panel pnContentCustomer;
        private Panel panel1;
        private Button btKembalikanSewa;
    }
}

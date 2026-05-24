namespace EcoDrive_vol2.Views
{
    partial class AdDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdDashboard));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btDasboard = new Button();
            pnDashboard = new Panel();
            pnCustomer = new Panel();
            btCustomer = new Button();
            pnKendaraan = new Panel();
            btKendaraan = new Button();
            pnTransaksi = new Panel();
            btTransaksi = new Button();
            pnPendapatan = new Panel();
            btPendapatan = new Button();
            panel1 = new Panel();
            pnContent = new Panel();
            btLogout = new Button();
            pnContentAdmin = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnDashboard.SuspendLayout();
            pnCustomer.SuspendLayout();
            pnKendaraan.SuspendLayout();
            pnTransaksi.SuspendLayout();
            pnPendapatan.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(33, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 89);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(142, 76);
            label1.Name = "label1";
            label1.Size = new Size(90, 24);
            label1.TabIndex = 3;
            label1.Text = "EcoDrive";
            // 
            // btDasboard
            // 
            btDasboard.BackColor = Color.White;
            btDasboard.FlatAppearance.BorderColor = Color.White;
            btDasboard.FlatStyle = FlatStyle.Flat;
            btDasboard.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btDasboard.Image = (Image)resources.GetObject("btDasboard.Image");
            btDasboard.ImageAlign = ContentAlignment.MiddleLeft;
            btDasboard.Location = new Point(3, 3);
            btDasboard.Name = "btDasboard";
            btDasboard.Size = new Size(312, 44);
            btDasboard.TabIndex = 5;
            btDasboard.Text = "           Dasboard";
            btDasboard.TextAlign = ContentAlignment.MiddleLeft;
            btDasboard.UseVisualStyleBackColor = false;
            // 
            // pnDashboard
            // 
            pnDashboard.BackColor = Color.Transparent;
            pnDashboard.Controls.Add(btDasboard);
            pnDashboard.Location = new Point(23, 176);
            pnDashboard.Name = "pnDashboard";
            pnDashboard.Size = new Size(322, 53);
            pnDashboard.TabIndex = 6;
            // 
            // pnCustomer
            // 
            pnCustomer.BackColor = Color.Transparent;
            pnCustomer.Controls.Add(btCustomer);
            pnCustomer.Location = new Point(23, 263);
            pnCustomer.Name = "pnCustomer";
            pnCustomer.Size = new Size(322, 53);
            pnCustomer.TabIndex = 7;
            // 
            // btCustomer
            // 
            btCustomer.BackColor = Color.White;
            btCustomer.FlatAppearance.BorderColor = Color.White;
            btCustomer.FlatStyle = FlatStyle.Flat;
            btCustomer.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btCustomer.Image = (Image)resources.GetObject("btCustomer.Image");
            btCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btCustomer.Location = new Point(3, 3);
            btCustomer.Name = "btCustomer";
            btCustomer.Size = new Size(312, 44);
            btCustomer.TabIndex = 5;
            btCustomer.Text = "           Customer";
            btCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btCustomer.UseVisualStyleBackColor = false;
            // 
            // pnKendaraan
            // 
            pnKendaraan.BackColor = Color.Transparent;
            pnKendaraan.Controls.Add(btKendaraan);
            pnKendaraan.Location = new Point(23, 347);
            pnKendaraan.Name = "pnKendaraan";
            pnKendaraan.Size = new Size(322, 53);
            pnKendaraan.TabIndex = 8;
            // 
            // btKendaraan
            // 
            btKendaraan.BackColor = Color.White;
            btKendaraan.FlatAppearance.BorderColor = Color.White;
            btKendaraan.FlatStyle = FlatStyle.Flat;
            btKendaraan.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btKendaraan.Image = (Image)resources.GetObject("btKendaraan.Image");
            btKendaraan.ImageAlign = ContentAlignment.MiddleLeft;
            btKendaraan.Location = new Point(3, 3);
            btKendaraan.Name = "btKendaraan";
            btKendaraan.Size = new Size(312, 44);
            btKendaraan.TabIndex = 5;
            btKendaraan.Text = "           Kendaraan";
            btKendaraan.TextAlign = ContentAlignment.MiddleLeft;
            btKendaraan.UseVisualStyleBackColor = false;
            btKendaraan.Click += btKendaraan_Click;
            // 
            // pnTransaksi
            // 
            pnTransaksi.BackColor = Color.Transparent;
            pnTransaksi.Controls.Add(btTransaksi);
            pnTransaksi.Location = new Point(23, 429);
            pnTransaksi.Name = "pnTransaksi";
            pnTransaksi.Size = new Size(322, 53);
            pnTransaksi.TabIndex = 9;
            // 
            // btTransaksi
            // 
            btTransaksi.BackColor = Color.White;
            btTransaksi.FlatAppearance.BorderColor = Color.White;
            btTransaksi.FlatStyle = FlatStyle.Flat;
            btTransaksi.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btTransaksi.Image = (Image)resources.GetObject("btTransaksi.Image");
            btTransaksi.ImageAlign = ContentAlignment.MiddleLeft;
            btTransaksi.Location = new Point(3, 3);
            btTransaksi.Name = "btTransaksi";
            btTransaksi.Size = new Size(312, 44);
            btTransaksi.TabIndex = 5;
            btTransaksi.Text = "           Transaksi";
            btTransaksi.TextAlign = ContentAlignment.MiddleLeft;
            btTransaksi.UseVisualStyleBackColor = false;
            // 
            // pnPendapatan
            // 
            pnPendapatan.BackColor = Color.Transparent;
            pnPendapatan.Controls.Add(btPendapatan);
            pnPendapatan.Location = new Point(23, 510);
            pnPendapatan.Name = "pnPendapatan";
            pnPendapatan.Size = new Size(322, 53);
            pnPendapatan.TabIndex = 10;
            // 
            // btPendapatan
            // 
            btPendapatan.BackColor = Color.White;
            btPendapatan.FlatAppearance.BorderColor = Color.White;
            btPendapatan.FlatStyle = FlatStyle.Flat;
            btPendapatan.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btPendapatan.Image = (Image)resources.GetObject("btPendapatan.Image");
            btPendapatan.ImageAlign = ContentAlignment.MiddleLeft;
            btPendapatan.Location = new Point(3, 3);
            btPendapatan.Name = "btPendapatan";
            btPendapatan.Size = new Size(312, 44);
            btPendapatan.TabIndex = 5;
            btPendapatan.Text = "           Pendapatan";
            btPendapatan.TextAlign = ContentAlignment.MiddleLeft;
            btPendapatan.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pnContent);
            panel1.Controls.Add(btLogout);
            panel1.Location = new Point(23, 655);
            panel1.Name = "panel1";
            panel1.Size = new Size(322, 53);
            panel1.TabIndex = 11;
            // 
            // pnContent
            // 
            pnContent.BackColor = Color.Transparent;
            pnContent.Location = new Point(-336, -294);
            pnContent.Name = "pnContent";
            pnContent.Size = new Size(994, 640);
            pnContent.TabIndex = 11;
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
            btLogout.Location = new Point(3, 3);
            btLogout.Name = "btLogout";
            btLogout.Size = new Size(312, 44);
            btLogout.TabIndex = 5;
            btLogout.Text = "           Logout";
            btLogout.TextAlign = ContentAlignment.MiddleLeft;
            btLogout.UseVisualStyleBackColor = false;
            // 
            // pnContentAdmin
            // 
            pnContentAdmin.BackColor = Color.Transparent;
            pnContentAdmin.Location = new Point(364, 97);
            pnContentAdmin.Name = "pnContentAdmin";
            pnContentAdmin.Size = new Size(994, 640);
            pnContentAdmin.TabIndex = 12;
            // 
            // AdDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1370, 749);
            Controls.Add(pnContentAdmin);
            Controls.Add(panel1);
            Controls.Add(pnPendapatan);
            Controls.Add(pnTransaksi);
            Controls.Add(pnKendaraan);
            Controls.Add(pnCustomer);
            Controls.Add(pnDashboard);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            Name = "AdDashboard";
            Text = "AdDashboard";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnDashboard.ResumeLayout(false);
            pnCustomer.ResumeLayout(false);
            pnKendaraan.ResumeLayout(false);
            pnTransaksi.ResumeLayout(false);
            pnPendapatan.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Button btDasboard;
        private Panel pnDashboard;
        private Panel pnCustomer;
        private Button btCustomer;
        private Panel pnKendaraan;
        private Button btKendaraan;
        private Panel pnTransaksi;
        private Button btTransaksi;
        private Panel pnPendapatan;
        private Button btPendapatan;
        private Panel panel1;
        private Button btLogout;
        private Panel pnContent;
        private Panel pnContentAdmin;
    }
}
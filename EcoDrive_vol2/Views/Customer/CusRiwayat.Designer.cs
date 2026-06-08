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
            mainPanel = new Panel();
            cardPanel = new Panel();
            tcRiwayat = new TabControl();
            tabPage1 = new TabPage();
            flpSewa = new FlowLayoutPanel();
            tabPage2 = new TabPage();
            flpCharging = new FlowLayoutPanel();
            tabPage3 = new TabPage();
            flpTopUp = new FlowLayoutPanel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            mainPanel.SuspendLayout();
            cardPanel.SuspendLayout();
            tcRiwayat.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(250, 248, 242);
            mainPanel.Controls.Add(cardPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(20, 15, 20, 20);
            mainPanel.Size = new Size(1010, 579);
            mainPanel.TabIndex = 2;
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.White;
            cardPanel.Controls.Add(tcRiwayat);
            cardPanel.Controls.Add(lblSubtitle);
            cardPanel.Controls.Add(lblTitle);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(20, 15);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(25, 25, 25, 20);
            cardPanel.Size = new Size(970, 544);
            cardPanel.TabIndex = 0;
            // 
            // tcRiwayat
            // 
            tcRiwayat.Controls.Add(tabPage1);
            tcRiwayat.Controls.Add(tabPage2);
            tcRiwayat.Controls.Add(tabPage3);
            tcRiwayat.Dock = DockStyle.Fill;
            tcRiwayat.Location = new Point(25, 99);
            tcRiwayat.Name = "tcRiwayat";
            tcRiwayat.SelectedIndex = 0;
            tcRiwayat.Size = new Size(920, 425);
            tcRiwayat.TabIndex = 4;
            tcRiwayat.Tag = "";
            tcRiwayat.Click += CusRiwayat_Load;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(flpSewa);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(912, 397);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Sewa Kendaraan";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // flpSewa
            // 
            flpSewa.AutoScroll = true;
            flpSewa.Dock = DockStyle.Fill;
            flpSewa.FlowDirection = FlowDirection.TopDown;
            flpSewa.Location = new Point(3, 3);
            flpSewa.Name = "flpSewa";
            flpSewa.Size = new Size(696, 262);
            flpSewa.TabIndex = 0;
            flpSewa.WrapContents = false;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(flpCharging);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(702, 268);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Charging";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // flpCharging
            // 
            flpCharging.AutoScroll = true;
            flpCharging.Dock = DockStyle.Fill;
            flpCharging.FlowDirection = FlowDirection.TopDown;
            flpCharging.Location = new Point(3, 3);
            flpCharging.Name = "flpCharging";
            flpCharging.Size = new Size(696, 262);
            flpCharging.TabIndex = 1;
            flpCharging.WrapContents = false;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(flpTopUp);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(702, 268);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Top Up";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // flpTopUp
            // 
            flpTopUp.AutoScroll = true;
            flpTopUp.Dock = DockStyle.Fill;
            flpTopUp.FlowDirection = FlowDirection.TopDown;
            flpTopUp.Location = new Point(3, 3);
            flpTopUp.Name = "flpTopUp";
            flpTopUp.Size = new Size(696, 262);
            flpTopUp.TabIndex = 1;
            flpTopUp.WrapContents = false;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Dock = DockStyle.Top;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.DarkGray;
            lblSubtitle.Location = new Point(25, 62);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Padding = new Padding(7, 5, 0, 15);
            lblSubtitle.Size = new Size(231, 37);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Riwayat Transaksi Customer EcoDrive";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(45, 45, 45);
            lblTitle.Location = new Point(25, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(5, 0, 0, 0);
            lblTitle.Size = new Size(251, 37);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Riwayat Transaksi";
            // 
            // CusRiwayat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 579);
            Controls.Add(mainPanel);
            Name = "CusRiwayat";
            Text = "CusRiwayat";
            mainPanel.ResumeLayout(false);
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            tcRiwayat.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel cardPanel;
        private Label lblSubtitle;
        private Label lblTitle;
        private TabControl tcRiwayat;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private FlowLayoutPanel flpSewa;
        private FlowLayoutPanel flpCharging;
        private FlowLayoutPanel flpTopUp;
    }
}
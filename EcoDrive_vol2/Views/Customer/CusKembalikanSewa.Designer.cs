namespace EcoDrive_vol2.Views.Customer
{
    partial class CusKembalikanSewa
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
            FlowLayoutPanel = new FlowLayoutPanel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            mainPanel.SuspendLayout();
            cardPanel.SuspendLayout();
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
            mainPanel.Size = new Size(928, 471);
            mainPanel.TabIndex = 2;
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.White;
            cardPanel.Controls.Add(FlowLayoutPanel);
            cardPanel.Controls.Add(lblSubtitle);
            cardPanel.Controls.Add(lblTitle);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(20, 15);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(25, 25, 25, 20);
            cardPanel.Size = new Size(888, 436);
            cardPanel.TabIndex = 0;
            // 
            // FlowLayoutPanel
            // 
            FlowLayoutPanel.AutoScroll = true;
            FlowLayoutPanel.BackColor = Color.FromArgb(252, 252, 250);
            FlowLayoutPanel.Dock = DockStyle.Fill;
            FlowLayoutPanel.Location = new Point(25, 99);
            FlowLayoutPanel.Name = "FlowLayoutPanel";
            FlowLayoutPanel.Size = new Size(838, 317);
            FlowLayoutPanel.TabIndex = 4;
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
            lblSubtitle.Size = new Size(400, 37);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Tempat Pengembalian Kendaraan EcoDrive yang Telah Anda Sewa";
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
            lblTitle.Size = new Size(424, 37);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Pengembalian Kendaraan Sewa";
            // 
            // CusKembalikanSewa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 471);
            Controls.Add(mainPanel);
            Name = "CusKembalikanSewa";
            Text = "CusKembalikanSewa";
            Load += CusKembalikanSewa_Load;
            mainPanel.ResumeLayout(false);
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel cardPanel;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel;
        private Label lblSubtitle;
        private Label lblTitle;
    }
}
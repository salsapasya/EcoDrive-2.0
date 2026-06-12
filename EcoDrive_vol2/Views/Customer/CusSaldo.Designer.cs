namespace EcoDrive_vol2.Views
{
    partial class CusSaldo
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
            flpRiwayatSaldo = new FlowLayoutPanel();
            lblRiwayatTitle = new Label();
            pnlSaldoCard = new Panel();
            btnTopUp = new Button();
            lblPengguna = new Label();
            lblSaldo = new Label();
            lblTotalSaldoTitle = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            mainPanel.SuspendLayout();
            cardPanel.SuspendLayout();
            pnlSaldoCard.SuspendLayout();
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
            mainPanel.Size = new Size(800, 450);
            mainPanel.TabIndex = 3;
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.White;
            cardPanel.Controls.Add(flpRiwayatSaldo);
            cardPanel.Controls.Add(lblRiwayatTitle);
            cardPanel.Controls.Add(pnlSaldoCard);
            cardPanel.Controls.Add(lblSubtitle);
            cardPanel.Controls.Add(lblTitle);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(20, 15);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(25, 25, 25, 20);
            cardPanel.Size = new Size(760, 415);
            cardPanel.TabIndex = 0;
            // 
            // flpRiwayatSaldo
            // 
            flpRiwayatSaldo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpRiwayatSaldo.AutoScroll = true;
            flpRiwayatSaldo.BackColor = Color.Transparent;
            flpRiwayatSaldo.FlowDirection = FlowDirection.TopDown;
            flpRiwayatSaldo.Location = new Point(28, 279);
            flpRiwayatSaldo.Name = "flpRiwayatSaldo";
            flpRiwayatSaldo.Size = new Size(704, 113);
            flpRiwayatSaldo.TabIndex = 6;
            flpRiwayatSaldo.WrapContents = false;
            // 
            // lblRiwayatTitle
            // 
            lblRiwayatTitle.AutoSize = true;
            lblRiwayatTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRiwayatTitle.Location = new Point(25, 235);
            lblRiwayatTitle.Name = "lblRiwayatTitle";
            lblRiwayatTitle.Size = new Size(118, 21);
            lblRiwayatTitle.TabIndex = 5;
            lblRiwayatTitle.Text = "Riwayat Saldo";
            lblRiwayatTitle.Click += lblRiwayatTitle_Click;
            // 
            // pnlSaldoCard
            // 
            pnlSaldoCard.BackColor = Color.FromArgb(30, 37, 47);
            pnlSaldoCard.Controls.Add(btnTopUp);
            pnlSaldoCard.Controls.Add(lblPengguna);
            pnlSaldoCard.Controls.Add(lblSaldo);
            pnlSaldoCard.Controls.Add(lblTotalSaldoTitle);
            pnlSaldoCard.Location = new Point(25, 102);
            pnlSaldoCard.Name = "pnlSaldoCard";
            pnlSaldoCard.Size = new Size(707, 113);
            pnlSaldoCard.TabIndex = 4;
            // 
            // btnTopUp
            // 
            btnTopUp.BackColor = Color.FromArgb(134, 196, 62);
            btnTopUp.FlatStyle = FlatStyle.Flat;
            btnTopUp.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTopUp.ForeColor = Color.White;
            btnTopUp.Location = new Point(583, 62);
            btnTopUp.Name = "btnTopUp";
            btnTopUp.Size = new Size(94, 29);
            btnTopUp.TabIndex = 3;
            btnTopUp.Text = "Top Up Saldo";
            btnTopUp.UseVisualStyleBackColor = false;
            btnTopUp.Click += btnTopup_Click;
            // 
            // lblPengguna
            // 
            lblPengguna.AutoSize = true;
            lblPengguna.ForeColor = Color.DarkGray;
            lblPengguna.Location = new Point(19, 70);
            lblPengguna.Name = "lblPengguna";
            lblPengguna.Size = new Size(162, 15);
            lblPengguna.TabIndex = 2;
            lblPengguna.Text = "ID Pengguna: ECO-2026-0001";
            lblPengguna.Click += lblPengguna_Click;
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSaldo.ForeColor = Color.White;
            lblSaldo.Location = new Point(129, 12);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(185, 37);
            lblSaldo.TabIndex = 1;
            lblSaldo.Text = "Rp 1.500.000";
            lblSaldo.Click += lblSaldoBesar_Click;
            // 
            // lblTotalSaldoTitle
            // 
            lblTotalSaldoTitle.AutoSize = true;
            lblTotalSaldoTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalSaldoTitle.ForeColor = Color.LightGray;
            lblTotalSaldoTitle.Location = new Point(19, 22);
            lblTotalSaldoTitle.Name = "lblTotalSaldoTitle";
            lblTotalSaldoTitle.Size = new Size(104, 25);
            lblTotalSaldoTitle.TabIndex = 0;
            lblTotalSaldoTitle.Text = "Total Saldo";
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
            lblSubtitle.Size = new Size(235, 37);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Silahkan Top Up Saldo EcoDrive Anda";
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
            lblTitle.Size = new Size(200, 37);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Top Up Saldo ";
            // 
            // CusSaldo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainPanel);
            Name = "CusSaldo";
            Text = "CusSaldo";
            Load += CusSaldo_Load;
            mainPanel.ResumeLayout(false);
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            pnlSaldoCard.ResumeLayout(false);
            pnlSaldoCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel cardPanel;
        private Label lblSubtitle;
        private Panel pnlSaldoCard;
        private Label lblTotalSaldoTitle;
        private Label lblSaldo;
        private Button btnTopUp;
        private Label lblPengguna;
        private Label lblRiwayatTitle;
        private FlowLayoutPanel flpRiwayatSaldo;
        private Label lblTitle;
    }
}
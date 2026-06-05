namespace EcoDrive_vol2.Views
{
    partial class CusCharging
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            btnFilterKendaraan = new Button();
            btnFilterStation = new Button();
            flpChargingContainer = new FlowLayoutPanel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            mainPanel.SuspendLayout();
            cardPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
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
            mainPanel.Size = new Size(1053, 557);
            mainPanel.TabIndex = 1;
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.White;
            cardPanel.Controls.Add(tableLayoutPanel1);
            cardPanel.Controls.Add(lblSubtitle);
            cardPanel.Controls.Add(lblTitle);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(20, 15);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(25, 25, 25, 20);
            cardPanel.Size = new Size(1013, 522);
            cardPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flpChargingContainer, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(25, 99);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(963, 403);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnFilterKendaraan);
            panel1.Controls.Add(btnFilterStation);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(851, 39);
            panel1.TabIndex = 0;
            // 
            // btnFilterKendaraan
            // 
            btnFilterKendaraan.BackColor = Color.FromArgb(248, 244, 238);
            btnFilterKendaraan.FlatStyle = FlatStyle.Flat;
            btnFilterKendaraan.ForeColor = Color.FromArgb(45, 45, 45);
            btnFilterKendaraan.Location = new Point(137, 3);
            btnFilterKendaraan.Name = "btnFilterKendaraan";
            btnFilterKendaraan.Size = new Size(128, 32);
            btnFilterKendaraan.TabIndex = 5;
            btnFilterKendaraan.Text = "Sedang Di-Charge";
            btnFilterKendaraan.UseVisualStyleBackColor = false;
            // 
            // btnFilterStation
            // 
            btnFilterStation.BackColor = Color.FromArgb(76, 175, 80);
            btnFilterStation.FlatStyle = FlatStyle.Flat;
            btnFilterStation.ForeColor = Color.White;
            btnFilterStation.Location = new Point(3, 3);
            btnFilterStation.Name = "btnFilterStation";
            btnFilterStation.Size = new Size(128, 32);
            btnFilterStation.TabIndex = 4;
            btnFilterStation.Text = "Station Charging";
            btnFilterStation.UseVisualStyleBackColor = false;
            // 
            // flpChargingContainer
            // 
            flpChargingContainer.AutoScroll = true;
            flpChargingContainer.BackColor = Color.FromArgb(252, 252, 250);
            flpChargingContainer.Dock = DockStyle.Fill;
            flpChargingContainer.Location = new Point(3, 48);
            flpChargingContainer.Name = "flpChargingContainer";
            flpChargingContainer.Size = new Size(957, 352);
            flpChargingContainer.TabIndex = 1;
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
            lblSubtitle.Size = new Size(319, 37);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Pilih stasiun atau pantau status pengisian daya Anda";
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
            lblTitle.Size = new Size(284, 37);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Charging Kendaraan";
            // 
            // CusCharging
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 557);
            Controls.Add(mainPanel);
            Name = "CusCharging";
            Text = "CusCharging";
            mainPanel.ResumeLayout(false);
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel cardPanel;
        private Label lblSubtitle;
        private Label lblTitle;
        private Button btnFilterStation;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button btnFilterKendaraan;
        private FlowLayoutPanel flpChargingContainer;
    }
}
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
            mainPanel = new Panel();
            cardPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            filterTableLayout = new TableLayoutPanel();
            txtSearch = new TextBox();
            leftFilterFlow = new FlowLayoutPanel();
            btnSemua = new Button();
            btnMobil = new Button();
            btnMotor = new Button();
            lblSubtitle = new Label();
            lblTitle = new Label();
            mainPanel.SuspendLayout();
            cardPanel.SuspendLayout();
            filterTableLayout.SuspendLayout();
            leftFilterFlow.SuspendLayout();
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
            mainPanel.Size = new Size(1100, 650);
            mainPanel.TabIndex = 0;
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.White;
            cardPanel.Controls.Add(flowLayoutPanel1);
            cardPanel.Controls.Add(filterTableLayout);
            cardPanel.Controls.Add(lblSubtitle);
            cardPanel.Controls.Add(lblTitle);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(20, 15);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(25, 25, 25, 20);
            cardPanel.Size = new Size(1060, 615);
            cardPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(252, 252, 250);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(25, 144);
            flowLayoutPanel1.Margin = new Padding(0, 15, 0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Size = new Size(1010, 451);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // filterTableLayout
            // 
            filterTableLayout.ColumnCount = 3;
            filterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            filterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240F));
            filterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            filterTableLayout.Controls.Add(txtSearch, 0, 0);
            filterTableLayout.Controls.Add(leftFilterFlow, 1, 0);
            filterTableLayout.Dock = DockStyle.Top;
            filterTableLayout.Location = new Point(25, 99);
            filterTableLayout.Name = "filterTableLayout";
            filterTableLayout.RowCount = 1;
            filterTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            filterTableLayout.Size = new Size(1010, 45);
            filterTableLayout.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BackColor = Color.FromArgb(248, 244, 238);
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(0, 2);
            txtSearch.Margin = new Padding(0, 2, 15, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(745, 27);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // leftFilterFlow
            // 
            leftFilterFlow.Controls.Add(btnSemua);
            leftFilterFlow.Controls.Add(btnMobil);
            leftFilterFlow.Controls.Add(btnMotor);
            leftFilterFlow.Dock = DockStyle.Fill;
            leftFilterFlow.Location = new Point(760, 0);
            leftFilterFlow.Margin = new Padding(0);
            leftFilterFlow.Name = "leftFilterFlow";
            leftFilterFlow.Size = new Size(240, 45);
            leftFilterFlow.TabIndex = 1;
            // 
            // btnSemua
            // 
            btnSemua.BackColor = Color.FromArgb(76, 175, 80);
            btnSemua.FlatStyle = FlatStyle.Flat;
            btnSemua.ForeColor = Color.White;
            btnSemua.Location = new Point(0, 2);
            btnSemua.Margin = new Padding(0, 2, 6, 0);
            btnSemua.Name = "btnSemua";
            btnSemua.Size = new Size(75, 36);
            btnSemua.TabIndex = 1;
            btnSemua.Text = "Semua";
            btnSemua.UseVisualStyleBackColor = false;
            // 
            // btnMobil
            // 
            btnMobil.BackColor = Color.FromArgb(248, 244, 238);
            btnMobil.FlatStyle = FlatStyle.Flat;
            btnMobil.ForeColor = Color.FromArgb(45, 45, 45);
            btnMobil.Location = new Point(81, 2);
            btnMobil.Margin = new Padding(0, 2, 6, 0);
            btnMobil.Name = "btnMobil";
            btnMobil.Size = new Size(70, 36);
            btnMobil.TabIndex = 2;
            btnMobil.Text = "Mobil";
            btnMobil.UseVisualStyleBackColor = false;
            // 
            // btnMotor
            // 
            btnMotor.BackColor = Color.FromArgb(248, 244, 238);
            btnMotor.FlatStyle = FlatStyle.Flat;
            btnMotor.ForeColor = Color.FromArgb(45, 45, 45);
            btnMotor.Location = new Point(157, 2);
            btnMotor.Margin = new Padding(0, 2, 0, 0);
            btnMotor.Name = "btnMotor";
            btnMotor.Size = new Size(70, 36);
            btnMotor.TabIndex = 3;
            btnMotor.Text = "Motor";
            btnMotor.UseVisualStyleBackColor = false;
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
            lblSubtitle.Size = new Size(336, 37);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Silakan pilih kendaraan listrik favorit Anda untuk disewa";
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
            lblTitle.Size = new Size(234, 37);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Sewa Kendaraan";
            // 
            // CusKendaraan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 650);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CusKendaraan";
            Text = "CusKendaraan";
            Load += CusKendaraan_Load;
            mainPanel.ResumeLayout(false);
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            filterTableLayout.ResumeLayout(false);
            filterTableLayout.PerformLayout();
            leftFilterFlow.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel filterTableLayout;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.FlowLayoutPanel leftFilterFlow;
        private System.Windows.Forms.Button btnSemua;
        private System.Windows.Forms.Button btnMobil;
        private System.Windows.Forms.Button btnMotor;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
    }
}
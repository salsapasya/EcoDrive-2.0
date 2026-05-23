using EcoDriveUI;
using System.Drawing;
using System.Windows.Forms;


namespace EcoDrive_vol2.Views
{
    partial class AdKendaraan
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private RoundedPanel cardPanel; // Menggunakan RoundedPanel kustom Anda
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel filterContainerPanel;
        private RoundedTextBox txtSearch;
        private Button btnSemua;
        private Button btnMobil;
        private Button btnMotor;
        private Button btnTambah;

        // Kontainer utama untuk menampung card-card kendaraan secara dinamis
        private FlowLayoutPanel flowKendaraan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            cardPanel = new RoundedPanel();
            flowKendaraan = new FlowLayoutPanel();
            filterTableLayout = new TableLayoutPanel();
            leftFilterFlow = new FlowLayoutPanel();
            txtSearch = new RoundedTextBox();
            btnSemua = new Button();
            btnMobil = new Button();
            btnMotor = new Button();
            btnTambah = new Button();
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
            cardPanel.Controls.Add(flowKendaraan);
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
            // flowKendaraan
            // 
            flowKendaraan.AutoScroll = true;
            flowKendaraan.BackColor = Color.FromArgb(252, 252, 250);
            flowKendaraan.Dock = DockStyle.Fill;
            flowKendaraan.Location = new Point(25, 144);
            flowKendaraan.Margin = new Padding(0, 15, 0, 0);
            flowKendaraan.Name = "flowKendaraan";
            flowKendaraan.Padding = new Padding(10);
            flowKendaraan.Size = new Size(1010, 451);
            flowKendaraan.TabIndex = 0;
            // 
            // filterTableLayout
            // 
            filterTableLayout.ColumnCount = 2;
            filterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            filterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            filterTableLayout.Controls.Add(leftFilterFlow, 0, 0);
            filterTableLayout.Controls.Add(btnTambah, 1, 0);
            filterTableLayout.Dock = DockStyle.Top;
            filterTableLayout.Location = new Point(25, 99);
            filterTableLayout.Name = "filterTableLayout";
            filterTableLayout.RowCount = 1;
            filterTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            filterTableLayout.Size = new Size(1010, 45);
            filterTableLayout.TabIndex = 1;
            // 
            // leftFilterFlow
            // 
            leftFilterFlow.Controls.Add(txtSearch);
            leftFilterFlow.Controls.Add(btnSemua);
            leftFilterFlow.Controls.Add(btnMobil);
            leftFilterFlow.Controls.Add(btnMotor);
            leftFilterFlow.Dock = DockStyle.Fill;
            leftFilterFlow.Location = new Point(0, 0);
            leftFilterFlow.Margin = new Padding(0);
            leftFilterFlow.Name = "leftFilterFlow";
            leftFilterFlow.Size = new Size(757, 45);
            leftFilterFlow.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(248, 244, 238);
            txtSearch.Location = new Point(0, 2);
            txtSearch.Margin = new Padding(0, 2, 10, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Padding = new Padding(15, 8, 15, 8);
            txtSearch.Size = new Size(300, 36);
            txtSearch.TabIndex = 0;
            // 
            // btnSemua
            // 
            btnSemua.Location = new Point(310, 2);
            btnSemua.Margin = new Padding(0, 2, 6, 0);
            btnSemua.Name = "btnSemua";
            btnSemua.Size = new Size(75, 36);
            btnSemua.TabIndex = 1;
            // 
            // btnMobil
            // 
            btnMobil.Location = new Point(391, 2);
            btnMobil.Margin = new Padding(0, 2, 6, 0);
            btnMobil.Name = "btnMobil";
            btnMobil.Size = new Size(70, 36);
            btnMobil.TabIndex = 2;
            // 
            // btnMotor
            // 
            btnMotor.Location = new Point(467, 2);
            btnMotor.Margin = new Padding(0, 2, 0, 0);
            btnMotor.Name = "btnMotor";
            btnMotor.Size = new Size(70, 36);
            btnMotor.TabIndex = 3;
            // 
            // btnTambah
            // 
            btnTambah.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTambah.Location = new Point(825, 2);
            btnTambah.Margin = new Padding(0, 2, 0, 0);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(185, 36);
            btnTambah.TabIndex = 1;
            btnTambah.Click += btnTambah_Click;
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
            lblSubtitle.Size = new Size(369, 37);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Manajemen armada kendaraan listrik & status baterai realtime";
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
            lblTitle.Size = new Size(248, 37);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Kelola Kendaraan";
            // 
            // AdKendaraan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 248, 242);
            ClientSize = new Size(1100, 650);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdKendaraan";
            Text = "Kelola Kendaraan";
            mainPanel.ResumeLayout(false);
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            filterTableLayout.ResumeLayout(false);
            leftFilterFlow.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Fungsi pembantu dekorasi tombol (Mengurangi redundansi parameter lokasi Point)
        private void SetupButton(Button btn, string text, Color bg, Color fg)
        {
            btn.Text = text;
            btn.BackColor = bg;
            btn.ForeColor = fg;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        private void SetupButton(Button btn, string text, Point location, Color bg, Color fg)
        {
            btn.Text = text;
            btn.Location = location;
            btn.BackColor = bg;
            btn.ForeColor = fg;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        private TableLayoutPanel filterTableLayout;
        private FlowLayoutPanel leftFilterFlow;
    }
}
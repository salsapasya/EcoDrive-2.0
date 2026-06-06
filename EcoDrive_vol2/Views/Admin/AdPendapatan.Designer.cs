namespace EcoDrive_vol2.Views
{
    partial class AdPendapatan
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
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdPendapatan));
            LiveChartsCore.Drawing.Padding padding1 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding2 = new LiveChartsCore.Drawing.Padding();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            cardPanel = new EcoDriveUI.RoundedPanel();
            mainPanel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pnTotalPendapatan = new EcoDriveUI.RoundedPanel();
            lblCardTitle1 = new Label();
            lblCardTotalPendapatan = new Label();
            pnPendapatanSewa = new EcoDriveUI.RoundedPanel();
            label1 = new Label();
            lblCardPendapatanSewa = new Label();
            pnPendapatanCharging = new EcoDriveUI.RoundedPanel();
            label3 = new Label();
            lblCardPendapatanCharging = new Label();
            pnTotalUnitSewa = new EcoDriveUI.RoundedPanel();
            label5 = new Label();
            lblTotalUnitSewa = new Label();
            pnTotalTransaksiCharging = new EcoDriveUI.RoundedPanel();
            label2 = new Label();
            lblTotalTransaksicharging = new Label();
            topPanel = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            dataGridView1 = new DataGridView();
            colBulan = new DataGridViewTextBoxColumn();
            colSewa = new DataGridViewTextBoxColumn();
            colCharging = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            cardPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnTotalPendapatan.SuspendLayout();
            pnPendapatanSewa.SuspendLayout();
            pnPendapatanCharging.SuspendLayout();
            pnTotalUnitSewa.SuspendLayout();
            pnTotalTransaksiCharging.SuspendLayout();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.FromArgb(250, 252, 250);
            cardPanel.Controls.Add(mainPanel);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(0, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(30);
            cardPanel.Size = new Size(893, 570);
            cardPanel.TabIndex = 3;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(tableLayoutPanel1);
            mainPanel.Controls.Add(flowLayoutPanel1);
            mainPanel.Controls.Add(topPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(30, 30);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(833, 510);
            mainPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.Controls.Add(cartesianChart1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 322);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(833, 188);
            tableLayoutPanel1.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(pnTotalPendapatan);
            flowLayoutPanel1.Controls.Add(pnPendapatanSewa);
            flowLayoutPanel1.Controls.Add(pnPendapatanCharging);
            flowLayoutPanel1.Controls.Add(pnTotalUnitSewa);
            flowLayoutPanel1.Controls.Add(pnTotalTransaksiCharging);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 83);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(833, 239);
            flowLayoutPanel1.TabIndex = 14;
            // 
            // pnTotalPendapatan
            // 
            pnTotalPendapatan.BackColor = Color.White;
            pnTotalPendapatan.Controls.Add(lblCardTitle1);
            pnTotalPendapatan.Controls.Add(lblCardTotalPendapatan);
            pnTotalPendapatan.Location = new Point(3, 3);
            pnTotalPendapatan.Name = "pnTotalPendapatan";
            pnTotalPendapatan.Size = new Size(220, 110);
            pnTotalPendapatan.TabIndex = 0;
            // 
            // lblCardTitle1
            // 
            lblCardTitle1.AutoSize = true;
            lblCardTitle1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardTitle1.ForeColor = Color.Gray;
            lblCardTitle1.Location = new Point(60, 20);
            lblCardTitle1.Name = "lblCardTitle1";
            lblCardTitle1.Size = new Size(114, 17);
            lblCardTitle1.TabIndex = 2;
            lblCardTitle1.Text = "Total Pendapatan";
            // 
            // lblCardTotalPendapatan
            // 
            lblCardTotalPendapatan.AutoSize = true;
            lblCardTotalPendapatan.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCardTotalPendapatan.ForeColor = Color.FromArgb(47, 47, 47);
            lblCardTotalPendapatan.Location = new Point(58, 45);
            lblCardTotalPendapatan.Name = "lblCardTotalPendapatan";
            lblCardTotalPendapatan.Size = new Size(110, 32);
            lblCardTotalPendapatan.TabIndex = 3;
            lblCardTotalPendapatan.Text = "Rp 6,7 jt";
            // 
            // pnPendapatanSewa
            // 
            pnPendapatanSewa.BackColor = Color.White;
            pnPendapatanSewa.Controls.Add(label1);
            pnPendapatanSewa.Controls.Add(lblCardPendapatanSewa);
            pnPendapatanSewa.Location = new Point(229, 3);
            pnPendapatanSewa.Name = "pnPendapatanSewa";
            pnPendapatanSewa.Size = new Size(220, 110);
            pnPendapatanSewa.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(52, 20);
            label1.Name = "label1";
            label1.Size = new Size(116, 17);
            label1.TabIndex = 4;
            label1.Text = "Pendapatan Sewa";
            // 
            // lblCardPendapatanSewa
            // 
            lblCardPendapatanSewa.AutoSize = true;
            lblCardPendapatanSewa.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCardPendapatanSewa.ForeColor = Color.FromArgb(47, 47, 47);
            lblCardPendapatanSewa.Location = new Point(52, 45);
            lblCardPendapatanSewa.Name = "lblCardPendapatanSewa";
            lblCardPendapatanSewa.Size = new Size(110, 32);
            lblCardPendapatanSewa.TabIndex = 5;
            lblCardPendapatanSewa.Text = "Rp 6,7 jt";
            // 
            // pnPendapatanCharging
            // 
            pnPendapatanCharging.BackColor = Color.White;
            pnPendapatanCharging.Controls.Add(label3);
            pnPendapatanCharging.Controls.Add(lblCardPendapatanCharging);
            pnPendapatanCharging.Location = new Point(455, 3);
            pnPendapatanCharging.Name = "pnPendapatanCharging";
            pnPendapatanCharging.Size = new Size(220, 110);
            pnPendapatanCharging.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(44, 20);
            label3.Name = "label3";
            label3.Size = new Size(140, 17);
            label3.TabIndex = 4;
            label3.Text = "Pendapatan Charging";
            label3.Click += label3_Click;
            // 
            // lblCardPendapatanCharging
            // 
            lblCardPendapatanCharging.AutoSize = true;
            lblCardPendapatanCharging.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCardPendapatanCharging.ForeColor = Color.FromArgb(47, 47, 47);
            lblCardPendapatanCharging.Location = new Point(54, 45);
            lblCardPendapatanCharging.Name = "lblCardPendapatanCharging";
            lblCardPendapatanCharging.Size = new Size(110, 32);
            lblCardPendapatanCharging.TabIndex = 5;
            lblCardPendapatanCharging.Text = "Rp 6,7 jt";
            // 
            // pnTotalUnitSewa
            // 
            pnTotalUnitSewa.BackColor = Color.White;
            pnTotalUnitSewa.Controls.Add(label5);
            pnTotalUnitSewa.Controls.Add(lblTotalUnitSewa);
            pnTotalUnitSewa.Location = new Point(3, 119);
            pnTotalUnitSewa.Name = "pnTotalUnitSewa";
            pnTotalUnitSewa.Size = new Size(220, 110);
            pnTotalUnitSewa.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(38, 26);
            label5.Name = "label5";
            label5.Size = new Size(151, 17);
            label5.TabIndex = 4;
            label5.Text = "Total Kendaraan disewa";
            // 
            // lblTotalUnitSewa
            // 
            lblTotalUnitSewa.AutoSize = true;
            lblTotalUnitSewa.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalUnitSewa.ForeColor = Color.FromArgb(47, 47, 47);
            lblTotalUnitSewa.Location = new Point(60, 52);
            lblTotalUnitSewa.Name = "lblTotalUnitSewa";
            lblTotalUnitSewa.Size = new Size(83, 32);
            lblTotalUnitSewa.TabIndex = 5;
            lblTotalUnitSewa.Text = "5 Unit";
            // 
            // pnTotalTransaksiCharging
            // 
            pnTotalTransaksiCharging.BackColor = Color.White;
            pnTotalTransaksiCharging.Controls.Add(label2);
            pnTotalTransaksiCharging.Controls.Add(lblTotalTransaksicharging);
            pnTotalTransaksiCharging.Location = new Point(229, 119);
            pnTotalTransaksiCharging.Name = "pnTotalTransaksiCharging";
            pnTotalTransaksiCharging.Size = new Size(220, 110);
            pnTotalTransaksiCharging.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(35, 26);
            label2.Name = "label2";
            label2.Size = new Size(144, 17);
            label2.TabIndex = 6;
            label2.Text = "Total Banyak Charging";
            // 
            // lblTotalTransaksicharging
            // 
            lblTotalTransaksicharging.AutoSize = true;
            lblTotalTransaksicharging.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalTransaksicharging.ForeColor = Color.FromArgb(47, 47, 47);
            lblTotalTransaksicharging.Location = new Point(57, 52);
            lblTotalTransaksicharging.Name = "lblTotalTransaksicharging";
            lblTotalTransaksicharging.Size = new Size(92, 32);
            lblTotalTransaksicharging.TabIndex = 7;
            lblTotalTransaksicharging.Text = "15 Kali";
            // 
            // topPanel
            // 
            topPanel.Controls.Add(lblTitle);
            topPanel.Controls.Add(lblSubtitle);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(833, 83);
            topPanel.TabIndex = 13;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(40, 42, 40);
            lblTitle.Location = new Point(14, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 41);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "Kelola Pendapatan";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.DarkGray;
            lblSubtitle.Location = new Point(18, 53);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(330, 17);
            lblSubtitle.TabIndex = 11;
            lblSubtitle.Text = "Pengelolaan Pendapatan Rental dan Charging EcoDrive";
            // 
            // cartesianChart1
            // 
            cartesianChart1.AutoUpdateEnabled = true;
            cartesianChart1.ChartTheme = null;
            cartesianChart1.Dock = DockStyle.Fill;
            skDefaultLegend1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultLegend1.Content = null;
            skDefaultLegend1.IsValid = true;
            skDefaultLegend1.Opacity = 1F;
            padding1.Bottom = 0F;
            padding1.Left = 0F;
            padding1.Right = 0F;
            padding1.Top = 0F;
            skDefaultLegend1.Padding = padding1;
            skDefaultLegend1.RemoveOnCompleted = false;
            skDefaultLegend1.RotateTransform = 0F;
            skDefaultLegend1.X = 0F;
            skDefaultLegend1.Y = 0F;
            cartesianChart1.Legend = skDefaultLegend1;
            cartesianChart1.Location = new Point(3, 3);
            cartesianChart1.MatchAxesScreenDataRatio = false;
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(452, 182);
            cartesianChart1.TabIndex = 0;
            skDefaultTooltip1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultTooltip1.Content = null;
            skDefaultTooltip1.IsValid = true;
            skDefaultTooltip1.Opacity = 1F;
            padding2.Bottom = 0F;
            padding2.Left = 0F;
            padding2.Right = 0F;
            padding2.Top = 0F;
            skDefaultTooltip1.Padding = padding2;
            skDefaultTooltip1.RemoveOnCompleted = false;
            skDefaultTooltip1.RotateTransform = 0F;
            skDefaultTooltip1.Wedge = 10;
            skDefaultTooltip1.X = 0F;
            skDefaultTooltip1.Y = 0F;
            cartesianChart1.Tooltip = skDefaultTooltip1;
            cartesianChart1.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.Automatic;
            cartesianChart1.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colBulan, colSewa, colCharging, colTotal });
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(461, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(369, 182);
            dataGridView1.TabIndex = 1;
            // 
            // colBulan
            // 
            colBulan.HeaderText = "Bulan";
            colBulan.Name = "colBulan";
            // 
            // colSewa
            // 
            colSewa.HeaderText = "Sewa";
            colSewa.Name = "colSewa";
            // 
            // colCharging
            // 
            colCharging.HeaderText = "Charging";
            colCharging.Name = "colCharging";
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            // 
            // AdPendapatan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 570);
            Controls.Add(cardPanel);
            Name = "AdPendapatan";
            Text = "AdPendapatan";
            cardPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            pnTotalPendapatan.ResumeLayout(false);
            pnTotalPendapatan.PerformLayout();
            pnPendapatanSewa.ResumeLayout(false);
            pnPendapatanSewa.PerformLayout();
            pnPendapatanCharging.ResumeLayout(false);
            pnPendapatanCharging.PerformLayout();
            pnTotalUnitSewa.ResumeLayout(false);
            pnTotalUnitSewa.PerformLayout();
            pnTotalTransaksiCharging.ResumeLayout(false);
            pnTotalTransaksiCharging.PerformLayout();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private EcoDriveUI.RoundedPanel cardPanel;
        private Panel mainPanel;
        private Panel topPanel;
        private Label lblTitle;
        private Label lblSubtitle;
        private FlowLayoutPanel flowLayoutPanel1;
        private EcoDriveUI.RoundedPanel pnTotalPendapatan;
        private EcoDriveUI.RoundedPanel pnPendapatanSewa;
        private EcoDriveUI.RoundedPanel pnPendapatanCharging;
        private EcoDriveUI.RoundedPanel pnTotalUnitSewa;
        private EcoDriveUI.RoundedPanel pnTotalTransaksiCharging;
        private Label lblCardTitle1;
        private Label lblCardTotalPendapatan;
        private Label label1;
        private Label lblCardPendapatanSewa;
        private Label label3;
        private Label lblCardPendapatanCharging;
        private Label label5;
        private Label lblTotalUnitSewa;
        private Label label2;
        private Label lblTotalTransaksicharging;
        private TableLayoutPanel tableLayoutPanel1;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colBulan;
        private DataGridViewTextBoxColumn colSewa;
        private DataGridViewTextBoxColumn colCharging;
        private DataGridViewTextBoxColumn colTotal;
    }
}
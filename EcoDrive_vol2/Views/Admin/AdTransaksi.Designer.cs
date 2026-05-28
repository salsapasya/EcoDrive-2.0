namespace EcoDrive_vol2.Views
{
    partial class AdTransaksi
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            cardPanel = new EcoDriveUI.RoundedPanel();
            cmbFilter = new ComboBox();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnFilter = new Button();
            dgvCustomer = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            colKontak = new DataGridViewTextBoxColumn();
            colBergabung = new DataGridViewTextBoxColumn();
            colTrip = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colAksi = new DataGridViewTextBoxColumn();
            cardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).BeginInit();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.White;
            cardPanel.Controls.Add(cmbFilter);
            cardPanel.Controls.Add(lblTitle);
            cardPanel.Controls.Add(lblSubtitle);
            cardPanel.Controls.Add(btnFilter);
            cardPanel.Controls.Add(dgvCustomer);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(0, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.Padding = new Padding(25);
            cardPanel.Size = new Size(1001, 450);
            cardPanel.TabIndex = 1;
            cardPanel.Paint += cardPanel_Paint;
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(59, 114);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(121, 25);
            cmbFilter.TabIndex = 9;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(47, 47, 47);
            lblTitle.Location = new Point(50, 50);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(243, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kelola Transaksi";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.DarkGray;
            lblSubtitle.Location = new Point(59, 94);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(188, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manajemen Transaksi EcoDrive";
            // 
            // btnFilter
            // 
            btnFilter.FlatAppearance.BorderColor = Color.Gainsboro;
            btnFilter.Location = new Point(1105, 107);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(85, 38);
            btnFilter.TabIndex = 6;
            // 
            // dgvCustomer
            // 
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AllowUserToResizeRows = false;
            dgvCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomer.BackgroundColor = Color.White;
            dgvCustomer.BorderStyle = BorderStyle.None;
            dgvCustomer.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomer.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(232, 245, 233);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(232, 245, 233);
            dgvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCustomer.ColumnHeadersHeight = 45;
            dgvCustomer.Columns.AddRange(new DataGridViewColumn[] { colId, colCustomer, colKontak, colBergabung, colTrip, colStatus, colAksi });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(242, 249, 242);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(47, 47, 47);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCustomer.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCustomer.EnableHeadersVisualStyles = false;
            dgvCustomer.GridColor = Color.FromArgb(240, 242, 240);
            dgvCustomer.Location = new Point(50, 145);
            dgvCustomer.MultiSelect = false;
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.RowHeadersVisible = false;
            dgvCustomer.RowHeadersWidth = 62;
            dgvCustomer.RowTemplate.Height = 65;
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.Size = new Size(939, 479);
            dgvCustomer.TabIndex = 8;
            // 
            // colId
            // 
            colId.FillWeight = 50F;
            colId.HeaderText = "ID";
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            // 
            // colCustomer
            // 
            colCustomer.FillWeight = 140F;
            colCustomer.HeaderText = "Customer";
            colCustomer.MinimumWidth = 8;
            colCustomer.Name = "colCustomer";
            // 
            // colKontak
            // 
            colKontak.FillWeight = 90F;
            colKontak.HeaderText = "Kontak";
            colKontak.MinimumWidth = 8;
            colKontak.Name = "colKontak";
            // 
            // colBergabung
            // 
            colBergabung.FillWeight = 90F;
            colBergabung.HeaderText = "Bergabung";
            colBergabung.MinimumWidth = 8;
            colBergabung.Name = "colBergabung";
            // 
            // colTrip
            // 
            colTrip.FillWeight = 70F;
            colTrip.HeaderText = "Total Sewa";
            colTrip.MinimumWidth = 8;
            colTrip.Name = "colTrip";
            // 
            // colStatus
            // 
            colStatus.FillWeight = 70F;
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            // 
            // colAksi
            // 
            colAksi.FillWeight = 70F;
            colAksi.HeaderText = "Aksi";
            colAksi.MinimumWidth = 8;
            colAksi.Name = "colAksi";
            // 
            // AdTransaksi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 450);
            Controls.Add(cardPanel);
            Name = "AdTransaksi";
            Text = "AdTransaksi";
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private EcoDriveUI.RoundedPanel cardPanel;
        private Label lblTitle;
        private Label lblSubtitle;
        private Button btnFilter;
        private DataGridView dgvCustomer;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn colKontak;
        private DataGridViewTextBoxColumn colBergabung;
        private DataGridViewTextBoxColumn colTrip;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colAksi;
        private ComboBox cmbFilter;
    }
}
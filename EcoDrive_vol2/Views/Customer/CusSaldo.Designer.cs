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
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblSaldo = new Label();
            btnTopUp = new Button();
            txtTopUp = new TextBox();
            lblTitle = new Label();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lblSaldo);
            flowLayoutPanel1.Controls.Add(btnTopUp);
            flowLayoutPanel1.Controls.Add(txtTopUp);
            flowLayoutPanel1.Controls.Add(lblTitle);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(776, 426);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(3, 0);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(30, 15);
            lblSaldo.TabIndex = 0;
            lblSaldo.Text = "Rp 0";
            lblSaldo.Click += lblSaldo_Click;
            // 
            // btnTopUp
            // 
            btnTopUp.Location = new Point(39, 3);
            btnTopUp.Name = "btnTopUp";
            btnTopUp.Size = new Size(75, 23);
            btnTopUp.TabIndex = 1;
            btnTopUp.Text = "Top Up";
            btnTopUp.UseVisualStyleBackColor = true;
            btnTopUp.Click += btnTopUp_Click_1;
            // 
            // txtTopUp
            // 
            txtTopUp.Location = new Point(120, 3);
            txtTopUp.Name = "txtTopUp";
            txtTopUp.Size = new Size(100, 23);
            txtTopUp.TabIndex = 2;
            txtTopUp.TextChanged += txtTopUp_TextChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(226, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(63, 15);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Saldo Saya";
            lblTitle.Click += lblTitle_Click;
            // 
            // CusSaldo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel1);
            Name = "CusSaldo";
            Text = "CusSaldo";
            Load += CusSaldo_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblSaldo;
        private Button btnTopUp;
        private TextBox txtTopUp;
        private Label lblTitle;
    }
}
namespace EcoDrive_vol2
{
    partial class FormRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegister));
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnSignUp = new Button();
            txtTelp = new TextBox();
            btnBack = new Button();
            roundedPanel2 = new EcoDriveUI.RoundedPanel();
            roundedPanel3 = new EcoDriveUI.RoundedPanel();
            roundedPanel4 = new EcoDriveUI.RoundedPanel();
            FrmJudul = new Label();
            roundedPanel5 = new EcoDriveUI.RoundedPanel();
            roundedPanel6 = new EcoDriveUI.RoundedPanel();
            txtNama = new TextBox();
            roundedPanel1 = new EcoDriveUI.RoundedPanel();
            roundedPanel2.SuspendLayout();
            roundedPanel3.SuspendLayout();
            roundedPanel4.SuspendLayout();
            roundedPanel5.SuspendLayout();
            roundedPanel6.SuspendLayout();
            roundedPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.MistyRose;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Location = new Point(17, 16);
            txtUsername.Margin = new Padding(2);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(195, 16);
            txtUsername.TabIndex = 4;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.AccessibleName = "txtPassowrd";
            txtPassword.BackColor = Color.MistyRose;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Location = new Point(17, 16);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(195, 16);
            txtPassword.TabIndex = 5;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // btnSignUp
            // 
            btnSignUp.AccessibleName = "btnSignUp";
            btnSignUp.BackColor = Color.LimeGreen;
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignUp.Location = new Point(10, 4);
            btnSignUp.Margin = new Padding(2);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(204, 37);
            btnSignUp.TabIndex = 0;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // txtTelp
            // 
            txtTelp.BackColor = Color.MistyRose;
            txtTelp.BorderStyle = BorderStyle.None;
            txtTelp.Location = new Point(17, 14);
            txtTelp.Margin = new Padding(2);
            txtTelp.Name = "txtTelp";
            txtTelp.PlaceholderText = "No Telepon";
            txtTelp.Size = new Size(195, 16);
            txtTelp.TabIndex = 3;
            txtTelp.TextChanged += txtTelp_TextChanged;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.SkyBlue;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(10, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(204, 37);
            btnBack.TabIndex = 1;
            btnBack.Text = "Login";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += button1_Click;
            // 
            // roundedPanel2
            // 
            roundedPanel2.BackColor = Color.MistyRose;
            roundedPanel2.Controls.Add(txtTelp);
            roundedPanel2.Location = new Point(928, 304);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Size = new Size(224, 46);
            roundedPanel2.TabIndex = 10;
            // 
            // roundedPanel3
            // 
            roundedPanel3.BackColor = Color.MistyRose;
            roundedPanel3.Controls.Add(txtUsername);
            roundedPanel3.Location = new Point(928, 362);
            roundedPanel3.Name = "roundedPanel3";
            roundedPanel3.Size = new Size(224, 46);
            roundedPanel3.TabIndex = 11;
            // 
            // roundedPanel4
            // 
            roundedPanel4.BackColor = Color.MistyRose;
            roundedPanel4.Controls.Add(txtPassword);
            roundedPanel4.Location = new Point(928, 421);
            roundedPanel4.Name = "roundedPanel4";
            roundedPanel4.Size = new Size(224, 46);
            roundedPanel4.TabIndex = 12;
            // 
            // FrmJudul
            // 
            FrmJudul.AutoSize = true;
            FrmJudul.BackColor = Color.Transparent;
            FrmJudul.Font = new Font("Tahoma", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FrmJudul.ForeColor = Color.FromArgb(255, 192, 192);
            FrmJudul.Location = new Point(909, 157);
            FrmJudul.Name = "FrmJudul";
            FrmJudul.Size = new Size(273, 58);
            FrmJudul.TabIndex = 13;
            FrmJudul.Text = "REGISTER";
            // 
            // roundedPanel5
            // 
            roundedPanel5.BackColor = Color.LimeGreen;
            roundedPanel5.Controls.Add(btnSignUp);
            roundedPanel5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundedPanel5.Location = new Point(928, 499);
            roundedPanel5.Name = "roundedPanel5";
            roundedPanel5.Size = new Size(224, 46);
            roundedPanel5.TabIndex = 14;
            // 
            // roundedPanel6
            // 
            roundedPanel6.BackColor = Color.SkyBlue;
            roundedPanel6.Controls.Add(btnBack);
            roundedPanel6.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundedPanel6.Location = new Point(928, 575);
            roundedPanel6.Name = "roundedPanel6";
            roundedPanel6.Size = new Size(224, 46);
            roundedPanel6.TabIndex = 15;
            // 
            // txtNama
            // 
            txtNama.BackColor = Color.MistyRose;
            txtNama.BorderStyle = BorderStyle.None;
            txtNama.Location = new Point(17, 15);
            txtNama.Margin = new Padding(2);
            txtNama.Name = "txtNama";
            txtNama.PlaceholderText = "Nama";
            txtNama.Size = new Size(195, 16);
            txtNama.TabIndex = 2;
            txtNama.TextChanged += txtNama_TextChanged;
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.MistyRose;
            roundedPanel1.Controls.Add(txtNama);
            roundedPanel1.Location = new Point(928, 246);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(224, 46);
            roundedPanel1.TabIndex = 9;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1370, 749);
            Controls.Add(FrmJudul);
            Controls.Add(roundedPanel1);
            Controls.Add(roundedPanel2);
            Controls.Add(roundedPanel3);
            Controls.Add(roundedPanel4);
            Controls.Add(roundedPanel5);
            Controls.Add(roundedPanel6);
            DoubleBuffered = true;
            Margin = new Padding(2);
            Name = "FormRegister";
            Text = "FormRegister";
            roundedPanel2.ResumeLayout(false);
            roundedPanel2.PerformLayout();
            roundedPanel3.ResumeLayout(false);
            roundedPanel3.PerformLayout();
            roundedPanel4.ResumeLayout(false);
            roundedPanel4.PerformLayout();
            roundedPanel5.ResumeLayout(false);
            roundedPanel6.ResumeLayout(false);
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnSignUp;
        private TextBox txtTelp;
        private Button btnBack;
        private EcoDriveUI.RoundedPanel roundedPanel2;
        private EcoDriveUI.RoundedPanel roundedPanel3;
        private EcoDriveUI.RoundedPanel roundedPanel4;
        private Label FrmJudul;
        private EcoDriveUI.RoundedPanel roundedPanel5;
        private EcoDriveUI.RoundedPanel roundedPanel6;
        private TextBox txtNama;
        private EcoDriveUI.RoundedPanel roundedPanel1;
    }
}
namespace EcoDrive_vol2
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            FrmJudul = new Label();
            TxtUsername = new TextBox();
            TxtPassword = new TextBox();
            label1 = new Label();
            lblSignUp = new LinkLabel();
            btnTogglePassword = new Button();
            roundedPanel1 = new EcoDriveUI.RoundedPanel();
            roundedPanel2 = new EcoDriveUI.RoundedPanel();
            roundedPanel3 = new EcoDriveUI.RoundedPanel();
            BtnLogin = new Button();
            roundedPanel1.SuspendLayout();
            roundedPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // FrmJudul
            // 
            FrmJudul.AutoSize = true;
            FrmJudul.BackColor = Color.Transparent;
            FrmJudul.Font = new Font("Tahoma", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FrmJudul.ForeColor = Color.FromArgb(255, 192, 192);
            FrmJudul.Location = new Point(909, 157);
            FrmJudul.Name = "FrmJudul";
            FrmJudul.Size = new Size(185, 58);
            FrmJudul.TabIndex = 0;
            FrmJudul.Text = "LOGIN";
            FrmJudul.Click += FrmJudul_Click;
            // 
            // TxtUsername
            // 
            TxtUsername.BackColor = Color.MistyRose;
            TxtUsername.BorderStyle = BorderStyle.None;
            TxtUsername.Location = new Point(24, 14);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.PlaceholderText = "Username";
            TxtUsername.Size = new Size(178, 16);
            TxtUsername.TabIndex = 1;
            TxtUsername.Enter += TxtUsername_Enter;
            TxtUsername.Leave += TxtUsername_Leave;
            // 
            // TxtPassword
            // 
            TxtPassword.BackColor = Color.MistyRose;
            TxtPassword.BorderStyle = BorderStyle.None;
            TxtPassword.Location = new Point(24, 14);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PlaceholderText = "Password";
            TxtPassword.Size = new Size(178, 16);
            TxtPassword.TabIndex = 2;
            TxtPassword.UseSystemPasswordChar = true;
            TxtPassword.Enter += TxtPassword_Enter;
            TxtPassword.Leave += TxtPassword_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(892, 495);
            label1.Name = "label1";
            label1.Size = new Size(140, 17);
            label1.TabIndex = 5;
            label1.Text = "Don't have an account?";
            label1.Click += label1_Click;
            // 
            // lblSignUp
            // 
            lblSignUp.AutoSize = true;
            lblSignUp.BackColor = Color.Transparent;
            lblSignUp.Location = new Point(1035, 495);
            lblSignUp.Name = "lblSignUp";
            lblSignUp.Size = new Size(47, 15);
            lblSignUp.TabIndex = 6;
            lblSignUp.TabStop = true;
            lblSignUp.Text = "Sign up";
            lblSignUp.LinkClicked += lblSignUp_Click;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.BackColor = Color.MistyRose;
            btnTogglePassword.Cursor = Cursors.Hand;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTogglePassword.Location = new Point(154, 8);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(48, 27);
            btnTogglePassword.TabIndex = 7;
            btnTogglePassword.Text = "SHOW";
            btnTogglePassword.UseVisualStyleBackColor = false;
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.MistyRose;
            roundedPanel1.Controls.Add(btnTogglePassword);
            roundedPanel1.Controls.Add(TxtPassword);
            roundedPanel1.Location = new Point(892, 344);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(212, 46);
            roundedPanel1.TabIndex = 10;
            // 
            // roundedPanel2
            // 
            roundedPanel2.BackColor = Color.MistyRose;
            roundedPanel2.Controls.Add(TxtUsername);
            roundedPanel2.Location = new Point(892, 292);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Size = new Size(212, 46);
            roundedPanel2.TabIndex = 9;
            // 
            // roundedPanel3
            // 
            roundedPanel3.BackColor = Color.LimeGreen;
            roundedPanel3.Location = new Point(892, 429);
            roundedPanel3.Name = "roundedPanel3";
            roundedPanel3.Size = new Size(212, 55);
            roundedPanel3.TabIndex = 11;
            // 
            // BtnLogin
            // 
            BtnLogin.BackColor = Color.LimeGreen;
            BtnLogin.FlatAppearance.BorderSize = 0;
            BtnLogin.FlatStyle = FlatStyle.Flat;
            BtnLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnLogin.ForeColor = Color.Black;
            BtnLogin.Location = new Point(895, 438);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(206, 38);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "LOGIN";
            BtnLogin.UseVisualStyleBackColor = false;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1370, 749);
            Controls.Add(lblSignUp);
            Controls.Add(label1);
            Controls.Add(BtnLogin);
            Controls.Add(FrmJudul);
            Controls.Add(roundedPanel1);
            Controls.Add(roundedPanel2);
            Controls.Add(roundedPanel3);
            DoubleBuffered = true;
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load;
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            roundedPanel2.ResumeLayout(false);
            roundedPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FrmJudul;
        private TextBox TxtUsername;
        private TextBox TxtPassword;
        private Label label1;
        private LinkLabel lblSignUp;
        private Button btnTogglePassword;
        private EcoDriveUI.RoundedPanel roundedPanel1;
        private EcoDriveUI.RoundedPanel roundedPanel2;
        private EcoDriveUI.RoundedPanel roundedPanel3;
        private Button BtnLogin;
    }
}
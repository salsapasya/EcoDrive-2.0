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
            BtnLogin = new Button();
            label1 = new Label();
            lblSignUp = new LinkLabel();
            btnTogglePassword = new Button();
            SuspendLayout();
            // 
            // FrmJudul
            // 
            FrmJudul.AutoSize = true;
            FrmJudul.BackColor = Color.Transparent;
            FrmJudul.Font = new Font("Stencil", 36F, FontStyle.Italic, GraphicsUnit.Point, 0);
            FrmJudul.ForeColor = Color.FromArgb(255, 192, 192);
            FrmJudul.Location = new Point(892, 159);
            FrmJudul.Name = "FrmJudul";
            FrmJudul.Size = new Size(162, 57);
            FrmJudul.TabIndex = 0;
            FrmJudul.Text = "LOGIN";
            FrmJudul.Click += FrmJudul_Click;
            // 
            // TxtUsername
            // 
            TxtUsername.Location = new Point(910, 265);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.PlaceholderText = "Username";
            TxtUsername.Size = new Size(129, 23);
            TxtUsername.TabIndex = 1;
            TxtUsername.Enter += TxtUsername_Enter;
            TxtUsername.Leave += TxtUsername_Leave;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(908, 318);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PlaceholderText = "Password";
            TxtPassword.Size = new Size(129, 23);
            TxtPassword.TabIndex = 2;
            TxtPassword.UseSystemPasswordChar = true;
            TxtPassword.Enter += TxtPassword_Enter;
            TxtPassword.Leave += TxtPassword_Leave;
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(940, 437);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(78, 30);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "LOGIN";
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(855, 495);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 5;
            label1.Text = "Don't have an account?";
            label1.Click += label1_Click;
            // 
            // lblSignUp
            // 
            lblSignUp.AutoSize = true;
            lblSignUp.Location = new Point(992, 495);
            lblSignUp.Name = "lblSignUp";
            lblSignUp.Size = new Size(47, 15);
            lblSignUp.TabIndex = 6;
            lblSignUp.TabStop = true;
            lblSignUp.Text = "Sign up";
            lblSignUp.LinkClicked += lblSignUp_Click;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.BackColor = Color.White;
            btnTogglePassword.Cursor = Cursors.Hand;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnTogglePassword.Location = new Point(988, 319);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(48, 21);
            btnTogglePassword.TabIndex = 7;
            btnTogglePassword.Text = "SHOW";
            btnTogglePassword.UseVisualStyleBackColor = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1370, 749);
            Controls.Add(btnTogglePassword);
            Controls.Add(lblSignUp);
            Controls.Add(label1);
            Controls.Add(BtnLogin);
            Controls.Add(TxtPassword);
            Controls.Add(TxtUsername);
            Controls.Add(FrmJudul);
            DoubleBuffered = true;
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FrmJudul;
        private TextBox TxtUsername;
        private TextBox TxtPassword;
        private Button BtnLogin;
        private Label label1;
        private LinkLabel lblSignUp;
        private Button btnTogglePassword;
    }
}
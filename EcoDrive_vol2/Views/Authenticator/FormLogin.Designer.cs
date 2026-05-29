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
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise, false.
        /// </param>
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
        /// Required method for Designer support
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            FrmJudul = new Label();
            TxtUsername = new TextBox();
            TxtPassword = new TextBox();
            CmbRole = new ComboBox();
            BtnLogin = new Button();
            label1 = new Label();
            lblSignUp = new LinkLabel();
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
            TxtUsername.TextChanged += TxtUsername_TextChanged_1;
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
            // CmbRole
            // 
            CmbRole.BackColor = SystemColors.Window;
            CmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbRole.FormattingEnabled = true;
            CmbRole.Items.AddRange(new object[] { "Admin", "Customer" });
            CmbRole.Location = new Point(908, 372);
            CmbRole.Name = "CmbRole";
            CmbRole.Size = new Size(129, 23);
            CmbRole.TabIndex = 3;
            CmbRole.SelectedIndexChanged += CmbRole_SelectedIndexChanged;
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(928, 437);
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
            label1.Click += label1_Click_1;
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
            Controls.Add(CmbRole);
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
        private ComboBox CmbRole;
        private Button BtnLogin;
        private Label label1;
        private LinkLabel lblSignUp;
    }
}
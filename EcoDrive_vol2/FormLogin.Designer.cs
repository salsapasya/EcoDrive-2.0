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
            LblLogin = new Label();
            TxtUsername = new TextBox();
            TxtPassword = new TextBox();
            CmbRole = new ComboBox();
            BtnLogin = new Button();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // LblLogin
            // 
            LblLogin.AutoSize = true;
            LblLogin.Font = new Font("Stencil", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            LblLogin.ForeColor = Color.FromArgb(255, 192, 192);
            LblLogin.Location = new Point(511, 65);
            LblLogin.Name = "LblLogin";
            LblLogin.Size = new Size(121, 43);
            LblLogin.TabIndex = 0;
            LblLogin.Text = "LOGIN";
            LblLogin.Click += LblLogin_Click;
            // 
            // TxtUsername
            // 
            TxtUsername.Location = new Point(406, 141);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.PlaceholderText = "Username";
            TxtUsername.Size = new Size(182, 31);
            TxtUsername.TabIndex = 1;
            TxtUsername.TextChanged += TxtUsername_TextChanged;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(406, 212);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PlaceholderText = "Password";
            TxtPassword.Size = new Size(182, 31);
            TxtPassword.TabIndex = 2;
            TxtPassword.UseSystemPasswordChar = true;
            // 
            // CmbRole
            // 
            CmbRole.FormattingEnabled = true;
            CmbRole.Items.AddRange(new object[] { "Admin", "Customer" });
            CmbRole.Location = new Point(406, 286);
            CmbRole.Name = "CmbRole";
            CmbRole.Size = new Size(182, 33);
            CmbRole.TabIndex = 3;
            CmbRole.Text = "Pilih Role";
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(621, 356);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(112, 34);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "LOGIN";
            BtnLogin.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(476, 356);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(112, 34);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "REGISTER";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(BtnLogin);
            Controls.Add(CmbRole);
            Controls.Add(TxtPassword);
            Controls.Add(TxtUsername);
            Controls.Add(LblLogin);
            DoubleBuffered = true;
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblLogin;
        private TextBox TxtUsername;
        private TextBox TxtPassword;
        private ComboBox CmbRole;
        private Button BtnLogin;
        private Button btnRegister;
    }
}
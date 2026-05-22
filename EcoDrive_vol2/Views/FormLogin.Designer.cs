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
            FrmJudul.Font = new Font("Stencil", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            FrmJudul.ForeColor = Color.FromArgb(255, 192, 192);
            FrmJudul.Location = new Point(582, 65);
            FrmJudul.Margin = new Padding(4, 0, 4, 0);
            FrmJudul.Name = "FrmJudul";
            FrmJudul.Size = new Size(121, 43);
            FrmJudul.TabIndex = 0;
            FrmJudul.Text = "LOGIN";
            FrmJudul.Click += FrmJudul_Click;
            // 
            // TxtUsername
            // 
            TxtUsername.Location = new Point(469, 143);
            TxtUsername.Margin = new Padding(4, 5, 4, 5);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.PlaceholderText = "Username";
            TxtUsername.Size = new Size(183, 31);
            TxtUsername.TabIndex = 1;
            TxtUsername.TextChanged += TxtUsername_TextChanged_1;
            TxtUsername.Enter += TxtUsername_Enter;
            TxtUsername.Leave += TxtUsername_Leave;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(469, 206);
            TxtPassword.Margin = new Padding(4, 5, 4, 5);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PlaceholderText = "Password";
            TxtPassword.Size = new Size(183, 31);
            TxtPassword.TabIndex = 2;
            TxtPassword.UseSystemPasswordChar = true;
            TxtPassword.Enter += TxtPassword_Enter;
            TxtPassword.Leave += TxtPassword_Leave;
            // 
            // CmbRole
            // 
            CmbRole.FormattingEnabled = true;
            CmbRole.Items.AddRange(new object[] { "Admin", "Customer" });
            CmbRole.Location = new Point(469, 270);
            CmbRole.Margin = new Padding(4, 5, 4, 5);
            CmbRole.Name = "CmbRole";
            CmbRole.Size = new Size(183, 33);
            CmbRole.TabIndex = 3;
            CmbRole.Text = "Pilih Role";
            CmbRole.SelectedIndexChanged += CmbRole_SelectedIndexChanged;
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(592, 339);
            BtnLogin.Margin = new Padding(4, 5, 4, 5);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(111, 50);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "LOGIN";
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(506, 418);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(197, 25);
            label1.TabIndex = 5;
            label1.Text = "Don't have an account?";
            label1.Click += label1_Click_1;
            // 
            // lblSignUp
            // 
            lblSignUp.AutoSize = true;
            lblSignUp.Location = new Point(711, 418);
            lblSignUp.Margin = new Padding(4, 0, 4, 0);
            lblSignUp.Name = "lblSignUp";
            lblSignUp.Size = new Size(73, 25);
            lblSignUp.TabIndex = 6;
            lblSignUp.TabStop = true;
            lblSignUp.Text = "Sign up";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(920, 518);
            Controls.Add(lblSignUp);
            Controls.Add(label1);
            Controls.Add(BtnLogin);
            Controls.Add(CmbRole);
            Controls.Add(TxtPassword);
            Controls.Add(TxtUsername);
            Controls.Add(FrmJudul);
            DoubleBuffered = true;
            Margin = new Padding(4, 5, 4, 5);
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
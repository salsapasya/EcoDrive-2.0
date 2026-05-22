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
            CmbRole = new ComboBox();
            BtnLogin = new Button();
            linkLabelRegis = new LinkLabel();
            SuspendLayout();
            // 
            // FrmJudul
            // 
            FrmJudul.AutoSize = true;
            FrmJudul.Font = new Font("Stencil", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            FrmJudul.ForeColor = Color.FromArgb(255, 192, 192);
            FrmJudul.Location = new Point(358, 39);
            FrmJudul.Margin = new Padding(2, 0, 2, 0);
            FrmJudul.Name = "FrmJudul";
            FrmJudul.Size = new Size(82, 29);
            FrmJudul.TabIndex = 0;
            FrmJudul.Text = "LOGIN";
            FrmJudul.Click += label1_Click;
            // 
            // TxtUsername
            // 
            TxtUsername.Location = new Point(284, 85);
            TxtUsername.Margin = new Padding(2, 2, 2, 2);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.PlaceholderText = "Username";
            TxtUsername.Size = new Size(129, 23);
            TxtUsername.TabIndex = 1;
            // 
            // TxtPassword
            // 
            TxtPassword.Location = new Point(284, 127);
            TxtPassword.Margin = new Padding(2, 2, 2, 2);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PlaceholderText = "Password";
            TxtPassword.Size = new Size(129, 23);
            TxtPassword.TabIndex = 2;
            TxtPassword.UseSystemPasswordChar = true;
            // 
            // CmbRole
            // 
            CmbRole.FormattingEnabled = true;
            CmbRole.Items.AddRange(new object[] { "Admin", "Customer" });
            CmbRole.Location = new Point(284, 172);
            CmbRole.Margin = new Padding(2, 2, 2, 2);
            CmbRole.Name = "CmbRole";
            CmbRole.Size = new Size(129, 23);
            CmbRole.TabIndex = 3;
            CmbRole.Text = "Pilih Role";
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(435, 214);
            BtnLogin.Margin = new Padding(2, 2, 2, 2);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(78, 20);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "LOGIN";
            BtnLogin.UseVisualStyleBackColor = true;
            // 
            // linkLabelRegis
            // 
            linkLabelRegis.AutoSize = true;
            linkLabelRegis.Location = new Point(358, 217);
            linkLabelRegis.Margin = new Padding(2, 0, 2, 0);
            linkLabelRegis.Name = "linkLabelRegis";
            linkLabelRegis.Size = new Size(57, 15);
            linkLabelRegis.TabIndex = 5;
            linkLabelRegis.TabStop = true;
            linkLabelRegis.Text = "REGISTER";
            linkLabelRegis.LinkClicked += linkLabelRegis_LinkClicked;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(560, 270);
            Controls.Add(linkLabelRegis);
            Controls.Add(BtnLogin);
            Controls.Add(CmbRole);
            Controls.Add(TxtPassword);
            Controls.Add(TxtUsername);
            Controls.Add(FrmJudul);
            DoubleBuffered = true;
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormLogin";
            Text = "FormLogin";
            Load += this.FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FrmJudul;
        private TextBox TxtUsername;
        private TextBox TxtPassword;
        private ComboBox CmbRole;
        private Button BtnLogin;
        private LinkLabel linkLabelRegis;
    }
}
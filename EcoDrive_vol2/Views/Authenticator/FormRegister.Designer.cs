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
            LblSignUp = new Label();
            btnSignUp = new Button();
            txtTelp = new TextBox();
            txtNama = new TextBox();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(281, 152);
            txtUsername.Margin = new Padding(2);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(129, 23);
            txtUsername.TabIndex = 1;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.AccessibleName = "txtPassowrd";
            txtPassword.Location = new Point(281, 190);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(129, 23);
            txtPassword.TabIndex = 2;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // LblSignUp
            // 
            LblSignUp.AutoSize = true;
            LblSignUp.Font = new Font("Stencil", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            LblSignUp.ForeColor = Color.FromArgb(255, 192, 192);
            LblSignUp.Location = new Point(342, 33);
            LblSignUp.Margin = new Padding(2, 0, 2, 0);
            LblSignUp.Name = "LblSignUp";
            LblSignUp.Size = new Size(104, 29);
            LblSignUp.TabIndex = 3;
            LblSignUp.Text = "Sign Up";
            LblSignUp.Click += LblSignUp_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.AccessibleName = "btnSignUp";
            btnSignUp.Location = new Point(440, 215);
            btnSignUp.Margin = new Padding(2);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(78, 20);
            btnSignUp.TabIndex = 5;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // txtTelp
            // 
            txtTelp.Location = new Point(281, 114);
            txtTelp.Margin = new Padding(2);
            txtTelp.Name = "txtTelp";
            txtTelp.PlaceholderText = "No Telp";
            txtTelp.Size = new Size(129, 23);
            txtTelp.TabIndex = 6;
            txtTelp.TextChanged += txtTelp_TextChanged;
            // 
            // txtNama
            // 
            txtNama.Location = new Point(281, 81);
            txtNama.Margin = new Padding(2);
            txtNama.Name = "txtNama";
            txtNama.PlaceholderText = "Nama";
            txtNama.Size = new Size(129, 23);
            txtNama.TabIndex = 7;
            txtNama.TextChanged += txtNama_TextChanged;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(560, 270);
            Controls.Add(txtNama);
            Controls.Add(txtTelp);
            Controls.Add(btnSignUp);
            Controls.Add(LblSignUp);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            DoubleBuffered = true;
            Margin = new Padding(2);
            Name = "FormRegister";
            Text = "FormRegister";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label LblSignUp;
        private Button btnSignUp;
        private TextBox txtTelp;
        private TextBox txtNama;
    }
}
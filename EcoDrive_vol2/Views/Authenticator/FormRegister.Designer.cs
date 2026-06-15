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
            btnBack = new Button();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(892, 352);
            txtUsername.Margin = new Padding(2);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(195, 23);
            txtUsername.TabIndex = 1;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.AccessibleName = "txtPassowrd";
            txtPassword.Location = new Point(892, 390);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(195, 23);
            txtPassword.TabIndex = 2;
            txtPassword.TextChanged += txtPassword_TextChanged;
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // LblSignUp
            // 
            LblSignUp.AutoSize = true;
            LblSignUp.BackColor = Color.Transparent;
            LblSignUp.Font = new Font("Stencil", 36F, FontStyle.Italic, GraphicsUnit.Point, 0);
            LblSignUp.ForeColor = Color.FromArgb(255, 192, 192);
            LblSignUp.Location = new Point(892, 159);
            LblSignUp.Margin = new Padding(2, 0, 2, 0);
            LblSignUp.Name = "LblSignUp";
            LblSignUp.Size = new Size(208, 57);
            LblSignUp.TabIndex = 3;
            LblSignUp.Text = "Sign Up";
            LblSignUp.Click += LblSignUp_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.AccessibleName = "btnSignUp";
            btnSignUp.Location = new Point(982, 443);
            btnSignUp.Margin = new Padding(2);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(80, 28);
            btnSignUp.TabIndex = 5;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // txtTelp
            // 
            txtTelp.Location = new Point(892, 314);
            txtTelp.Margin = new Padding(2);
            txtTelp.Name = "txtTelp";
            txtTelp.PlaceholderText = "No Telp";
            txtTelp.Size = new Size(195, 23);
            txtTelp.TabIndex = 6;
            txtTelp.TextChanged += txtTelp_TextChanged;
            // 
            // txtNama
            // 
            txtNama.Location = new Point(892, 273);
            txtNama.Margin = new Padding(2);
            txtNama.Name = "txtNama";
            txtNama.PlaceholderText = "Nama";
            txtNama.Size = new Size(195, 23);
            txtNama.TabIndex = 7;
            txtNama.TextChanged += txtNama_TextChanged;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(892, 443);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(85, 26);
            btnBack.TabIndex = 8;
            btnBack.Text = "back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += button1_Click;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1370, 749);
            Controls.Add(btnBack);
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
        private Button btnBack;
    }
}
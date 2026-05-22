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
            txtUsername.Location = new Point(401, 254);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(182, 31);
            txtUsername.TabIndex = 1;
            txtUsername.TextChanged += textBox2_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(401, 316);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(182, 31);
            txtPassword.TabIndex = 2;
            txtPassword.TextChanged += textBox3_TextChanged;
            // 
            // LblSignUp
            // 
            LblSignUp.AutoSize = true;
            LblSignUp.Font = new Font("Stencil", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            LblSignUp.ForeColor = Color.FromArgb(255, 192, 192);
            LblSignUp.Location = new Point(489, 55);
            LblSignUp.Name = "LblSignUp";
            LblSignUp.Size = new Size(155, 43);
            LblSignUp.TabIndex = 3;
            LblSignUp.Text = "Sign Up";
            LblSignUp.Click += LblSignUp_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(629, 359);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(112, 34);
            btnSignUp.TabIndex = 5;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += button1_Click;
            // 
            // txtTelp
            // 
            txtTelp.Location = new Point(401, 190);
            txtTelp.Name = "txtTelp";
            txtTelp.PlaceholderText = "No Telp";
            txtTelp.Size = new Size(182, 31);
            txtTelp.TabIndex = 6;
            txtTelp.TextChanged += txtTelp_TextChanged;
            // 
            // txtNama
            // 
            txtNama.Location = new Point(401, 135);
            txtNama.Name = "txtNama";
            txtNama.PlaceholderText = "Nama";
            txtNama.Size = new Size(182, 31);
            txtNama.TabIndex = 7;
            txtNama.TextChanged += txtNama_TextChanged;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(txtNama);
            Controls.Add(txtTelp);
            Controls.Add(btnSignUp);
            Controls.Add(LblSignUp);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            DoubleBuffered = true;
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
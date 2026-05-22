using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoDrive_vol2
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Role
            CmbRole.Items.Add("Admin");
            CmbRole.Items.Add("Customer");

            CmbRole.SelectedIndex = 0;

            // Password
            TxtPassword.UseSystemPasswordChar = true;

            // Placeholder Username
            TxtUsername.Text = "Masukkan Username";
            TxtUsername.ForeColor = Color.Gray;

            // Placeholder Password
            TxtPassword.Text = "Masukkan Password";
            TxtPassword.ForeColor = Color.Gray;
            TxtPassword.UseSystemPasswordChar = false;
        }

        private void LblLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            if (TxtUsername.Text == "Masukkan Username")
            {
                TxtUsername.Text = "";
                TxtUsername.ForeColor = Color.Black;
            }
        }
    }
}

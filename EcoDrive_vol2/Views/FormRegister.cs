using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoDrive_vol2
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            //Password
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            //Username
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        "Register Berhasil");

            FormLogin login =
                new FormLogin();

            login.Show();

            this.Hide();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }

        private void LblSignUp_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Password
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Username
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
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

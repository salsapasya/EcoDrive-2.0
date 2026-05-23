using EcoDrive_vol2.Views;

namespace EcoDrive_vol2
{
    public partial class CusDasboard : Form
    {
        private Form activeForm = null;
        private Color bgUtama = Color.FromArgb(255, 253, 246);

        public CusDasboard()
        {
            InitializeComponent();

            btDasboard.Click += btDasboard_Click;
            btKendaraan.Click += btKendaraan_Click;
            btCharging.Click += btCharging_Click;
            btRiwayat.Click += btRiwayat_Click;
            btSaldo.Click += btSaldo_Click;
        }
        // FUNCTION PINDAH FORM
        private void OpenForm(Form childForm)
        {
            // Tutup form sebelumnya
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnContentCustomer.Controls.Clear();
            pnContentCustomer.Controls.Add(childForm);

            childForm.BringToFront();
            childForm.Show();
        }

        // RESET WARNA BUTTON
        private void ResetButton()
        {
            btDasboard.BackColor = Color.White;
            btKendaraan.BackColor = Color.White;
            btCharging.BackColor = Color.White;
            btRiwayat.BackColor = Color.White;
            btSaldo.BackColor = Color.White;
        }

        // DASHBOARD
        private void btDasboard_Click(object sender, EventArgs e)
        {
            ResetButton();

            btDasboard.BackColor = Color.FromArgb(191, 219, 120);

            if (activeForm != null)
            {
                activeForm.Close();
            }
            else
            {
                OpenForm(new CusDasboard());
            }
        }

        // KENDARAAN
        private void btKendaraan_Click(object sender, EventArgs e)
        {
            ResetButton();

            btKendaraan.BackColor = Color.FromArgb(191, 219, 120);

            OpenForm(new CusKendaraan());
        }

        // CHARGING
        private void btCharging_Click(object sender, EventArgs e)
        {
            ResetButton();

            btCharging.BackColor = Color.FromArgb(191, 219, 120);

            OpenForm(new CusCharging());
        }

        // RIWAYAT
        private void btRiwayat_Click(object sender, EventArgs e)
        {
            ResetButton();

            btRiwayat.BackColor = Color.FromArgb(191, 219, 120);

            OpenForm(new CusRiwayat());
        }

        // SALDO
        private void btSaldo_Click(object sender, EventArgs e)
        {
            ResetButton();

            btSaldo.BackColor = Color.FromArgb(191, 219, 120);

            OpenForm(new CusSaldo());
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // buka login
                FormLogin login = new FormLogin();
                login.Show();

                // tutup dashboard
                this.Close();
            }
        }

        private void btKendaraan_Click_1(object sender, EventArgs e)
        {

        }
    }
}

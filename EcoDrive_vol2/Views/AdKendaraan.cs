using EcoDrive_vol2.Controllers;
using EcoDrive_vol2.Models;

namespace EcoDrive_vol2.Views
{
    public partial class AdKendaraan : Form
    {
        AdKendaraanController controller =
            new AdKendaraanController();

        private Color bgUtama =
            Color.FromArgb(255, 253, 246);

        public AdKendaraan()
        {
            InitializeComponent();

            this.BackColor = bgUtama;

            LoadComboStatus();

            LoadData();

            dgvKendaraan.CellFormatting +=
                dgvKendaraan_CellFormatting;
        }

        // LOAD DATA
        public void LoadData()
        {
            dgvKendaraan.DataSource =
                controller.GetKendaraan();
        }

        // COMBO STATUS
        private void LoadComboStatus()
        {
            cbStatus.Items.Add("tersedia");
            cbStatus.Items.Add("disewa");
            cbStatus.Items.Add("rusak");
            cbStatus.Items.Add("dalam perbaikan");
        }

        // WARNA STATUS
        private void dgvKendaraan_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKendaraan.Columns[e.ColumnIndex]
                .Name == "StatusKendaraan"
                && e.Value != null)
            {
                string status =
                    e.Value.ToString();

                if (status == "tersedia")
                {
                    e.CellStyle.BackColor =
                        Color.LightGreen;
                }
                else if (status == "disewa")
                {
                    e.CellStyle.BackColor =
                        Color.LightYellow;
                }
                else if (status == "rusak")
                {
                    e.CellStyle.BackColor =
                        Color.LightCoral;
                }
            }
        }

        // TAMBAH
        private void btnTambah_Click(
            object sender,
            EventArgs e)
        {
            Kendaraan kendaraan =
                new Kendaraan
                {
                    NamaKendaraan =
                        txtNamaKendaraan.Text,

                    IdTipeKendaraan =
                        Convert.ToInt32(
                            cbTipeKendaraan.SelectedValue),

                    IdMerkKendaraan =
                        Convert.ToInt32(
                            cbMerk.SelectedValue),

                    StokKendaraan =
                        Convert.ToInt32(
                            txtStok.Text),

                    HargaSewa =
                        Convert.ToInt32(
                            txtHargaSewa.Text),

                    StatusKendaraan =
                        cbStatus.Text.ToLower()
                };

            controller.AddKendaraan(
                kendaraan);

            MessageBox.Show(
                "Kendaraan berhasil ditambah");

            LoadData();
        }
    }
}
using EcoDrive_vol2.Controllers;
using EcoDrive_vol2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class AdKendaraan : Form
    {
        AdKendaraanController controller = new AdKendaraanController();
        private Color bgUtama = Color.FromArgb(255, 253, 246);
        private System.Windows.Forms.DataGridView dgvKendaraan;

        public AdKendaraan()
        {
            InitializeComponent();
            this.BackColor = bgUtama;
            LoadData();
        }
        public void LoadData()
        {
            dgvKendaraan.DataSource = controller.GetKendaraan();
        }
        private void dgvKendaraan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKendaraan.Columns[e.ColumnIndex].Name == "HargaSewa" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Tersedia")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else if (status == "Tidak Tersedia")
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }
            }
        }

        private void AdKendaraan_Load(object sender, EventArgs e)
        {

        }
    }
}

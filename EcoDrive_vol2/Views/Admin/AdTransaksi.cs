using EcoDrive_vol2.Context;
using EcoDrive_vol2.Models;
using EcoDrive_vol2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EcoDrive_vol2.Views
{
    public partial class AdTransaksi : Form
    {
        private Color bgUtama = Color.FromArgb(255, 253, 246);
        private AdTransaksiContext _transaksiContext;
        private TransaksiChargingContext _chargingContext;
        private TransaksiSewaContext _sewaContext;
        public AdTransaksi()
        {
            InitializeComponent();
            this.BackColor = bgUtama;

            _transaksiContext = new AdTransaksiContext();
            _chargingContext = new TransaksiChargingContext();
            _sewaContext = new TransaksiSewaContext();

            SetupFilterComboBox();
            SetupDataGridViewStyle();
            LoadDataGrid("Semua");
        }

        private void SetupFilterComboBox()
        {
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("Semua");
            cmbFilter.Items.Add("Sewa");
            cmbFilter.Items.Add("Charging");
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += CmbFilter_SelectedIndexChanged;
        }

        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGrid(cmbFilter.SelectedItem.ToString());
        }

        private void LoadDataGrid(string filterMode)
        {
            try
            {
                dgvTransaksi.DataSource = null;
                dgvTransaksi.Columns.Clear();

                var data = _transaksiContext.GetAdTransaksi(filterMode);
                dgvTransaksi.DataSource = data;

                if (dgvTransaksi.Columns["RawId"] != null) dgvTransaksi.Columns["RawID"].Visible = false;
                if (dgvTransaksi.Columns["Kategori"] != null) dgvTransaksi.Columns["Kategori"].Visible = false;

                dgvTransaksi.Columns["ID_Transaksi"].HeaderText = "ID Transaksi";
                dgvTransaksi.Columns["Username"].HeaderText = "Username";
                dgvTransaksi.Columns["Nama"].HeaderText = "Nama";
                dgvTransaksi.Columns["Kontak"].HeaderText = "Kontak";
                dgvTransaksi.Columns["Waktu"].HeaderText = "Tanggal";
                dgvTransaksi.Columns["Detail"].HeaderText = "Durasi";
                dgvTransaksi.Columns["Status"].HeaderText = "Status";

                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.Name = "BtnAksi";
                btnColumn.HeaderText = "Aksi";
                dgvTransaksi.Columns.Add(btnColumn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Data Grid : " + ex.Message);
            }
        }

        private void SetupDataGridViewStyle()
        {
            dgvTransaksi.BackgroundColor = Color.White;
            dgvTransaksi.BorderStyle = BorderStyle.None;
            dgvTransaksi.RowHeadersVisible = false;
            dgvTransaksi.AllowUserToAddRows = false;
            dgvTransaksi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Menghubungkan event format warna status dan klik tombol
            dgvTransaksi.CellFormatting += DgvTransaksi_CellFormatting;
            dgvTransaksi.CellContentClick += DgvTransaksi_CellContentClick;
        }

        private void DgvTransaksi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string status = dgvTransaksi.Rows[e.RowIndex].Cells["Status"].Value?.ToString().ToLower() ?? "";
            string kategori = dgvTransaksi.Rows[e.RowIndex].Cells["Kategori"].Value?.ToString().ToLower() ?? "";
            {
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                if (dgvTransaksi.Columns[e.ColumnIndex].Name == "Status")
                {
                    if (status == "pending")
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 230, 230);
                        e.CellStyle.ForeColor = Color.FromArgb(200, 0, 0);
                    }
                    else if (status == "mengisi daya")
                    {
                        e.CellStyle.BackColor = Color.FromArgb(230, 255, 230);
                        e.CellStyle.ForeColor = Color.FromArgb(0, 150, 0);
                    }
                    else if (status == "selesai")
                    {
                        e.CellStyle.BackColor = Color.FromArgb(230, 230, 255);
                        e.CellStyle.ForeColor = Color.FromArgb(0, 0, 150);
                    }
                }
            }

            if (dgvTransaksi.Columns[e.ColumnIndex].Name == "BtnAksi")
            {
                if (kategori == "Charging" && status == "pending")
                    e.Value = "Konfirmasi Daya";
                else
                    e.Value = "-";
            }

        }
        private void DgvTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTransaksi.Columns[e.ColumnIndex].Name == "BtnAksi")
            {

            };
        }


        // Designer wires handlers named 'dgvTransaksi_CellFormatting' and
        // 'dgvTransaksi_CellContentClick' (lowercase). Provide these
        // forwarding methods so the Designer-generated code can find them
        // and delegate to the actual implementations above.
        private void dgvTransaksi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DgvTransaksi_CellFormatting(sender, e);
        }

        private void dgvTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvTransaksi_CellContentClick(sender, e);
        }

        private void cardPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

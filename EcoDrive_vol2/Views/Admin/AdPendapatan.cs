using EcoDrive_vol2.Controllers.Admin;
using EcoDrive_vol2.Models.Admin;
using EcoDrive_vol2.Views;
using EcoDrive_vol2.Service;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class AdPendapatan : Form
    {
        private Color bgUtama = Color.FromArgb(255, 253, 246);
        private AdPendapatanController _controller;
        public AdPendapatan()
        {
            InitializeComponent();
            this.BackColor = bgUtama;
            _controller = new AdPendapatanController(new PendapatanService());

            string[] namaBulan = { "Januari", "Februari", "Maret", "April", "Mei", "Juni",
                           "Juli", "Agustus", "September", "Oktober", "November", "Desember" };
            string bulanSekarang = namaBulan[DateTime.Now.Month - 1];
            int indexBulan = cmbBulan.FindStringExact(bulanSekarang);
            if (indexBulan >= 0) cmbBulan.SelectedIndex = indexBulan;
        }

        private void AdPendapatan_Load(object sender, EventArgs e)
        {
            RefreshSemuaData();
        }
        private void cmbTahun_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSemuaData();
        }
        private void cmbBulan_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSemuaData();
        }
        private void RefreshSemuaData()
        {
            try
            {
                int tahun = dtpTahun.Value.Year;

                CardPendapatanModel dataCard = _controller.LoadCardTahun(tahun);
                lblCardTotalPendapatan.Text = $"Rp {dataCard.TotalGabunganTahunan:N0}";
                lblCardPendapatanSewa.Text = $"Rp {dataCard.TotalSewaTahunan:N0}";
                lblCardPendapatanCharging.Text = $"Rp {dataCard.TotalChargingTahunan:N0}";
                lblTotalUnitSewa.Text = $"{dataCard.TotalUnitTahunan} Unit";
                lblTotalTransaksicharging.Text = $"{dataCard.TotalBanyakChargingTahunan} Transaksi";

                RefreshDataBawah();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal load data card atas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshDataBawah()
        {
            try
            {
                if (cmbBulan.SelectedIndex <= 0) return;

                int bulan = cmbBulan.SelectedIndex;
                int tahun = dtpTahun.Value.Year;

                List<RincianPendapatanModel> dataRincian = _controller.LoadRincianBulanTahun(bulan, tahun);
                dgvPendapatan.AutoGenerateColumns = false; // update dgv

                colTanggal.DataPropertyName = "TanggalHari";
                colSewa.DataPropertyName = "PendapatanSewa";
                colCharging.DataPropertyName = "PendapatanCharging";
                colTotal.DataPropertyName = "TotalHarian";

                colTanggal.DefaultCellStyle.Format = "dd MMM yyyy";
                colSewa.DefaultCellStyle.Format = "N0";
                colCharging.DefaultCellStyle.Format = "N0";
                colTotal.DefaultCellStyle.Format = "N0";

                dgvPendapatan.DataSource = dataRincian;

                var nilaiSewa = new List<double>();
                var nilaiCharging = new List<double>();
                var labelTanggal = new List<string>();

                foreach (var item in dataRincian)
                {
                    nilaiSewa.Add(Convert.ToDouble(item.PendapatanSewa));
                    nilaiCharging.Add(Convert.ToDouble(item.PendapatanCharging));
                    labelTanggal.Add(item.TanggalHari.ToString("dd"));
                }
                cartesianChart1.Series = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = nilaiSewa,
                        Name = "Pendapatan Sewa"
                    },
                    new LineSeries<double>
                    {
                        Values = nilaiCharging,
                        Name = "Pendapatan Charging"
                    }
                };
                cartesianChart1.XAxes = new Axis[]
                {
                    new Axis {
                    Labels = labelTanggal,
                    Name = "Tanggal"
                    }
                };
                cartesianChart1.YAxes = new Axis[]
                {
                    new Axis {
                        Labeler = value => value.ToString("N0")
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal load data grafik/dgv: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtpTahun_ValueChanged(object sender, EventArgs e)
        {
            RefreshSemuaData();
        }
    }
}
// ini aku cuma nyoba ngepush ke branch salsapasya
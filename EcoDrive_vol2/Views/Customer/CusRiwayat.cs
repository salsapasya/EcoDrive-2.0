// Pastikan namespace controller customer sudah dipanggil dengan benar
using EcoDrive_vol2.Controllers.Admin;
using EcoDrive_vol2.Controllers.Customer;
using EcoDrive_vol2.Helpers;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class CusRiwayat : Form
    {
        private readonly Color bgUtama = Color.FromArgb(255, 253, 246);

        private readonly CusRiwayatController _riwayatController = new CusRiwayatController();

        public CusRiwayat()
        {
            InitializeComponent();
            this.BackColor = bgUtama;
        }
        private void CusRiwayat_Load(object sender, EventArgs e)
        {
            LoadDataRiwayat();
        }

        private void LoadDataRiwayat()
        {
            LoadRiwayatSewa();
            LoadRiwayatCharging();
            LoadRiwayatTopUp();
        }
        private void LoadRiwayatSewa()
        {
            try
            {
                flpSewa.Controls.Clear();
                DataTable dt = _riwayatController.AmbilRiwayatSewa(UserSession.IdUserAktif);

                foreach (DataRow row in dt.Rows)
                {
                    // Sesuai dengan kolom di view_riwayat_customer
                    string kendaraan = row["nama_kendaraan"].ToString();
                    string tanggal = DateTime.Parse(row["tanggal_sewa"].ToString()).ToString("dd MMM yyyy");
                    string durasi = row["durasi_sewa"].ToString();
                    decimal total = Convert.ToDecimal(row["total_bayar"]);
                    string status = row["status_pengembalian"].ToString().ToUpper().Trim();

                    Panel card = CreateBaseCard();

                    card.Controls.Add(CreateLabel(kendaraan, 11, FontStyle.Bold, Color.Black, 15, 15));
                    card.Controls.Add(CreateLabel($"{tanggal}   •   {durasi} Hari", 9, FontStyle.Regular, Color.DimGray, 15, 42));
                    card.Controls.Add(CreateLabel("Rp " + total.ToString("N0"), 12, FontStyle.Bold, Color.Black, 450, 22));

                    Label lblStatus = CreateBadge(status, 580, 22);
                    if (status == "SUDAH KEMBALI" || status == "SELESAI" || status == "PAID")
                    {
                        lblStatus.BackColor = Color.FromArgb(220, 245, 220); lblStatus.ForeColor = Color.ForestGreen;
                    }
                    else
                    {
                        lblStatus.BackColor = Color.FromArgb(255, 225, 225); lblStatus.ForeColor = Color.Firebrick;
                    }
                    card.Controls.Add(lblStatus);

                    flpSewa.Controls.Add(card);
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal load riwayat Sewa: " + ex.Message); }
        }
        private void LoadRiwayatCharging()
        {
            try
            {
                flpCharging.Controls.Clear();

                DataTable dt = _riwayatController.AmbilRiwayatCharging(UserSession.IdUserAktif);

                foreach (DataRow row in dt.Rows)
                {
                    string kendaraan = row["nama_kendaraan"].ToString();
                    string tanggal = DateTime.Parse(row["tanggal_charging"].ToString()).ToString("dd MMM yyyy");
                    string durasi = row["durasi_charging"].ToString();
                    decimal biaya = Convert.ToDecimal(row["biaya_charging"]);
                    string status = row["status_charging"].ToString().ToUpper().Trim();

                    Panel card = CreateBaseCard();

                    Label lblJudul = CreateLabel($"Charging - {kendaraan}", 11, FontStyle.Bold, Color.Black, 15, 15);
                    Label lblDetail = CreateLabel($"{tanggal}   •   {durasi} Jam", 9, FontStyle.Regular, Color.DimGray, 15, 42);
                    Label lblHarga = CreateLabel("Rp " + biaya.ToString("N0"), 12, FontStyle.Bold, Color.Black, 450, 22);

                    Label lblStatus = CreateBadge(status, 580, 22);
                    if (status == "BERHASIL" || status == "SUCCESS" || status == "SELESAI")
                    {
                        lblStatus.BackColor = Color.FromArgb(220, 245, 220);
                        lblStatus.ForeColor = Color.ForestGreen;
                    }
                    else
                    {
                        lblStatus.BackColor = Color.FromArgb(255, 225, 225);
                        lblStatus.ForeColor = Color.Firebrick;
                    }

                    card.Controls.AddRange(new Control[] { lblJudul, lblDetail, lblHarga, lblStatus });
                    flpCharging.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat riwayat charging:\n{ex.Message}", "Peringatan Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadRiwayatTopUp()
        {
            try
            {
                flpTopUp.Controls.Clear();
                DataTable dt = _riwayatController.AmbilRiwayatTopUp(UserSession.IdUserAktif);

                foreach (DataRow row in dt.Rows)
                {
                    // Sesuai dengan kolom di view_riwayat_topup
                    string idRef = row["id_topup_saldo"].ToString();
                    decimal jumlah = Convert.ToDecimal(row["jumlah_topup"]);
                    string status = row["status_topup"].ToString().ToUpper().Trim();

                    Panel card = CreateBaseCard();

                    card.Controls.Add(CreateLabel("Top Up Saldo EcoDrive", 11, FontStyle.Bold, Color.Black, 15, 15));
                    card.Controls.Add(CreateLabel($"Ref ID: #TP-{idRef}", 9, FontStyle.Regular, Color.DimGray, 15, 42));

                    // Uang masuk kasih tanda +
                    Label lblHarga = CreateLabel((status == "BERHASIL" ? "+ Rp " : "Rp ") + jumlah.ToString("N0"), 12, FontStyle.Bold, Color.Black, 450, 22);
                    if (status == "BERHASIL") lblHarga.ForeColor = Color.ForestGreen;
                    card.Controls.Add(lblHarga);

                    Label lblStatus = CreateBadge(status, 580, 22);
                    if (status == "BERHASIL")
                    {
                        lblStatus.BackColor = Color.FromArgb(220, 245, 220); lblStatus.ForeColor = Color.ForestGreen;
                    }
                    else if (status == "PENDING" || status == "MENUNGGU")
                    {
                        lblStatus.BackColor = Color.FromArgb(255, 245, 200); lblStatus.ForeColor = Color.DarkGoldenrod;
                    }
                    else
                    {
                        lblStatus.BackColor = Color.FromArgb(255, 225, 225); lblStatus.ForeColor = Color.Firebrick;
                    }
                    card.Controls.Add(lblStatus);

                    flpTopUp.Controls.Add(card);
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal load riwayat Top Up: " + ex.Message); }
        }
        private Panel CreateBaseCard()
        {
            return new Panel 
            { 
                Size = new Size(690, 75), 
                BackColor = Color.White, 
                Margin = new Padding(0, 0, 0, 10) 
            };
        }

        private Label CreateLabel(string text, float fontSize, FontStyle style, Color color, int x, int y)
        {
            return new Label 
            { 
                Text = text, 
                Font = new Font("Segoe UI", fontSize, style), 
                ForeColor = color, 
                Location = new Point(x, y), 
                AutoSize = true 
            };
        }

        private Label CreateBadge(string text, int x, int y)
        {
            return new Label 
            { 
                Text = text, 
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold), 
                Size = new Size(95, 26), Location = new Point(x, y), 
                TextAlign = ContentAlignment.MiddleCenter 
            };
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
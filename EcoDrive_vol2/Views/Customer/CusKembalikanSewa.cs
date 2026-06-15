using EcoDrive_vol2.Controllers.Customer;
using EcoDrive_vol2.Helpers;
using EcoDrive_vol2.Models.Transaksi;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views.Customer
{
    public partial class CusKembalikanSewa : Form
    {
        private readonly Color bgUtama = Color.FromArgb(255, 253, 246);
        private Color hijauUtama = Color.FromArgb(139, 195, 74);

        private CusPengembalianController _controller = new CusPengembalianController();
        private int idUser = UserSession.IdUserAktif;
        public CusKembalikanSewa()
        {
            InitializeComponent();
            this.BackColor = bgUtama;

            this.FlowLayoutPanel.AutoScroll = true;       
            this.FlowLayoutPanel.WrapContents = true;
            this.FlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
        }
        private void CusKembalikanSewa_Load(object sender, EventArgs e)
        {
            try
            {
                idUser = UserSession.IdUserAktif;
                LoadDaftarSewaAktif();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menginisialisasi halaman: {ex.Message}", 
                    "Error Sistem Sesi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDaftarSewaAktif()
        {
            try
            {
                this.FlowLayoutPanel.Controls.Clear();
                List<TransaksiSewa> listSewa = _controller.AmbilSewaAktifUser(idUser);
                if (listSewa == null || listSewa.Count == 0)
                {
                    Label lblKosong = new Label
                    {
                        Text = "Anda tidak memiliki kendaraan sewa yang aktif saat ini.",
                        Font = new Font("Segoe UI", 10, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Margin = new Padding(20)
                    };
                    this.FlowLayoutPanel.Controls.Add(lblKosong);
                    return;
                }
                foreach (var sewa in listSewa)
                {
                    CreateSewaCard(sewa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateSewaCard(TransaksiSewa sewa)
        {
            try
            {
                Panel card = new Panel
                {
                    Size = new Size(650, 150),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                Label lblNama = new Label
                {
                    Text = $"🚗 {sewa.NamaKendaraan.ToUpper()} ({sewa.NomorPlatKendaraan})",
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    Location = new Point(15, 15),
                    AutoSize = true
                };

                Label lblDetailSewa = new Label
                {
                    Text = $"📅 Tanggal Sewa   : {sewa.TanggalSewa:dd/MM/yyyy}\n📅 Batas Kembali  : {sewa.TanggalKembali:dd/MM/yyyy} ({sewa.DurasiSewa} Hari)",
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    Location = new Point(15, 45),
                    Size = new Size(350, 40)
                };

                // OOP (ENCAPSULATION) = menggunakan () untuk memanggil method encap dari model
                Color warnaStatus = sewa.CekBelumKembali() ? Color.Red : Color.Orange;
                string iconStatus = sewa.CekBelumKembali() ? "🔴" : "🕒";

                Label lblStatus = new Label
                {
                    Text = $"{iconStatus} STATUS: {sewa.FormatStatus()}",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = warnaStatus,
                    Location = new Point(15, 95),
                    AutoSize = true
                };

                Button btnAksi = new Button
                {
                    Size = new Size(160, 35),
                    Location = new Point(460, 90),
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat
                };
                if (sewa.CekBelumKembali())
                {
                    btnAksi.Text = "🔁 Kembalikan Sewa";
                    btnAksi.BackColor = hijauUtama;
                    btnAksi.ForeColor = Color.White;
                    btnAksi.Enabled = true;

                    btnAksi.Click += (sender, e) =>
                    {
                        DialogResult res = MessageBox.Show("Apakah Anda yakin ingin mengembalikan kendaraan ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            _controller.AjukanPengembalian(sewa.IdTransaksiSewa);
                            MessageBox.Show("Pengembalian diajukan! Silakan serah terima fisik kendaraan ke admin.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDaftarSewaAktif(); // Re-render card list
                        }
                    };
                }
                else // "menunggu konfirmasi"
                {
                    btnAksi.Text = "⏳ Menunggu ACC Admin";
                    btnAksi.BackColor = Color.LightGray;
                    btnAksi.ForeColor = Color.DarkGray;
                    btnAksi.Enabled = false;
                }

                card.Controls.Add(lblNama);
                card.Controls.Add(lblDetailSewa);
                card.Controls.Add(lblStatus);
                card.Controls.Add(btnAksi);

                this.FlowLayoutPanel.Controls.Add(card);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat menyusun komponen kartu kendaraan: {ex.Message}",
                                "Error Render UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
    }
}

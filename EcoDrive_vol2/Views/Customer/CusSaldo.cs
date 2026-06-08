using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EcoDrive_vol2.Controllers.Customer;
using EcoDrive_vol2.Helpers;

namespace EcoDrive_vol2.Views
{
    public partial class CusSaldo : Form
    {
        private Color bgUtama = Color.FromArgb(255, 253, 246);

        private int idUser = UserSession.IdUserAktif;
        private decimal saldo = 0;

        private CusSaldoController controller = new CusSaldoController();

        public CusSaldo()
        {
            InitializeComponent();
            this.BackColor = bgUtama;
        }

        private void CusSaldo_Load(object sender, EventArgs e)
        {
            // Sesuai kodingan lamamu, set ID user aktif dari session lalu load halaman
            idUser = UserSession.IdUserAktif;
            LoadHalamanSaldo();
        }

        private void LoadHalamanSaldo()
        {
            try
            {
                // 1. Sinkronisasi Kartu Utama dengan Data DB Terbaru via Controller
                //saldo = controller.GetSaldo(idUser);
                //lblSaldo.Text = "Rp " + saldo.ToString("N0");

                // Cari label ID Pengguna jika ada di designer form-mu
                //if (Controls.Find("lblIdPengguna", true).Length > 0)
                //{
                //    lblIdPengguna.Text = "ID Pengguna: ECO-" + idUser.ToString("D4");
                //}

                // 2. Bersihkan penampung list riwayat (FlowLayoutPanel)
                flpRiwayatSaldo.Controls.Clear();

                // 3. Tarik data dari database lewat Controller (Bentuknya DataTable)
                DataTable dtRiwayat = controller.AmbilRiwayatTopUp(idUser);

                // Looping isi baris tabel database untuk dicetak jadi panel ala Figma
                foreach (DataRow row in dtRiwayat.Rows)
                {
                    string status = row["status_topup"].ToString().ToUpper();
                    string idTopUp = row["id_topup_saldo"].ToString();
                    decimal jumlah = Convert.ToDecimal(row["jumlah_topup"]);

                    // --- PROSES GENERATE PANEL SECARA RUNTIME ---
                    Panel itemPanel = new Panel();
                    itemPanel.Size = new Size(630, 65);
                    itemPanel.BackColor = Color.White;
                    itemPanel.Margin = new Padding(0, 0, 0, 8);

                    // Label Status / Judul Aktivitas (Kiri Atas)
                    Label lblJudul = new Label();
                    lblJudul.Text = status == "BERHASIL" ? "Top Up Saldo Berhasil" : (status == "PENDING" ? "Top Up Menunggu Konfirmasi" : "Top Up Saldo Gagal");
                    lblJudul.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lblJudul.Location = new Point(15, 12);
                    lblJudul.AutoSize = true;

                    // Label Ref ID Transaksi (Kiri Bawah)
                    Label lblSub = new Label();
                    lblSub.Text = $"Ref ID: #TP-{idTopUp}";
                    lblSub.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                    lblSub.ForeColor = Color.Gray;
                    lblSub.Location = new Point(15, 34);
                    lblSub.AutoSize = true;

                    // Label Nominal Transaksi (Kanan Tengah)
                    Label lblNominal = new Label();
                    lblNominal.Text = (status == "BERHASIL" ? "+ Rp " : "Rp ") + jumlah.ToString("N0");
                    lblNominal.Font = new Font("Segoe UI", 11, FontStyle.Bold);

                    // Pewarnaan teks status: Berhasil = Ijo, Pending = Oranye, Gagal = Merah
                    if (status == "BERHASIL") lblNominal.ForeColor = Color.ForestGreen;
                    //else if (status == "PENDING") lblNominal.ForeColor = Color.OrangeScalar ?? Color.FromArgb(230, 140, 10);
                    else lblNominal.ForeColor = Color.Firebrick;

                    lblNominal.Location = new Point(480, 20);
                    lblNominal.AutoSize = true;

                    // Gabungkan komponen ke dalam struktur panel figma
                    itemPanel.Controls.Add(lblJudul);
                    itemPanel.Controls.Add(lblSub);
                    itemPanel.Controls.Add(lblNominal);

                    // Tumpuk masuk ke FlowLayoutPanel
                    flpRiwayatSaldo.Controls.Add(itemPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data saldo & riwayat figma: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTopup_Click(object sender, EventArgs e)
        {
            try
            {
                //if (string.IsNullOrEmpty(txtTopUp.Text))
                //{
                //    MessageBox.Show("Masukkan jumlah top up");
                //    return;
                //}

                //decimal jumlahTopUp = Convert.ToDecimal(txtTopUp.Text);

                // Jalankan query simpan topup saldo via controller
                //controller.TopupSaldo(idUser, jumlahTopUp);

                MessageBox.Show("Top Up Berhasil! Menunggu Konfirmasi Admin", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //txtTopUp.Clear();

                // REFRESH LAYOUT KARTU DAN LIST BARU SECARA OTOMATIS
                LoadHalamanSaldo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTopUp_Click_1(object sender, EventArgs e)
        {
            btnTopup_Click(sender, e);
        }

        // ====================================================================
        // IGNORE / BIARKAN EVENT SISA DESIGNER INI TETAP ADA BIAR GA MERAH
        // ====================================================================
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void lblSaldo_Click(object sender, EventArgs e) { }
        private void txtTopUp_TextChanged(object sender, EventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void lblSaldoBesar_Click(object sender, EventArgs e) { }
        private void lblRiwayatTitle_Click(object sender, EventArgs e) { }
        private void lblPengguna_Click(object sender, EventArgs e) { }
        private void btnTopUp_Click_2(object sender, EventArgs e) { }
    }
}
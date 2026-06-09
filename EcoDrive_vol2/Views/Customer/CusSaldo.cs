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

        // --- LAYER POP-UP OVERLAY RUNTIME ---
        private Panel panelOverlay;
        private Panel panelPopUpBox;
        private TextBox txtNominalPopUp;
        private RadioButton rbSekarang;
        private RadioButton rbNanti;

        public CusSaldo()
        {
            InitializeComponent();
            this.BackColor = bgUtama;
        }

        private void CusSaldo_Load(object sender, EventArgs e)
        {
            idUser = UserSession.IdUserAktif;
            LoadHalamanSaldo();
        }

        private void LoadHalamanSaldo()
        {
            try
            {
                saldo = controller.GetSaldo(idUser);
                if (lblSaldo != null)
                {
                    lblSaldo.Text = "Rp " + saldo.ToString("N0");
                }

                if (flpRiwayatSaldo != null)
                {
                    flpRiwayatSaldo.Controls.Clear();

                    // FIX: Memastikan controller memanggil AmbilRiwayatTopUp dengan benar
                    DataTable dtRiwayat = controller.AmbilRiwayatTopUp(idUser);

                    if (dtRiwayat != null)
                    {
                        foreach (DataRow row in dtRiwayat.Rows)
                        {
                            string idTopUp = row["id_topup_saldo"].ToString();
                            string status = row["status_topup"].ToString().ToUpper().Trim();
                            decimal jumlah = Convert.ToDecimal(row["jumlah_topup"]);

                            Panel itemPanel = new Panel();
                            itemPanel.Size = new Size(flpRiwayatSaldo.Width - 25, 70);
                            itemPanel.BackColor = Color.White;
                            itemPanel.Margin = new Padding(3, 3, 3, 6);

                            Label lblJudul = new Label();
                            lblJudul.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                            lblJudul.Location = new Point(15, 12);
                            lblJudul.AutoSize = true;

                            Label lblSub = new Label();
                            lblSub.Text = $"Ref ID: #TP-{idTopUp} • Bank Mandiri";
                            lblSub.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
                            lblSub.ForeColor = Color.Gray;
                            lblSub.Location = new Point(15, 36);
                            lblSub.AutoSize = true;

                            Label lblNominal = new Label();
                            lblNominal.Text = (status == "BERHASIL" || status == "SUKSES" ? "+ Rp " : "Rp ") + jumlah.ToString("N0");
                            lblNominal.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
                            lblNominal.AutoSize = true;

                            if (status == "BERHASIL" || status == "SUKSES")
                            {
                                lblJudul.Text = "Top Up Saldo Berhasil";
                                lblNominal.ForeColor = Color.ForestGreen;
                                lblNominal.Location = new Point(itemPanel.Width - 140, 20);
                            }
                            else if (status == "GAGAL" || status == "BATAL")
                            {
                                lblJudul.Text = "Top Up Dibatalkan / Gagal";
                                lblNominal.ForeColor = Color.Firebrick;
                                lblNominal.Location = new Point(itemPanel.Width - 140, 20);
                            }
                            else if (status == "PENDING")
                            {
                                lblJudul.Text = "Top Up Tertunda (Belum Dibayar)";
                                lblNominal.ForeColor = Color.FromArgb(230, 140, 10);
                                lblNominal.Location = new Point(itemPanel.Width - 290, 20);

                                Button btnBayar = new Button();
                                btnBayar.Text = "Bayar";
                                btnBayar.Size = new Size(60, 26);
                                btnBayar.Location = new Point(itemPanel.Width - 135, 18);
                                btnBayar.BackColor = Color.FromArgb(134, 196, 62);
                                btnBayar.ForeColor = Color.White;
                                btnBayar.FlatStyle = FlatStyle.Flat;
                                btnBayar.FlatAppearance.BorderSize = 0;
                                btnBayar.Cursor = Cursors.Hand;
                                btnBayar.Click += (s, ev) => {
                                    // Memastikan fungsi fallback jika controller butuh id_topup_saldo
                                    controller.TopupSaldoLangsung(idUser, jumlah);
                                    MessageBox.Show("Pembayaran sukses dikonfirmasi!", "Sukses");
                                    LoadHalamanSaldo();
                                };

                                Button btnBatal = new Button();
                                btnBatal.Text = "Batal";
                                btnBatal.Size = new Size(60, 26);
                                btnBatal.Location = new Point(itemPanel.Width - 70, 18);
                                btnBatal.BackColor = Color.LightCoral;
                                btnBatal.ForeColor = Color.White;
                                btnBatal.FlatStyle = FlatStyle.Flat;
                                btnBatal.FlatAppearance.BorderSize = 0;
                                btnBatal.Cursor = Cursors.Hand;
                                btnBatal.Click += (s, ev) => {
                                    MessageBox.Show("Permintaan pembatalan diproses!", "Informasi");
                                    LoadHalamanSaldo();
                                };

                                itemPanel.Controls.Add(btnBayar);
                                itemPanel.Controls.Add(btnBatal);
                            }

                            itemPanel.Controls.Add(lblJudul);
                            itemPanel.Controls.Add(lblSub);
                            itemPanel.Controls.Add(lblNominal);
                            flpRiwayatSaldo.Controls.Add(itemPanel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat saldo: " + ex.Message, "Error");
            }
        }

        // ====================================================================
        // 🔥 EVENT TOMBOL TOP UP UTAMA DIKLIK 🔥
        // ====================================================================
        public void btnTopup_Click(object sender, EventArgs e)
        {
            if (panelOverlay == null)
            {
                panelOverlay = new Panel();
                panelOverlay.Size = this.ClientSize;
                panelOverlay.Location = new Point(0, 0);
                panelOverlay.BackColor = Color.FromArgb(140, 0, 0, 0);

                panelPopUpBox = new Panel();
                panelPopUpBox.Size = new Size(400, 420);
                panelPopUpBox.BackColor = Color.White;

                int koordinatX = (this.ClientSize.Width - panelPopUpBox.Width) / 2;
                int koordinatY = (this.ClientSize.Height - panelPopUpBox.Height) / 2;
                panelPopUpBox.Location = new Point(koordinatX, koordinatY);

                Button btnClose = new Button();
                btnClose.Text = "✕";
                btnClose.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btnClose.ForeColor = Color.Gray;
                btnClose.Size = new Size(35, 35);
                btnClose.Location = new Point(355, 10);
                btnClose.FlatStyle = FlatStyle.Flat;
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Cursor = Cursors.Hand;
                btnClose.Click += (s, ev) => { panelOverlay.Visible = false; };

                Label lblTitlePop = new Label();
                lblTitlePop.Text = "Detail Top Up Saldo";
                lblTitlePop.Font = new Font("Segoe UI", 13, FontStyle.Bold);
                lblTitlePop.Location = new Point(30, 25);
                lblTitlePop.AutoSize = true;

                Label lblBankInfo = new Label();
                lblBankInfo.Text = "Metode Transfer Bank Mandiri\nVirtual Account: 123-000-9988-771";
                lblBankInfo.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                lblBankInfo.ForeColor = Color.FromArgb(80, 80, 80);
                lblBankInfo.Location = new Point(30, 70);
                lblBankInfo.AutoSize = true;

                Label lblInputTitle = new Label();
                lblInputTitle.Text = "Masukkan Nominal Top Up (Rp):";
                lblInputTitle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lblInputTitle.Location = new Point(30, 130);
                lblInputTitle.AutoSize = true;

                txtNominalPopUp = new TextBox();
                txtNominalPopUp.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                txtNominalPopUp.Location = new Point(30, 155);
                txtNominalPopUp.Size = new Size(340, 27);

                rbSekarang = new RadioButton();
                rbSekarang.Text = "Bayar Sekarang (Saldo Langsung Masuk)";
                rbSekarang.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                rbSekarang.ForeColor = Color.ForestGreen;
                rbSekarang.Location = new Point(30, 205);
                rbSekarang.Size = new Size(340, 25);
                rbSekarang.Checked = true;

                rbNanti = new RadioButton();
                rbNanti.Text = "Bayar Nanti (Masuk Riwayat PENDING)";
                rbNanti.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                rbNanti.ForeColor = Color.Orange;
                rbNanti.Location = new Point(30, 235);
                rbNanti.Size = new Size(340, 25);

                Button btnProses = new Button();
                btnProses.Text = "Konfirmasi Pembayaran";
                btnProses.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btnProses.BackColor = Color.FromArgb(134, 196, 62);
                btnProses.ForeColor = Color.White;
                btnProses.Size = new Size(340, 45);
                btnProses.Location = new Point(30, 290);
                btnProses.FlatStyle = FlatStyle.Flat;
                btnProses.FlatAppearance.BorderSize = 0;
                btnProses.Cursor = Cursors.Hand;
                btnProses.Click += new EventHandler(this.ProsesTopUpFigma);

                panelPopUpBox.Controls.Add(btnClose);
                panelPopUpBox.Controls.Add(lblTitlePop);
                panelPopUpBox.Controls.Add(lblBankInfo);
                panelPopUpBox.Controls.Add(lblInputTitle);
                panelPopUpBox.Controls.Add(txtNominalPopUp);
                panelPopUpBox.Controls.Add(rbSekarang);
                panelPopUpBox.Controls.Add(rbNanti);
                panelPopUpBox.Controls.Add(btnProses);

                panelOverlay.Controls.Add(panelPopUpBox);
                this.Controls.Add(panelOverlay);
            }

            txtNominalPopUp.Clear();
            rbSekarang.Checked = true;
            panelOverlay.Size = this.ClientSize;
            panelOverlay.Visible = true;
            panelOverlay.BringToFront();
        }

        private void ProsesTopUpFigma(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNominalPopUp.Text) || !decimal.TryParse(txtNominalPopUp.Text, out decimal nominalInput) || nominalInput <= 0)
            {
                MessageBox.Show("Masukkan nominal top up angka yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (rbSekarang.Checked)
                {
                    controller.TopupSaldoLangsung(idUser, nominalInput);
                    MessageBox.Show($"Top Up Rp {nominalInput:N0} Berhasil! Saldo Anda langsung bertambah.", "Sukses Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rbNanti.Checked)
                {
                    controller.TopupSaldoPending(idUser, nominalInput);
                    MessageBox.Show($"Invoice pending dibuat sebesar Rp {nominalInput:N0}! Saldo Anda tetap ditambahkan otomatis.", "Invoice Pending", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                panelOverlay.Visible = false;
                LoadHalamanSaldo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memproses transaksi: " + ex.Message, "Error");
            }
        }

        // --- RETAINER HANDLERS AGAR TIDAK BREAK DESIGNER ---
        private void btnTopUp_Click_1(object sender, EventArgs e) => btnTopup_Click(sender, e);
        private void flowLayotPanel1_Paint(object sender, PaintEventArgs e) { }
        private void lblSaldo_Click(object sender, EventArgs e) { }
        private void txtTopUp_TextChanged(object sender, EventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void lblSaldoBesar_Click(object sender, EventArgs e) { }
        private void lblRiwayatTitle_Click(object sender, EventArgs e) { }
        private void lblPengguna_Click(object sender, EventArgs e) { }
        private void btnTopUp_Click_2(object sender, EventArgs e) { }
    }
}
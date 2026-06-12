using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EcoDrive_vol2.Controllers.Admin;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Vehicles;
using EcoDriveUI;

namespace EcoDrive_vol2.Views
{
    public partial class AdKendaraan : Form
    {
        private AdKendaraanController controller;
        private List<Kendaraan> listMasterKendaraan;

        private string filterAktif = "Semua";
        public AdKendaraan()
        {
            InitializeComponent();
            controller = new AdKendaraanController();

            this.Load += AdKendaraan_Load;
            txtSearch.TextChanged += TxtSearch_TextChanged;

            btnSemua.Click += FilterButton_Click;
            btnMobil.Click += FilterButton_Click;
            btnMotor.Click += FilterButton_Click;
            btnTambah.Click += btnTambah_Click;
        }

        private void AdKendaraan_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            // --- STYLE SEARCH TEXTBOX ---
            txtSearch.BackColor = Color.FromArgb(245, 245, 240);
            txtSearch.ForeColor = Color.Black;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.PlaceholderText = "🔍 Cari kendaraan...";

            // --- STYLE FILTER BUTTONS ---
            btnSemua.Text = "Semua";
            btnMobil.Text = "Mobil";
            btnMotor.Text = "Motor";

            btnSemua.BackColor = Color.FromArgb(92, 184, 92);
            btnSemua.ForeColor = Color.White;

            btnMobil.BackColor = btnMotor.BackColor = Color.FromArgb(248, 244, 238);
            btnMobil.ForeColor = btnMotor.ForeColor = Color.FromArgb(35, 35, 35);

            btnSemua.FlatStyle = btnMobil.FlatStyle = btnMotor.FlatStyle = FlatStyle.Flat;
            btnSemua.FlatAppearance.BorderSize = btnMobil.FlatAppearance.BorderSize = btnMotor.FlatAppearance.BorderSize = 0;

            // --- STYLE BUTTON TAMBAH ---
            btnTambah.Text = "+ Tambah Kendaraan";
            btnTambah.BackColor = Color.FromArgb(92, 184, 92);
            btnTambah.ForeColor = Color.White;
            btnTambah.FlatStyle = FlatStyle.Flat;
            btnTambah.FlatAppearance.BorderSize = 0;

            if (flowKendaraan != null)
            {
                flowKendaraan.AutoScroll = true;
                flowKendaraan.FlowDirection = FlowDirection.LeftToRight;
                flowKendaraan.WrapContents = true;
            }

            RefreshDataDariDatabase();
        }

        private void RefreshDataDariDatabase()
        {
            listMasterKendaraan = controller.GetKendaraan();
            ApplyFilterDanPencarian();
        }

        private void ApplyFilterDanPencarian()
        {
            if (listMasterKendaraan == null) return;

            List<Kendaraan> dataTerfilter = listMasterKendaraan;
            if (filterAktif == "Mobil")
            {
                dataTerfilter = listMasterKendaraan.FindAll(x => x.TipeKendaraan == KendaraanTipe.mobil);
            }
            else if (filterAktif == "Motor")
            {
                dataTerfilter = listMasterKendaraan.FindAll(x => x.TipeKendaraan == KendaraanTipe.motor);
            }

            string keyword = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(keyword))
            {
                dataTerfilter = dataTerfilter.FindAll(x =>
                    x.NamaKendaraan.ToLower().Contains(keyword) ||
                    x.TipeKendaraan.ToString().ToLower().Contains(keyword) ||
                    x.NomorPlatKendaraan.ToLower().Contains(keyword)
                );
            }

            RenderVehicleCards(dataTerfilter);
        }
        private void RenderVehicleCards(List<Kendaraan> dataKendaraan)
        {
            flowKendaraan.Controls.Clear();
            if (dataKendaraan == null) return;

            flowKendaraan.HorizontalScroll.Maximum = 0;
            flowKendaraan.AutoScroll = false;
            flowKendaraan.VerticalScroll.Visible = true;
            flowKendaraan.AutoScroll = true;

            foreach (var vh in dataKendaraan)
            {
                RoundedPanel card = new RoundedPanel
                {
                    Size = new Size(270, 170),
                    BackColor = Color.White,
                    BorderRadius = 15,
                    Margin = new Padding(6)
                };

                Label lblNama = new Label
                {
                    Text = vh.NamaKendaraan,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(45, 45, 45),
                    Location = new Point(15, 15),
                    AutoSize = true
                };

                string tipeTeks = vh.TipeKendaraan == KendaraanTipe.mobil ? "Mobil" : "Motor";

                Label lblInfo = new Label
                {
                    Text = $"{tipeTeks} • Rp {vh.HargaSewa:N0}/hari",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.Gray,
                    Location = new Point(15, 45),
                    AutoSize = true
                };

                Label lblPlat = new Label
                {
                    Text = $"Plat : {vh.NomorPlatKendaraan}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.DimGray,
                    Location = new Point(15, 70),
                    AutoSize = true
                };

                Label lblStok = new Label
                {
                    Text = $"Stok : {vh.StokKendaraan}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.DimGray,
                    Location = new Point(15, 92),
                    AutoSize = true
                };

                string statusDb = vh.StatusKendaraan.ToString().Replace("_", " ");

                Color bgStatus = Color.FromArgb(232, 245, 233);
                Color fgStatus = Color.FromArgb(67, 160, 71);

                switch (statusDb.ToLower())
                {
                    case "disewa":
                        bgStatus = Color.FromArgb(255, 244, 229);
                        fgStatus = Color.FromArgb(255, 152, 0);
                        break;
                    case "rusak":
                        bgStatus = Color.FromArgb(255, 235, 238);
                        fgStatus = Color.FromArgb(244, 67, 54);
                        break;
                    case "dalam perbaikan":
                        bgStatus = Color.FromArgb(227, 242, 253);
                        fgStatus = Color.FromArgb(30, 136, 229);
                        break;
                }

                Label lblStatus = new Label
                {
                    Text = statusDb,
                    Size = new Size(110, 25),
                    Location = new Point(15, 125),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                    BackColor = bgStatus,
                    ForeColor = fgStatus
                };

                Button btnKelola = new Button
                {
                    Text = "Kelola ⚙",
                    Size = new Size(95, 30),
                    Location = new Point(155, 120),
                    BackColor = Color.FromArgb(245, 245, 245),
                    FlatStyle = FlatStyle.Flat
                };
                btnKelola.FlatAppearance.BorderSize = 0;

                // --- ACTION KELOLA KENDARAAN ---
                btnKelola.Click += (s, e) =>
                {
                    Form frm = new Form
                    {
                        Text = "Kelola Kendaraan",
                        Size = new Size(480, 600),
                        StartPosition = FormStartPosition.CenterScreen,
                        BackColor = Color.White,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        MaximizeBox = false
                    };

                    Label lblNamaForm = new Label { Text = "Nama Kendaraan", Location = new Point(30, 20), AutoSize = true };
                    TextBox txtNama = new TextBox { Location = new Point(30, 45), Size = new Size(400, 30), Text = vh.NamaKendaraan };

                    Label lblPlatForm = new Label { Text = "Nomor Plat", Location = new Point(30, 90), AutoSize = true };
                    TextBox txtPlat = new TextBox { Location = new Point(30, 115), Size = new Size(400, 30), Text = vh.NomorPlatKendaraan };

                    Label lblStokForm = new Label { Text = "Stok Kendaraan", Location = new Point(30, 160), AutoSize = true };
                    NumericUpDown numStok = new NumericUpDown { Location = new Point(30, 185), Size = new Size(400, 30), Minimum = 0, Maximum = 1000, Value = vh.StokKendaraan };

                    Label lblHarga = new Label { Text = "Harga Sewa (Rp)", Location = new Point(30, 230), AutoSize = true };
                    NumericUpDown numHarga = new NumericUpDown { Location = new Point(30, 255), Size = new Size(400, 30), Maximum = 100000000, DecimalPlaces = 0, Value = (decimal)vh.HargaSewa };

                    Label lblTipeForm = new Label { Text = "Tipe Kendaraan", Location = new Point(30, 300), AutoSize = true };
                    ComboBox cbTipe = new ComboBox { Location = new Point(30, 325), Size = new Size(400, 30), DropDownStyle = ComboBoxStyle.DropDownList };
                    cbTipe.Items.AddRange(Enum.GetNames(typeof(KendaraanTipe)));
                    cbTipe.SelectedItem = vh.TipeKendaraan.ToString();

                    Label lblStatusForm = new Label { Text = "Status Kendaraan", Location = new Point(30, 370), AutoSize = true };
                    ComboBox cbStatus = new ComboBox { Location = new Point(30, 395), Size = new Size(400, 30), DropDownStyle = ComboBoxStyle.DropDownList };
                    cbStatus.Items.AddRange(new string[] { "tersedia", "disewa", "rusak", "dalam perbaikan" });
                    cbStatus.SelectedItem = statusDb.ToLower();

                    Button btnHapus = new Button
                    {
                        Text = "Hapus Kendaraan",
                        Size = new Size(150, 40),
                        Location = new Point(30, 480),
                        BackColor = Color.FromArgb(244, 67, 54),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                    };
                    btnHapus.FlatAppearance.BorderSize = 0;

                    btnHapus.Click += (senderHapus, evHapus) =>
                    {
                        DialogResult result = MessageBox.Show(
                            $"Apakah Anda yakin ingin menghapus {vh.NamaKendaraan} dengan Plat [{vh.NomorPlatKendaraan}]?",
                            "Konfirmasi Hapus",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                controller.DeleteKendaraan(vh.IdKendaraan);
                                MessageBox.Show("Kendaraan berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frm.Close();
                                RefreshDataDariDatabase();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Gagal menghapus data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };

                    Button btnSimpan = new Button
                    {
                        Text = "Simpan Perubahan",
                        Size = new Size(180, 40),
                        Location = new Point(250, 480),
                        BackColor = Color.FromArgb(92, 184, 92),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat
                    };
                    btnSimpan.FlatAppearance.BorderSize = 0;

                    btnSimpan.Click += (sender2, ev2) =>
                    {
                        try
                        {
                            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtPlat.Text))
                            {
                                MessageBox.Show("Nama dan Nomor Plat tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            vh.NamaKendaraan = txtNama.Text.Trim();
                            vh.NomorPlatKendaraan = txtPlat.Text.Trim().ToUpper();
                            vh.StokKendaraan = (int)numStok.Value;
                            vh.HargaSewa = (long)numHarga.Value;
                            vh.TipeKendaraan = Enum.Parse<KendaraanTipe>(cbTipe.SelectedItem.ToString());
                            vh.StatusKendaraan = Enum.Parse<OptionStatus>(cbStatus.SelectedItem.ToString().Replace(" ", "_"));

                            controller.UpdateKendaraan(vh);
                            MessageBox.Show("Berhasil update data kendaraan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frm.Close();
                            RefreshDataDariDatabase();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Gagal menyimpan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    frm.Controls.AddRange(new Control[] {
                        lblNamaForm, txtNama, lblPlatForm, txtPlat, lblStokForm, numStok,
                        lblHarga, numHarga, lblTipeForm, cbTipe, lblStatusForm, cbStatus, btnHapus, btnSimpan
                    });

                    frm.ShowDialog();
                };

                card.Controls.AddRange(new Control[] { lblNama, lblInfo, lblPlat, lblStok, lblStatus, btnKelola });
                flowKendaraan.Controls.Add(card);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilterDanPencarian();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btnSemua.BackColor = btnMobil.BackColor = btnMotor.BackColor = Color.FromArgb(248, 244, 238);
            btnSemua.ForeColor = btnMobil.ForeColor = btnMotor.ForeColor = Color.FromArgb(35, 35, 35);

            btn.BackColor = Color.FromArgb(92, 184, 92);
            btn.ForeColor = Color.White;

            if (btn == btnSemua) filterAktif = "Semua";
            else if (btn == btnMobil) filterAktif = "Mobil";
            else if (btn == btnMotor) filterAktif = "Motor";

            ApplyFilterDanPencarian();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            Form frm = new Form
            {
                Text = "Tambah Kendaraan",
                Size = new Size(480, 600),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };

            Label lblNama = new Label { Text = "Nama Kendaraan", Location = new Point(30, 20), AutoSize = true };
            TextBox txtNama = new TextBox { Location = new Point(30, 45), Size = new Size(400, 30) };

            Label lblPlat = new Label { Text = "Nomor Plat", Location = new Point(30, 90), AutoSize = true };
            TextBox txtPlat = new TextBox { Location = new Point(30, 115), Size = new Size(400, 30), PlaceholderText = "Contoh: B 1234 ABC" };

            Label lblStok = new Label { Text = "Stok Kendaraan", Location = new Point(30, 160), AutoSize = true };
            NumericUpDown numStok = new NumericUpDown { Location = new Point(30, 185), Size = new Size(400, 30), Minimum = 1, Maximum = 1000, Value = 1 };

            Label lblHarga = new Label { Text = "Harga Sewa (Rp)", Location = new Point(30, 230), AutoSize = true };
            NumericUpDown numHarga = new NumericUpDown { Location = new Point(30, 255), Size = new Size(400, 30), Maximum = 100000000, DecimalPlaces = 0 };

            Label lblTipe = new Label { Text = "Tipe Kendaraan", Location = new Point(30, 300), AutoSize = true };
            ComboBox cbTipe = new ComboBox { Location = new Point(30, 325), Size = new Size(400, 30), DropDownStyle = ComboBoxStyle.DropDownList };
            cbTipe.Items.AddRange(Enum.GetNames(typeof(KendaraanTipe)));
            cbTipe.SelectedIndex = 0;

            Label lblStatus = new Label { Text = "Status Kendaraan", Location = new Point(30, 370), AutoSize = true };
            ComboBox cbStatus = new ComboBox { Location = new Point(30, 395), Size = new Size(400, 30), DropDownStyle = ComboBoxStyle.DropDownList };
            cbStatus.Items.AddRange(new string[] { "tersedia", "disewa", "rusak", "dalam perbaikan" });
            cbStatus.SelectedIndex = 0;

            Button btnSimpan = new Button
            {
                Text = "Tambah Kendaraan",
                Size = new Size(180, 40),
                Location = new Point(250, 480),
                BackColor = Color.FromArgb(92, 184, 92),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSimpan.FlatAppearance.BorderSize = 0;

            btnSimpan.Click += (s, ev) =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtPlat.Text))
                    {
                        MessageBox.Show("Semua bidang input wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Kendaraan kendaraan = new Kendaraan
                    {
                        NamaKendaraan = txtNama.Text.Trim(),
                        NomorPlatKendaraan = txtPlat.Text.Trim().ToUpper(),
                        StokKendaraan = (int)numStok.Value,
                        HargaSewa = (long)numHarga.Value,
                        TipeKendaraan = Enum.Parse<KendaraanTipe>(cbTipe.SelectedItem.ToString()),
                        StatusKendaraan = Enum.Parse<OptionStatus>(cbStatus.SelectedItem.ToString().Replace(" ", "_")),
                        IdMerkKendaraan = 1
                    };

                    controller.AddKendaraan(kendaraan);
                    MessageBox.Show("Kendaraan baru berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm.Close();
                    RefreshDataDariDatabase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menambah data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            frm.Controls.AddRange(new Control[] {
                lblNama, txtNama, lblPlat, txtPlat, lblStok, numStok,
                lblHarga, numHarga, lblTipe, cbTipe, lblStatus, cbStatus, btnSimpan
            });

            frm.ShowDialog();
        }

        private void flowKendaraan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
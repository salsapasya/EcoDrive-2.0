using EcoDrive_vol2.Controllers.Admin;
using EcoDrive_vol2.Models;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Vehicles;
using EcoDriveUI;

namespace EcoDrive_vol2.Views
{
    public partial class AdKendaraan : Form
    {
        private AdKendaraanController controller;

        private List<Kendaraan> listMasterKendaraan;

        public AdKendaraan()
        {
            InitializeComponent();

            controller = new AdKendaraanController();

            this.Load += AdKendaraan_Load;

            txtSearch.TextChanged += TxtSearch_TextChanged;

            btnSemua.Click += FilterButton_Click;
            btnMobil.Click += FilterButton_Click;
            btnMotor.Click += FilterButton_Click;
        }

        private void AdKendaraan_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            if (this.Parent != null)
            {
                this.Size = this.Parent.ClientSize;
            }

            if (txtSearch != null)
            {
                txtSearch.BackColor = Color.FromArgb(245, 245, 240);

                txtSearch.ForeColor = Color.DimGray;

                txtSearch.Text = "🔍 Cari nama, tipe, ID...";
            }

            if (btnSemua != null)
            {
                btnSemua.BackColor = Color.FromArgb(92, 184, 92);

                btnSemua.ForeColor = Color.White;

                btnSemua.Text = "Semua";
            }

            if (btnMobil != null)
            {
                btnMobil.BackColor = Color.FromArgb(248, 244, 238);

                btnMobil.ForeColor = Color.FromArgb(35, 35, 35);

                btnMobil.Text = "Mobil";
            }

            if (btnMotor != null)
            {
                btnMotor.BackColor = Color.FromArgb(248, 244, 238);

                btnMotor.ForeColor = Color.FromArgb(35, 35, 35);

                btnMotor.Text = "Motor";
            }

            if (btnTambah != null)
            {
                btnTambah.BackColor = Color.FromArgb(92, 184, 92);

                btnTambah.ForeColor = Color.White;

                btnTambah.Text = "+ Tambah Kendaraan";
            }

            if (flowKendaraan != null)
            {
                flowKendaraan.AutoScroll = true;
            }

            RefreshDataDariDatabase();
        }

        private void RefreshDataDariDatabase()
        {
            listMasterKendaraan = controller.GetKendaraan();

            RenderVehicleCards(listMasterKendaraan);
        }

        private void RenderVehicleCards(List<Kendaraan> dataKendaraan)
        {
            flowKendaraan.Controls.Clear();

            if (dataKendaraan == null) return;

            foreach (var vh in dataKendaraan)
            {
                RoundedPanel card = new RoundedPanel
                {
                    Size = new Size(270, 160),
                    BackColor = Color.White,
                    BorderRadius = 15,
                    Margin = new Padding(12)
                };

                Label lblNama = new Label
                {
                    Text = !string.IsNullOrEmpty(vh.NamaKendaraan)
                        ? vh.NamaKendaraan
                        : "Tanpa Nama",

                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),

                    ForeColor = Color.FromArgb(45, 45, 45),

                    Location = new Point(15, 15),

                    AutoSize = true
                };

                string tipeTeks =
                    vh.TipeKendaraan == KendaraanTipe.mobil
                    ? "Mobil"
                    : "Motor";

                string infoSewa =
                    $"Rp {vh.HargaSewa:N0}/hari";

                Label lblSubInfo = new Label
                {
                    Text = $"{tipeTeks} • {infoSewa}",

                    Font = new Font("Segoe UI", 9F),

                    ForeColor = Color.Gray,

                    Location = new Point(15, 40),

                    AutoSize = true
                };

                int persenBaterai =
                    vh.StatusKendaraan ==
                    OptionStatus.dalam_perbaikan
                    ? 0
                    : (vh.NamaKendaraan.Contains("Tesla")
                        ? 15
                        : 92);

                Color batteryColor =
                    persenBaterai > 50
                    ? Color.FromArgb(67, 160, 71)
                    : (persenBaterai > 20
                        ? Color.Orange
                        : Color.Red);

                Label lblBaterai = new Label
                {
                    Text = $"🔋 {persenBaterai}%",

                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),

                    ForeColor = batteryColor,

                    Location = new Point(15, 75),

                    AutoSize = true
                };

                string statusDb =
                    vh.StatusKendaraan
                        .ToString()
                        .Replace("_", " ")
                        .ToLower();

                Color bgStatus;
                Color fgStatus;

                switch (statusDb)
                {
                    case "tersedia":

                        bgStatus = Color.FromArgb(232, 245, 233);

                        fgStatus = Color.FromArgb(67, 160, 71);

                        break;

                    case "disewa":

                        bgStatus = Color.FromArgb(255, 243, 224);

                        fgStatus = Color.OrangeRed;

                        break;

                    case "dalam perbaikan":

                    case "rusak":

                        bgStatus = Color.FromArgb(255, 235, 235);

                        fgStatus = Color.Red;

                        break;

                    default:

                        bgStatus = Color.FromArgb(227, 242, 253);

                        fgStatus = Color.FromArgb(30, 136, 229);

                        break;
                }

                Label lblStatusBadge = new Label
                {
                    Text = statusDb,

                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),

                    BackColor = bgStatus,

                    ForeColor = fgStatus,

                    Location = new Point(15, 115),

                    Size = new Size(110, 25),

                    TextAlign = ContentAlignment.MiddleCenter
                };

                Button btnDetailCard = new Button
                {
                    Text = "Kelola ⚙",

                    Size = new Size(95, 30),

                    Location = new Point(155, 112),

                    BackColor = Color.FromArgb(245, 245, 242),

                    ForeColor = Color.FromArgb(45, 45, 45),

                    FlatStyle = FlatStyle.Flat,

                    Cursor = Cursors.Hand,

                    Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
                };

                btnDetailCard.FlatAppearance.BorderSize = 0;

                btnDetailCard.Click += (s, e) =>
                {
                    Form frm = new Form();

                    frm.Text = "Kelola Kendaraan";

                    frm.Size = new Size(500, 520);

                    frm.StartPosition = FormStartPosition.CenterScreen;

                    frm.BackColor = Color.White;

                    frm.FormBorderStyle = FormBorderStyle.FixedDialog;

                    frm.MaximizeBox = false;

                    Label lblFormTitle = new Label
                    {
                        Text = "Informasi Kendaraan",

                        Font = new Font("Segoe UI", 16,
                        FontStyle.Bold),

                        Location = new Point(25, 20),

                        AutoSize = true
                    };

                    Label lblNamaKendaraan = new Label
                    {
                        Text = "Nama Kendaraan",

                        Location = new Point(30, 80),

                        Font = new Font("Segoe UI", 9F,
                        FontStyle.Bold),

                        AutoSize = true
                    };

                    TextBox txtNama = new TextBox
                    {
                        Size = new Size(400, 30),

                        Location = new Point(30, 105),

                        Text = vh.NamaKendaraan
                    };

                    Label lblHarga = new Label
                    {
                        Text = "Harga Sewa (Rp)",

                        Location = new Point(30, 150),

                        Font = new Font("Segoe UI", 9F,
                        FontStyle.Bold),

                        AutoSize = true
                    };

                    NumericUpDown numHarga =
                        new NumericUpDown
                        {
                            Location = new Point(30, 175),

                            Size = new Size(400, 30),

                            Minimum = 0,

                            Maximum = 10000000,

                            DecimalPlaces = 2,

                            Value = vh.HargaSewa
                        };

                    Label lblStatus = new Label
                    {
                        Text = "Status Kendaraan",

                        Location = new Point(30, 220),

                        Font = new Font("Segoe UI", 9F,
                        FontStyle.Bold),

                        AutoSize = true
                    };

                    ComboBox cbStatus = new ComboBox
                    {
                        Location = new Point(30, 245),

                        Size = new Size(400, 30),

                        DropDownStyle =
                        ComboBoxStyle.DropDownList
                    };

                    cbStatus.Items.AddRange(new string[]
                    {
                        "tersedia",
                        "disewa",
                        "rusak",
                        "dalam perbaikan"
                    });

                    cbStatus.SelectedItem = statusDb;

                    Button btnSimpan = new Button
                    {
                        Text = "Simpan",

                        Size = new Size(130, 42),

                        Location = new Point(300, 410),

                        BackColor = Color.FromArgb(123, 201, 111),

                        ForeColor = Color.White,

                        FlatStyle = FlatStyle.Flat,

                        Font = new Font("Segoe UI", 9F,
                        FontStyle.Bold)
                    };

                    btnSimpan.FlatAppearance.BorderSize = 0;

                    btnSimpan.Click += (sender2, ev2) =>
                    {
                        try
                        {
                            vh.NamaKendaraan =
                                txtNama.Text;

                            vh.HargaSewa =
                                numHarga.Value;

                            vh.StatusKendaraan =
                                Enum.Parse<OptionStatus>(
                                    cbStatus.SelectedItem
                                        .ToString()
                                        .Replace(" ", "_")
                                );

                            controller.UpdateKendaraan(vh);

                            MessageBox.Show(
                                "Data berhasil diperbarui!",
                                "EcoDrive",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            frm.Close();

                            RefreshDataDariDatabase();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                $"Gagal menyimpan data: {ex.Message}",
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    };

                    frm.Controls.AddRange(new Control[]
                    {
                        lblFormTitle,
                        lblNamaKendaraan,
                        txtNama,
                        lblHarga,
                        numHarga,
                        lblStatus,
                        cbStatus,
                        btnSimpan
                    });

                    frm.ShowDialog();
                };

                card.Controls.AddRange(new Control[]
                {
                    lblNama,
                    lblSubInfo,
                    lblBaterai,
                    lblStatusBadge,
                    btnDetailCard
                });

                flowKendaraan.Controls.Add(card);
            }
        }

        private void TxtSearch_TextChanged(
            object sender,
            EventArgs e)
        {
            string keyword =
                txtSearch.Text.Trim().ToLower();

            if (keyword ==
                "🔍 cari nama, tipe, id..."
                || string.IsNullOrEmpty(keyword))
            {
                RenderVehicleCards(listMasterKendaraan);

                return;
            }

            var hasilFilter =
                listMasterKendaraan.FindAll(x =>

                    x.NamaKendaraan
                        .ToLower()
                        .Contains(keyword)

                    ||

                    x.TipeKendaraan
                        .ToString()
                        .ToLower()
                        .Contains(keyword)

                    ||

                    x.IdKendaraan
                        .ToString()
                        .Contains(keyword)
                );

            RenderVehicleCards(hasilFilter);
        }

        private void FilterButton_Click(
            object sender,
            EventArgs e)
        {
            if (listMasterKendaraan == null)
                return;

            Button btnKlik = (Button)sender;

            btnSemua.BackColor =
            btnMobil.BackColor =
            btnMotor.BackColor =
                Color.FromArgb(248, 244, 238);

            btnSemua.ForeColor =
            btnMobil.ForeColor =
            btnMotor.ForeColor =
                Color.FromArgb(35, 35, 35);

            btnKlik.BackColor =
                Color.FromArgb(92, 184, 92);

            btnKlik.ForeColor =
                Color.White;

            if (btnKlik == btnSemua)
            {
                RenderVehicleCards(
                    listMasterKendaraan
                );
            }

            else if (btnKlik == btnMobil)
            {
                RenderVehicleCards(
                    listMasterKendaraan.FindAll(
                        x =>
                        x.TipeKendaraan ==
                        KendaraanTipe.mobil
                    )
                );
            }

            else if (btnKlik == btnMotor)
            {
                RenderVehicleCards(
                    listMasterKendaraan.FindAll(
                        x =>
                        x.TipeKendaraan ==
                        KendaraanTipe.motor
                    )
                );
            }
        }

        private void btnTambah_Click(
            object sender,
            EventArgs e)
        {

        }
    }
}
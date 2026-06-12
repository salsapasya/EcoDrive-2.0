using System;
using System.Windows.Forms;
using EcoDrive_vol2.Controllers.Admin;
using EcoDrive_vol2.Models.Enums;
using EcoDrive_vol2.Models.Vehicles;

namespace EcoDrive_vol2.Views.Admin
{
    public partial class FrmDetailKendaraan : Form
    {
        private readonly AdKendaraanController _controller;
        private readonly Kendaraan _kendaraanEksisting;
        private readonly bool _isEditMode;

        public FrmDetailKendaraan(AdKendaraanController controller, Kendaraan kendaraan = null)
        {
            // PENTING: Panggil InitializeComponent agar komponen desainer dirakit
            InitializeComponent();

            _controller = controller;
            _kendaraanEksisting = kendaraan;
            _isEditMode = (kendaraan != null);

            // Pasang event secara dinamis
            btnSimpan.Click += BtnSimpan_Click;

            // Atur tombol hapus berdasarkan mode
            if (_isEditMode)
            {
                btnHapus.Click += BtnHapus_Click;
                btnSimpan.Text = "Simpan Perubahan";
            }
            else
            {
                btnHapus.Visible = false; // Sembunyikan jika mode tambah data
                btnSimpan.Text = "Tambah Kendaraan";
            }

            SetupDropdownItems();
            LoadDataIfEditMode();
        }

        private void SetupDropdownItems()
        {
            cbTipe.Items.AddRange(Enum.GetNames(typeof(KendaraanTipe)));
            cbTipe.SelectedIndex = 0;

            cbStatus.Items.AddRange(new string[] { "tersedia", "disewa", "rusak", "dalam perbaikan" });
            cbStatus.SelectedIndex = 0;
        }

        private void LoadDataIfEditMode()
        {
            if (!_isEditMode) return;

            txtNama.Text = _kendaraanEksisting.NamaKendaraan;
            txtPlat.Text = _kendaraanEksisting.NomorPlatKendaraan;
            numStok.Value = _kendaraanEksisting.StokKendaraan;
            numHarga.Value = (decimal)_kendaraanEksisting.HargaSewa;
            cbTipe.SelectedItem = _kendaraanEksisting.TipeKendaraan.ToString();
            cbStatus.SelectedItem = _kendaraanEksisting.StatusKendaraan.ToString().Replace("_", " ").ToLower();
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtPlat.Text))
            {
                MessageBox.Show("Nama dan Nomor Plat wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Kendaraan target = _isEditMode ? _kendaraanEksisting : new Kendaraan();

                target.NamaKendaraan = txtNama.Text.Trim();
                target.NomorPlatKendaraan = txtPlat.Text.Trim().ToUpper();
                target.StokKendaraan = (int)numStok.Value;
                target.HargaSewa = (long)numHarga.Value;
                target.TipeKendaraan = Enum.Parse<KendaraanTipe>(cbTipe.SelectedItem.ToString());
                target.StatusKendaraan = Enum.Parse<OptionStatus>(cbStatus.SelectedItem.ToString().Replace(" ", "_"));

                if (!_isEditMode) target.IdMerkKendaraan = 1;

                if (_isEditMode)
                    _controller.UpdateKendaraan(target);
                else
                    _controller.AddKendaraan(target);

                MessageBox.Show($"Data kendaraan berhasil {(_isEditMode ? "diperbarui" : "ditambahkan")}!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus {_kendaraanEksisting.NamaKendaraan}?",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.DeleteKendaraan(_kendaraanEksisting.IdKendaraan);
                    MessageBox.Show("Kendaraan berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghapus data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmDetailKendaraan_Load(object sender, EventArgs e)
        {
            // Event load bawaan desainer (bisa dikosongkan jika tidak dipakai)
        }
    }
}
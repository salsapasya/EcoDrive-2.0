namespace EcoDrive_vol2.Views
{
    partial class AdKendaraan
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvKendaraan;
        private TextBox txtNamaKendaraan;
        private TextBox txtHargaSewa;
        private TextBox txtStok;

        private ComboBox cbStatus;
        private ComboBox cbMerk;
        private ComboBox cbTipeKendaraan;

        private Button btnTambah;
        private Button btnDelete;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvKendaraan =
                new DataGridView();

            txtNamaKendaraan =
                new TextBox();

            txtHargaSewa =
                new TextBox();

            txtStok =
                new TextBox();

            cbStatus =
                new ComboBox();

            cbMerk =
                new ComboBox();

            cbTipeKendaraan =
                new ComboBox();

            btnTambah =
                new Button();

            btnDelete =
                new Button();

            SuspendLayout();

            // dgv
            dgvKendaraan.Location =
                new Point(20, 20);

            dgvKendaraan.Size =
                new Size(740, 200);

            dgvKendaraan.Name =
                "dgvKendaraan";

            // txt nama
            txtNamaKendaraan.Location =
                new Point(20, 250);

            txtNamaKendaraan.Name =
                "txtNamaKendaraan";

            txtNamaKendaraan.PlaceholderText =
                "Nama Kendaraan";

            // txt harga
            txtHargaSewa.Location =
                new Point(20, 290);

            txtHargaSewa.Name =
                "txtHargaSewa";

            txtHargaSewa.PlaceholderText =
                "Harga Sewa";

            // txt stok
            txtStok.Location =
                new Point(20, 330);

            txtStok.Name =
                "txtStok";

            txtStok.PlaceholderText =
                "Stok";

            // cb tipe
            cbTipeKendaraan.Location =
                new Point(250, 250);

            cbTipeKendaraan.Name =
                "cbTipeKendaraan";

            // cb merk
            cbMerk.Location =
                new Point(250, 290);

            cbMerk.Name =
                "cbMerk";

            // cb status
            cbStatus.Location =
                new Point(250, 330);

            cbStatus.Name =
                "cbStatus";

            // btn tambah
            btnTambah.Location =
                new Point(500, 250);

            btnTambah.Size =
                new Size(100, 40);

            btnTambah.Text =
                "Tambah";

            btnTambah.Click +=
                btnTambah_Click;

            // btn delete
            btnDelete.Location =
                new Point(500, 310);

            btnDelete.Size =
                new Size(100, 40);

            btnDelete.Text =
                "Delete";

            // FORM
            ClientSize =
                new Size(800, 450);

            Controls.Add(dgvKendaraan);
            Controls.Add(txtNamaKendaraan);
            Controls.Add(txtHargaSewa);
            Controls.Add(txtStok);

            Controls.Add(cbStatus);
            Controls.Add(cbMerk);
            Controls.Add(cbTipeKendaraan);

            Controls.Add(btnTambah);
            Controls.Add(btnDelete);

            Name = "AdKendaraan";

            Text = "AdKendaraan";

            ResumeLayout(false);

            PerformLayout();
        }
    }
}
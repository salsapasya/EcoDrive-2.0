using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class AdDashboard : Form
    {
        private Form activeForm = null;
        private Color bgUtama = Color.FromArgb(255, 253, 246);

        public AdDashboard()
        {
            InitializeComponent();

            btDasboard.Click += btDasboard_Click;
            btKendaraan.Click += btKendaraan_Click;
            btCustomer.Click += btCustomer_Click;
            btTransaksi.Click += btTransaksi_Click;
            btPendapatan.Click += btPendapatan_Click;
        }

        // --- FUNGSI UTAMA PINDAH FORM (SUDAH DIPERBAIKI) ---
            private void OpenForm(Form childForm)
            {
                if (activeForm != null)
                {
                    activeForm.Close();
                    activeForm.Dispose();
                }

                activeForm = childForm;

                // 1. Matikan semua properti Form yang membuatnya bertingkah seperti 'Window Terpisah'
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
    
                // 2. JURUS PAMUNGKAS: Paksa ukurannya MENYAMAI persis ukuran Panel Kontainer Anda saat itu
                childForm.Size = pnContentAdmin.ClientSize; 
    
                // 3. Pasang Dock Fill agar dia mengunci dan ikut melar kalau layar dibesarkan lagi
                childForm.Dock = DockStyle.Fill;

                // 4. Bersihkan dan masukkan ke kontainer
                pnContentAdmin.Controls.Clear();
                pnContentAdmin.Controls.Add(childForm);
                pnContentAdmin.Tag = childForm;

                // 5. Reset koordinat ke ujung kiri atas (0,0) agar pas di sebelah sidebar
                childForm.Location = new Point(0, 0);
    
                // 6. Paksa Windows menggambar ulang layout secara realtime
                pnContentAdmin.PerformLayout();
                childForm.Refresh();

                childForm.BringToFront();
                childForm.Show();
            }

        // RESET WARNA BUTTON SIDEBAR
        private void ResetButton()
        {
            btDasboard.BackColor = Color.White;
            btKendaraan.BackColor = Color.White;
            btTransaksi.BackColor = Color.White;
            btPendapatan.BackColor = Color.White;
            btCustomer.BackColor = Color.White;
        }

        // DASHBOARD MENU
        private void btDasboard_Click(object sender, EventArgs e)
        {
            ResetButton();
            btDasboard.BackColor = Color.FromArgb(191, 219, 120);

            // Perbaikan: Jangan panggil 'new AdDashboard()' lagi di sini agar tidak infinite loop.
            // Cukup kosongkan panel kontainer untuk kembali ke tampilan home dashboard awal Anda,
            // atau panggil form sub-dashboard khusus (misal: AdHomeDashboard).
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
                activeForm = null;
            }
            pnContentAdmin.Controls.Clear();
        }

        // KENDARAAN MENU
        private void btKendaraan_Click(object sender, EventArgs e)
        {
            ResetButton();
            btKendaraan.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdKendaraan());
        }

        // CUSTOMER MENU
        private void btCustomer_Click(object sender, EventArgs e)
        {
            ResetButton();
            btCustomer.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdCustomer());
        }

        // TRANSAKSI MENU
        private void btTransaksi_Click(object sender, EventArgs e)
        {
            ResetButton();
            btTransaksi.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdTransaksi());
        }

        // PENDAPATAN MENU
        private void btPendapatan_Click(object sender, EventArgs e)
        {
            ResetButton();
            btPendapatan.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdPendapatan());
        }
    }
}
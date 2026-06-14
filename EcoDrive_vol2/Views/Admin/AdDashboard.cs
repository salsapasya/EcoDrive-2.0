using EcoDrive_vol2.Views.Admin;
using EcoDrive_vol2.Controllers.Admin;
using EcoDriveUI; 
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

        private Panel pnDefaultDashboardContent;

        private Label lblCountCustomer;
        private Label lblCountKendaraan;
        private Label lblCountDisewa;
        private Label lblCountPendapatan;

        private Label lblCountTersedia;
        private Label lblCountSedangDisewa;
        private Label lblCountCharging;
        private Label lblCountMaintenance;

        public AdDashboard()
        {
            InitializeComponent();

            btDasboard.Click += btDasboard_Click;
            btKendaraan.Click += btKendaraan_Click;
            btCustomer.Click += btCustomer_Click;
            btTransaksi.Click += btTransaksi_Click;
            btPendapatan.Click += btPendapatan_Click;
            btTopUp.Click += btTopUp_Click;

            if (btLogoutAd != null) btLogoutAd.Click += btLogoutAd_Click;

            InitDashboardLayout();
        }

        private void AdDashboard_Load(object sender, EventArgs e)
        {
            ResetButton();
            btDasboard.BackColor = Color.FromArgb(191, 219, 120);

            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                AdDashboardController controller = new AdDashboardController();
                var data = controller.GetDashboardData();

                lblCountCustomer.Text = data.TotalCustomer.ToString("N0");
                lblCountKendaraan.Text = data.TotalKendaraan.ToString("N0");
                lblCountDisewa.Text = data.TotalDisewa.ToString("N0");

                lblCountPendapatan.Text = "Rp " + (data.TotalPendapatan / 1000000).ToString("N1") + "M";

                lblCountTersedia.Text = data.Tersedia.ToString();
                lblCountSedangDisewa.Text = data.Disewa.ToString();
                lblCountCharging.Text = data.Charging.ToString();
                lblCountMaintenance.Text = data.Maintenance.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void InitDashboardLayout()
        {
            pnDefaultDashboardContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = bgUtama
            };
            pnContentAdmin.Controls.Add(pnDefaultDashboardContent);

            RoundedPanel cardCustomer = CreateStatCard("Total Customer", Color.FromArgb(232, 245, 233), "👤", new Point(30, 30), out lblCountCustomer);
            RoundedPanel cardKendaraan = CreateStatCard("Total Kendaraan", Color.FromArgb(227, 242, 253), "🚗", new Point(270, 30), out lblCountKendaraan);
            RoundedPanel cardDisewa = CreateStatCard("Kendaraan Disewa", Color.FromArgb(243, 229, 245), "🔑", new Point(510, 30), out lblCountDisewa);
            RoundedPanel cardPendapatan = CreateStatCard("Total Pendapatan", Color.FromArgb(255, 235, 238), "💰", new Point(750, 30), out lblCountPendapatan);
            RoundedPanel panelStatus = new RoundedPanel
            {
               
                Size = new Size(940, 150),
                Location = new Point(30, 210), 
                BackColor = Color.White,
                BorderRadius = 20,
                Padding = new Padding(20)
            };

            Label lblStatusTitle = new Label
            {
                Text = "Status Kendaraan",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 45),
                Location = new Point(20, 20),
                AutoSize = true
            };
            panelStatus.Controls.Add(lblStatusTitle);

            int startX = 20;
            int gap = 20;

            panelStatus.Controls.Add(CreateStatusRow("Tersedia", Color.FromArgb(245, 247, 248), Color.FromArgb(100, 110, 120), new Point(startX, 65), out lblCountTersedia));
            panelStatus.Controls.Add(CreateStatusRow("Sedang Disewa", Color.FromArgb(230, 242, 255), Color.FromArgb(30, 144, 255), new Point(startX + 230 + gap, 65), out lblCountSedangDisewa));
            panelStatus.Controls.Add(CreateStatusRow("Sedang Charging", Color.FromArgb(255, 251, 230), Color.FromArgb(255, 193, 7), new Point(startX + (230 + gap) * 2, 65), out lblCountCharging));
            panelStatus.Controls.Add(CreateStatusRow("Maintenance", Color.FromArgb(255, 240, 240), Color.FromArgb(220, 53, 69), new Point(startX + (230 + gap) * 3, 65), out lblCountMaintenance));

            pnDefaultDashboardContent.Controls.AddRange(new Control[] {
                cardCustomer, cardKendaraan, cardDisewa, cardPendapatan, panelStatus
            });
        }

        private RoundedPanel CreateStatCard(string title, Color iconBg, string emoji, Point location, out Label valueLabel)
        {
            RoundedPanel card = new RoundedPanel
            {
                Size = new Size(220, 140),
                Location = location,
                BackColor = Color.White,
                BorderRadius = 20
            };

            RoundedPanel pnlIcon = new RoundedPanel
            {
                Size = new Size(50, 50),
                Location = new Point(20, 25), 
                BackColor = iconBg,
                BorderRadius = 15
            };

            Label lblEmoji = new Label
            {
                Text = emoji,
                Font = new Font("Segoe UI Emoji", 18F), 
                Size = new Size(50, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };
            pnlIcon.Controls.Add(lblEmoji);
            card.Controls.Add(pnlIcon);

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI Semibold", 9F),
                ForeColor = Color.DarkGray,
                Location = new Point(80, 30),
                AutoSize = true
            };

            valueLabel = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 45),
                Location = new Point(80, 50),
                AutoSize = true
            };

            card.Controls.AddRange(new Control[] { lblTitle, valueLabel });
            return card;
        }

        private RoundedPanel CreateStatusRow(string statusName, Color rowBg, Color textColor, Point location, out Label countLabel)
        {
            RoundedPanel rowContainer = new RoundedPanel
            {
                Size = new Size(220, 60), 
                Location = location,      
                BackColor = rowBg,
                BorderRadius = 12
            };

            Label lblName = new Label
            {
                Text = statusName,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(15, 10),
                AutoSize = true
            };

            countLabel = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(15, 30),
                AutoSize = true
            };

            rowContainer.Controls.AddRange(new Control[] { lblName, countLabel });
            return rowContainer;
        }

        private void OpenForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            pnDefaultDashboardContent.Visible = false;

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Size = pnContentAdmin.ClientSize;
            childForm.Dock = DockStyle.Fill;

            for (int i = pnContentAdmin.Controls.Count - 1; i >= 0; i--)
            {
                if (pnContentAdmin.Controls[i] != pnDefaultDashboardContent)
                    pnContentAdmin.Controls.RemoveAt(i);
            }

            pnContentAdmin.Controls.Add(childForm);
            pnContentAdmin.Tag = childForm;
            pnContentAdmin.PerformLayout();
            childForm.Refresh();
            childForm.BringToFront();
            childForm.Show();
        }

        private void ResetButton()
        {
            btDasboard.BackColor = Color.White;
            btKendaraan.BackColor = Color.White;
            btTransaksi.BackColor = Color.White;
            btPendapatan.BackColor = Color.White;
            btCustomer.BackColor = Color.White;
            btTopUp.BackColor = Color.White;
        }

        private void btDasboard_Click(object sender, EventArgs e)
        {
            ResetButton();
            btDasboard.BackColor = Color.FromArgb(191, 219, 120);

            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
                activeForm = null;
            }

            LoadDataFromDatabase();

            pnDefaultDashboardContent.Visible = true;
            pnDefaultDashboardContent.BringToFront();
        }

        private void btKendaraan_Click(object sender, EventArgs e)
        {
            ResetButton();
            btKendaraan.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdKendaraan());
        }

        private void btCustomer_Click(object sender, EventArgs e)
        {
            ResetButton();
            btCustomer.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdCustomer());
        }

        private void btTransaksi_Click(object sender, EventArgs e)
        {
            ResetButton();
            btTransaksi.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdTransaksi());
        }

        private void btPendapatan_Click(object sender, EventArgs e)
        {
            ResetButton();
            btPendapatan.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdPendapatan());
        }

        private void btTopUp_Click(object sender, EventArgs e)
        {
            ResetButton();
            btTopUp.BackColor = Color.FromArgb(191, 219, 120);
            OpenForm(new AdTopUpCustomer());
        }

        private void btLogoutAd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FormLogin login = new FormLogin();
                login.Show();
                this.Close();
            }
        }

        private void pnContent_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
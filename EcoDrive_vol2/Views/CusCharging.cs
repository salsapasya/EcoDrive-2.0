using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoDrive_vol2.Views
{
    public partial class CusCharging : Form
    {
        private Color bgUtama = Color.FromArgb(255, 253, 246);
        public CusCharging()
        {
            InitializeComponent();
            this.BackColor = bgUtama;
        }
    }
}
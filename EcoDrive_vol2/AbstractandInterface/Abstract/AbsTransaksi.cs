using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EcoDrive_vol2.AbstractandInterface.Abstract
{
    // OOP (Abstraction): Menyediakan cetak biru berupa kelas abstrak yang tidak bisa di-instansiasi langsung.
    public abstract class AbsTransaksi
    {
        // 2. ENCAPSULATION: Menggunakan get dan set untuk melindungi data.
        // (Misal: TotalBiaya hanya bisa di-set dari dalam class ini atau turunannya)


        // protected set memastikan nilai TotalBiaya tidak bisa diubah sembarangan dari luar kelas, melainkan hanya bisa diubah dari dalam kelas turunannya.
        public decimal TotalBiaya { get; protected set; }

        // Method abstrak wajib dibuat ulang oleh class turunannya
        public abstract void HitungBiaya();
    }
}

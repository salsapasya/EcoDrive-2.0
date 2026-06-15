using EcoDrive_vol2.Models.Transaksi;
using System.Collections.Generic;

namespace EcoDrive_vol2.Context.Admin
{
    // Minimal placeholder context for admin sewa transactions.
    public class AdTransaksiSewaContext
    {
        public AdTransaksiSewaContext() { }

        public List<TransaksiSewa> GetSewaByUser(int idUser)
        {
            return new List<TransaksiSewa>();
        }

        public void InsertTransaksi(TransaksiSewa transaksi)
        {
            // Implement DB insert logic
        }

        public void UpdateStatusPengembalian(int rawId)
        {
            // Implement DB update logic
        }
    }
}

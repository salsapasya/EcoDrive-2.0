using EcoDrive_vol2.Models.Transaksi;
using System.Collections.Generic;

namespace EcoDrive_vol2.Context.Customer
{
    // Minimal placeholder context to satisfy compiler and provide a place
    // to implement real DB logic for 'sewa' transactions.
    public class TransaksiSewaContext
    {
        public TransaksiSewaContext() { }

        // Placeholder methods — replace with actual DB access implementations.
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

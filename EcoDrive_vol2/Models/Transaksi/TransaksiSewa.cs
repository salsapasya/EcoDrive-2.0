using System;
using EcoDrive_vol2.AbstractandInterface.Abstract;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Transaksi
{
    // INHERITANCE
    // TransaksiSewa mewarisi dari AbsTransaksi
    // Kelas TransaksiSewa mewarisi semua properti (IdUser, TanggalTransaksi, TotalBiaya) dari kelas induk AbsTransaksi tanpa perlu menulis ulang kodenya dari awal.
    public class TransaksiSewa : AbsTransaksi
    {
        public int IdTransaksiSewa { get; set; }

        public int IdUser { get; set; }

        public int IdKendaraan { get; set; }

        public DateTime TanggalSewa { get; set; }

        public DateTime TanggalKembali { get; set; }

        public int DurasiSewa { get; set; }

        public decimal HargaPerHari { get; set; }

        public StatusKembali StatusPengembalian { get; set; }

        // tambahan buat di pengembalian kendaraan
        public string NamaKendaraan { get; set; }
        public string NomorPlatKendaraan { get; set; }

        // Dibuat khusus agar database reader (Mapping/Context) bisa melakukan 
        // mapping objek 'new TransaksiSewa { ... }' tanpa terikat 4 parameter wajib.
        public TransaksiSewa()
        {
            // Biarkan kosong melompong seperti ini!
        }
        // OOP (Constructor): Menerima parameter mentah dari View untuk mengisi properti
        public TransaksiSewa(int idUser, int idKendaraan, int durasiSewa, decimal hargaPerHari)
        {
            IdUser = idUser;
            IdKendaraan = idKendaraan;
            DurasiSewa = durasiSewa;
            HargaPerHari = hargaPerHari;
            TanggalSewa = DateTime.Now;
            TanggalKembali = DateTime.Now.AddDays(durasiSewa);
        }
        
        // OOP (POLIMORFISME) = menggunakan override untuk memodifikasi dari kelas abstrak
        public override void HitungBiaya()
        {
            DurasiSewa = (TanggalKembali - TanggalSewa).Days;
            if (DurasiSewa < 1)
                DurasiSewa = 1; // Minimal 1 hari sewa
            TotalBiaya = DurasiSewa * HargaPerHari;
        }
        // ENCAPSULATION LOGIC: Fungsi pembantu mandiri khusus transaksi sewa
        public bool CekBelumKembali()
        {
            return StatusPengembalian.ToString().ToLower().Replace("_", " ") == "belum kembali";
        }

        public string FormatStatus()
        {
            return StatusPengembalian.ToString().ToLower().Replace("_", " ").ToUpper();
        }
    }
}

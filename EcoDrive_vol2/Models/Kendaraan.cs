// Models/Kendaraan.cs
namespace EcoDrive_vol2.Models
{
    public class Kendaraan
    {
        public int IdKendaraan { get; set; }
        public int IdTipeKendaraan { get; set; }
        public int IdMerkKendaraan { get; set; }
        public string NamaKendaraan { get; set; }
        public int StokKendaraan { get; set; }
        public int HargaSewa { get; set; } // Diubah ke int sesuai isi DB (INTEGER)
        public string StatusKendaraan { get; set; }

        // Properti kompatibilitas agar tidak merusak binding lama
        public string Nama
        {
            get => NamaKendaraan;
            set => NamaKendaraan = value;
        }

        public string Status
        {
            get => StatusKendaraan;
            set => StatusKendaraan = value;
        }

        // Properti visual UI (karena tidak ada di tabel kendaraan, kita beri default nilai penampung)
        public string Tipe { get; set; }
        public string Lokasi { get; set; } = "Main Station"; // Default lokasi umum
        public int Baterai { get; set; } = 100;              // Default baterai penuh jika kolom belum ada
    }
}
// Models/Kendaraan.cs
namespace EcoDrive_vol2.Models.Kendaraan
{
    public class Kendaraan
    {
        // Encapsulation
        private int batteryPercentage;

        // Property
        public int IdKendaraan { get; set; }
        public int IdTipeKendaraan { get; set; }
        public int IdMerkKendaraan { get; set; }
        public string NamaKendaraan { get; set; }
        public int StokKendaraan { get; set; }
        public int HargaSewa { get; set; } 
        public string StatusKendaraan { get; set; }

        // Property dengan validasi
        public int BatteryPercentage
        {
            get
            { return batteryPercentage; }
            set
            {
                if (value >= 0 && value <= 100)
                    batteryPercentage = value;
            }
        }

        // Constructor
        public Kendaraan()
        {

        }

        // Default implementation of BiayaRental (concrete instead of abstract)
        public virtual decimal BiayaRental(int jam)
        {
            // Basic calculation: price per unit (HargaSewa) times duration
            return (decimal)(HargaSewa * jam);
        }

        // Encapsulation Method
        public void Charge(int duration)
        {
            BatteryPercentage += duration * 20;

            if (BatteryPercentage > 100)
                BatteryPercentage = 100;
        }

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
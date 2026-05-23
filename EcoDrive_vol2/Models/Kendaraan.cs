namespace EcoDrive_vol2.Models
{
    public class Kendaraan
    {
        public int IdKendaraan { get; set; }

        public int IdTipeKendaraan { get; set; }

        public int IdMerkKendaraan { get; set; }

        public string NamaKendaraan { get; set; }

        public int StokKendaraan { get; set; }

        public decimal HargaSewa { get; set; }

        public string StatusKendaraan { get; set; }
    }
}
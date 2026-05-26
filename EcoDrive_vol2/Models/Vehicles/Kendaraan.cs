using System;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Vehicles
{
    public class Kendaraan
    {
        public int IdKendaraan { get; set; }

        public int IdMerkKendaraan { get; set; }

        public string NomorPlatKendaraan { get; set; }

        public string NamaKendaraan { get; set; }

        public int StokKendaraan { get; set; }

        public decimal HargaSewa { get; set; }

        public KendaraanTipe TipeKendaraan { get; set; }

        public OptionStatus StatusKendaraan { get; set; }


        // Constructor
        public Kendaraan()
        {

        }


        // Method sederhana milik object kendaraan
        public virtual decimal BiayaRental(int jam)
        {
            return HargaSewa * jam;
        }


        // Property tambahan untuk binding UI
        public string Nama
        {
            get => NamaKendaraan;
            set => NamaKendaraan = value;
        }


        public string Status
        {
            get => StatusKendaraan.ToString();
            set
            {
                StatusKendaraan = Enum.Parse<OptionStatus>(value);
            }
        }


        public string Tipe
        {
            get => TipeKendaraan.ToString();
            set => TipeKendaraan = Enum.Parse<KendaraanTipe>(value);
        }
    }
}
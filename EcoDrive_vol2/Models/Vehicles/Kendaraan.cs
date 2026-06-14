using System;
using EcoDrive_vol2.Models.Enums;

namespace EcoDrive_vol2.Models.Vehicles
{
    public class Kendaraan
    {
        public int IdKendaraan { get; set; }

        public int IdMerkKendaraan { get; set; }

        private string _nomorPlatKendaraan;

        public string NamaKendaraan { get; set; }

        private int _stokKendaraan;

        private decimal _hargaSewa;

        public KendaraanTipe TipeKendaraan { get; set; }

        public OptionStatus StatusKendaraan { get; set; }

        public bool IsDeleted { get; set; }

        public string NomorPlatKendaraan
        {
            get => _nomorPlatKendaraan;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Nomor plat kendaraan tidak boleh kosong.");

                value = value.Trim().ToUpper();

                if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[A-Z]{1,2}\s\d{1,4}\s[A-Z]{1,3}$"))
                    throw new ArgumentException("Nomor plat kendaraan hanya boleh mengandung huruf, angka, dan spasi.");

                if (value.Length < 5 || value.Length > 10)
                    throw new ArgumentException("Nomor plat kendaraan harus antara 5 hingga 10 karakter.");

                _nomorPlatKendaraan = value;
            }
        }

        public int StokKendaraan
        {
            get => _stokKendaraan;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Stok kendaraan tidak boleh negatif.");
                _stokKendaraan = value;
            }
        }

        public decimal HargaSewa
        {
            get => _hargaSewa;
            set
            {
                if (value < 100000)
                    throw new ArgumentException(
                        "Harga sewa minimal Rp100.000.");

                if (value > 5000000)
                    throw new ArgumentException(
                        "Harga sewa melebihi batas yang diizinkan.");

                _hargaSewa = value;
            }
        }

        // Constructor
        public Kendaraan()
        {
        }

        public string Nama  //ENCAP
        {
            get => NamaKendaraan;
            set => NamaKendaraan = value;
        }


        public string Status  //ENCAP 
        {
            get => StatusKendaraan.ToString();
            set
            {
                StatusKendaraan = Enum.Parse<OptionStatus>(value);
            }
        }


        public string Tipe  //ENCAP
        {
            get => TipeKendaraan.ToString();
            set => TipeKendaraan = Enum.Parse<KendaraanTipe>(value);
        }
    }
}
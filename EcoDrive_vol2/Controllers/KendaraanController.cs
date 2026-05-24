using Npgsql;
using EcoDrive_vol2.Models;
using EcoDrive_vol2.Helpers;

namespace EcoDrive_vol2.Controllers
{
    public class KendaraanController
    {
        NpgsqlConnection conn = DatabaseHelper.GetConnection();

        public List<Kendaraan> GetKendaraan()
        {
            List<Kendaraan> kendaraanList = new List<Kendaraan>();
            try
            {
                conn.Open();

                string query = "SELECT * FROM kendaraan";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    string jenis = rd["JenisKendaraan"].ToString();
                    Kendaraan kendaraan;

                    // Inheritance untuk menentukan jenis kendaraan
                    if (jenis == "Mobil")
                    {
                        kendaraan = new ElectricCar();
                    }
                    else
                    {
                        kendaraan = new ElectricMotor();
                    }

                    kendaraan.IdKendaraan = Convert.ToInt32(rd["IdKendaraan"]);
                    kendaraan.NamaKendaraan = rd["NamaKendaraan"].ToString();
                    kendaraan.IdTipeKendaraan = Convert.ToInt32(rd["IdTipeKendaraan"]);
                    kendaraan.IdMerkKendaraan = Convert.ToInt32(rd["IdMerkKendaraan"]);
                    kendaraan.StokKendaraan = Convert.ToInt32(rd["StokKendaraan"]);
                    kendaraan.HargaSewa = Convert.ToInt32(rd["HargaSewa"]);
                    kendaraan.StatusKendaraan = rd["StatusKendaraan"].ToString();
                    kendaraan.BatteryPercentage = Convert.ToInt32(rd["BatteryPercentage"]);

                    kendaraanList.Add(kendaraan);
                }

            }
            finally
            {
                conn.Close();
            }
            return kendaraanList;
        }
    }
}

using System;
using EcoDrive_vol2.Context.Customer;
using EcoDrive_vol2.AbstractandInterface.Interface;

namespace EcoDrive_vol2.Services.Customer
{
    public class DashboardService : IDashboardService
    {
        private readonly DashboardContext _context;
        public DashboardService()
        {
            _context = new DashboardContext();
        }

        public decimal AmbilSaldoTerbaru(int idUser)
        {
            return _context.GetSaldoUser(idUser);
        }

        public int HitungTotalSewa(int idUser)
        {
            return _context.GetTotalRiwayatSewa(idUser);
        }

        public RentalAktifData GetInformasiRental(int idUser)
        {
            var dto = _context.GetRentalAktif(idUser);
            var data = new RentalAktifData { IsActive = dto.IsActive };

            if (dto.IsActive)
            {
                data.KendaraanInfo = $"{dto.NamaKendaraan}\n({dto.NomorPlat})";

                int sisaHari = (dto.TanggalKembali.Date - DateTime.Now.Date).Days;
                data.SisaHari = sisaHari;
                data.TeksSisaWaktu = sisaHari >= 0 ? $"Sisa Waktu: {sisaHari} Hari Lagi" : "Sisa Waktu: Terlambat / Jatuh Tempo";
            }

            return data;
        }
    }

    public class RentalAktifData
    {
        public bool IsActive { get; set; }
        public string KendaraanInfo { get; set; }
        public int SisaHari { get; set; }
        public string TeksSisaWaktu { get; set; }
    }
}
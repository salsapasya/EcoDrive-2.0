using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.Models.Admin
{
    public class AdminGrid
    {
        public int RawId { get; set; }
        public string Kategori { get; set; }
        public string ID_Transaksi { get; set; }
        public string Username { get; set; }
        public string Nama { get; set; }
        public string Kontak { get; set; }
        public string Waktu { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }

        // Constructor Kosong
        public AdminGrid() { }

        // Constructor Berparameter agar pembuatan objek model OOP-nya nyata dan tidak cuma pajangan
        public AdminGrid(int rawId, string kategori, string idTransaksi, string username, string nama, string kontak, string waktu, string detail, string status)
        {
            RawId = rawId;
            Kategori = kategori;
            ID_Transaksi = idTransaksi;
            Username = username;
            Nama = nama;
            Kontak = kontak;
            Waktu = waktu;
            Detail = detail;
            Status = status;
        }
    }
}

using EcoDrive_vol2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EcoDrive_vol2.Models.Admin
{
    public class TopUp
    {
        // OOP ENCAPSULATION
        public int IdTopupSaldo { get; set; }
        public string Username { get; set; }
        public string NamaUser { get; set; }
        public string NoTelpUser { get; set; }
        public decimal JumlahTopup { get; set; }
        public TopupStatus Status { get; set; }
        public bool MintaBatal { get; set; }

        // OOP (POLYMORPHISM) = ada 2 cosntruktor untuk fleksibilitas pembuatan objek
        // constructor kosong
        public TopUp()
        {

        }
        public TopUp(int idTopupSaldo, string username, string namaUser, string noTelpUser, decimal jumlahTopup, TopupStatus status, bool mintaBatal)
        {
            // ID Transaksi dari view_admin_topup harus valid
            if (idTopupSaldo <= 0)
            {
                throw new ArgumentException("Gagal memuat model: ID Transaksi tidak valid.");
            }

            // Data text customer tidak boleh kosong
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(namaUser))
            {
                throw new ArgumentException("Gagal memuat model: Data identitas Customer tidak ada.");
            }

            // Nominal transaksi tidak boleh minus
            if (jumlahTopup < 0)
            {
                throw new ArgumentException("Gagal memuat model: Jumlah top up tidak boleh negatif.");
            }

            // Jika semua lolos, data baru dimasukkan ke properti form
            this.IdTopupSaldo = idTopupSaldo;
            this.Username = username;
            this.NamaUser = namaUser;
            this.NoTelpUser = noTelpUser;
            this.JumlahTopup = jumlahTopup;
            this.Status = status;
            this.MintaBatal = mintaBatal;
        }
    }
}

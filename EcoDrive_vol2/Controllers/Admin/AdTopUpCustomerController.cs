using System;
using System.Collections.Generic;
using System.Text;
using EcoDrive_vol2.Service;
using EcoDrive_vol2.Models.Admin;


namespace EcoDrive_vol2.Controllers.Admin
{
    public class AdTopUpCustomerController
    {
        private readonly AdTopUpCustomerService _adminService = new AdTopUpCustomerService();

        public List<TopUp> GetDaftarTransaksiTopUp(string statusFilter = "")
        {
            try
            {
                return _adminService.AmbilDaftarTopUpAdmin(statusFilter);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller AdTopUpCustomer Error: " + ex.Message);
            }
        }

        public void KonfirmasiPembatalanTopUp(int idTopupSaldo, int idUser)
        {
            try
            {
                _adminService.ProsesKonfirmasiPembatalan(idTopupSaldo, idUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller AdTopUpCustomer Error: " + ex.Message);
            }
        }
        public int GetIdUserByUsername(string username)
        {
            return _adminService.GetIdUserByUsername(username);
        }
        // Menjembatani request View untuk meminta validasi state tombol visual
        public (bool IsEnabled, string ButtonText) DapatkanStateTombolAksi(string status, bool isMintaBatal)
        {
            return _adminService.ValidasiStateTombolAksi(status, isMintaBatal);
        }
    }
}

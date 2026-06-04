using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    public interface IRental
    {
        decimal DapatkanEstimasiBiaya(int idKendaraan, int durasi);
        void ProsesSewaKendaraan(int idUser, int idKendaraan, int durasi, decimal totalBiaya);
    }
}
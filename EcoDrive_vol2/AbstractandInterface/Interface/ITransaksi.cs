using EcoDrive_vol2.Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    public interface ITransaksi
    {
        List<TransaksiModel> GetAllTransaksi();
    }
}

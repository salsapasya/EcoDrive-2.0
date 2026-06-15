using System;
using System.Collections.Generic;
using System.Text;
using EcoDrive_vol2.Models.Admin;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    public interface ICusTopup
    {
        List<TopUp> GetAllTopup();
    }
}

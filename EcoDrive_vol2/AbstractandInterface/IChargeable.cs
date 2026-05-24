using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.AbstractandInterface
{
    public interface IChargeable
    {
        void Plugin();

        void Unplug();
    }
}

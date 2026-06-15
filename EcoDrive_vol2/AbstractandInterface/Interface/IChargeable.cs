using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.AbstractandInterface.Interface
{
    // OOP (Interface): Kontrak yang mendefinisikan kemampuan pengisian daya kendaraan.
    public interface IChargeable
    {
        void Plugin();

        void Unplug();
    }
}

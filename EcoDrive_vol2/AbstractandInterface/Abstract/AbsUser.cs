using System;
using System.Collections.Generic;
using System.Text;

namespace EcoDrive_vol2.AbstractandInterface.Abstract
{
    public abstract class AbsUser
    {
        public int IdUser { get; set; }
        public string NamaUser { get; set; }

        public abstract string GetRole();
    }
}

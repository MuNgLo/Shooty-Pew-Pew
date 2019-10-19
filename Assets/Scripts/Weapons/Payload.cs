using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weapons
{
    [System.Serializable]
    public class Payload
    {
        public WEAPONTYPE _weaponType = WEAPONTYPE.UNSET;
        public DAMAGETYPE _damageType = DAMAGETYPE.ENERGY;
        public int _damageValue = 1;
    }
}

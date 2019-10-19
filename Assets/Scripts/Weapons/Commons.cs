using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Weapons
{
    public enum WEAPONTYPE { UNSET, LASER, PLASMA }
    public enum DAMAGETYPE { ENERGY, EXPLOSIVE }

    public abstract class PlayerWeapons : MonoBehaviour
    {
        [Range(1, 1000)]
        public int _fireRate = 100;
        public float _lastShot = -1000.0f;
        [Range(1, 1000)]
        public int _bulletSpeed = 100;

        public LayerMask _hittable;
        public float _range = 10.0f;
        public float _lifetime = 0.2f;
        public Payload _payload;
        abstract internal void Fire();
    }
}

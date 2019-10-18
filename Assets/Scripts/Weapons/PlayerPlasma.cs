using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Weapons
{
    class PlayerPlasma : PlayerWeapons
    {
        public GameObject _bulletPrefab = null;

        internal override void Fire()
        {
            GameObject bullet = (GameObject)Instantiate(_bulletPrefab);
            bullet.transform.position = this.transform.position;
            bullet.GetComponent<Bullet>()._payload  = _payload;
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * _bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
            _lastShot = Time.time;
        }
    }
}

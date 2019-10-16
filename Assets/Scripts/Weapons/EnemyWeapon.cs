using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Weapons {
    public class EnemyWeapon : MonoBehaviour
    {
        public GameObject _bulletPrefab;
        [Range(1, 1000)]
        public int _fireRate = 100;
        private float _lastShot = 0.0f;
        public int _damage = 10;
        public DAMAGETYPE _type = DAMAGETYPE.ENERGY;
        [Range(1, 1000)]
        public int _bulletSpeed = 100;

        void Awake()
        {
            _lastShot = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            if (_lastShot + 60.0f / _fireRate < Time.time && Input.GetButton("Fire1"))
            {
                Debug.Log("Enemy goes PEWPEW!!!");
                GameObject bullet = (GameObject)Instantiate(_bulletPrefab);
                bullet.transform.position = this.transform.position;
                bullet.GetComponent<Bullet>()._payload._damageType = _type;
                bullet.GetComponent<Bullet>()._payload._damageValue = _damage;
                Vector2 aim = Core.player.position - this.transform.position;
                bullet.GetComponent<Rigidbody2D>().AddForce(aim.normalized * _bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
                _lastShot = Time.time;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Weapons {
    public class PlayerWeapon : MonoBehaviour
    {
        public GameObject _bulletPrefab;
        [Range(1, 1000)]
        public int _fireRate = 100;
        private float _lastShot = 0.0f;
        public int _damage = 10;
        public DAMAGETYPE _type = DAMAGETYPE.ENERGY;
        [Range(1, 1000)]
        public int _bulletSpeed = 100;

        // Start is called before the first frame update
        void Start()
        {
            _lastShot = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            if(Core.gLogic._state != GAMESTATE.PLAYING) { return; }
            if (_lastShot + 60.0f / _fireRate < Time.time && Input.GetButton("Fire1"))
            {
                GameObject bullet = (GameObject)Instantiate(_bulletPrefab);
                bullet.transform.position = this.transform.position;
                bullet.GetComponent<Bullet>()._payload._damageType = _type;
                bullet.GetComponent<Bullet>()._payload._damageValue = _damage;
                bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * _bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
                _lastShot = Time.time;
            }
        }
    }
}
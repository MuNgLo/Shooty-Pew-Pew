using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Weapons {
    public class PlayerWeapon : MonoBehaviour
    {
        public bool _canShot = false;
        public int _weaponIndex = 0;
        public List<PlayerWeapons> _weapons = new List<PlayerWeapons>();

        public PlayerWeapons CurrentWeapon { get { return _weapons[_weaponIndex]; } set { } }

        // Update is called once per frame
        void Update()
        {
            if(Core.gLogic._state != GAMESTATE.PLAYING || !_canShot) { return; }
            if (CurrentWeapon._lastShot + 60.0f / CurrentWeapon._fireRate < Time.time && Input.GetButton("Fire1"))
            {
                CurrentWeapon.Fire();
                GameEvents.RaiseOnFire();
            }
        }
    }
}
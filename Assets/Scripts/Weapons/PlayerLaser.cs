using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(LineRenderer))]
    class PlayerLaser : PlayerWeapons
    {
        private LineRenderer _line;

        private void Awake()
        {
            _line = GetComponent<LineRenderer>();
            _line.enabled = false;
        }

        internal override void Fire()
        {
            
            StartCoroutine("ShowLaser");
            _lastShot = Time.time;
        }

        IEnumerator ShowLaser()
        {
            float startTime = Time.time;
            _line.enabled = true;
            float laserLength = _range;
            int prevCollID = -1;
            while (startTime + _lifetime > Time.time)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, laserLength, _hittable, 0.0f, 100.0f);
                if (hit.collider != null)
                {
                    if (hit.collider.GetComponent<CanTakeDamage>())
                    {
                        hit.collider.GetComponent<CanTakeDamage>().TakeDamage(_payload);
                    }
                    laserLength = hit.distance;
                    if (prevCollID != hit.collider.GetInstanceID())
                    {
                        Debug.Log("PlayerLaser hit something!");

                        GameEvents.RaiseOnHit(
                            new WeaponHitEventArguments()
                            { WeaponType = _payload._weaponType, Location = hit.point });
                        prevCollID = hit.collider.GetInstanceID();
                    }
                }
                _line.SetPosition(1, Vector3.right * laserLength);
                yield return new WaitForEndOfFrame();
            }
            _line.enabled = false;
            yield return null;
        }
    }
}

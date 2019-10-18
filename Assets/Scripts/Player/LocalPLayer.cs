using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public class LocalPLayer : MonoBehaviour
    {
        public PlayerHealth _health;
        public PlayerMover _mover;
        public Weapons.PlayerWeapon _weapon;
        public SpriteRenderer _sprite;
        public PolygonCollider2D _hitbox;

        private void Awake()
        {
            Core.localPlayer = this;
        }

        internal void SelectWeapon(string v)
        {
            switch (v)
            {
                case "Laser":
                    _weapon._weaponIndex = 1;
                    break;
                case "Plasma":
                default:
                    _weapon._weaponIndex = 0;
                    break;
            }
        }

        private void Start()
        {
            _health.gameObject.SetActive(false);
        }
    }
}
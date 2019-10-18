using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public int _value = 100;
        public int Value { get { return _value; } private set { } }

        private void Start()
        {
            GameEvents.OnStartRun.AddListener(OnStartRun);
        }

        private void OnStartRun()
        {
            _value = 100;
        }

        public void TakeDamage(Weapons.Payload payload)
        {
            if (payload._damageValue < 1) { return; }
            _value -= payload._damageValue;
            if (_value < 1)
            {
                Die();
            }
        }
        public void TakenumericDamage(int value)
        {
            if (value < 1) { return; }
            _value -= value;
            if (_value < 1)
            {
                Die();
            }
        }

        private void Die()
        {
            GameEvents.RaiseOnPlayerDeath();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.GetComponent<HurtsToTouch>())
            {
                TakenumericDamage(collision.collider.GetComponent<HurtsToTouch>()._damageOnTouch);
            }
            if (collision.collider.GetComponent<Pickup>())
            {
                collision.collider.GetComponent<Pickup>().Apply();
            }
        }
    }
}

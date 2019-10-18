using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Enemies
{

        public class EnemyHealth : CanTakeDamage
        {

            private int _value = 100;
            public int Value { get { return _value; } private set { } }

        public void ResetToSpawnValues()
        {
            _value = 100;
        }

        internal override void TakeDamage(Weapons.Payload payload)
            {
                if (payload._damageValue < 1) { return; }
                _value -= payload._damageValue;
                if (_value < 1)
                {
                    Die();
                }
            }

        private void Die()
        {
            GameEvents.RaiseOnEnemyDeath(new DeathEventArguments() { Location = this.transform.position });
                GameObject.Destroy(this.gameObject);
            }
        }
    }

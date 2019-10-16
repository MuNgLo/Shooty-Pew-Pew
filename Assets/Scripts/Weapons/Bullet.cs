using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class Bullet : MonoBehaviour
    {
        public Payload _payload;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.GetComponent<Player.PlayerHealth>())
            {
                collision.collider.GetComponent<Player.PlayerHealth>().TakeDamage(_payload);
                Die();
            }
            if (collision.collider.GetComponent<Enemies.EnemyHealth>())
            {
                collision.collider.GetComponent<Enemies.EnemyHealth>().TakeDamage(_payload);
                Die();
            }
        }

        private void Die()
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
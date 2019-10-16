using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMover : MonoBehaviour
    {
        public float _engineThrust = 1000.0f;
        public List<Transform> _plotCourse = new List<Transform>();
        public int _plotIndex = 0;
        public bool _loop = false;

        public string _route = string.Empty;

        private Rigidbody2D _rb;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.freezeRotation = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (_plotIndex >= _plotCourse.Count)
            {
                if (_loop) { _plotIndex = 0; } else { Die(); return; }
            }
            _rb.AddForce((_plotCourse[_plotIndex].position - transform.position).normalized * _engineThrust * Time.deltaTime);
            if(Vector3.Distance(_plotCourse[_plotIndex].position, transform.position) < 0.3f)
            {
                _plotIndex++;
            }
        }

        public void ResetOnSpawn()
        {
            _loop = false;
            _plotIndex = 0;
        }

        private void Die()
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
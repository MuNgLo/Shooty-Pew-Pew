using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour
    {
        public float _engineThrust = 1000.0f;

        private Vector2 _inputVector = Vector2.zero;
        private Rigidbody2D _rb;

        private void Awake()
        {
            Core.player = this.transform;
        }

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.freezeRotation = true;
        }

        // Update is called once per frame
        void Update()
        {
            _inputVector.x = Input.GetAxis("Horizontal");
            _inputVector.y = Input.GetAxis("Vertical");
            if (_inputVector != Vector2.zero)
            {
                Vector2 forceVector = _inputVector * _engineThrust;
                _rb.AddForce(ClampOnScreen(forceVector) * Time.deltaTime);
            }
        }

        Vector2 ClampOnScreen(Vector3 forceVector)
        {
            float border = Screen.height * 0.05f;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //Block up
            if (screenPos.y > Screen.height - border)
            {
                if (_rb.velocity.y > 0.0f)
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, 0.0f);

                }
                if (forceVector.y > 0.0f)
                {
                    forceVector.y = 0.0f;
                }
            }
            //Block down
            if (screenPos.y < border)
            {
                if (_rb.velocity.y < 0.0f)
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, 0.0f);
                }
                if (forceVector.y < 0.0f)
                {
                    forceVector.y = 0.0f;
                }
            }
            //Block left
            if (screenPos.x < border)
            {
                if (_rb.velocity.x < 0.0f)
                {
                    _rb.velocity = new Vector2(0.0f, _rb.velocity.y);
                }
                if (forceVector.x < 0.0f)
                {
                    forceVector.x = 0.0f;
                }
            }
            //Block right
            if (screenPos.x > Screen.width - border)
            {
                if (_rb.velocity.x > 0.0f)
                {
                    _rb.velocity = new Vector2(0.0f, _rb.velocity.y);
                }
                if (forceVector.x > 0.0f)
                {
                    forceVector.x = 0.0f;
                }
            }

            return forceVector;
        }
    }
}
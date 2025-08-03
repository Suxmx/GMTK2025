using System;
using UnityEngine;

namespace GMTK
{
    public class PlayerCollideHandler : MonoBehaviour
    {
        private PlayerController2D _controller;
        private void Awake()
        {
            _controller = GetComponent<PlayerController2D>();
        }

        private void PlayerCollisionEnter(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<DamageSlot>(out var slot))
            {
                _controller.RequestDie();
            }
        }

        private void PlayerTriggerEnter(Collider2D other)
        {
			Debug.Log($"Player collided with: {other.gameObject.name}");
            if (other.TryGetComponent<DamageSlot>(out var slot))
            {
                _controller.RequestDie();
            }
        }
    }
}
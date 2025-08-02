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
            
        }

        private void PlayerTriggerEnter(Collider2D other)
        {
            if (other.CompareTag("Die"))
            {
                _controller.RequestDie();
            }
        }
    }
}
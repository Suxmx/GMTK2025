using System;
using UnityEngine;

namespace GMTK
{
    public class DestroyableSlot : MonoBehaviour
    {
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet"))
            {
                if (_animator)
                {
                    _animator.Play("Destroy");
                }
                else
                {
                    OnAnimEnd();
                }
                Destroy(other.gameObject);
            }
        }

        public void OnAnimEnd()
        {
            gameObject.SetActive(false);
        }
    }
}
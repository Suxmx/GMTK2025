using System;
using MemoFramework.Extension;
using MemoFramework.ObjectPool;
using Unity.VisualScripting;
using UnityEngine;

namespace GMTK
{
    
    public class SpecialBullet : MonoBehaviour
    {
        private float createTime;
        [SerializeField] private float Duration;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            Debug.Log("Create a bullet");
            createTime = Time.time;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetSprite(Sprite sprite)
        {
            if (spriteRenderer == null)
            {
                Debug.LogError("SpriteRenderer is null.");
            }
            spriteRenderer.sprite = sprite;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.GetComponent<Rigidbody2D>().velocity = velocity;
        }

        private void Update()
        {
            if (Time.time >= createTime + Duration)
            {
                Debug.Log("Destroy bullet because times out");
                Destroy(gameObject);
            }
        }
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                return;
            }
            Debug.Log("Destroy bullet because it touch something");
            Destroy(gameObject);
        }
    }
}
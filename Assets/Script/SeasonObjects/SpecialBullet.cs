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

        private void Start()
        {
            Debug.Log("Create a bullet");
            createTime = Time.time;
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
    }
}
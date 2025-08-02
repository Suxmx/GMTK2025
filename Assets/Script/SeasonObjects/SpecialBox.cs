using System;
using UnityEngine;

namespace GMTK
{
    public class SpecialBox : MonoBehaviour
    {
        private float buildTime;
        [SerializeField]private float KillTime;

        private void Start()
        {
            buildTime = Time.time;
        }

        public void SetSprite(Sprite sprite)
        {
            this.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        private void Update()
        {
            if (Time.time - buildTime > KillTime)
            {
                SpecialManager.instance.RemoveSpecialBox(this);
            }
        }
    }
}
using System;
using UnityEngine;

namespace GMTK
{
    public class PlayerAnimaTrigger : MonoBehaviour
    {
        private PlatformerMotor2D _motor;

        private void Awake()
        {
            _motor = GetComponentInParent<PlatformerMotor2D>();
        }

        public void AnimaTrigger()
        {
            SpecialManager.instance.BuildBullet(_motor.transform.position + new Vector3(0.75f*(_motor.facingRight?1:-1),0,0), (_motor.facingRight?Vector2.right:Vector2.left));
        }
    }
}
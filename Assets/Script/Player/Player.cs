using System;
using System.Collections;
using System.Collections.Generic;
using MemoFramework;
using UnityEngine;

namespace GMTK
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        #region StateMachine & States

        public PlayerStateMachine stateMachine;
        public IdleState idleState { get; private set; }
        public MoveState moveState { get; private set; }

        #endregion
        
        #region Components
        public Animator animator { get; private set; }
        public Rigidbody2D rb { get; private set; }
        #endregion

        [Header("Movement")]
        public float moveSpeed;
        public float jumpForce;
        public bool isFacingRight = true;
        
        [Header("Collision Detection Variables")]
        [SerializeField, Tooltip("落地射线检测的长度")] private float groundCheckDistance;
        [SerializeField] private float wallCheckDistance;
        [SerializeField] private LayerMask groundLayer;
        public bool GroundDetected { get; private set; }
        public bool WallDetected { get; private set; }
        

        public void Awake()
        {
            #region GetComponent
            animator = GetComponentInChildren<Animator>();
            #endregion
            
            stateMachine = new PlayerStateMachine();
            idleState = new IdleState(this, stateMachine, "Idle");
            moveState = new MoveState(this, stateMachine, "Move");
        }

        private void Start()
        {
            
        }

        private void FlipHandler(float xVelocity)
        {
            if ((xVelocity > 0 && !isFacingRight) || (xVelocity < 0 && isFacingRight))
            {
                transform.Rotate(0f, 180f, 0f);
                isFacingRight = !isFacingRight;
            }
        }

        public void Update()
        {
            stateMachine.UpdateActiveState();
        }

        public void SetVelocity(Vector2 velocity)
        {
            rb.velocity = velocity;
            FlipHandler(velocity.x);
        }

        public void SetVelocity(float x, float y)
        {
            SetVelocity(new Vector2(x, y));
        }
        
        /// <summary>
        /// 地面和墙面碰撞检测
        /// </summary>
        private void HandleCollisionDetection()
        {
            GroundDetected = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
            WallDetected = Physics2D.Raycast(transform.position, Vector2.right * (isFacingRight?1:-1), wallCheckDistance, groundLayer);
        }

    }
}
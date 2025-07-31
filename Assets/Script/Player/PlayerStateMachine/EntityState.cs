using UnityEngine;

namespace GMTK
{
    public class EntityState
    {
        public Player player;
        protected PlayerStateMachine stateMachine;
        protected string StateName;

        protected Animator Anim;
        protected Rigidbody2D Rb;

        public EntityState(Player player, PlayerStateMachine stateMachine, string stateName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.StateName = stateName;

            this.Anim = player.animator;
            this.Rb = player.rb;
        }

        public virtual void Enter()
        {
            Debug.Log("Player Enter State: "+ this.StateName);
            Anim.SetBool(this.StateName, true);
        }
        public virtual void Update()
        {
            
        }

        public virtual void Exit()
        {
            Anim.SetBool(this.StateName, false);
            Debug.Log("Player Exit State: "+ this.StateName);
        }
    }
}
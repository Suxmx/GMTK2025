using UnityEngine;

namespace GMTK
{
    public class IdleState : EntityState
    {
        public IdleState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocity(0,Rb.velocity.y);
        }

        public override void Update()
        {
            base.Update();
            if (Input.GetAxis("Horizontal") != 0)
            {
                stateMachine.ChangeState(player.moveState);
            }
        }
    }
}
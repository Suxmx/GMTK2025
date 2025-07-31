namespace GMTK
{
    public class MoveState : EntityState
    {
        public MoveState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
        {
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
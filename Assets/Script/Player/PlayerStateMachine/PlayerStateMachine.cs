namespace GMTK
{
    public class PlayerStateMachine
    {
        public EntityState CurrentState { get; set; }
        
        /// <summary>
        /// 初始化状态机
        /// </summary>
        /// <param name="startState">初始状态</param>
        public void Initialize(EntityState startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }

        public void ChangeState(EntityState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void UpdateActiveState()
        {
            CurrentState.Update();
        }
    }
}
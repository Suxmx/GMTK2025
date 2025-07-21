using MemoFramework;
using MemoFramework.Extension;
using MemoFramework.GameState;
using UnityEngine;

namespace M2.GameState
{
    public class MainGameState : GameStateBase
    {
        protected override void OnStateEnter()
        {
            base.OnStateEnter();
            Transform root = new GameObject("Managers").transform;
            
        }
        

        protected override void OnStateExit()
        {
            base.OnStateExit();
           
        }
    }
}
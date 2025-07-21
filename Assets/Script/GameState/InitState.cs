using System;
using MemoFramework;
using MemoFramework.GameState;
using UnityEngine;

namespace M2.GameState
{
    public class InitState : GameStateBase
    {
        protected override void OnStateEnter()
        {
            base.OnStateEnter();
        }
        
        private void OnLoadEnd()
        {
            GameStateComponent.RequestStateChange(EGameState.Splash.ToString());
        }
        
    }
}
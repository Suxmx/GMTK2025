using System;
using MemoFramework;
using MemoFramework.GameState;
using UnityEngine;

namespace GMTK
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
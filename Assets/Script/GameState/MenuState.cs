using System;
using System.Collections.Generic;
using MemoFramework;
using MemoFramework.Extension;
using MemoFramework.GameState;
using Unity.VisualScripting;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace M2.GameState
{
    public class MenuState : GameStateBase
    {
        public MenuState(Action<State<string, string>> onEnter = null, Action<State<string, string>> onLogic = null,
            Action<State<string, string>> onExit = null, Func<State<string, string>, bool> canExit = null,
            bool needsExitTime = false, bool isGhostState = false) : base(onEnter, onLogic, onExit, canExit,
            needsExitTime, isGhostState)
        {
        }

        protected override void OnStateEnter()
        {
            base.OnStateEnter();
        }

        protected override void OnStateExit()
        {
            base.OnStateExit();
        }
        
    }
}
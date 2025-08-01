using System;
using System.Collections.Generic;
using GMTK.EventArgs;
using MemoFramework;
using MemoFramework.Extension;
using MemoFramework.GameState;
using Unity.VisualScripting;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.SceneManagement;

namespace GMTK
{
    public class MenuState : GameStateBase
    {
        protected override void OnStateEnter()
        {
            base.OnStateEnter();
            SceneManager.LoadScene(SceneConstants.Menu);
            if (MF.Cutscene.IsPlaying)
            {
                MF.Cutscene.FadeCutScene(GlobalConstants.CutSceneFadeDuration);
            }
            MF.Event.Subscribe<OnRequireEnterGame>(RequireEnterGame);
        }

        protected override void OnStateExit()
        {
            base.OnStateExit();
            MF.Event.Unsubscribe<OnRequireEnterGame>(RequireEnterGame);
        }

        private void RequireEnterGame(object sender, OnRequireEnterGame e)
        {
            MF.Cutscene.EnterCutScene(GlobalConstants.CutSceneEnterDuration, () =>
            {
                GameStateComponent.RequestStateChange(EGameState.Game.ToString());
            });
            
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using GMTK;
using GMTK.EventArgs;
using GMTK.UI;
using MemoFramework.Extension;
using MemoFramework.GameState;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelState : GameStateBase
{
    protected override void OnStateEnter()
    {
        base.OnStateEnter();
        SceneManager.LoadScene(SceneConstants.SelectLevel);
        if (MF.Cutscene.IsPlaying)
        {
            MF.Cutscene.FadeCutScene(GlobalConstants.CutSceneFadeDuration);
        }
        MF.Event.Subscribe<OnRequireEnterGame>(RequireEnterGame);
    }

    protected override void OnStateUpdate()
    {
        base.OnStateUpdate();
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

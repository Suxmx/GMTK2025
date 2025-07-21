using System;
using MemoFramework;
using MemoFramework.Extension;
using MemoFramework.GameState;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using Object = UnityEngine.Object;

namespace M2.GameState
{
    public class PreloadState : GameStateBase
    {
        private bool _enterEnd;

        protected override void OnStateEnter()
        {
            base.OnStateEnter();
            // 播放加载过场
            _enterEnd = false;
            var cutscene = Object.Instantiate(Resources.Load<GameObject>("CutScene"), MF.Cutscene.CutsceneRoot)
                .GetComponent<CutsceneAgent>();
            MF.Cutscene.SetCutSceneAgent(cutscene);
            MF.Cutscene.EnterCutScene(0.3f, () => _enterEnd = true);
        }

        protected override void OnStateUpdate()
        {
            base.OnStateUpdate();
            if (_enterEnd)
            {
                GameStateComponent.RequestStateChange(EGameState.Menu.ToString());
            }
        }

        protected override void OnStateExit()
        {
            base.OnStateExit();
            MF.Cutscene.FadeCutScene(1f);
            // 这时候场景已经加载出来了，初始化地图管理
        }
    }
}
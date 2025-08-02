using System.Collections.Generic;
using GMTK.EventArgs;
using MemoFramework.Extension;
using MemoFramework.GameState;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace GMTK
{
    public class MainGameState : GameStateBase
    {
        public Seasons currentSeason;
        private Transform m_ManagersRoot;

        protected override void OnStateEnter()
        {
            base.OnStateEnter();
            RegisterEvents();
            InitGame();
        }

        private void InitGame()
        {
            // 加载场景
            SceneManager.LoadScene(SceneConstants.Game);
            // 播放过场
            if (MF.Cutscene.IsPlaying)
            {
                MF.Cutscene.FadeCutScene(GlobalConstants.CutSceneFadeDuration);
            }

            // 注册管理
            m_ManagersRoot = new GameObject("Managers").transform;
            currentSeason = (Seasons)MF.Blackboard.GetInt("StartSeason");
        }

        protected override void OnStateExit()
        {
            base.OnStateExit();
            UnRegisterEvents();
        }

        private void RegisterEvents()
        {
            MF.Event.Subscribe<OnRequireRestartGame>(OnRequireRestartGameHandler);
            MF.Event.Subscribe<OnRequireReturnMenu>(OnRequireReturnMenuHandler);
        }

        private void UnRegisterEvents()
        {
            MF.Event.Unsubscribe<OnRequireRestartGame>(OnRequireRestartGameHandler);
            MF.Event.Unsubscribe<OnRequireReturnMenu>(OnRequireReturnMenuHandler);
        }

        // 重开
        private void OnRequireRestartGameHandler(object sender, OnRequireRestartGame e)
        {
            if (m_ManagersRoot)
            {
                Object.Destroy(m_ManagersRoot);
            }

            MF.Cutscene.EnterCutScene(GlobalConstants.CutSceneEnterDuration, InitGame);
        }

        // 返回菜单
        private void OnRequireReturnMenuHandler(object sender, OnRequireReturnMenu e)
        {
            MF.Cutscene.EnterCutScene(GlobalConstants.CutSceneEnterDuration,
                () => { GameStateComponent.RequestStateChange(EGameState.Menu.ToString()); });
        }
    }
}
using GMTK.EventArgs;
using MemoFramework.Extension;
using MemoFramework.GameState;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GMTK
{
    public class MainGameState : GameStateBase
    {
        private Transform m_ManagersRoot;

        protected override void OnStateEnter()
        {
            base.OnStateEnter();
            RegisterEvents();
            InitGame();
        }

        private void InitGame()
        {
            if (PlayerPrefs.GetInt("SelectedLevel") == -1)
            {
                Debug.LogError("SelectedLevel is null");
            }
            
            // 加载场景
            SceneManager.LoadScene(PlayerPrefs.GetInt("SelectedLevel"));
            // 播放过场
            if (MF.Cutscene.IsPlaying)
            {
                MF.Cutscene.FadeCutScene(GlobalConstants.CutSceneFadeDuration);
            }

            // 注册管理
            m_ManagersRoot = new GameObject("Managers").transform;
            PlayerPrefs.SetInt("SelectedLevel", -1);
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
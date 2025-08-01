using System.Collections.Generic;
using GMTK.EventArgs;
using MemoFramework.Extension;
using UnityEngine;
using UnityEngine.UI;

namespace GMTK.UI
{
    public class MainGameForm : MonoBehaviour
    {
        [Header("序列化按钮")] [SerializeField] private Button pauseBtn;
        [SerializeField] private Button pausePanel_SettingBtn;
        [SerializeField] private Button pausePanel_RestartBtn;
        [SerializeField] private Button pausePanel_ReturnBtn;
        [SerializeField] private Button pausePanel_ResumeBtn;
        [Header("序列化面板")] [SerializeField] private GameObject pausePanel;

        [Header("其他UI")] 
        [SerializeField] private Image BG_Image;
        private List<Sprite> BGImages = new List<Sprite>();

        private void Awake()
        {
            PanelManager.Instance?.RegisterPanel(PanelId.Game, gameObject);
        }

        private void OnDestroy()
        {
            PanelManager.Instance?.UnregisterPanel(PanelId.Game);
        }

        private void OnEnable()
        {
            RegisterEvents();
            BG_Image.sprite = BGImages[MF.Blackboard.GetInt("StartSeason")];
        }

        private void OnDisable()
        {
            UnRegisterEvents();
        }

        private void RegisterEvents()
        {
            pauseBtn.onClick.AddListener(OnClickPause);
            pausePanel_SettingBtn.onClick.AddListener(OnClickSetting);
            pausePanel_RestartBtn.onClick.AddListener(OnClickRestart);
            pausePanel_ReturnBtn.onClick.AddListener(OnClickReturn);
            pausePanel_ResumeBtn.onClick.AddListener(OnClickResume);
        }

        private void UnRegisterEvents()
        {
            pauseBtn.onClick.RemoveListener(OnClickPause);
            pausePanel_SettingBtn.onClick.RemoveListener(OnClickSetting);
            pausePanel_RestartBtn.onClick.RemoveListener(OnClickRestart);
            pausePanel_ReturnBtn.onClick.RemoveListener(OnClickReturn);
            pausePanel_ResumeBtn.onClick.RemoveListener(OnClickResume);
        }

        #region Events

        public void OnClickPause()
        {
            pausePanel.SetActive(true);
            pauseBtn.gameObject.SetActive(false);
        }

        public void OnClickResume()
        {
            pausePanel.SetActive(false);
            pauseBtn.gameObject.SetActive(true);
        }

        public void OnClickSetting()
        {
            PanelManager.Instance.CheckShow(PanelId.Setting, true);
        }

        public void OnClickRestart()
        {
            MF.Event.Fire(this, OnRequireRestartGame.Create());
        }

        public void OnClickReturn()
        {
            MF.Event.Fire(this, OnRequireReturnMenu.Create());
        }

        #endregion
    }
}
using System;
using GMTK.EventArgs;
using I2.Loc;
using MemoFramework.Extension;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace GMTK.UI
{
    public class MenuForm : MonoBehaviour
    {
        [Header("序列化按钮")]
        [SerializeField] private Button enterBtn;
        [SerializeField] private Button settingBtn;
        [SerializeField] private Button exitBtn;

        private void Awake()
        {
            PanelManager.Instance?.RegisterPanel(PanelId.Menu,gameObject);
        }

        private void OnDestroy()
        {
            PanelManager.Instance?.UnregisterPanel(PanelId.Menu);
        }

        private void OnEnable()
        {
            RegisterEvents();
        }

        private void OnDisable()
        {
            UnRegisterEvents();
        }

        private void RegisterEvents()
        {
            enterBtn.onClick.AddListener(OnClickEnter);
            settingBtn.onClick.AddListener(OnClickSettings);
            exitBtn.onClick.AddListener(OnClickExit);
        }

        
        private void UnRegisterEvents()
        {
            enterBtn.onClick.RemoveListener(OnClickEnter);
            settingBtn.onClick.RemoveListener(OnClickSettings);
            exitBtn.onClick.RemoveListener(OnClickExit);
        }
        
        private void OnClickEnter()
        {
            MF.Blackboard.SetInt("StartSeason", 0);
            MF.Event.Fire(this,OnRequireEnterGame.Create());
        }
        private void OnClickSettings()
        {
            PanelManager.Instance.CheckShow(PanelId.Setting,true);
        }

        private void OnClickExit()
        {
            Debug.Log("退出游戏");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
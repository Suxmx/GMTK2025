using System;
using GMTK.EventArgs;
using I2.Loc;
using MemoFramework.Extension;
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
            MF.Event.Fire(this,OnRequireEnterGame.Create());
        }
        private void OnClickSettings()
        {
        }

        private void OnClickExit()
        {
            // 退出游戏
            Debug.Log("退出游戏");
            Application.Quit();
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace GMTK.UI
{
    public class MainGameForm : MonoBehaviour
    {
        [Header("序列化按钮")] 
        [SerializeField] private Button pauseBtn;
        [SerializeField] private Button pausePanel_SettingBtn;
        [SerializeField] private Button pausePanel_RestartBtn;
        [SerializeField] private Button pausePanel_ReturnBtn;
        [SerializeField] private Button pausePanel_ResumeBtn;
        [Header("序列化面板")]
        [SerializeField] private GameObject pausePanel;
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
            
        }
        private void UnRegisterEvents()
        {
           
        }
    }
}
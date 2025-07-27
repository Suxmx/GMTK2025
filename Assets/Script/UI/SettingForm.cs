using System;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

namespace GMTK.UI
{
    public class SettingForm : MonoBehaviour
    {
        [Header("序列化")] 
        [SerializeField] private Button switchLanguageBtn;
        [SerializeField] private Button returnBtn;
        [SerializeField] private Slider volumeSlider;

        private void OnDestroy()
        {
            PanelManager.Instance?.UnregisterPanel(PanelId.Setting);
        }
        private void Awake()
        {
            PanelManager.Instance?.RegisterPanel(PanelId.Setting,gameObject);
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            switchLanguageBtn.onClick.AddListener(OnClickLanguageBtn);
            returnBtn.onClick.AddListener(OnClickReturn);
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }

        private void OnVolumeChanged(float arg0)
        {
            Debug.Log($"音量已设置为: {arg0}1111");
        }

        private void OnClickReturn()
        {
            Destroy(gameObject);
        }

        private void OnClickLanguageBtn()
        {
            if(LocalizationManager.CurrentLanguageCode == "zh-CN")
            {
                LocalizationManager.CurrentLanguageCode = "en";
            }
            else
            {
                LocalizationManager.CurrentLanguageCode = "zh-CN";
            }
        }
        
    }
}
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using DG;
using DG.Tweening;
using GMTK.EventArgs;
using MemoFramework.Extension;
using MemoFramework.GameState;
using UnityEditor.Experimental.GraphView;

namespace GMTK.UI.LevelSelect
{
    public class LevelButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [FormerlySerializedAs("levelName")] [SerializeField]
        private TextMeshProUGUI levelNameText;
        private SelectLevelForm m_selectLevelForm;
        public LevelData levelData { get; set; }
        private Vector3 originalScale;
        private Button _button;
        private Image _image;
        [Tooltip("UI默认颜色(默认已解锁：白色；未解锁：灰色)")]public Color ReturnColor { get; set; }
        
        [Tooltip("选中UI时按钮变色")]public Color SelectedColor { get; set; }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            ReturnColor = Color.gray;
            originalScale = _image.rectTransform.localScale;
            SelectedColor = Color.red;
        }

        public void SetUp(LevelData level,SelectLevelForm controllor ,bool isUnlocked)
        {
            levelData = level;
            m_selectLevelForm = controllor;
            levelNameText.SetText(level.levelID);
            _button.interactable = isUnlocked;

            if (isUnlocked)
            {
                ReturnColor = Color.white;
                _image.color = ReturnColor;
            }
            else
            {
                ReturnColor = Color.gray;
                _image.color = ReturnColor;
            }
        }

        public void Unlock()
        {
            _button.interactable = true;
            
            ReturnColor = Color.white;
            _image.color = ReturnColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_button.interactable)
            {
                levelData.LevelButtonObj.transform.DOScale(originalScale * 1.05f, 0.25f);
                _image.color = SelectedColor;
            }
            m_selectLevelForm.LevelHeaderText.SetText(levelData.levelName);
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            levelData.LevelButtonObj.transform.DOScale(originalScale, 0.25f);
            _image.color = ReturnColor;
            m_selectLevelForm.LevelHeaderText.SetText("");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_button.interactable)
            {
                /*PlayerPrefs.SetInt("SelectedLevel", levelData.sceneID);*/
                MF.Blackboard.SetInt("SelectedLevel", levelData.sceneID);
                MF.Event.Fire(this,OnRequireEnterGame.Create());
            }
        }
    }
}
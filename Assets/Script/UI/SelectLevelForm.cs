using System;
using System.Collections.Generic;
using GMTK.EventArgs;
using GMTK.UI.LevelSelect;
using JetBrains.Annotations;
using MemoFramework.Extension;
using MemoFramework.GameState;
using Sirenix.Utilities;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GMTK.UI
{
    public class SelectLevelForm : MonoBehaviour
    {
        public Transform LevelParent;
        public GameObject LevelButtonPrefab;

        public TextMeshProUGUI AreaHeaderText;
        public TextMeshProUGUI LevelHeaderText;

        public AreaData currentArea;

        public HashSet<string> unlockedLevelIDs = new HashSet<string>();
        public List<GameObject> levelButtons = new List<GameObject>();

        private void Awake()
        {
            PanelManager.Instance?.RegisterPanel(PanelId.SelectLevel, gameObject);
        }

        private void OnDestroy()
        {
            PanelManager.Instance?.UnregisterPanel(PanelId.SelectLevel);
        }

        private void OnEnable()
        {
            SetUp();
        }

        private void SetUp()
        {
            AssignAreaText();
            LoadUnlockedLevels();
            CreateLevelButtons();
        }
        
        private void OnDisable()
        { 
            DestroyAllButtons();
        }
        
        private void DestroyAllButtons()
        {
            for (int i = levelButtons.Count - 1; i >= 0; i--)
            {
                Destroy(levelButtons[i]);
                levelButtons.RemoveAt(i);
                currentArea.levels[i].LevelButtonObj = null;
            }

            if (!levelButtons.IsNullOrEmpty())
            {
                Debug.Log("levelButtons clear unsuccessfully!");
            }
        }


        private void AssignAreaText()
        {
            AreaHeaderText.SetText(currentArea.areaName);
            LevelHeaderText.SetText("");
            Debug.Log("Area Name Has Been Set!");
        }

        private void LoadUnlockedLevels()
        {
            foreach (var level in currentArea.levels)
            {
                if (level.isUnlockedDefault)
                {
                    unlockedLevelIDs.Add(level.levelID);
                }
            }
        }

        private void CreateLevelButtons()
        {
            for (int i = 0; i < currentArea.levels.Count; i++)
            {
                GameObject buttonGo = Instantiate(LevelButtonPrefab, LevelParent);
                levelButtons.Add(buttonGo);
                
                buttonGo.name = currentArea.levels[i].levelID;
                currentArea.levels[i].LevelButtonObj = buttonGo;

                LevelButton levelButton = buttonGo.GetComponent<LevelButton>();
                levelButton.SetUp(currentArea.levels[i], this,unlockedLevelIDs.Contains(currentArea.levels[i].levelID));
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using GMTK;
using MemoFramework.Extension;
using UnityEngine;

namespace GMTK.UI.LevelSelect
{
    [CreateAssetMenu(menuName = "Level Data/Levels", fileName = "New Level")]
    public class LevelData : ScriptableObject
    {
        [Header("LevelState")] public string levelID;
        public bool isUnlockedDefault;

        [Tooltip("在MF.SceneConstants中对应跳转的场景")]
        public int sceneID;

        [Header("Level Display Info")] public string levelName;

        public GameObject LevelButtonObj { get; set; }
    }
}
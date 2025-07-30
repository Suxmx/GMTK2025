using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GMTK.UI.LevelSelect
{
    [CreateAssetMenu(menuName = "Level Data/Areas", fileName = "New Area")]
    public class AreaData : ScriptableObject
    {
        public string areaName;
        public List<LevelData> levels = new List<LevelData>();
    }
}
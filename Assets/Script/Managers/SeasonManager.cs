using System;
using GMTK.EventArgs;
using MemoFramework.Extension;
using UnityEngine;

namespace GMTK
{
    public enum ESeason
    {
        Spring = 0,
        Summer = 1,
        Autumn = 2,
        Winter = 3,
    }

	[DefaultExecutionOrder(-1000)]
    public class SeasonManager : MonoBehaviour
    {
        public static SeasonManager Instance { get; private set; }
        public ESeason CurrentSeason { get; private set; } = ESeason.Spring;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
               
            }
            else
            {
                Debug.LogError("[SeasonManager] More than one instance of SeasonManager!");
                Destroy(gameObject);
                return;
            }
        }

        public void NextSeason()
        {
            CurrentSeason = (ESeason)(((int)CurrentSeason + 1) % Enum.GetValues(typeof(ESeason)).Length);
            Debug.Log($"Season changed to: {CurrentSeason}");
            MF.Event.Fire(this,OnSeasonChanged.Create(CurrentSeason));
        }
    }
}
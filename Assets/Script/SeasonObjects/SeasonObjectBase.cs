using System;
using GMTK.EventArgs;
using MemoFramework.Extension;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GMTK
{
    public abstract class SeasonObjectBase : SerializedMonoBehaviour
    {
        protected virtual void Start()
        {
            if (SeasonManager.Instance)
            {
                OnChangeToSeason(SeasonManager.Instance.CurrentSeason);
            }
            else
            {
                Debug.LogError("[SeasonObjectBase] SeasonManager instance not found.");
            }
        }

        private void OnEnable()
        {
            MF.Event.Subscribe<OnSeasonChanged>(OnSeasonChangedHandler);
        }

        private void OnDisable()
        {
            MF.Event.Unsubscribe<OnSeasonChanged>(OnSeasonChangedHandler);
        }

        private void OnSeasonChangedHandler(object sender, OnSeasonChanged args)
        {
            OnChangeToSeason(args.Season);
        }

        private void OnChangeToSeason(ESeason season)
        {
            Debug.Log($"[{GetType().FullName}]<{name}> Season changed to: " + season);
            switch (season)
            {
                case ESeason.Spring:
                    OnSpring();
                    break;
                case ESeason.Summer:
                    OnSummer();    
                    break;
                case ESeason.Autumn:
                    OnAutumn();
                    break;
                case ESeason.Winter:
                    OnWinter();
                    break;
            }
        }

        protected abstract void OnSpring();
        protected abstract void OnSummer();
        protected abstract void OnAutumn();
        protected abstract void OnWinter();
    }
}
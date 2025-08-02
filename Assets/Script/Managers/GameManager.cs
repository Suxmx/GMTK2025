using System;
using System.Collections.Generic;
using GMTK.EventArgs;
using MemoFramework.Extension;
using UnityEngine;

namespace GMTK
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public PlayerController2D Player { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogError("[GameManager] More than one instance of GameManager!");
                Destroy(gameObject);
                return;
            }
        }

        private void Start()
        {
            int spawnPointIndex = 0;
            if(!MF.Blackboard.HasInt("SpawnPointIndex"))
            {
                MF.Blackboard.SetInt("SpawnPointIndex", 0);
            }
            else
            {
                spawnPointIndex = MF.Blackboard.GetInt("SpawnPointIndex");
            }
            ReturnToSpawnPoint(spawnPointIndex);
        }

        private void OnEnable()
        {
            MF.Event.Subscribe<OnPlayerDie>(OnPlayerDie);
        }

        private void OnDisable()
        {
            MF.Event.Unsubscribe<OnPlayerDie>(OnPlayerDie);
        }

        private void OnPlayerDie(object sender, OnPlayerDie args)
        {
            MF.Cutscene.EnterCutScene(GlobalConstants.CutSceneEnterDuration, () =>
            {
                // ReturnToSpawnPoint();
                MF.Cutscene.FadeCutScene(GlobalConstants.CutSceneFadeDuration);
            });
        }

        #region SpawnPoint

        private Dictionary<int, SpawnPointTrigger> _spawnPoints = new();

        public void RegisterSpawnPoint(SpawnPointTrigger spawnPointTrigger)
        {
            if (_spawnPoints.ContainsKey(spawnPointTrigger.Index))
            {
                Debug.LogError("[GameManager] SpawnPoint with the same name already exists: " +
                               spawnPointTrigger.Index);
                return;
            }

            _spawnPoints.Add(spawnPointTrigger.Index, spawnPointTrigger);
        }

        public void ReturnToSpawnPoint(int spawnPointIndex)
        {
            if(!_spawnPoints.TryGetValue(spawnPointIndex, out var spawnPoint))
            {
                Debug.LogError($"[GameManager] SpawnPoint with index {spawnPointIndex} not found.");
                return;
            }

            if (!spawnPoint.PlayerSpawnPoint)
            {
                Debug.LogError("[GameManager] PlayerSpawnPoint is not set for the spawn point with index: " + spawnPointIndex);
                return;
            }

            MF.Cutscene.EnterCutScene(GlobalConstants.CutSceneEnterDuration, () =>
            {
                if (Player != null)
                {
                    Player.transform.position = spawnPoint.PlayerSpawnPoint.position;
                }
                else
                {
                    Debug.LogError("[GameManager] Player object not found.");
                }
                MF.Cutscene.FadeCutScene(GlobalConstants.CutSceneFadeDuration);
            });
        }

        #endregion
        
        
    }
}
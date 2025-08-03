using System;
using System.Collections.Generic;
using GMTK.EventArgs;
using MemoFramework.Extension;
using UnityEngine;

namespace GMTK
{
    [DefaultExecutionOrder(-1000)]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public PlayerController2D Player { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Player = GameObject.Find("Player")?.GetComponent<PlayerController2D>();
            }
            else
            {
                Debug.LogError("[GameManager] More than one instance of GameManager!");
                Destroy(gameObject);
                return;
            }
        }

        // private void Start()
        // {
        //     ReturnToSpawnPoint();
        // }

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
                ReturnToSpawnPoint();
                Player.RequestRespawn();
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

        public void TryUpdateCurrentSpawnPoint(SpawnPointTrigger spawnPoint)
        {
            Debug.Log("[GameManager] TryUpdateCurrentSpawnPoint called.Try to update spawn point: " +
                      spawnPoint.Index);
            int spawnPointIndex = spawnPoint.Index;
            if (!MF.Blackboard.HasInt("SpawnPointIndex") || MF.Blackboard.GetInt("SpawnPointIndex") < spawnPointIndex)
            {
                Debug.LogWarning("[GameManager] Updating current spawn point to: " + spawnPointIndex);
                MF.Blackboard.SetInt("SpawnPointIndex", spawnPointIndex);
            }
        }

        public void ReturnToSpawnPoint()
        {
            int spawnPointIndex = 0;
            if(MF.Blackboard.HasInt("SpawnPointIndex"))
            {
                spawnPointIndex = MF.Blackboard.GetInt("SpawnPointIndex");
            }
            if (!_spawnPoints.TryGetValue(spawnPointIndex, out var spawnPoint))
            {
                Debug.LogError($"[GameManager] SpawnPoint with index {spawnPointIndex} not found.");
                return;
            }

            if (!spawnPoint.PlayerSpawnPoint)
            {
                Debug.LogError("[GameManager] PlayerSpawnPoint is not set for the spawn point with index: " +
                               spawnPointIndex);
                return;
            }

            Debug.Log("[GameManager] Returning to spawn point: " + spawnPointIndex);
            Player.transform.position = spawnPoint.PlayerSpawnPoint.position;
        }

        #endregion

        public void QuitGame()
        {
            Debug.Log("退出游戏");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        
        
    }
}
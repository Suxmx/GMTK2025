using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GMTK
{
    public class RockSpawner : MonoBehaviour
    {
        [LabelText("生成间隔")] public float interval = 2f;
        public GameObject rockPrefab;

        private float _timer = 0;

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= interval)
            {
                _timer = 0f;
                SpawnRock();
            }
        }

        private void SpawnRock()
        {
            if (rockPrefab == null)
            {
                Debug.LogError("[RockSpawner] Rock prefab is not assigned.");
                return;
            }

            Vector3 spawnPosition = transform.position;
            GameObject rock = Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
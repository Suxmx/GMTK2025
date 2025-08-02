using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GMTK
{
    public class SpawnPointTrigger : MonoBehaviour
    {
        [LabelText("重生点序号")] public int Index;
        [LabelText("玩家重生到的位置")] public Transform PlayerSpawnPoint;

        private void Awake()
        {
            GameManager.Instance.RegisterSpawnPoint(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
            }
        }
    }
}
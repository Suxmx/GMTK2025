using System;
using GMTK.EventArgs;
using MemoFramework.Extension;
using UnityEngine;

namespace GMTK
{
    public class DestroyWhenRespawn : MonoBehaviour
    {
        private void Awake()
        {
            MF.Event.Subscribe<OnPlayerRespawn>(OnPlayerRespawnHandler);
        }

        private void OnPlayerRespawnHandler(object sender, OnPlayerRespawn e)
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            MF.Event.Unsubscribe<OnPlayerRespawn>(OnPlayerRespawnHandler);
        }
        
    }
}
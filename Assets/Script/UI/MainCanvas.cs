using System;
using UnityEngine;

namespace GMTK.UI
{
    public class MainCanvas : MonoBehaviour
    {
        private void Awake()
        {
            PanelManager.Instance?.RegisterMainCanvas(this);
        }

        private void OnDestroy()
        {
            PanelManager.Instance?.UnregisterMainCanvas(this);
        }
    }
}
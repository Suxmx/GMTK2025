using System;
using UnityEngine;

namespace GMTK
{
    public class SeasonChanger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                DoChangeSeason();
            }
        }

        private void DoChangeSeason()
        {
            SeasonManager.Instance?.NextSeason();
        }
    }
}
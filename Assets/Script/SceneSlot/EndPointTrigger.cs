using System;
using UnityEngine;
using UnityEngine.Playables;

namespace GMTK
{
    public class EndPointTrigger : MonoBehaviour
    {
        [SerializeField] private PlayableDirector director;
        [SerializeField] private GameObject env;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                env.SetActive(false);
                director.Play();
            }
        }
    }
}
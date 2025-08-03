using System;
using UnityEngine;
using UnityEngine.Playables;

namespace GMTK
{
    public class EndPointTrigger : MonoBehaviour
    {
        [SerializeField] private PlayableDirector director;
        [SerializeField] private GameObject env;
        [SerializeField] private AudioSource winSource;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                env.SetActive(false);
                director.Play();
                winSource?.Play();
            }
        }
    }
}
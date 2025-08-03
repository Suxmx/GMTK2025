using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Playables;

namespace GMTK
{
    public class TimelineTester : MonoBehaviour
    {
        [Button("播放Timeline")]
        public void PlayTimeline()
        {
            GetComponent<PlayableDirector>().Play();
        }
    }
}
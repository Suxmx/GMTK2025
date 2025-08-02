using System;
using UnityEngine;

namespace GMTK
{
    public class MovingPlatform : MonoBehaviour
    {
        public Transform from;
        public Transform to;
        public Transform platform;
        public float speed = 2;

        private Transform _curTarget;
        private bool _xLarger;

        private void Awake()
        {
            if (from == null || to == null || platform == null)
            {
                Debug.LogError("[MovingPlatform] Missing references for from, to, or platform.");
                return;
            }

            _curTarget = to;
            _xLarger = platform.position.x > _curTarget.position.x;
        }

        private void Update()
        {
            if (platform == null || from == null || to == null)
            {
                return;
            }

            platform.position = Vector3.MoveTowards(platform.position, _curTarget.position, Time.deltaTime * speed);

            if (_xLarger && platform.position.x <= _curTarget.position.x ||
                !_xLarger && platform.position.x >= _curTarget.position.x)
            {
                _curTarget = _curTarget == to ? from : to;
                _xLarger = platform.position.x > _curTarget.position.x;
            }
        }
    }
}
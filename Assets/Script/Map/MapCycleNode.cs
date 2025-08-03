using UnityEngine;

namespace GMTK
{
    public class MapCycleNode
    {
        public float PosX
        {
            get => transform.position.x;
            set
            {
                var pos = transform.position;
                pos.x = value;
                transform.position = pos;
            }
        }

        public Transform transform;
        public float Length;

        public float LeftX
        {
            get => PosX - Length / 2f - Offset;
            set => PosX = value + Length / 2f + Offset;
        }

        public float RightX
        {
            get => PosX + Length / 2f + Offset;
            set => PosX = value - Length / 2f - Offset;
        }

        public float Offset { get; private set; }

        public void Set(Transform trans, float length, float offset)
        {
            transform = trans;
            Length = length;
            Offset = offset;
        }
    }
}
using System;
using MemoFramework;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GMTK
{
     /// <summary>
    /// 靠自己+克隆的共3个地图资源循环
    /// </summary>
    public class MapSelfCycle : MonoBehaviour
    {
        // public float Length => length;
        //
        [LabelText("长度"), SerializeField]
        private float length;
        
        [LabelText("视差移动倍率"), SerializeField]
        private float moveFactor = 1f;

        private MFLinkedList<MapCycleNode> _mapNodes;
        private float _initPlayerX;
        private float _initX;
        private Camera _mainCamera;
        private void Start()
        {
            if(length<=0)
            {
                length = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
            }
            _mainCamera = Camera.main;
            _initPlayerX = GetCameraX();
            _initX = transform.position.x;
            _mapNodes = new();
            string cycleName = gameObject.name;
            gameObject.name = cycleName + "_1";
            // 新建一个父节点来容纳三个节点
            Transform parent = new GameObject("MapCycle_" + cycleName).transform;
            parent.SetParent(transform.parent);
            parent.position = transform.position;
            transform.SetParent(parent, true);
            // 先将自己加入
            var selfNode = new MapCycleNode();
            selfNode.Set(transform, length, 0);
            selfNode.LeftX = GetCameraRightX();
            _mapNodes.AddFirst(selfNode);
            // 再克隆两个
            for (int i = 1; i <= 1; i++)
            {
                var obj = Instantiate(gameObject, parent);
                obj.name = cycleName + "_" + (i + 1).ToString();
                Destroy(obj.GetComponent<MapSelfCycle>());
                var node = new MapCycleNode();
                node.Set(obj.transform, length, 0);
                node.transform.position =
                    transform.position + Vector3.right * length * i;

                _mapNodes.AddLast(node);
            }
        }

        public void LateUpdate()
        {
            // 只更新第一个节点，其他节点的位置由第一个节点决定  
            var firstNode = _mapNodes.First.Value;
            float playerOffsetX = GetCameraX() - _initPlayerX;
            float x = _initX + playerOffsetX * moveFactor;
            firstNode.PosX = x;
            // 更新后续节点
            foreach (var node in _mapNodes)
            {
                // 跳过第一个节点
                if (node == firstNode) continue;
                x += node.Length;
                node.PosX = x;
            }

            // 最后判断是否需要移动节点
            if (firstNode.RightX < GetCameraLeftX())
            {
                var lastNode = _mapNodes.Last.Value;
                firstNode.LeftX = lastNode.RightX;
                _mapNodes.RemoveFirst();
                _mapNodes.AddLast(firstNode);
            }
        }
        
        private float GetCameraRightX()
        {
            if (!_mainCamera) return 0;
            // 获取摄像机右侧的X坐标
            return _mainCamera.transform.position.x + _mainCamera.orthographicSize * _mainCamera.aspect;
        }
        
        private float GetCameraLeftX()
        {
            if (!_mainCamera) return 0;
            // 获取摄像机左侧的X坐标
            return _mainCamera.transform.position.x - _mainCamera.orthographicSize * _mainCamera.aspect;
        }

        private float GetCameraX()
        {
            return _mainCamera.transform.position.x;
        }
        
    }
}
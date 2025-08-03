using System;
using System.Collections.Generic;
using UnityEngine;


namespace GMTK
{
    public class SpecialManager : MonoBehaviour
    {
        public static SpecialManager instance { get; private set; }

        public GameObject BulletPrefab;
        public GameObject BoxPrefab;
        
        public List<Sprite> SpecialBoxSprites;
        private List<SpecialBox> SpecialBoxesList = new List<SpecialBox>();
        
        [SerializeField] private int maxSpecialBoxes = 3;
        [SerializeField] private int BulletSpeed = 5;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                Clear();
            }
        }

        public void BuildBox(Vector3 createPosition)
        {
            if (SpecialBoxesList.Count >= maxSpecialBoxes)
            {
                Debug.LogWarning("You have built 4 Boxes!");
                return;
            }
            GameObject go = Instantiate(BoxPrefab, createPosition, Quaternion.identity);
            
            SpecialBox box = go.GetComponent<SpecialBox>();
            
            go.GetComponent<SpriteRenderer>().sprite = SpecialBoxSprites[0];
            // sb.SetSprite(SpecialBoxSprites[(int)SeasonManager.Instance.CurrentSeason]);
            SpecialBoxesList.Add(box);
        }

        public void BuildBullet(Vector3 createPosition, Vector2 direction)
        {
            GameObject go = Instantiate(BulletPrefab, createPosition, Quaternion.identity);
            
            SpecialBullet sb = go.GetComponent<SpecialBullet>();
            
            // sb.SetSprite(SpecialBulletSprites[0]);
            sb.SetVelocity(direction * BulletSpeed);
        }

        public void RemoveSpecialBox(SpecialBox sb)
        {
            SpecialBoxesList.Remove(sb);
            Destroy(sb.gameObject);
        }

        public void Clear()
        {
            for (int i = SpecialBoxesList.Count - 1; i >= 0; i--)
            {
                SpecialBox sb = SpecialBoxesList[i];
                SpecialBoxesList.Remove(sb);
                Destroy(sb);
            }
        }
    }
}
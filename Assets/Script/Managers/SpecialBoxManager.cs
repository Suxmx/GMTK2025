using System;
using System.Collections.Generic;
using UnityEngine;


namespace GMTK
{
    public class SpecialBoxManager : MonoBehaviour
    {
        public static SpecialBoxManager instance { get; private set; }
        public GameObject BoxPrefab;
        public List<Sprite> SpecialBoxSprites;
        private List<SpecialBox> SpecialBoxesList = new List<SpecialBox>();
        [SerializeField] private int maxSpecialBoxes = 4;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
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
            go.GetComponent<SpriteRenderer>().sprite = SpecialBoxSprites[0];
            // SpecialBox sb = go.GetComponent<SpecialBox>();
            // sb.SetSprite(SpecialBoxSprites[(int)SeasonManager.Instance.CurrentSeason]);
            SpecialBoxesList.Add(go.GetComponent<SpecialBox>());
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
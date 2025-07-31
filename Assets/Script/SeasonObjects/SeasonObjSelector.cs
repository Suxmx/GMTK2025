using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace GMTK
{
    public class SeasonObjSelector : SeasonObjectBase
    {
        [ValidateInput("ValidateDict", "Dictionary must contain all seasons and no duplicates.")]
        public Dictionary<ESeason, GameObject> seasonObjects;

        protected override void OnSpring()
        {
            foreach (var kvp in seasonObjects)
            {
                kvp.Value?.SetActive(kvp.Key == ESeason.Spring);
            }
        }

        protected override void OnSummer()
        {
            foreach (var kvp in seasonObjects)
            {
                kvp.Value?.SetActive(kvp.Key == ESeason.Summer);
            }
        }

        protected override void OnAutumn()
        {
            foreach (var kvp in seasonObjects)
            {
                kvp.Value?.SetActive(kvp.Key == ESeason.Autumn);
            }
        }

        protected override void OnWinter()
        {
            foreach (var kvp in seasonObjects)
            {
                kvp.Value?.SetActive(kvp.Key == ESeason.Winter);
            }
        }

        private bool ValidateDict()
        {
            if (seasonObjects == null || seasonObjects.Count < Enum.GetValues(typeof(ESeason)).Length)
            {
                return false;
            }

            return true;
        }
    }
}
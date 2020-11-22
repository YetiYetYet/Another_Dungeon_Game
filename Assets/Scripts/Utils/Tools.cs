using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Tools
    {
        public static List<Transform> GetChildRecursive(Transform parent, List<Transform> transformsList = null)
        {
            if (transformsList == null)
                transformsList = new List<Transform>();
            foreach (Transform child in parent)
            {
                transformsList.Add(child);
                GetChildRecursive(child, transformsList);
            }

            return transformsList;
        }
    }
}
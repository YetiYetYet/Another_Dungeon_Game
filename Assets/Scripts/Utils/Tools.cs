using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Tools
    {
        public static List<Transform> GetChildRecursive(Transform root)
        {
            List<Transform> childs = new List<Transform>();
            ChildBuildList(root, childs);
            return childs;
        }

        private static void ChildBuildList(Transform root, List<Transform> list)
        {
            if (root.childCount > 0)
            {
                foreach (var child in root.GetComponentsInChildren<Transform>())
                {
                    list.Add(child);
                    ChildBuildList(child, list);
                }
            }
        }
    }
}
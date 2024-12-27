using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardLayoutData", menuName = "Card Layout Data")]
public class CardLayoutData : ScriptableObject
{
    [System.Serializable]
    public class Layout
    {
        public int rows;
        public int columns;
    }

    public Layout[] layouts;

    public void ValidateLayoutsList()
    {
        List<Layout> validLayouts = new List<Layout>();
        foreach (var layout in layouts)
        {
            var count = layout.rows * layout.columns;
            if (count % 2 == 0 && count>0)
            {
                validLayouts.Add(layout);
            }
        }
        layouts = validLayouts.ToArray();
    }
}

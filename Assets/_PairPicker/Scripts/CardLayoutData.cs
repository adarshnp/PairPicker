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
}

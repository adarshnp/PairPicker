using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// class representing a card. 
/// contains card data and user input reading
/// </summary>
public class Card : MonoBehaviour
{
    public int Value { get; private set; }
    public bool IsMatched { get; private set; } = false;
    public TMP_Text valueText;
    public void SetCardValue(int value)
    {
        this.Value = value;
        valueText.text = value.ToString();
    }

    private void OnMouseDown()
    {
        //register card selection to board manager
    }
    public void MarkAsMatched()
    {
        IsMatched = true;
    }
}

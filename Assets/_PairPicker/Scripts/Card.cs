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
        BoardManager.Instance.CardSelected(this);
    }
    public void MarkAsMatched()
    {
        IsMatched = true;
        VanishAndDisable();
    }
    private void VanishAndDisable()
    {
        //card vanish anim

        // After the animation is complete, disable the GameObject
        gameObject.SetActive(false);
    }
}

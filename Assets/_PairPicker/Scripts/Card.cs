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
    public bool IsFlipped { get; private set; } = false;
    public TMP_Text valueText;
    private Vector3 originalScale;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        originalScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetCardValue(int value)
    {
        this.Value = value;
        valueText.text = value.ToString();
    }

    private void OnMouseDown()
    {
        if(IsFlipped) { return; }
        IsFlipped = true;
        BoardManager.Instance.CardSelected(this);
        SoundManager.Instance.PlayFlipSound();
    }
    public void StartCardOpenAnimation()
    {
        StartCoroutine(transform.PlayCardOpen(originalScale));
    }
    public void StartCardReturnAnimation()
    {
        IsFlipped = false;
        StartCoroutine(transform.PlayCardReturn(originalScale));
    }
    public void MarkAsMatched()
    {
        IsMatched = true;
        StartCoroutine(VanishAndDisable());
    }
    private IEnumerator VanishAndDisable()
    {
        yield return StartCoroutine(spriteRenderer.PlayCardVanish(originalScale));

        // After the animation is complete, disable the GameObject
        gameObject.SetActive(false);
    }
}

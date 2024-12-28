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
        StartCoroutine(FlashCard(0.5f));
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
        SoundManager.Instance.PlaySound(SoundType.Flip);
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
    public IEnumerator FlashCard(float duration)
    {
        IsFlipped = true;
        yield return transform.PlayCardOpen(originalScale);
        yield return new WaitForSeconds(duration);
        yield return transform.PlayCardReturn(originalScale);
        IsFlipped = false;
    }
    public void MarkAsMatched()
    {
        IsMatched = true;
        StartCoroutine(VanishAndDisable());
    }
    private IEnumerator VanishAndDisable()
    {
        yield return StartCoroutine(spriteRenderer.PlayCardVanish(originalScale));

        gameObject.SetActive(false);
    }
}

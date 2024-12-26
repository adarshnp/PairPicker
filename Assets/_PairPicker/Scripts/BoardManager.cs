using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles setting up the card grid, flipping cards, and managing card matching logic.
/// </summary>
public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform board;
    private int totalPairs;
    private List<int> cardValues = new List<int>();
    [SerializeField] private float spacing;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InitializeBoard(2, 2);
    }
    private void InitializeBoard(int rows, int columns)
    {
        //ClearCards
        cardValues.Clear();

        totalPairs = (rows * columns) / 2;


        // Initialize card Values for each pair
        for (int i = 0; i < totalPairs; i++)
        {
            cardValues.Add(i);
            cardValues.Add(i);
        }

        //ShuffleCardValues

        PopulateCardsToGrid(rows, columns);

        //ScaleBoard
    }
    private void PopulateCardsToGrid(int rows, int columns)
    {
        float halfLength = (columns - 1) * spacing * 0.5f;
        float halfHeight = (rows - 1) * spacing * 0.5f;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                int cardIndex = row * columns + col;
                if (cardIndex >= cardValues.Count) break;

                GameObject newCard = Instantiate(cardPrefab, board);
                newCard.transform.localPosition = new Vector3(col * spacing - halfLength, row * spacing - halfHeight, 0);

                Card cardComponent = newCard.GetComponent<Card>();
                cardComponent.SetCardValue(cardValues[cardIndex]);
            }
        }
    }
}

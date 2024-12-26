using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
/// <summary>
/// Game Manager class that handles score and game flow
/// </summary>
public class GameManager : MonoBehaviour
{
    private int highScore;
    private int matches = 0;
    private int turns = 0;
    private int totalPairs;
    private float currentLevelMultiplier = 1;
    public int currentScore = 0;
    public float scoreMultiplierIncrementPerLevel = 0.25f;
    private int CompletedLevelsScore = 0;


    public event Action<int, int> onGridGeneration; // generate card layout for current level
    public event Action<int, int, int> onSaveGame;// on save after a matchwin

    public event Action onGameSessionStart; //enable game level UI and disable main menu UI
    public event Action onEnterMainMenu;

    public static GameManager instance;

    public CardLayoutData cardLayoutData;
    private int currentLevelIndex = 0;
    private void Awake()
    {
        instance = this;
    }
    public void SetTotalPairsCount(int value)
    {
        totalPairs = value;
    }

    //track moves count
    public void IncrementTurns()
    {
        turns++;
        currentScore = CompletedLevelsScore + CalculateCurrentLevelScore();
        Debug.Log($"turn : {turns} \n score : {currentScore}");
    }

    //track matches count
    public void IncrementMatches()
    {
        matches++;
        currentScore = CompletedLevelsScore + CalculateCurrentLevelScore();
        Debug.Log($"matches : {matches} \n score : {currentScore}");
        if (totalPairs <= matches)
        {
            WinLevel();
        }
    }

    //calculate score
    private int CalculateCurrentLevelScore()
    {
        if (turns == 0) return 0;
        currentLevelMultiplier = 1 + currentLevelIndex * scoreMultiplierIncrementPerLevel;
        float score = (float)matches / turns * currentLevelMultiplier;
        return (int)(score * 100);
    }

    //handle end game
    public void WinLevel()
    {
        //play sound depending on game win or match win

        CompletedLevelsScore = currentScore;
        if (highScore < CompletedLevelsScore)
        {
            highScore = CompletedLevelsScore;
        }

        Debug.Log($"WON!!! \n score : {CompletedLevelsScore} \n highscore : {highScore}");

    }



    //handle new game
    public void NewGame()
    {
        onGameSessionStart.Invoke();
        currentLevelIndex = 0;
        CompletedLevelsScore = 0;
        currentScore = 0;
        LoadLevel(currentLevelIndex);
    }
    public void NextLevel()
    {
        currentLevelIndex++;
        LoadLevel(currentLevelIndex);
    }
    public void LoadLevel(int levelIndex)
    {
        if (levelIndex >= cardLayoutData.layouts.Length)
        {
            Debug.Log("No more levels available.");
            return;
        }

        var layout = cardLayoutData.layouts[levelIndex];

        matches = 0;
        turns = 0;
        currentScore = CompletedLevelsScore;

        Debug.Log($"New Game!!! turns : {turns} \n matches : {matches} \n score : {currentScore} \n highscore : {highScore}");

        onGridGeneration.Invoke(layout.rows, layout.columns);
    }
    public void EnterMainMenu()
    {
        onEnterMainMenu.Invoke();
    }
    public void Quit()
    {
        Application.Quit();
    }
}

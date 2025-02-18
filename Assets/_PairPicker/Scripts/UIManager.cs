using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text matchesUI;
    [SerializeField] private TMP_Text turnsUI;
    [SerializeField] private TMP_Text levelScoreUI;
    [SerializeField] private TMP_Text highScoreUI;


    [SerializeField] private GameObject matchCompletionUI;
    [SerializeField] private GameObject gameBoard;
    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject continueButton;

    [SerializeField] private GameObject scoreTextUI;
    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] private GameObject levelCompletionMessage;
    [SerializeField] private GameObject gameCompletionMessage;


    private void Start()
    {
        if (GameManager.instance == null) return;
        SubscribeToEvents();
    }
    private void SubscribeToEvents()
    {
        GameManager.instance.onMatchesUpdate += UpdateMatchesUI;
        GameManager.instance.onTurnUpdate += UpdateTurnsUI;
        GameManager.instance.onScoreUpdate += UpdateLevelScoreUI;
        GameManager.instance.onHighScoreUpdate += UpdateHighScoreUI;

        GameManager.instance.onMatchWin += OpenMatchCompletionUI;
        GameManager.instance.onNextLevel += CloseMatchCompletionUI;
        GameManager.instance.onGameSessionStart += CloseMatchCompletionUI;
        GameManager.instance.onEnterMainMenu += ToggleContinueButton;
    }

    #region GameScore

    private void UpdateMatchesUI(int value) => matchesUI.text = value.ToString();

    private void UpdateTurnsUI(int value) => turnsUI.text = value.ToString();

    private void UpdateLevelScoreUI(int value) => levelScoreUI.text = value.ToString();

    private void UpdateHighScoreUI(int value) => highScoreUI.text = value.ToString();

    #endregion

    #region MatchCompletion

    private void OpenMatchCompletionUI()
    {
        gameBoard.SetActive(false);
        matchCompletionUI.SetActive(true);
        scoreUI.text = GameManager.instance.currentScore.ToString();

        bool isLastLevel = GameManager.instance.IsLastLevel();
        nextLevelButton.SetActive(!isLastLevel);
        gameCompletionMessage.SetActive(isLastLevel);
        levelCompletionMessage.SetActive(!isLastLevel);
    }
    private void CloseMatchCompletionUI()
    {
        gameBoard.SetActive(true);
        matchCompletionUI.SetActive(false);
    }
    #endregion

    #region MAIN_MENU
    private void ToggleContinueButton()
    {
        continueButton.SetActive(GameManager.instance != null && !GameManager.instance.IsLastLevel());
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// BootStrapper class that controls execution of scripts 
/// WIll be helpful as more scripts get added later.
/// </summary>
public class BootStrapper : MonoBehaviour
{
    public SaveSystem saveSystem;
    public UIManager uiManager;
    public BoardManager boardManager;
    private IEnumerator Start()
    {
        GameManager.instance.onGameSessionStart += OpenGameScene;
        GameManager.instance.onEnterMainMenu += OpenMainMenu;
        yield return null;
        Boot();
        yield return null;
        GameManager.instance.EnterMainMenu();
    }

    private void Boot()
    {
        boardManager.enabled = true;
        uiManager.enabled = true;
        saveSystem.enabled = true;
    }

    #region SceneControl

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameLevel;
    private void OpenGameScene()
    {
        mainMenu.SetActive(false);
        gameLevel.SetActive(true);
    }

    private void OpenMainMenu()
    {
        gameLevel.SetActive(false);
        mainMenu.SetActive(true);
    }
    #endregion
}

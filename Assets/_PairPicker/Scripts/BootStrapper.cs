using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrapper : MonoBehaviour
{

    #region SceneControl

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameLevel;
    private void Start()
    {
        OpenMainMenu();
    }
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

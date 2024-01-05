using System;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{
    private Button _quitButton;

    void Start()
    {
        _quitButton = GetComponent<Button>();
        _quitButton.onClick.AddListener(QuitGame);
    }

    private static void QuitGame()
    {
        Application.Quit();
    }
}